using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrganizerLibrary.Models;
using System.Linq;

namespace OrganizerDataFilesConnection.Services
{
    public class TextFilesItemsDataService<T> : IDataService<T> where T : BaseItemModel
    {
        private const string fileOfGoalTrackers = "GoalTrackerFile.csv";
        private const string fileOfCheckBoxes = "CheckListFile.csv";
        private const string fileOfLists = "ListObjFile.csv";
        private const string fileOfEvents = "EventObjFile.csv";
        private const string fileOfNotes = "NotesFile.csv";

        private const string fileOfTimeTrackers = "TimeTrackerFile.csv";
        private const string folderOfTimeTracker = "TimeTrackerFolder";
        private const string folderOfGoalTracker = "GoalTrackerFolder";
        private const string folderOfNotes = "NotesFolder";

        public async Task<T> Create(T entity)
        {
            (string fileName, ItemType itemType) = GetFileNameAndType(entity.GetType());

            List<BaseItemModel> items = await Task.Run(() => fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType));

            entity.Id = fileName.FindEmptyId();

            items.Add(entity);

            await Task.Run(() => items.SaveItemToFile(fileName, itemType));

            if(itemType == ItemType.Notes)
                entity.SaveNoteText(folderOfNotes);
            if (itemType == ItemType.GoalTracker)
                entity.SaveGoalTrackerText(folderOfGoalTracker);

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            (string fileName, ItemType itemType) = GetFileNameAndType(typeof(T));

            List<BaseItemModel> itemList = fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType);

            itemList.Remove(itemList.Find(model => model.Id == id));

            await Task.Run(() => itemList.SaveItemToFile(fileName, itemType));

            return true;
        }

        public async Task<T> Get(int id)
        {
            T result;
            (string fileName, ItemType itemType) = GetFileNameAndType(typeof(T));
            List<BaseItemModel> temp = new List<BaseItemModel>(await Task.Run(() => fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType)));

            result = (T)temp.Single(m => m.Id == id);

            return result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> result = new List<T>();
            (string fileName, ItemType itemType) = GetFileNameAndType(typeof(T));
            IEnumerable<BaseItemModel> temp = await Task.Run(()=> fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType));
           
            foreach (BaseItemModel d in temp)
            {
                result.Add((T)d);
            }
          
            return result;
        }

        public async Task<IEnumerable<T>> GetAllExtended()
        {
            List<T> result = new List<T>();
            (string fileName, ItemType itemType) = GetFileNameAndType(typeof(T));
            IEnumerable<BaseItemModel> temp = await Task.Run(() => fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType));

            foreach (BaseItemModel d in temp)
            {
                if (itemType == ItemType.GoalTracker)
                {
                    ((GoalTrackerModel)d).ListOfData = d.ReadGoalTrackerText(folderOfGoalTracker);
                }
                result.Add((T)d);
            }

            return result;
        }

        public async Task<T> GetExtended(int id)
        {
            BaseItemModel result;
            (string fileName, ItemType itemType) = GetFileNameAndType(typeof(T));

            List<BaseItemModel> temp = new List<BaseItemModel>(await Task.Run(() => fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType)));

            result = (T)temp.Single(m => m.Id == id);

            if (itemType == ItemType.Notes)
            {
                ((NotesModel)result).Text = result.ReadNoteText(folderOfNotes);
            }
            if (itemType == ItemType.GoalTracker)
            {
                ((GoalTrackerModel)result).ListOfData = result.ReadGoalTrackerText(folderOfGoalTracker);
            }
            

            return (T)result;
        }

        public async Task<T> Update(int id, T entity)
        {
            (string fileName, ItemType itemType) = GetFileNameAndType(entity.GetType());

            List<BaseItemModel> items = await Task.Run(() => fileName.FullFilePath().LoadFile().GetItemList(fileOfLists, itemType));

            items.Remove(items.FirstOrDefault(model => model.Id == id));
            items.Add(entity);

            await Task.Run(() => items.SaveItemToFile(fileName, itemType));

            if (itemType == ItemType.GoalTracker)
                await Task.Run(() => entity.SaveGoalTrackerText(folderOfGoalTracker));

            return entity;
        }



        private (string, ItemType) GetFileNameAndType(Type type)
        {
            string fileName = "";
            ItemType outputType = ItemType.Events;
            if (typeof(T) == typeof(EventModel))
            {
                fileName = fileOfEvents;
                outputType = ItemType.Events;
            }
            if (typeof(T) == typeof(CheckBoxModel))
            {
                fileName = fileOfCheckBoxes;
                outputType = ItemType.Checkbox;
            }
            if (typeof(T) == typeof(NotesModel))
            {
                fileName = fileOfNotes;
                outputType = ItemType.Notes;
            }
            if (typeof(T) == typeof(GoalTrackerModel))
            {
                fileName = fileOfGoalTrackers;
                outputType = ItemType.GoalTracker;
            }
            if (typeof(T) == typeof(TimeTrackerModel))
            {
                fileName = fileOfTimeTrackers;
                outputType = ItemType.TimeTracker;
            }

            return (fileName, outputType);
        }

       


   
    }
}

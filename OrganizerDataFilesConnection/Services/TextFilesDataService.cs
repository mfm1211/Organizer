using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizerDataFilesConnection.Services
{


    public class TextFilesDataService<T> : IDataService<T> where T : DomainObject
    {
     
        private const string fileOfLists = "ListObjFile.csv";    
        private const string fileOfSections = "SubListFile.csv";
      
       


        public async Task<T> Create(T entity)
        {
            DomainObject result = new ListModel();
            if (typeof(T)==typeof(ListModel))
            {
                result = await Task.Run(() => CreateList(entity as ListModel));
            }
           
            return (T)result;
        }

        public async Task<bool> Delete(int id)
        {
            if (typeof(T) == typeof(ListModel))
            {
                await Task.Run(() => DeleteListObj(id));
            }
          
          
            return true;
        }

        public async Task<T> Get(int id)
        {
            DomainObject result = new ListModel();
            if (typeof(T) == typeof(ListModel))
            {
                result = await Task.Run(() => GetSingleListObjModel(id));
            }
            return (T)result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> result = new List<T>();
            if (typeof(T) == typeof(ListModel))
            {
                IEnumerable<DomainObject> temp = await Task.Run(() => GetAllListObj());
                
                foreach(DomainObject d in temp)
                {
                    result.Add((T)d);
                }
            }
           
            return result;
        }

        public async Task<IEnumerable<T>> GetAllExtended()
        {
            List<T> result = new List<T>();
            if (typeof(T) == typeof(ListModel))
            {
                IEnumerable<DomainObject> temp = await Task.Run(() => GetAllListObj());

                foreach (DomainObject d in temp)
                {
                    ((ListModel)d).EventModels = new List<EventModel>();
                    ((ListModel)d).CheckBoxModels = new List<CheckBoxModel>();
                    result.Add((T)d);
                }
            }
            return result;
        }

        public async Task<T> GetExtended(int id)
        {
            DomainObject result = new ListModel();
            if (typeof(T) == typeof(ListModel))
            {
                result = await Task.Run(() => GetSingleListObjModel(id));
            }
            return (T)result;
        }

        public async Task<T> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }



        private ListModel CreateList(ListModel model)
        {
            List<ListModel> ListObjs = fileOfLists.FullFilePath().LoadFile().ConvertToListObjModels();

            model.Id = fileOfLists.FindEmptyId();

            ListObjs.Add(model);

            ListObjs.SaveToListObjFile(fileOfLists);


            return model;
        }


        private SectionModel CreateSubList(SectionModel model)
        {
            List<SectionModel> Sublists = fileOfSections.FullFilePath().LoadFile().ConvertToSubListModels();

            model.Id = fileOfSections.FindEmptyId(); 

            Sublists.Add(model);

            Sublists.SaveToSubListFile(fileOfSections);

            return model;
        }


    


    


    


        public List<ListModel> GetAllListObj()
        {
            return fileOfLists.FullFilePath().LoadFile().ConvertToListObjModels();
        }

        public ListModel GetSingleListObjModel(int id)
        {
            return fileOfLists.FullFilePath().LoadFile().ConvertToSingleListObjModel(id);
        }


     

        public List<SectionModel> GetAllSubList()
        {
            return fileOfSections.FullFilePath().LoadFile().ConvertToSubListModels();
        }


     

      
     

      


        //public List<SectionModel>[] GetAllSubListSortedByListId()
        //{
        //    List<SectionModel> listOfAllSublists = GlobalConfig.Connections.GetAllSubList();

        //    List<SectionModel>[] sortedSublists = new List<SectionModel>[20];

        //    for (int i = 0; i < 20; i++)
        //    {
        //        List<SectionModel> temp = new List<SectionModel>();
        //        sortedSublists[i] = temp;
        //    }


        //    foreach (SectionModel sub in listOfAllSublists)
        //    {
        //        sortedSublists[sub.ListId].Add(sub);
        //    }


        //    return sortedSublists;
        //}


       





        public void DeleteListObj(int id)
        {

            List<ListModel> ListObjs = fileOfLists.FullFilePath().LoadFile().ConvertToListObjModels();

            ListObjs.Remove(ListObjs.Find(model => model.Id == id));

            ListObjs.SaveToListObjFile(fileOfLists);


        }




       



      

    
    }
}

using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace OrganizerDataFilesConnection
{

    public enum ItemType
    {
        Events,
        Checkbox,
        GoalTracker,
        TimeTracker,
        Notes
    }

    public static class TextConnectorProcessor
    {
       


        public static string FullFilePath(this string fileName)
        {
            string s = @"c:\Users\Mateusz\source\repos\Organizer\DataFiles\" + fileName;

            return s;
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            else
            {
                return File.ReadAllLines(file).ToList();
            }
        }


        public static void SaveToListObjFile(this List<ListModel> listOfModels, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (ListModel p in listOfModels)
            {
                Bitmap bmp;
                using (var ms = new MemoryStream(p.ChechBoxImageByteArray))
                {
                    bmp = new Bitmap(ms);
                }

                bmp.Save("checkboxes".FullFilePath()+"\\"+p.Id.ToString()+".png", ImageFormat.Png);

                lines.Add($"{p.Id};{p.Name};{p.ColorString};{p.Description};");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }


        public static void AppendListObjFile(this ListModel listModel, string fileName)
        {

            string line = $"{listModel.Id};{listModel.Name};{listModel.ColorString};{listModel.Description}";

            File.AppendAllText(fileName.FullFilePath(), line);

        }



        public static void SaveToSubListFile(this List<SectionModel> listOfModels, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (SectionModel p in listOfModels)
            {
                lines.Add($"{p.Id};{p.Name};{p.ListModelId}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

    

        public static void SaveItemToFile(this List<BaseItemModel> listOfModels, string fileName, ItemType type)
        {
            List<string> lines = new List<string>();

            foreach(BaseItemModel m in listOfModels)
            {
                string line="";
                switch (type)
                {
                    case ItemType.Events:
                        line = GetEventModelLine((EventModel)m);
                        break;
                    case ItemType.Checkbox:
                        line = GetCheckBoxModelLine((CheckBoxModel)m);
                        break;
                    case ItemType.GoalTracker:
                        line = GetGoalTrackerModelLine((GoalTrackerModel)m);
                        break;
                    case ItemType.TimeTracker:
                        line = GetTimeTrackerModelLine((TimeTrackerModel)m);
                        break;
                    case ItemType.Notes:
                        line = GetNotesModelLine((NotesModel)m);
                        break;
                }
                lines.Add(line);

            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }



        private static string GetEventModelLine(this EventModel p)
        {
            return $"{p.Id};{p.StartTime.ToString("yyyyMMddHHmmss")};{p.EndTime.ToString("yyyyMMddHHmmss")};{p.ListModelId};{p.SectionId};{p.Text};{p.Description};{(p.Important ? 1 : 0)}"; 
        }

        private static string GetCheckBoxModelLine(this CheckBoxModel p)
        {
            return $"{p.Id};{p.StartTime.ToString("yyyyMMddHHmmss")};{p.EndTime.ToString("yyyyMMddHHmmss")};{p.ListModelId};{p.SectionId};{p.Text};{(p.Checked ? 1 : 0)}";       
        }

        public static string GetGoalTrackerModelLine(this GoalTrackerModel p)
        {
            return $"{p.Id};{p.StartTime.ToString("yyyyMMddHHmmss")};{p.EndTime.ToString("yyyyMMddHHmmss")};{p.ListModelId};{p.SectionId};{p.Name}";
        }

        private static string GetTimeTrackerModelLine(this TimeTrackerModel p)
        {
            return $"{p.Id};{p.StartTime.ToString("yyyyMMddHHmmss")};{p.EndTime.ToString("yyyyMMddHHmmss")};{p.ListModelId};{p.SectionId};{p.Text}";
        }

        public static string GetNotesModelLine(this NotesModel p)
        {        
            return $"{p.Id};{p.StartTime.ToString("yyyyMMddHHmmss")};{p.EndTime.ToString("yyyyMMddHHmmss")};{p.ListModelId};{p.SectionId};{p.Title}";
        }

        public static void SaveNoteText(this BaseItemModel model, string folderName)
        {
            string fullfilename = folderName.FullFilePath() + "\\" + model.Id.ToString().PadLeft(4, '0') + ".txt";

            File.WriteAllText(fullfilename, ((NotesModel)model).Text);
        }


        public static string ReadNoteText(this BaseItemModel model, string folderName)
        {
            string fullfilename = folderName.FullFilePath() + "\\" + model.Id.ToString().PadLeft(4, '0') + ".txt";

            IEnumerable<string> lines = File.ReadAllLines(fullfilename);

            StringBuilder _Text = new StringBuilder();

            foreach (string line in lines)
            {
                _Text.AppendLine(string.Format(line));
            }
            return _Text.ToString();
        }


        public static List<ListModel> ConvertToListObjModels(this List<string> lines)
        {
            List<ListModel> output = new List<ListModel>();

            ImageConverter converter = new ImageConverter();
            foreach (string line in lines)
            {
                if (line != "" && line != " ")
                {
                    string[] cols = line.Split(';');

                    ListModel g = new ListModel();

                    g.Id = int.Parse(cols[0]);
                    g.Name = cols[1];
                    g.ColorString = cols[2];
                    
                    Bitmap bmp = new Bitmap("checkboxes".FullFilePath()+"\\"+g.Id.ToString()+".png");
                    g.ChechBoxImageByteArray = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
                    bmp.Dispose();
                    output.Add(g);
                }
            }
            return output;
        }


        public static ListModel ConvertToSingleListObjModel(this List<string> lines, int id)
        {
            foreach (string line in lines)
            {
                string input = line.Substring(0, 2);
                string s = new string(input.Where(c => char.IsDigit(c)).ToArray());

                if (s == id.ToString())
                {
                    string[] cols = line.Split(';');

                    ListModel output = new ListModel();

                    output.Id = int.Parse(cols[0]);
                    output.Name = cols[1];
                    output.ColorString = cols[2];


                    return output;
                }
            }
            return null;
        }



    



        public static List<SectionModel> ConvertToSubListModels(this List<string> lines)
        {
            List<SectionModel> output = new List<SectionModel>();

            foreach (string line in lines)
            {
                if (line != "" && line != " ")
                {
                    string[] cols = line.Split(';');

                    SectionModel g = new SectionModel();

                    g.Id = int.Parse(cols[0]);
                    g.Name = cols[1];
                    g.ListModelId = int.Parse(cols[2]);

                    output.Add(g);
                }
            }
            return output;
        }



        public static List<BaseItemModel> GetItemList(this List<string> lines, string fileList, ItemType type)
        {
            List<BaseItemModel> output = new List<BaseItemModel>();
           
            foreach (string line in lines)
            {
                string[] cols = line.Split(';');
                BaseItemModel h;
                switch (type)
                {
                    case ItemType.Events:
                        h = BaseItemModelWithAssignedValues(cols, new EventModel(), fileList);
                        ((EventModel)h).Text = cols[5];
                        output.Add(h);
                        break;
                    case ItemType.Checkbox:
                        h = BaseItemModelWithAssignedValues(cols, new CheckBoxModel(), fileList);
                        ((CheckBoxModel)h).Text = cols[5];
                        ((CheckBoxModel)h).Checked = (int.Parse(cols[6]) == 1);
                        output.Add(h);
                        break;
                    case ItemType.Notes:
                        h = BaseItemModelWithAssignedValues(cols, new NotesModel(), fileList);
                        ((NotesModel)h).Title = cols[5];
                        output.Add(h);
                        break;
                    case ItemType.GoalTracker:
                        h = BaseItemModelWithAssignedValues(cols, new GoalTrackerModel(), fileList);
                        ((GoalTrackerModel)h).Name = cols[5];
                        output.Add(h);
                        break;
                    case ItemType.TimeTracker:
                        h = BaseItemModelWithAssignedValues(cols, new CheckBoxModel(), fileList);
                        ((TimeTrackerModel)h).Text = cols[5];
                        output.Add(h);
                        break;

                }
             
                
            }
            return output;
        }


        private static BaseItemModel BaseItemModelWithAssignedValues(string[] cols, BaseItemModel model, string fileList)
        {
            List<ListModel> listModels = fileList.FullFilePath().LoadFile().ConvertToListObjModels();

            model.Id = int.Parse(cols[0]);
            model.StartTime = DateTime.ParseExact(cols[1], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            model.EndTime = DateTime.ParseExact(cols[2], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            model.ListModelId = int.Parse(cols[3]);
            model.SectionId = int.Parse(cols[4]);
            model.FontColor = listModels.Single(m => m.Id == model.ListModelId).ColorString;
            return model;
        }


        public static List<int> GetListOfId(this List<string> lines)
        {
            List<int> listOfIds = new List<int>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                listOfIds.Add(int.Parse(cols[0]));
            }

            return listOfIds;
        }


        public static int FindEmptyId(this string filename)
        {
            List<int> ListOfId = filename.FullFilePath().LoadFile().GetListOfId();
            int id = 1;

            if (ListOfId.Count > 0)
            {
                ListOfId.Sort();

                List<int> GapsInIdList = Enumerable.Range(ListOfId.First(), ListOfId.Last() - ListOfId.First() + 1).Except(ListOfId).ToList();

                if (GapsInIdList.Count == 0)
                {
                    GapsInIdList.Add(ListOfId[ListOfId.Count - 1] + 1);
                }

                id = GapsInIdList[0];
            }

            return id;
        }

    }
}

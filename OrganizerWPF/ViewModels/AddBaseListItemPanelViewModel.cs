using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels
{
    public class AddBaseListItemPanelViewModel:ViewModelBase
    {
        private ListModel _selectedList;
        public ICommand AddItemCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private readonly Action<bool> _action;

        public BaseListItemModel CreatedItem { get; set; }

        public string TextString { get; set; }

        private IDataService<EventModel> _eventModelsService;

        public List<ListModel> ListOfListObjsForCombobox { get; set; } = new List<ListModel>();

        public ListModel SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                //GetSectionViewModels(_selectedList.Id);

            }
        }

        public AddBaseListItemPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<EventModel> eventModelsService)
        {
            _eventModelsService = eventModelsService;

            AddItemCommand = new RelayCommand(CreateNewItem);

            CancelCommand = new RelayCommand(CreateCancelEvent);

            _action = action;

            GetLists(listModelsService);
        }

        private async void GetLists(IDataService<ListModel> listModelsService)
        {
            ListOfListObjsForCombobox =  new List<ListModel>(await listModelsService.GetAll());
           
        }

        private async void CreateNewItem()
        {

            CreatedItem = new EventModel();
            CreatedItem.ListModelId = SelectedList.Id;
           // CreatedItem.SectionId = SelectedSection.Id;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;

            if (CreatedItem.GetType() == typeof(EventModel))
            {
                ((EventModel)CreatedItem).Text = TextString;

                await _eventModelsService.Create((EventModel)CreatedItem);
            }
           


            _action.Invoke(true);
        }
        private void CreateCancelEvent()
        {
            _action.Invoke(false);
        }


        //private List<SubListModel> GetSectionViewModels(int listobjId)
        //{
        //    List<SubListModel> output = new List<SubListModel>();

        //    List<SubListModel> listOfModels = GlobalConfig.Connections.GetAllSubList();

        //    foreach (SubListModel li in listOfModels)
        //    {
        //        if (li.ListId == listobjId)
        //        {
        //            output.Add(li);
        //        }

        //    }
        //    if (output.Count > 0)
        //    {
        //        SelectedSection = output[0];
        //    }

        //    return output;
        //}

    }
}

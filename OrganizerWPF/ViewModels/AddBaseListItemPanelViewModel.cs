using OrganizerLibrary;
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

        private Action<bool> _action;

        public BaseItemModel CreatedItem { get; set; }

        public string TextString { get; set; }

        private IDataService<ListModel> _listModelsService;

        private bool ListOfListsIsEmpty = false;
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
            InitializeCommon(action, listModelsService);

            AddItemCommand = new RelayCommand(() => CreateNewEvent(eventModelsService));
        }

        public AddBaseListItemPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<CheckBoxModel> checkoxModelsService)
        {          
            InitializeCommon(action, listModelsService);

            AddItemCommand = new RelayCommand(() => CreateNewCheckBox(checkoxModelsService));
        }

        public AddBaseListItemPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<BaseItemModel> checkoxModelsService)
        {
            InitializeCommon(action, listModelsService);

          //  AddItemCommand = new RelayCommand(() => CreateNewCheckBox(checkoxModelsService));
        }


        private void InitializeCommon(Action<bool> action, IDataService<ListModel> listModelsService)
        {
            _listModelsService = listModelsService;
            GetLists(listModelsService);
            CancelCommand = new RelayCommand(TriggerCancelEvent);
            _action = action;
        }


        private async void GetLists(IDataService<ListModel> listModelsService)
        {
            ListOfListObjsForCombobox =  new List<ListModel>(await listModelsService.GetAll());
            if(ListOfListObjsForCombobox.Count == 0)
            {
                ListModel othersList = new ListModel();
                othersList.ColorString = "#FAFAFA";
                othersList.Name = "Others";
                othersList.ChechBoxImageByteArray = DrawImages.DrawCheckBox(1, "#FAFAFA");
              
                ListOfListObjsForCombobox.Add(othersList);              
                ListOfListsIsEmpty = true;
            }
            SelectedList = ListOfListObjsForCombobox[0];
        }

        private async void CreateNewEvent(IDataService<EventModel> service)
        {
            CreateListIfItDoesNotExist();

            CreatedItem = new EventModel();
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;
            ((EventModel)CreatedItem).Text = TextString;

            await service.Create((EventModel)CreatedItem);
            
            _action.Invoke(true);
        }

        private async void CreateNewCheckBox(IDataService<CheckBoxModel> service)
        {
            CreateListIfItDoesNotExist();

            CreatedItem = new CheckBoxModel();
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;
            ((CheckBoxModel)CreatedItem).Text = TextString;
            ((CheckBoxModel)CreatedItem).Checked = false;
            await service.Create((CheckBoxModel)CreatedItem);

            _action.Invoke(true);
        }


        private async void CreateListIfItDoesNotExist()
        {
            if (ListOfListsIsEmpty == true)
            {
                ListModel temp = await _listModelsService.Create(ListOfListObjsForCombobox[0]);
                ListOfListObjsForCombobox[0].Id = temp.Id;
            }
        }

        private void TriggerCancelEvent()
        {
            _action.Invoke(false);
        }


       

    }
}

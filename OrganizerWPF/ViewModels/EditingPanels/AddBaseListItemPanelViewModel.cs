using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class AddBaseListItemPanelViewModel<T>:ViewModelBase
    {
        private ListModel _selectedList;
        public ICommand AddItemCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public BaseItemModel CreatedItem { get; set; }

        public string MainTextString { get; set; }
        public string SecondaryTextString { get; set; }

        private IDataService<ListModel> _listModelsService;

        private bool ListOfListsIsEmpty = false;

        protected IDataService<T> _service;

        private INavigator _navigator;

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


        public AddBaseListItemPanelViewModel(IDataService<ListModel> listModelsService, IDataService<T> service, INavigator navigator)
        {
            _listModelsService = listModelsService;
            GetLists(listModelsService);
            CancelCommand = new RelayCommand(TriggerCancelEvent);
            _navigator = navigator;
            _service = service;
            AddItemCommand = new RelayCommand(() => CreateNewItem(service));
        }
        ~AddBaseListItemPanelViewModel()
        {

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

        private async void CreateNewItem(IDataService<T> service)
        {
            CreateListIfItDoesNotExist();

            if(typeof(T) == typeof(EventModel))
                await CreateNewEvent(service as IDataService<EventModel>);
            else if(typeof(T) == typeof(CheckBoxModel))
                await CreateNewCheckBox(service as IDataService<CheckBoxModel>);
            else if (typeof(T) == typeof(NotesModel))
                await CreateNewNote(service as IDataService<NotesModel>);
            else if (typeof(T) == typeof(GoalTrackerModel))
                await CreateNewGoal(service as IDataService<GoalTrackerModel>);

           // _action.Invoke(true);
            _navigator.EditingPanelIsVIsible = new Tuple<bool, bool>(false, true);
        }





        private async Task<EventModel> CreateNewEvent(IDataService<EventModel> service)
        {         
            CreatedItem = new EventModel();
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;
            ((EventModel)CreatedItem).Text = MainTextString;
            await service.Create((EventModel)CreatedItem);

            return (EventModel)CreatedItem;
        }

        private async Task<CheckBoxModel> CreateNewCheckBox(IDataService<CheckBoxModel> service)
        {
            CreatedItem = new CheckBoxModel();
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;
            ((CheckBoxModel)CreatedItem).Text = MainTextString;
            ((CheckBoxModel)CreatedItem).Checked = false;
            await service.Create((CheckBoxModel)CreatedItem);

            return (CheckBoxModel)CreatedItem;
        }

        private async Task<NotesModel> CreateNewNote(IDataService<NotesModel> service)
        {
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now;
            CreatedItem.EndTime = DateTime.Now;
            ((NotesModel)CreatedItem).Pined = false;
            await service.Create((NotesModel)CreatedItem);

            return (NotesModel)CreatedItem;
        }

        private async Task<GoalTrackerModel> CreateNewGoal(IDataService<GoalTrackerModel> service)
        {
            CreatedItem.ListModelId = SelectedList.Id;
            CreatedItem.SectionId = 0;
            CreatedItem.StartTime = DateTime.Now.AddDays(-140);
            CreatedItem.EndTime = DateTime.Now;
            ((GoalTrackerModel)CreatedItem).ListOfData = new int[100];
            await service.Create((GoalTrackerModel)CreatedItem);

            return (GoalTrackerModel)CreatedItem;
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
           // _action.Invoke(false);
            _navigator.EditingPanelIsVIsible = new Tuple<bool, bool>(false,false);
        }


     

    }
}

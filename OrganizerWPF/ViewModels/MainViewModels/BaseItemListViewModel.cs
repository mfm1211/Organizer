using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class BaseItemListViewModel : ViewModelBase
    {
        protected readonly INavigator _navigator;
        protected readonly IDataService<ListModel> _listModelsService;
        protected readonly IChosenIndexesStore _chosenIndexesStore;

        public ICommand DeleteItemCommand { get; set; }
        public ICommand EditItemCommand { get; set; }
        public ICommand ShowAddItemPanelCommand { get; set; }

        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public bool AddItemPanelVisibility { get; set; } = false;

        protected Action<bool> editigPanelEndedAction;

        public ObservableCollection<BaseItemViewModel> DisplayedListOfItems { get; set; } = new ObservableCollection<BaseItemViewModel>();

        private Action screenExpansionChangedAction;

        public BaseItemListViewModel(INavigator navigator, IDataService<ListModel> listModelsService, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _listModelsService = listModelsService;
            _chosenIndexesStore = chosenIndexesStore;
            screenExpansionChangedAction = () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            _navigator.ScreenExpansionChanged += screenExpansionChangedAction;

            ShowAddItemPanelCommand = new RelayCommand(ShowAddItemPanel);    
        }


        private void ShowAddItemPanel()
        {
            AddItemPanelVisibility = true;
            _navigator.EditingPanelIsVIsible = new Tuple<bool, bool>(true, false);
        }


        protected async void DeleteItem<T>(BaseItemViewModel model, IDataService<T> dataService)
        {
            await dataService.Delete(model.Id);
            List<BaseItemViewModel> temp = DisplayedListOfItems.ToList();
            temp.RemoveAll(m => m.Id == model.Id);
            DisplayedListOfItems = new ObservableCollection<BaseItemViewModel>(temp);
        }


        protected async Task<List<T>> GetItemsForGivenList<T>(IDataService<T> dataService)
        {
            List<T> listOfModels = (await dataService.GetAll()).ToList();

            if (_chosenIndexesStore.ChosenListId != -1)
            {
                listOfModels = new List<T>(listOfModels.Where(m => (m as BaseItemModel).ListModelId == _chosenIndexesStore.ChosenListId).ToList());
            }
            
            return listOfModels;
        }

        protected void UpdateDisplayedList(IEnumerable<BaseItemViewModel> list)
        {
            DisplayedListOfItems = new ObservableCollection<BaseItemViewModel>(list);
        }


        public override void Dispose()
        {
            _navigator.ScreenExpansionChanged -= screenExpansionChangedAction;
            base.Dispose();
        }
    }
}

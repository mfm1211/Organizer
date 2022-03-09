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

        public ObservableCollection<BaseItemViewModel> DisplayedListOfItems { get; set; } = new ObservableCollection<BaseItemViewModel>();

        public AddBaseListItemPanelViewModel AddItemPanel { get; set; }

        public BaseItemListViewModel(INavigator navigator, IDataService<ListModel> listModelsService, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _listModelsService = listModelsService;
            _chosenIndexesStore = chosenIndexesStore;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));

            ShowAddItemPanelCommand = new RelayCommand(() => AddItemPanelVisibility = true);
        }



        protected async void DeleteItem<T>(BaseItemViewModel model, IDataService<T> dataService)
        {
            await dataService.Delete(model.Id);
            List<BaseItemViewModel> temp = DisplayedListOfItems.ToList();
            temp.RemoveAll(m => m.Id == model.Id);
            DisplayedListOfItems = new ObservableCollection<BaseItemViewModel>(temp);
        }

        protected void UpdateDisplayedList(IEnumerable<BaseItemViewModel> list)
        {
            DisplayedListOfItems = new ObservableCollection<BaseItemViewModel>(list);
        }
    }
}

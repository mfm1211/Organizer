using Microsoft.Extensions.DependencyInjection;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using OrganizerWPF.Commands;
using OrganizerWPF.ViewModels.Factories;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class ListOfListsViewModel : ViewModelBase
    {
        protected IDataService<ListModel> _listModelsService;

        public ObservableCollection<ListModel> DisplayedListOfItems { get; set; } = new ObservableCollection<ListModel>();

        protected readonly INavigator _navigator;
    
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public ICommand OpenListDataCommand { get; set; }

        IOrganizerViewModelFactory _viewModelFactory;

        public ListOfListsViewModel(IDataService<ListModel> listModelsService, INavigator navigator, IOrganizerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _listModelsService = listModelsService;
            _viewModelFactory = viewModelFactory;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            OpenListDataCommand = new RelayCommandWithParameter((param) => OpenListDataScreen((int)param));
            GetLists();
        }

        private void OpenListDataScreen(int n)
        {
            _navigator.CurrentRetractableViewModel = _viewModelFactory.CreateViewModel(ViewType.RetractableList);
        }

        protected async void GetLists()
        {
            IEnumerable<ListModel> temp = await _listModelsService.GetAllExtended();
            DisplayedListOfItems = new ObservableCollection<ListModel>(temp);
           
        }

    }
}

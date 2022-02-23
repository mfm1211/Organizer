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

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class ListOfListsViewModel : ViewModelBase
    {
        private IDataService<ListModel> _listModelsService;

        public ObservableCollection<ListModel> DisplayedListOfItems { get; set; } = new ObservableCollection<ListModel>();

        private readonly INavigator _navigator;
    
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;


        public ListOfListsViewModel(IDataService<ListModel> listModelsService, INavigator navigator)
        {
            _navigator = navigator;
            _listModelsService = listModelsService;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            GetLists();
        }

        private async void GetLists()
        {
            IEnumerable<ListModel> temp = await _listModelsService.GetAllWithItemLists();
            DisplayedListOfItems = new ObservableCollection<ListModel>(temp);
           
        }

    }
}

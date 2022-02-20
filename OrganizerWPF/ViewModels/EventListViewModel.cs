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

namespace OrganizerWPF.ViewModels
{
    public class EventListViewModel:ViewModelBase
    {
        private IDataService<EventModel> _eventModelsService;

        public ObservableCollection<EventModel> DisplayedListOfItems { get; set; } = new ObservableCollection<EventModel>();

        private readonly INavigator _navigator;

        private readonly IChosenIndexesStore _chosenIndexesStore;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public EventListViewModel(IDataService<EventModel> EventModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _eventModelsService = EventModelsService;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            _chosenIndexesStore = chosenIndexesStore;
            GetEvents();
        }

        private async void GetEvents()
        {
            IEnumerable<EventModel> temp = await _eventModelsService.GetAll();
            DisplayedListOfItems = new ObservableCollection<EventModel>(temp);
            if(_chosenIndexesStore.ChosenListId != -1)
            {
                DisplayedListOfItems = new ObservableCollection<EventModel>(DisplayedListOfItems.Where(m => m.ListModelId == _chosenIndexesStore.ChosenListId).ToList());
            }
        }


    }
}

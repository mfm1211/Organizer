using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class TimeTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<TimeTrackerModel> _timeTrackerModelsService;

        public TimeTrackerListViewModel(IDataService<TimeTrackerModel> timeTrackerModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _timeTrackerModelsService = timeTrackerModelsService;
            GetTimeTrackers();
        }


        private async void GetTimeTrackers()
        {
            //IEnumerable<TimeTrackerModel> listOfItems = await _timeTrackerModelsService.GetAll();

            //UpdateDisplayedList(listOfItems);

        }
    }
}
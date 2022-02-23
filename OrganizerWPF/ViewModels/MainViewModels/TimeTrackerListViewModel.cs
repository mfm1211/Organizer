using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class TimeTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<TimeTrackerModel> _timeTrackerModelsService;

        public TimeTrackerListViewModel(IDataService<TimeTrackerModel> timeTrackerModelsService, INavigator navigator) : base(navigator)
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
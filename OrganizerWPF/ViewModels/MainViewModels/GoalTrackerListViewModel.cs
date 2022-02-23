using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class GoalTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<GoalTrackerModel> _goalTrackerModelsService;

        public GoalTrackerListViewModel(IDataService<GoalTrackerModel> goalTrackerModelsService, INavigator navigator) : base(navigator)
        {
            _goalTrackerModelsService = goalTrackerModelsService;
            GetGoalTrackers();
        }


        private async void GetGoalTrackers()
        {
            //IEnumerable<GoalTrackerModel> listOfItems = await _goalTrackerModelsService.GetAll();

            //UpdateDisplayedList(listOfItems);

        }
    }
}

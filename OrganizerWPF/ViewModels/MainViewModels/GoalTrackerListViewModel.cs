using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class GoalTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<GoalTrackerModel> _goalTrackerModelsService;

        public GoalTrackerListViewModel(IDataService<GoalTrackerModel> goalTrackerModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) :
            base(navigator, listModelsService, chosenIndexesStore)
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

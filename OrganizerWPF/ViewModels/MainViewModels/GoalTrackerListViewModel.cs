using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.EditingPanels;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class GoalTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<GoalTrackerModel> _goalTrackerModelsService;

        public GoalTrackersEditingPanelViewModel AddItemPanel { get; set; }

        public ICommand UpdateGoalTrackerCommand { get; set; }
 
        public GoalTrackerListViewModel(IDataService<GoalTrackerModel> goalTrackerModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _goalTrackerModelsService = goalTrackerModelsService;
            GetGoalTrackers();

            UpdateGoalTrackerCommand = new RelayCommandWithParameter((param) => UpdateTracker(param as GoalTrackerViewModel));

            AddItemPanel = new GoalTrackersEditingPanelViewModel((param) => AddPanelAction((bool)param), listModelsService, _goalTrackerModelsService);
        }


        private async void GetGoalTrackers()
        {
            IEnumerable<GoalTrackerModel> listOfItems = await _goalTrackerModelsService.GetAll();

            List<GoalTrackerViewModel> tempViewModel = new List<GoalTrackerViewModel>();

            foreach (GoalTrackerModel m in listOfItems)
            {
                tempViewModel.Add(new GoalTrackerViewModel(m));
            }


            UpdateDisplayedList(tempViewModel);

        }

        private void UpdateTracker(GoalTrackerViewModel temp)
        {

        }

        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                //  GetEvents();
            }

            AddItemPanelVisibility = false;
        }
    }
}

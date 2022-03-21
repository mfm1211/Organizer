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
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class GoalTrackerListViewModel : BaseItemListViewModel
    {
        private IDataService<GoalTrackerModel> _goalTrackerModelsService;

        public GoalTrackersEditingPanelViewModel AddItemPanel { get; set; }

        public ICommand UpdateGoalTrackerCommand { get; set; }

        public ObservableCollection<string> ListOfDayNames { get; set; } = new ObservableCollection<string>();


        public GoalTrackerListViewModel(IDataService<GoalTrackerModel> goalTrackerModelsService, IDataService<ListModel> listModelsService, INavigator navigator, 
            IChosenIndexesStore chosenIndexesStore, GoalTrackersEditingPanelViewModel addItemPanel) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _goalTrackerModelsService = goalTrackerModelsService;
            GetGoalTrackers();

            UpdateGoalTrackerCommand = new RelayCommandWithParameter((param) => UpdateTracker(param as GoalTrackerViewModel));
            chosenIndexesStore.ChosenListIdChanged += GetGoalTrackers;
            editigPanelEndedAction = (param) => AddPanelAction((bool)param);
            navigator.EditigPanelEnded += editigPanelEndedAction;

            AddItemPanel = addItemPanel;

            SetDayNames();
        }


        private async void GetGoalTrackers()
        {
            IEnumerable<GoalTrackerModel> listOfItems = await _goalTrackerModelsService.GetAllExtended();

            List<GoalTrackerViewModel> tempViewModel = new List<GoalTrackerViewModel>();

            foreach (GoalTrackerModel m in listOfItems)
            {
                tempViewModel.Add(new GoalTrackerViewModel(m));
            }


            UpdateDisplayedList(tempViewModel);

        }

        private async void UpdateTracker(GoalTrackerViewModel temp)
        {
            await _goalTrackerModelsService.Update(temp.GoalTracker.Id, temp.GoalTracker);
        }

        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                //  GetEvents();
            }

            AddItemPanelVisibility = false;
        }


        private void SetDayNames()
        {
            for(int i=0;i>-4;i--)
            {
                string s = DateTime.Now.AddDays(i).DayOfWeek.ToString().Substring(0,3);

                ListOfDayNames.Add(s);
            }
        }


        public override void Dispose()
        {
            _chosenIndexesStore.ChosenListIdChanged -= GetGoalTrackers;
            _navigator.EditigPanelEnded -= editigPanelEndedAction;
            base.Dispose();
        }
    }
}

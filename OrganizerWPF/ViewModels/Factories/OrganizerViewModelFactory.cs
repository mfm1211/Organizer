using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.MainViewModels;
using OrganizerWPF.ViewModels.RetractableViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace OrganizerWPF.ViewModels.Factories
{
    class OrganizerViewModelFactory : IOrganizerViewModelFactory
    {

        private readonly CreateViewModel<ListOfListsViewModel> _createListOfListsViewModel;
        private readonly CreateViewModel<EventListViewModel> _createEventListViewModel;
        private readonly CreateViewModel<CheckBoxListViewModel> _createCheckBoxListViewModel;
        private readonly CreateViewModel<TimeTrackerListViewModel> _createTimeTrackerListViewModel;
        private readonly CreateViewModel<GoalTrackerListViewModel> _createGoalTrackerListViewModel;
        private readonly CreateViewModel<NotesListViewModel> _createNotesListViewModel;
        private readonly CreateViewModel<SelectionBarViewModel> _createSelectionBarViewModel;
        private readonly CreateViewModel<RetractableEventListViewModel> _createRetractableEventListViewModel;
        private readonly CreateViewModel<RetractableCheckBoxListViewModel> _createRetractableCheckBoxListViewModel;
        private readonly CreateViewModel<RetractableListOfListsViewModel> _createRetractableListOfListViewModel;

        public OrganizerViewModelFactory(CreateViewModel<ListOfListsViewModel> createListOfListsModel, 
            CreateViewModel<EventListViewModel> createEventListViewModel,
            CreateViewModel<CheckBoxListViewModel> createCheckBoxListViewModel,
            CreateViewModel<TimeTrackerListViewModel> createTimeTrackerListViewModel,
            CreateViewModel<GoalTrackerListViewModel> createGoalTrackerListViewModel,
            CreateViewModel<NotesListViewModel> createNotesListViewModel,
            CreateViewModel<SelectionBarViewModel> createSelectionBarViewModel,
            CreateViewModel<RetractableEventListViewModel> createRetractableEventListViewModel,
            CreateViewModel<RetractableCheckBoxListViewModel> createRetractableCheckBoxListViewModel,
            CreateViewModel<RetractableListOfListsViewModel> createRetractableListOfListViewModel)
        {
            _createListOfListsViewModel = createListOfListsModel;
            _createEventListViewModel = createEventListViewModel;
            _createCheckBoxListViewModel = createCheckBoxListViewModel;
            _createTimeTrackerListViewModel = createTimeTrackerListViewModel;
            _createGoalTrackerListViewModel = createGoalTrackerListViewModel;
            _createNotesListViewModel = createNotesListViewModel;
            _createSelectionBarViewModel = createSelectionBarViewModel;
            _createRetractableEventListViewModel = createRetractableEventListViewModel;
            _createRetractableCheckBoxListViewModel = createRetractableCheckBoxListViewModel;
            _createRetractableListOfListViewModel = createRetractableListOfListViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createListOfListsViewModel();
                case ViewType.Events:
                    return _createEventListViewModel();
                case ViewType.Checkbox:
                    return _createCheckBoxListViewModel();
                case ViewType.TimeTracker:
                    return _createTimeTrackerListViewModel();
                case ViewType.GoalTracker:
                    return _createGoalTrackerListViewModel();
                case ViewType.Notes:
                    return _createNotesListViewModel();             
                case ViewType.SelectionBar:
                    return _createSelectionBarViewModel();
                case ViewType.RetractableEvents:
                    return _createRetractableEventListViewModel();
                 case ViewType.RetractableCheckBoxes:
                    return _createRetractableCheckBoxListViewModel();
                case ViewType.RetractableListOfLists:
                    return _createRetractableListOfListViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}

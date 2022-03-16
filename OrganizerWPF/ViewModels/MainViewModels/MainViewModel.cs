using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerWPF;
using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.Factories;
using OrganizerWPF.ViewModels.RetractableViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class MainViewModel : ViewModelBase
    {

        List<Type> listOfViewModelsTypes;
        List<Type> listOfRetractableViewModelsTypes;

        public ObservableCollection<Tuple<ViewType, string, ICommand>> ListMenuOptions { get; set; }

        private readonly INavigator _navigator;

        private readonly IOrganizerViewModelFactory _viewModelFactory;


        public bool ScreenIsExanded => _navigator.ScreenIsExpanded;
        public ICommand UpdateCurrentViewModel { get; }

        public ICommand ChangeSizeCommand { get;}

        public ICommand ArrowClickCommandCommand { get; }

        public ICommand ChangeRetractableScreenVisibility { get; }

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public string ViewTypeString { get; set; } = "Events";

        public MainViewModel(INavigator navigator, IOrganizerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.CurrentViewModelChanged += ()=> { OnPropertyChanged(nameof(CurrentViewModel)); ChangeTitle(); };
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(ScreenIsExanded));

            ChangeSizeCommand = new RelayCommand(ChangeSizeOfWindow);



            ArrowClickCommandCommand = new RelayCommandWithParameter(param => ChangeScreen((string)param));

            UpdateCurrentViewModel = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);

            ChangeRetractableScreenVisibility = new RelayCommand(MakeRetractabelpanelVisible); 

            UpdateCurrentViewModel.Execute(ViewType.Events);

            listOfViewModelsTypes = new List<Type> { typeof(ListOfListsViewModel), 
                typeof(EventListViewModel),
                typeof(CheckBoxListViewModel), 
                typeof(TimeTrackerListViewModel),
                typeof(GoalTrackerListViewModel), 
                typeof(NotesListViewModel)};

            listOfRetractableViewModelsTypes = new List<Type> { typeof(RetractableListOfListsViewModel),
                typeof(EventListViewModel),
                typeof(CheckBoxListViewModel),
                typeof(TimeTrackerListViewModel),
                typeof(GoalTrackerListViewModel),
                typeof(NotesListViewModel)};
            ;
        }


     

        private void MakeRetractabelpanelVisible()
        {
            ViewType mainViewType = ViewType.SelectionBar;
            ViewType retractableViewType;

            if (CurrentViewModel.GetType() == typeof(EventListViewModel)) retractableViewType = ViewType.Events;          
            else if (CurrentViewModel.GetType() == typeof(CheckBoxListViewModel)) retractableViewType = ViewType.Checkbox;
            else if (CurrentViewModel.GetType() == typeof(GoalTrackerListViewModel)) retractableViewType = ViewType.GoalTracker;
            else if (CurrentViewModel.GetType() == typeof(TimeTrackerListViewModel)) retractableViewType = ViewType.TimeTracker;
            else if (CurrentViewModel.GetType() == typeof(NotesListViewModel)) retractableViewType = ViewType.Notes;
            else
            {
               
                retractableViewType = ViewType.RetractableListOfLists;
            }

            (new ChangeRetractableScreenVisibilityCommand(_navigator)).Execute(true);

            _navigator.CurrentRetractableViewModel = _viewModelFactory.CreateViewModel(retractableViewType);

            (new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory)).Execute(mainViewType);
        }


        public void ChangeSizeOfWindow()
        {
            _navigator.ScreenIsExpanded = !ScreenIsExanded;
           

        }

        public void ChangeSizeOfWindow(bool extended)
        {
            _navigator.ScreenIsExpanded = extended;
           
        }

        private void ChangeTitle()
        {
            if(CurrentViewModel.GetType() == typeof(EventListViewModel)) ViewTypeString = "Events";
            else if (CurrentViewModel.GetType() == typeof(CheckBoxListViewModel)) ViewTypeString = "CheckList";
            else if (CurrentViewModel.GetType() == typeof(ListOfListsViewModel)) ViewTypeString = "Lists";
            else if (CurrentViewModel.GetType() == typeof(TimeTrackerListViewModel)) ViewTypeString = "Time trackers";
            else if (CurrentViewModel.GetType() == typeof(GoalTrackerListViewModel)) ViewTypeString = "Goals";
            else if (CurrentViewModel.GetType() == typeof(NotesListViewModel)) ViewTypeString = "Notes";
            else if (CurrentViewModel.GetType() == typeof(SelectionBarViewModel)) ViewTypeString = "Selecton Bar";

        }

        public void ChangeScreen(string n)
        {
            int offset = -1;
            if (n == "left") offset=1;
           
            if (_navigator.RetractableScreenIsVisible == false)
            {
                int index = listOfViewModelsTypes.FindIndex(a => a == CurrentViewModel.GetType());
                index = index + offset;

                if (index < 0) index = listOfViewModelsTypes.Count - 1;
                if (index > listOfViewModelsTypes.Count - 1) index = 0;

                switch (index)
                {
                    case 0:
                        UpdateCurrentViewModel.Execute(ViewType.Home); break;
                    case 1:
                        UpdateCurrentViewModel.Execute(ViewType.Events); break;
                    case 2:
                        UpdateCurrentViewModel.Execute(ViewType.Checkbox); break;
                    case 3:
                        UpdateCurrentViewModel.Execute(ViewType.TimeTracker); break;
                    case 4:
                        UpdateCurrentViewModel.Execute(ViewType.GoalTracker); break;
                    case 5:
                        UpdateCurrentViewModel.Execute(ViewType.Notes); break;

                }
            }
            else
            {
                int index = listOfRetractableViewModelsTypes.FindIndex(a => a == _navigator.CurrentRetractableViewModel.GetType());

                index = index + offset;

                if (index < 0) index = listOfRetractableViewModelsTypes.Count - 1;
                if (index > listOfRetractableViewModelsTypes.Count - 1) index = 0;

                ViewType retractableView = ViewType.RetractableListOfLists;
                switch (index)
                {
                    case 0:
                        retractableView = ViewType.RetractableListOfLists;  break;
                    case 1:
                        retractableView = ViewType.Events; break;
                    case 2:
                        retractableView = ViewType.Checkbox; break;
                    case 3:
                        retractableView = ViewType.TimeTracker; break;
                    case 4:
                        retractableView = ViewType.GoalTracker; break;
                    case 5:
                        retractableView = ViewType.Notes; break;

                }

                _navigator.CurrentRetractableViewModel = _viewModelFactory.CreateViewModel(retractableView);
            }
          
        }

      

    }
}

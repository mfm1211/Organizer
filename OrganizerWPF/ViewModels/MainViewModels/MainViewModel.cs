using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerWPF;
using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.Factories;
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

            _navigator.CurrentViewModelChanged += ()=> OnPropertyChanged(nameof(CurrentViewModel));
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(ScreenIsExanded));

            ChangeSizeCommand = new RelayCommand(ChangeSizeOfWindow);

            ArrowClickCommandCommand = new RelayCommandWithParameter(param => ChangeScreen((string)param));

            UpdateCurrentViewModel = new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory);

            ChangeRetractableScreenVisibility = new RelayCommand(MakeRetractabelpanelVisible); 
            InitializeItemMenuButtons();

            UpdateCurrentViewModel.Execute(ViewType.Events);

            listOfViewModelsTypes = new List<Type> { typeof(ListOfListsViewModel), typeof(EventListViewModel),
            typeof(CheckBoxListViewModel), typeof(TimeTrackerListViewModel),typeof(GoalTrackerListViewModel), typeof(NotesListViewModel)};
        }


        protected void InitializeItemMenuButtons()
        {
            Tuple<ViewType, string, ICommand> item1 = new Tuple<ViewType, string, ICommand>(ViewType.Events, "Events", UpdateCurrentViewModel);
            Tuple<ViewType, string, ICommand> item2 = new Tuple<ViewType, string, ICommand>(ViewType.Home, "Home", UpdateCurrentViewModel);
           

            ListMenuOptions = new ObservableCollection<Tuple<ViewType, string, ICommand>>();
            ListMenuOptions.Add(item1);
            ListMenuOptions.Add(item2);
         
        }


        private void MakeRetractabelpanelVisible()
        {
            (new ChangeRetractableScreenVisibilityCommand(_navigator)).Execute(true);
            (new UpdateCurrentViewModelCommand(_navigator, _viewModelFactory)).Execute(ViewType.SelectionBar);
            _navigator.CurrentRetractableViewModel = _viewModelFactory.CreateViewModel(ViewType.RetractableEvents);
        }


        public void ChangeSizeOfWindow()
        {
            _navigator.ScreenIsExpanded = !ScreenIsExanded;
           

        }

        public void ChangeSizeOfWindow(bool extended)
        {
            _navigator.ScreenIsExpanded = extended;
           
        }


        public void ChangeScreen(string n)
        {
            int index = listOfViewModelsTypes.FindIndex(a => a == CurrentViewModel.GetType());
            if (n == "left") index++;
            else index--;

            if (index < 0) index = listOfViewModelsTypes.Count - 1;
            if (index > listOfViewModelsTypes.Count - 1) index = 0;

            if (index == 0)
            {
                UpdateCurrentViewModel.Execute(ViewType.Home);
                ViewTypeString = "Lists";
            }
            else if(index == 1)
            {
                UpdateCurrentViewModel.Execute(ViewType.Events);
                ViewTypeString = "Events";
            }
            else if (index == 2)
            {
                UpdateCurrentViewModel.Execute(ViewType.Checkbox);
                ViewTypeString = "CheckList";
            }
            else if (index == 3)
            {
                UpdateCurrentViewModel.Execute(ViewType.TimeTracker);
                ViewTypeString = "Time trackers";
            }
            else if (index == 4)
            {
                UpdateCurrentViewModel.Execute(ViewType.GoalTracker);
                ViewTypeString = "Goals";
            }
            else if (index == 5)
            {
                UpdateCurrentViewModel.Execute(ViewType.Notes);
                ViewTypeString = "Notes";
            }
        }

      

    }
}

using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.RetractableWindow
{
    public class RetractableMainViewModel : ViewModelBase
    {

        private readonly INavigator _navigator;

        private readonly IOrganizerViewModelFactory _viewModelFactory;

        bool _windowVisibility;
        public bool WindowVisibility
        {
            get
            {
                return _navigator.RetractableScreenIsVisible;
            }
            set
            {
                _windowVisibility = value;
            }
        }

        public ICommand HideWindowCommand { get; set; }

        public ViewModelBase CurrentViewModel => _navigator.CurrentRetractableViewModel;

        ICommand UpdateCurrentViewModel;


        public RetractableMainViewModel(INavigator navigator, IOrganizerViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.RetractableScreenVisibilityChanged += () => OnPropertyChanged(nameof(WindowVisibility));
            _navigator.CurrentRetractableViewModelChanged += () => OnPropertyChanged(nameof(CurrentViewModel));

            HideWindowCommand = new RelayCommand(HideBigWindow);


            
        }

        private void HideBigWindow()
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Events);
            _navigator.RetractableScreenIsVisible = false;
        }
    }
}

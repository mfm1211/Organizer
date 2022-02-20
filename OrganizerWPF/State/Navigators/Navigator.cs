using OrganizerWPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.State.Navigators
{
    class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;

        private ViewModelBase _currentRetractableViewModel;

        private bool _screenIsExpanded;

        private bool _retractableScreenIsVisible;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

    
        public bool ScreenIsExpanded
        {
            get
            {
                return _screenIsExpanded;
            }
            set
            {
                _screenIsExpanded = value;
                ScreenExpansionChanged?.Invoke();
            }
        }

        public bool RetractableScreenIsVisible
        {
            get
            {
                return _retractableScreenIsVisible;
            }
            set
            {
                _retractableScreenIsVisible = value;
                RetractableScreenVisibilityChanged?.Invoke();
            }
        }

        public ViewModelBase CurrentRetractableViewModel
        {
            get
            {
                return _currentRetractableViewModel;
            }
            set
            {
                _currentRetractableViewModel = value;
                CurrentRetractableViewModelChanged?.Invoke();
            }
        }


        public event Action CurrentViewModelChanged;
        public event Action ScreenExpansionChanged;
        public event Action RetractableScreenVisibilityChanged;
        public event Action CurrentRetractableViewModelChanged;
    }
}

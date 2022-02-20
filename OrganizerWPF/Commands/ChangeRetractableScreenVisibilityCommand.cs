using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.Commands
{
    public class ChangeRetractableScreenVisibilityCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly bool _isVsisible;
        private INavigator _navigator;

        public ChangeRetractableScreenVisibilityCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is bool)
            {
                _navigator.RetractableScreenIsVisible = (bool)parameter;
            }
           
        }
    }
}

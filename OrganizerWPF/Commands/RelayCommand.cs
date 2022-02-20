using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.Commands
{
    /// <summary>
    /// A basic command that run an Action
    /// </summary>
    public class RelayCommand : ICommand
    {

        private Action mAction;

        /// <summary>
        /// The event fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };


        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }


        /// <summary>
        /// A realy command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}

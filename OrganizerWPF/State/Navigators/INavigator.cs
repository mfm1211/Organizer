using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Events,
        Checkbox,
        GoalTracker,
        TimeTracker,
        Notes,
        SelectionBar,
        RetractableEvents,
        RetractableListOfLists
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        bool ScreenIsExpanded { get; set; }
        bool RetractableScreenIsVisible { get; set; }
        ViewModelBase CurrentRetractableViewModel { get; set; }


        event Action CurrentViewModelChanged;

        event Action CurrentRetractableViewModelChanged;

        event Action ScreenExpansionChanged;

        event Action RetractableScreenVisibilityChanged;
    }
}

using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.WrappedModels
{
    public class GoalTrackerViewModel : BaseItemViewModel
    {
        private GoalTrackerModel _goalTracker;

        public GoalTrackerModel GoalTracker
        {
            get { return _goalTracker; }
        }

        public string Name => _goalTracker.Name;

        public GoalTrackerViewModel(GoalTrackerModel checkBox)
        {
            this._goalTracker = checkBox;
            Id = _goalTracker.Id;
            ListModelId = _goalTracker.ListModelId;
        }
    }
}

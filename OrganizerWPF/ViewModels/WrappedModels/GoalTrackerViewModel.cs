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
        public int[] ListOfData => _goalTracker.ListOfData;
        public bool CheckboxOn => _goalTracker.CheckboxOn;

        public GoalTrackerViewModel(GoalTrackerModel checkBox)
        {
            this._goalTracker = checkBox;
            Id = _goalTracker.Id;
            ListModelId = _goalTracker.ListModelId;
            FontColor = _goalTracker.FontColor;
        }
    }
}

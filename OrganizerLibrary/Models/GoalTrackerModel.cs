using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary
{
    public class GoalTrackerModel : BaseItemModel
    {
        /// <summary>
        /// Represents the name  of given tracker
        /// </summary>
        public string Name { get; set; }

        public int DisplayedNumber { get; set; }


        public bool CheckboxOn { get; set; }

        public void GetTrackedData()
        {

        }

        /// <summary>
        /// Initializes a new a new instance of the <see cref="GoalTrackerModel"/>
        /// </summary>
        public GoalTrackerModel()
        {
           
        }
    }
}

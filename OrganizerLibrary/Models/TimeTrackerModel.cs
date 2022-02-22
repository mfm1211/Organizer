using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary.Models
{
    public class TimeTrackerModel : BaseItemModel
    {
        /// <summary>
        /// Represents the Text description of given tracker
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new a new instance of the <see cref="TimeTrackerModel"/>
        /// </summary>
        public TimeTrackerModel()
        {
           
        }

    }
}

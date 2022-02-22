using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary.Models
{
    public class EventModel : BaseItemModel
    {

        /// <summary>
        /// Represents the Text description of given Event
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Represents the more detailed description of given Event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Shows if Event is labeled as important. (True if is important)
        /// </summary>
        public bool Important { get; set; }


        public string StringStartEndTime
        {
            get
            {
                return StartTime.ToString("dd-MM-yy    HH:mm") + "-" + EndTime.ToString("HH:mm");
            }
        }


        /// <summary>
        /// Initializes a new a new instance of the <see cref="EventModel"/>
        /// </summary>
        public EventModel()
        {
          
        }

     

    }
}

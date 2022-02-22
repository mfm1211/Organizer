using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary.Models
{
    public class DayModel
    {
     
        public DateTime Date { get; set; }


        public List<TimeTrackerModel> TimeTrackerList { get; set; } = new List<TimeTrackerModel>();
    }
}

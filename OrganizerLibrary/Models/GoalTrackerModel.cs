using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrganizerLibrary.Models
{
    public class GoalTrackerModel : BaseItemModel
    {
        /// <summary>
        /// Represents the name  of given tracker
        /// </summary>
        public string Name { get; set; }

        public bool CheckboxOn { get; set; }

        [MaxLength(2000)]
        public byte[] ListOfData { get; set; }


        /// <summary>
        /// Initializes a new a new instance of the <see cref="GoalTrackerModel"/>
        /// </summary>
        public GoalTrackerModel()
        {
           
        }
    }
}

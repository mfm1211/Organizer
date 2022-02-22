using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary.Models
{
    public abstract class BaseListItemModel: DomainObject
    {
        
      
        /// <summary>
        /// Represents the unique identifier of the Section to which the item belongs
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Represents time when item  starts
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Represents time when item ends
        /// </summary>
        public DateTime EndTime { get; set; }


        /// <summary>
        /// Represents the unique identifier of the List to which the item belongs
        /// </summary>
        public int ListModelId{ get; set; }


        /// <summary>
        /// Represents the color of the List
        /// </summary>
        public string FontColor { get; set; }
       


    }
}

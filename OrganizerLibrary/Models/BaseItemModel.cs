using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizerLibrary.Models
{
    public abstract class BaseItemModel: DomainObject
    {

        /// <summary>
        /// Represents time when item  starts
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Represents time when item ends
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Represents the color of the List
        /// </summary>
        [NotMapped]
        public string FontColor { get; set; }

        /// <summary>
        /// Represents the unique identifier of the List to which the item belongs
        /// </summary>
        [Required]
        public int ListModelId { get; set; }

        /// <summary>
        /// Represents the unique identifier of the Section to which the item belongs
        /// </summary>
        [Required]
        public int SectionId { get; set; }



    }
}

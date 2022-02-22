using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrganizerLibrary.Models
{
    public class SectionModel:DomainObject
    {
        private string shortName;
        private string name;

        /// <summary>
        /// Represents the name of given Section
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                shortName = name.Length > 12 ? (name.Substring(0, 10) + "..") : name;
            }
        }


        /// <summary>
        /// Represents the short name of given List (first 12 symbols)
        /// </summary>
        public string ShortName
        {
            get { return shortName; }

        }



        /// <summary>
        /// Id of the list to which the section belongs
        /// </summary>
        [Required]
        public int ListModelId { get; set; }

    }
}

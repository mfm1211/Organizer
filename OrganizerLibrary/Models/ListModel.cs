using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrganizerLibrary.Models
{
    public class ListModel: DomainObject
    {

        private string shortName;
        private string name;



        /// <summary>
        /// Represents the name of given List
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
        /// Keeps the info about color of the List in a string of six signs (RGB - hexagonal values)
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string ColorString { get; set; }


        /// <summary>
        /// Represents the short name of given List (first 12 symbols)
        /// </summary>
        public string ShortName
        {
            get { return shortName; }

        }


        /// <summary>
        /// Keeps the description string
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }


        public ICollection<EventModel> EventModels { get; set; }

        public ICollection<CheckBoxModel> CheckBoxModels { get; set; }

        public ICollection<NotesModel> NotesModels { get; set; }

        public ICollection<SectionModel> SectionModels { get; set; }





    }
}

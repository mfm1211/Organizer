using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrganizerLibrary.Models
{
    public class SectionModel: DomainObject
    {
        private string _shortName;
        private string _name;

      
        /// <summary>
        /// Represents the name of given Section
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _shortName = _name.Length > 12 ? (_name.Substring(0, 10) + "..") : _name;
            }
        }


        /// <summary>
        /// Represents the short name of given List (first 12 symbols)
        /// </summary>
        public string ShortName
        {
            get { return _shortName; }

        }



        /// <summary>
        /// Id of the list to which the section belongs
        /// </summary>
        [Required]
        public int ListModelId { get; set; }


        public SectionModel(string name, int listModelId)
        {
            Name = name;
            ListModelId = listModelId;
        }

        public SectionModel()
        {
         
        }

    }
}

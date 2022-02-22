using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrganizerLibrary.Models
{
    public class NotesModel : BaseItemModel
    {

        /// <summary>
        /// Represents the title of a given note
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Represents the text inside the note
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// If true then note is shown on main screen
        /// </summary>
        public bool Pined { get; set; }

        /// <summary>
        /// Initializes a new a new instance of the <see cref="NotesModel"/>
        /// </summary>
        public NotesModel()
        {
           
        }

     
    }
}

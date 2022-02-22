using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OrganizerLibrary.Models
{
    public class CheckBoxModel : BaseItemModel
    {
        /// <summary>
        /// Represents the Text description of given CheckBox
        /// </summary>
        [MaxLength(100)]
        public string Text { get; set; }

        /// <summary>
        /// Represents the more detailed description of given CheckBox
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// Shows if Checklist is checked
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Initializes a new a new instance of the <see cref="CheckBoxModel"/>
        /// </summary>
        public CheckBoxModel()
        {

        }
    }
}

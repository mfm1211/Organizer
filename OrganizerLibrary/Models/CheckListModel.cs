using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerLibrary.Models
{
    class CheckListModel : BaseListItemModel
    {
        /// <summary>
        /// Represents the Text description of given CheckBox
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Represents the more detailed description of given CheckBox
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Shows if Checklist is checked
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Initializes a new a new instance of the <see cref="CheckListModel"/>
        /// </summary>
        public CheckListModel()
        {

        }
    }
}

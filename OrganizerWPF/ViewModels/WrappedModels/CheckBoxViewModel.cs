using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OrganizerWPF.ViewModels.WrappedModels
{
    public class CheckBoxViewModel: BaseItemViewModel
    {
        private CheckBoxModel _checkBox;

        public CheckBoxModel CheckBox
        {
            get { return _checkBox; }
        }

      
        public string Text => _checkBox.Text;
        public string Description => _checkBox.Description;
        public bool Checked
        {
            get
            {
                return _checkBox.Checked;
            }
            set
            {
                _checkBox.Checked = value;
            }
        }
        public Bitmap CheckBoxBitmap => _checkBox.CheckBoxBitmap;



        public CheckBoxViewModel(CheckBoxModel checkBox)
        {
            this._checkBox = checkBox;
            Id = _checkBox.Id;
            ListModelId = _checkBox.ListModelId;
            Checked = _checkBox.Checked;
        }
    }
}

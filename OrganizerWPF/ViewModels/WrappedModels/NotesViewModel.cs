using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.WrappedModels
{
    public class NotesViewModel : BaseItemViewModel
    {
        private NotesModel _notesModel;

        public NotesModel NotesObj
        {
            get { return _notesModel; }
        }

        public string Title => _notesModel.Title;
        public string Text => _notesModel.Text;

        public NotesViewModel(NotesModel notesModel)
        {
            this._notesModel = notesModel;
            Id = _notesModel.Id;
            ListModelId = _notesModel.ListModelId;

            StartTime = _notesModel.StartTime;

            EndTime = _notesModel.EndTime;

            FontColor = _notesModel.FontColor;
        }
    }
}

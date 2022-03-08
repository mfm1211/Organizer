using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.WrappedModels
{
    public class EventViewModel: BaseItemViewModel
    {
        private EventModel _eventModel;

        public EventModel EventObj
        {
            get { return _eventModel; }
        }

        public string Text => _eventModel.Text;
        public string Description => _eventModel.Description;
        public bool Important => _eventModel.Important;
        public string StringStartEndTime => _eventModel.StringStartEndTime;
      
        

        public EventViewModel(EventModel eventModel)
        {
            this._eventModel = eventModel;
            Id = _eventModel.Id;
            ListModelId = _eventModel.ListModelId;

            StartTime = _eventModel.StartTime;

            EndTime = _eventModel.EndTime;

            FontColor = _eventModel.FontColor;
        }

    }
}

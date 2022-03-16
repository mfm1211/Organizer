using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class EventsEditingPanelViewModel: AddBaseListItemPanelViewModel<EventModel>
    {
        public EventsEditingPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<EventModel> service) :
            base(action, listModelsService, service)
        {

        }
    }
}

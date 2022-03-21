using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class EventsEditingPanelViewModel: AddBaseListItemPanelViewModel<EventModel>
    {
        public EventsEditingPanelViewModel(IDataService<ListModel> listModelsService, IDataService<EventModel> service, INavigator navigator) :
            base(listModelsService, service, navigator)
        {

        }
    }
}

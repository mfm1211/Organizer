using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class GoalTrackersEditingPanelViewModel : AddBaseListItemPanelViewModel<GoalTrackerModel>
    {
        public GoalTrackersEditingPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<GoalTrackerModel> service) :
          base(action, listModelsService, service)
        {
            CreatedItem = new GoalTrackerModel();
        }
    }
}

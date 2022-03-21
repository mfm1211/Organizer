using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class GoalTrackersEditingPanelViewModel : AddBaseListItemPanelViewModel<GoalTrackerModel>
    {
        public GoalTrackersEditingPanelViewModel(IDataService<ListModel> listModelsService, IDataService<GoalTrackerModel> service, INavigator navigator) :
          base(listModelsService, service, navigator)
        {
            CreatedItem = new GoalTrackerModel();
        }
    }
}

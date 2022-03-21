using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class CheckBoxesEditingPanelViewModel: AddBaseListItemPanelViewModel<CheckBoxModel>
    {
        public CheckBoxesEditingPanelViewModel(IDataService<ListModel> listModelsService, IDataService<CheckBoxModel> service, INavigator navigator) :
            base(listModelsService, service, navigator)
        {

        }
    }
}

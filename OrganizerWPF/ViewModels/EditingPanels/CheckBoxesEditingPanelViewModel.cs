using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class CheckBoxesEditingPanelViewModel: AddBaseListItemPanelViewModel<CheckBoxModel>
    {
        public CheckBoxesEditingPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<CheckBoxModel> service) :
            base(action, listModelsService, service)
        {

        }
    }
}

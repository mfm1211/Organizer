using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class NotesEditingPanelViewModel: AddBaseListItemPanelViewModel<NotesModel>
    {
        public NotesEditingPanelViewModel(IDataService<ListModel> listModelsService, IDataService<NotesModel> service, INavigator navigator):
            base(listModelsService, service, navigator)
        {
            CreatedItem = new NotesModel();
        }

        public async void PopulatePanelVithData(NotesViewModel note)
        {
            CreatedItem = await _service.GetExtended(note.Id);
        }
    }
}

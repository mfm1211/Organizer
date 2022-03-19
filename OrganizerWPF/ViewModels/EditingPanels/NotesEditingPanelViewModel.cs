using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.EditingPanels
{
    public class NotesEditingPanelViewModel: AddBaseListItemPanelViewModel<NotesModel>
    {
        public NotesEditingPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService, IDataService<NotesModel> service):
            base(action, listModelsService, service)
        {
            CreatedItem = new NotesModel();
        }

        public async void PopulatePanelVithData(NotesViewModel note)
        {
            CreatedItem = await _service.GetExtended(note.Id);
        }
    }
}

using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.EditingPanels;
using OrganizerWPF.ViewModels.WrappedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class NotesListViewModel : BaseItemListViewModel
    {
        private IDataService<NotesModel> _notesModelsService;

        public NotesEditingPanelViewModel AddItemPanel { get; set; }

        public NotesListViewModel(IDataService<NotesModel> notesModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _notesModelsService = notesModelsService;
            chosenIndexesStore.ChosenListIdChanged += GetNotes;
            GetNotes();

            AddItemPanel = new NotesEditingPanelViewModel((param) => AddPanelAction((bool)param), listModelsService, _notesModelsService);
            EditItemCommand = new RelayCommandWithParameter((param) => { AddItemPanelVisibility = true; AddItemPanel.PopulatePanelVithData((NotesViewModel)param); });
        }


        private async void GetNotes()
        {
            List<NotesModel> listOfModels = await GetItemsForGivenList<NotesModel>(_notesModelsService);

            List<NotesViewModel> tempViewModel = new List<NotesViewModel>();

            foreach (NotesModel m in listOfModels)
            {
                tempViewModel.Add(new NotesViewModel(m));
            }


            UpdateDisplayedList(tempViewModel);

        }


        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
              //  GetEvents();
            }

            AddItemPanelVisibility = false;
        }
    }
}
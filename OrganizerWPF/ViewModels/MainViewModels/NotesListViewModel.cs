using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class NotesListViewModel : BaseItemListViewModel
    {
        private IDataService<NotesModel> _notesModelsService;

        public NotesListViewModel(IDataService<NotesModel> notesModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _notesModelsService = notesModelsService;
            GetCheckBoxes();
        }


        private async void GetCheckBoxes()
        {
            IEnumerable<NotesModel> listOfItems = await _notesModelsService.GetAll();

        //    UpdateDisplayedList(listOfItems);

        }
    }
}
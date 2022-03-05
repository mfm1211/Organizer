using OrganizerLibrary;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    public class AddListPanelViewModel
    {

        ListModel createdListModel;

        private readonly Action<bool> _action;

        private IDataService<ListModel> _listModelsService;

        public ICommand AddListCommand { get; set; }

        public ICommand CancelCommand { get; set; }


        public AddListPanelViewModel(Action<bool> action, IDataService<ListModel> listModelsService)
        {
            _action = action;

            _listModelsService = listModelsService;

            AddListCommand = new RelayCommand(CreateNewItem);

            CancelCommand = new RelayCommand(CreateCancelEvent);
        }


        private async void CreateNewItem()
        {
            createdListModel = new ListModel();

            createdListModel.Name = "listTest";

            createdListModel.ColorString = "#0FC482";

            createdListModel.ChechBoxImageByteArray = DrawImages.DrawCheckBox(1, createdListModel.ColorString);

            await _listModelsService.Create(createdListModel);

            _action.Invoke(true);
        }

        private void CreateCancelEvent()
        {
            _action.Invoke(false);
        }

    }
}

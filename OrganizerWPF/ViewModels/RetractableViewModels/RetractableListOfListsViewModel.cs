using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    public class RetractableListOfListsViewModel : ListOfListsViewModel
    {
        public AddListPanelViewModel AddListPanel { get; set; }

        public bool AddListPanelVisibility { get; set; }

        public ICommand ShowAddPanelCommand { get; }

        public ICommand DeleteListCommand { get; set; }

        public RetractableListOfListsViewModel(IDataService<ListModel> listModelsService, INavigator navigator) : base(listModelsService, navigator)
        {
            AddListPanel = new AddListPanelViewModel((param) => AddPanelAction((bool)param), listModelsService);

            ShowAddPanelCommand = new RelayCommand(() => { AddListPanelVisibility = true; });

            DeleteListCommand = new RelayCommandWithParameter((param) => DeleteList((ListModel)param));
        }


        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                GetLists();
            }
            AddListPanelVisibility = false;
        }


        private async void DeleteList(ListModel model)
        {
            await _listModelsService.Delete(model.Id);
            List<ListModel> temp = DisplayedListOfItems.ToList();
            temp.RemoveAll(m => m.Id == model.Id);
            DisplayedListOfItems = new ObservableCollection<ListModel>(temp);

        }

    }
}

using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    public class RetractableListOfListsViewModel : ListOfListsViewModel
    {
        public AddListPanelViewModel AddListPanel { get; set; }

        public bool AddListPanelVisibility { get; set; }

        public ICommand ShowAddPanelCommand { get; }

        public RetractableListOfListsViewModel(IDataService<ListModel> listModelsService, INavigator navigator) : base(listModelsService, navigator)
        {
            AddListPanel = new AddListPanelViewModel((param) => AddPanelAction((bool)param), listModelsService);

            ShowAddPanelCommand = new RelayCommand(() => { AddListPanelVisibility = true; });
        }


        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                GetLists();
            }
            AddListPanelVisibility = false;


        }
    }
}

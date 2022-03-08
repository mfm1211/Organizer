using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Input;
using OrganizerWPF.Commands;
using OrganizerWPF.ViewModels.WrappedModels;
using OrganizerWPF.State.ItemListStates;
using System.Collections.ObjectModel;
using OrganizerWPF.ViewModels.MainViewModels;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    public class RetractableCheckBoxListViewModel : CheckBoxListViewModel
    {
        private readonly IChosenIndexesStore _chosenIndexesStore;

        public ICommand DeleteItemCommand { get; set; }
        public ICommand EditItemCommand { get; set; }

        public AddBaseListItemPanelViewModel AddCheckBoxPanel { get; set; }

        public ICommand ShowAddItemPanelCommand { get; set; }

        public bool AddItemPanelVisibility { get; set; } = false;

        public RetractableCheckBoxListViewModel(IDataService<CheckBoxModel> checkboxModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore):
            base(checkboxModelsService,  listModelsService, navigator)
        {        
            _chosenIndexesStore = chosenIndexesStore;
            DeleteItemCommand = new RelayCommandWithParameter((param) => DeleteItem((CheckBoxViewModel)param));
            ShowAddItemPanelCommand = new RelayCommand(() => AddItemPanelVisibility = true);
            AddCheckBoxPanel = new AddBaseListItemPanelViewModel((param) => AddPanelAction((bool)param), listModelsService, checkboxModelsService);
        }


        private async void DeleteItem(CheckBoxViewModel model)
        {
            await _checkboxModelsService.Delete(model.Id);
            List<BaseItemViewModel> temp = DisplayedListOfItems.ToList();
            temp.RemoveAll(m => m.Id == model.Id);
            DisplayedListOfItems = new ObservableCollection<BaseItemViewModel>(temp);
        }


        private void AddPanelAction(bool itemCreted)
        {
            if (itemCreted)
            {
                GetCheckBoxes();
            }

            AddItemPanelVisibility = false;
        }


        public override void Dispose()
        {
          //  _chosenIndexesStore.ChosenListIdChanged -= GetEvents;
            base.Dispose();
        }

    }
}

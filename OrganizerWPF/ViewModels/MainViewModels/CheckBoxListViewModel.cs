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

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class CheckBoxListViewModel : BaseItemListViewModel
    {
        protected IDataService<CheckBoxModel> _checkboxModelsService;

        public ICommand CheckBoxClickedCommand { get; }

        

        

        public CheckBoxListViewModel(IDataService<CheckBoxModel> checkboxModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore) : 
            base(navigator, listModelsService, chosenIndexesStore)
        {
            
            _checkboxModelsService = checkboxModelsService;
            CheckBoxClickedCommand = new RelayCommandWithParameter((param) => ChangeCheckBoxState((param as CheckBoxViewModel).Id));
            GetCheckBoxes();

            _chosenIndexesStore.ChosenListIdChanged += GetCheckBoxes;

            DeleteItemCommand = new RelayCommandWithParameter((param) => DeleteItem<CheckBoxModel>((CheckBoxViewModel)param, checkboxModelsService));
            
            AddItemPanel = new AddBaseListItemPanelViewModel((param) => AddPanelAction((bool)param), listModelsService, checkboxModelsService);

        }


        protected async void GetCheckBoxes()
        {
            List<CheckBoxModel> listOfItems = (await _checkboxModelsService.GetAll()).ToList();
            IEnumerable<ListModel> listOfLists = await _listModelsService.GetAll();
            List<CheckBoxViewModel> tempViewModel = new List<CheckBoxViewModel>();

            if (_chosenIndexesStore.ChosenListId != -1)
            {
                listOfItems = new List<CheckBoxModel>(listOfItems.Where(m => m.ListModelId == _chosenIndexesStore.ChosenListId).ToList());
            }

            foreach (CheckBoxModel item in listOfItems)
            {
                byte[] byteArray = listOfLists.Single(m => m.Id == item.ListModelId).ChechBoxImageByteArray;

                using (var ms = new MemoryStream(byteArray))
                {
                    item.CheckBoxBitmap = new Bitmap(ms);
                   
                }

                tempViewModel.Add(new CheckBoxViewModel(item));

            }

            UpdateDisplayedList(tempViewModel);

        }

        private async void ChangeCheckBoxState(int id)
        {
            CheckBoxViewModel temp = (CheckBoxViewModel)DisplayedListOfItems.Single(model => model.Id == id);

            CheckBoxViewModel chosenCheckBox = (CheckBoxViewModel)DisplayedListOfItems.Single(model => model.Id == id);

            chosenCheckBox.Checked = !temp.Checked;
          
            await _checkboxModelsService.Update(id, chosenCheckBox.CheckBox);


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

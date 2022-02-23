using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class CheckBoxListViewModel : BaseItemListViewModel
    {
        private IDataService<CheckBoxModel> _checkboxModelsService;

        public CheckBoxListViewModel(IDataService<CheckBoxModel> checkboxModelsService, INavigator navigator) : base(navigator)
        {
            _checkboxModelsService = checkboxModelsService;
            GetCheckBoxes();
        }


        private async void GetCheckBoxes()
        {
            IEnumerable<CheckBoxModel> listOfItems = await _checkboxModelsService.GetAll();

            UpdateDisplayedList(listOfItems);

        }
    }
}

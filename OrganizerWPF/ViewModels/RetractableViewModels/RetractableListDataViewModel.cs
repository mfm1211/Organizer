using OrganizerWPF.Commands;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    public class RetractableListDataViewModel : ViewModelBase
    {
        public ICommand GoBackToListCommand { get; set; }

        INavigator _navigator;

        IOrganizerViewModelFactory _viewModelFactory;

        public RetractableListDataViewModel(INavigator navigator, IOrganizerViewModelFactory viewModelFactory)
        {
            GoBackToListCommand = new RelayCommand(GoBack);

            _navigator = navigator;

            _viewModelFactory = viewModelFactory;
        }

        private void GoBack()
        {
            _navigator.CurrentRetractableViewModel = _viewModelFactory.CreateViewModel(ViewType.RetractableListOfLists);
        }
    }
}

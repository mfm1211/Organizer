using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels.MainWindow;
using OrganizerWPF.ViewModels.RetractableWindow;
using System;
using System.Collections.Generic;
using System.Text;


namespace OrganizerWPF.ViewModels.Factories
{
    class OrganizerViewModelFactory : IOrganizerViewModelFactory
    {

        private readonly CreateViewModel<ListOfListsViewModel> _createListOfListsViewModel;
        private readonly CreateViewModel<EventListViewModel> _createEventListViewModel;
        private readonly CreateViewModel<SelectionBarViewModel> _createSelectionBarViewModel;
        private readonly CreateViewModel<RetractableEventListViewModel> _createRetractableEventListViewModel;

        public OrganizerViewModelFactory(CreateViewModel<ListOfListsViewModel> createListOfListsModel, 
            CreateViewModel<EventListViewModel> createEventListViewModel, 
            CreateViewModel<SelectionBarViewModel> createSelectionBarViewModel,
            CreateViewModel<RetractableEventListViewModel> createRetractableEventListViewModel)
        {
            _createListOfListsViewModel = createListOfListsModel;
            _createEventListViewModel = createEventListViewModel;
            _createSelectionBarViewModel = createSelectionBarViewModel;
            _createRetractableEventListViewModel = createRetractableEventListViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createListOfListsViewModel();
                case ViewType.Events:
                    return _createEventListViewModel();
                case ViewType.SelectionBar:
                    return _createSelectionBarViewModel();
                case ViewType.RetractableEvents:
                    return _createRetractableEventListViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}

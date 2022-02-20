using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.Factories
{
    class OrganizerViewModelFactory : IOrganizerViewModelFactory
    {

        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<EventListViewModel> _createEventListViewModel;
        private readonly CreateViewModel<SelectionBarViewModel> _createSelectionBarViewModel;
        private readonly CreateViewModel<RetractableEventListViewModel> _createRetractableEventListViewModel;

        public OrganizerViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel, 
            CreateViewModel<EventListViewModel> createEventListViewModel, 
            CreateViewModel<SelectionBarViewModel> createSelectionBarViewModel,
            CreateViewModel<RetractableEventListViewModel> createRetractableEventListViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createEventListViewModel = createEventListViewModel;
            _createSelectionBarViewModel = createSelectionBarViewModel;
            _createRetractableEventListViewModel = createRetractableEventListViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
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

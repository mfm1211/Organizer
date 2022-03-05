﻿using Microsoft.Extensions.DependencyInjection;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using OrganizerWPF.Commands;

namespace OrganizerWPF.ViewModels.RetractableViewModels
{
    class RetractableEventListViewModel : ViewModelBase
    {
        private IDataService<EventModel> _eventModelsService;

        public ObservableCollection<EventModel> DisplayedListOfItems { get; set; } = new ObservableCollection<EventModel>();

        private readonly INavigator _navigator;

        private readonly IChosenIndexesStore _chosenIndexesStore;
       
        public bool AddItemPanelVisibility { get; set; } = false;

        public AddBaseListItemPanelViewModel AddEventPanel { get; set; }

        public ICommand ShowAddItemPanelCommand { get; set; }

         public ICommand DeleteItemCommand { get; set; }

        public ICommand EditItemCommand { get; set; }

        public RetractableEventListViewModel(IDataService<EventModel> eventModelsService, IDataService<ListModel> listModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _eventModelsService = eventModelsService;
            chosenIndexesStore.ChosenListIdChanged += GetEvents;
            _chosenIndexesStore = chosenIndexesStore;
            ShowAddItemPanelCommand=new RelayCommand(()=> AddItemPanelVisibility=true);
            AddEventPanel = new AddBaseListItemPanelViewModel((param) => AddPanelAction((bool)param), listModelsService, eventModelsService);
            DeleteItemCommand = new RelayCommandWithParameter((param) => DeleteItem((EventModel)param));
            GetEvents();
        }


        private async void DeleteItem(EventModel model)
        {
            await _eventModelsService.Delete(model.Id);
            List<EventModel> temp = DisplayedListOfItems.ToList();
            temp.RemoveAll(m => m.Id== model.Id);
            DisplayedListOfItems = new ObservableCollection<EventModel>(temp);

        }

      


        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                GetEvents();
            }


            AddItemPanelVisibility = false;
        }

        private async void GetEvents()
        {
            IEnumerable<EventModel> temp = await _eventModelsService.GetAll();
            DisplayedListOfItems = new ObservableCollection<EventModel>(temp);
            if (_chosenIndexesStore.ChosenListId != -1)
            {
                DisplayedListOfItems = new ObservableCollection<EventModel>(DisplayedListOfItems.Where(m => m.ListModelId == _chosenIndexesStore.ChosenListId).ToList());
            }
        }


        public override void Dispose()
        {
            _chosenIndexesStore.ChosenListIdChanged -= GetEvents;
            base.Dispose();
        }


    }
}
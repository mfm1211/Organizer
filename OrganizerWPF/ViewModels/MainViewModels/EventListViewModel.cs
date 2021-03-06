using Microsoft.Extensions.DependencyInjection;
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
using OrganizerWPF.ViewModels.WrappedModels;
using System.Windows.Input;
using OrganizerWPF.Commands;
using OrganizerWPF.ViewModels.EditingPanels;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class EventListViewModel : BaseItemListViewModel
    {
        private IDataService<EventModel> _eventModelsService;

       
        public string NextEventObjString { get; set; }

        public EventsEditingPanelViewModel AddItemPanel { get; set; }

        public EventListViewModel(IDataService<EventModel> eventModelsService, IDataService<ListModel> listModelsService, INavigator navigator, 
            IChosenIndexesStore chosenIndexesStore, EventsEditingPanelViewModel localAddItemPanel) :
            base(navigator, listModelsService, chosenIndexesStore)
        {
            _eventModelsService = eventModelsService; 
            GetEvents();

            chosenIndexesStore.ChosenListIdChanged += GetEvents;
            editigPanelEndedAction = (param) => AddPanelAction((bool)param);
            navigator.EditigPanelEnded += editigPanelEndedAction;
            AddItemPanel = localAddItemPanel;
            DeleteItemCommand = new RelayCommandWithParameter((param) => DeleteItem<EventModel>((EventViewModel)param, eventModelsService));

        }

        ~EventListViewModel()
        {

        }

        private async void GetEvents()
        {
            List<EventModel> listOfModels =  await GetItemsForGivenList<EventModel>(_eventModelsService);

            List<EventViewModel> tempViewModel = new List<EventViewModel>();

            foreach (EventModel m in listOfModels)
            {
                tempViewModel.Add(new EventViewModel(m));
            }


            UpdateDisplayedList(tempViewModel);

            SetNextEventString();
        }

        private void SetNextEventString()
        {
            if (DisplayedListOfItems.Count > 1)
            {
                string dateString = "";
                string textString = "";
                if ((DisplayedListOfItems[1]).StartTime.Date == DateTime.Today)
                    dateString = "(Today)";
                else if ((DisplayedListOfItems[1]).StartTime.Date == DateTime.Today.AddDays(1))
                    dateString = "(Tommorow)";
                else
                    dateString = "(" + (DisplayedListOfItems[1]).StartTime.ToString("dd-MMM  HH:mm") + ")";

                if (((EventViewModel)DisplayedListOfItems[1]).Text.Length > 17)
                    textString = ((EventViewModel)DisplayedListOfItems[1]).Text.Substring(0, 17) + "...";
                else
                    textString = ((EventViewModel)DisplayedListOfItems[1]).Text;

                NextEventObjString = "Next:  " + dateString + "  " + textString;
            }
            else
            {
                NextEventObjString = "No other events";
            }
        }


        private void AddPanelAction(bool eventCreted)
        {
            if (eventCreted)
            {
                GetEvents();
            }
            AddItemPanelVisibility = false;
        }

        public override void Dispose()
        {
            _chosenIndexesStore.ChosenListIdChanged -= GetEvents;
            _navigator.EditigPanelEnded -= editigPanelEndedAction;
            base.Dispose();
        }


    }
}

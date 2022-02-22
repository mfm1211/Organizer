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

namespace OrganizerWPF.ViewModels.MainWindow
{
    public class EventListViewModel : BaseItemListViewModel
    {
        private IDataService<EventModel> _itemModelsService;

        public string NextEventObjString { get; set; }

        public EventListViewModel(IDataService<EventModel> eventModelsService, INavigator navigator) : base(navigator)
        {         
            _itemModelsService = eventModelsService; 
            GetEvents();
        }

        private async void GetEvents()
        {
            IEnumerable<EventModel> temp = await _itemModelsService.GetAll();
            
            UpdateDisplayedList(temp);

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

                if (((EventModel)DisplayedListOfItems[1]).Text.Length > 17)
                    textString = ((EventModel)DisplayedListOfItems[1]).Text.Substring(0, 17) + "...";
                else
                    textString = ((EventModel)DisplayedListOfItems[1]).Text;

                NextEventObjString = "Next:  " + dateString + "  " + textString;
            }
            else
            {
                NextEventObjString = "No other events";
            }
        }


    }
}

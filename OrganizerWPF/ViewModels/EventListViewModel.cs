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

namespace OrganizerWPF.ViewModels
{
    public class EventListViewModel:ViewModelBase
    {
        private IDataService<EventModel> _eventModelsService;

        public ObservableCollection<EventModel> DisplayedListOfItems { get; set; } = new ObservableCollection<EventModel>();

        private readonly INavigator _navigator;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public string NextEventObjString { get; set; }

        public EventListViewModel(IDataService<EventModel> EventModelsService, INavigator navigator)
        {
            _navigator = navigator;
            _eventModelsService = EventModelsService;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            GetEvents();
        }

        private async void GetEvents()
        {
            IEnumerable<EventModel> temp = await _eventModelsService.GetAll();
          
            DisplayedListOfItems = new ObservableCollection<EventModel>(temp);

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

                if ((DisplayedListOfItems[1]).Text.Length > 17)
                    textString = (DisplayedListOfItems[1]).Text.Substring(0, 17) + "...";
                else
                    textString = (DisplayedListOfItems[1]).Text;

                NextEventObjString = "Next:  " + dateString + "  " + textString;
            }
            else
            {
                NextEventObjString = "No other events";
            }
        }


    }
}

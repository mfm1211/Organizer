using OrganizerLibrary.Models;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OrganizerWPF.ViewModels.MainWindow
{
    public class BaseItemListViewModel : ViewModelBase
    {
        protected INavigator _navigator;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public ObservableCollection<BaseItemModel> DisplayedListOfItems { get; set; } = new ObservableCollection<BaseItemModel>();

        public BaseItemListViewModel(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
        }


        protected void UpdateDisplayedList(IEnumerable<BaseItemModel> list)
        {
            DisplayedListOfItems = new ObservableCollection<BaseItemModel>(list);
        }
    }
}

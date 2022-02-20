using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.ViewModels.Factories
{
    public interface IOrganizerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}

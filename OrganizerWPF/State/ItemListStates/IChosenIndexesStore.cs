using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.State.ItemListStates
{
    public interface IChosenIndexesStore
    {
        int ChosenListId { get; set; }

        event Action ChosenListIdChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizerWPF.State.ItemListStates
{
    public class ChosenIndexesStore : IChosenIndexesStore
    {
        private int _chosenListId = -1;

        public int ChosenListId
        {
            get
            {
                return _chosenListId;
            }
            set
            {
                _chosenListId = value;
                ChosenListIdChanged?.Invoke();
            }
        }

        public event Action ChosenListIdChanged;


    }
}

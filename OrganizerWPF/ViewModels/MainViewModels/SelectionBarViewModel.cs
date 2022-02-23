using Microsoft.Extensions.DependencyInjection;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using OrganizerWPF.State.ItemListStates;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class SelectionBarViewModel : ViewModelBase
    {
        private IDataService<ListModel> _simpleListModelsService;
        private readonly INavigator _navigator;
        private readonly IChosenIndexesStore _chosenIndexesStore;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        private Tuple<int, string> _selectedListTuple;

        public int ChosenListId { get; set; } = -1;
       
        public List<Tuple<int, string>> ListOfListObjStrings { get; set; } = new List<Tuple<int, string>>();

       
        public Tuple<int, string> SelectedListTuple
        {
            get { return _selectedListTuple; }
            set
            {
                _selectedListTuple = value;
                if (_selectedListTuple != null)
                {
                    ChosenListId = _selectedListTuple.Item1;
                    ChangeChosenList(ChosenListId);
                }

            }
        }


        public SelectionBarViewModel(IDataService<ListModel> simpleListModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _simpleListModelsService = simpleListModelsService;
            _chosenIndexesStore = chosenIndexesStore;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            dd();
        }

        private async void dd()
        {
            IEnumerable<ListModel> temp = await _simpleListModelsService.GetAll();
            ListOfListObjStrings = temp.Select(listobj => new Tuple<int, string>(listobj.Id, listobj.Name)).ToList();
        }

     

        private void ChangeChosenList(int modelId)
        {

            //ListOfChosenListSubLists = _listOfSubList[model.Id];
            if (modelId != -1)
            {
              //  ListOfSectionsForCombobox = GetSectionViewModels(true, model.Id);

              //  ListOfSectionsTuples = ListOfSectionsForCombobox.Select(section => new Tuple<int, string>(section.Id, section.Name)).ToList();
             //   SelectedSectionTuple = ListOfSectionsTuples[0];

             //   comboboxOfSectionsVisibility = true;
            }
            else
            {
                //  SelectedSectionTuple = new Tuple<int, string>(0, "");
              //  comboboxOfSectionsVisibility = false;
            }
          
            if (_chosenIndexesStore != null)
            {
                _chosenIndexesStore.ChosenListId = modelId;
            }


            ///if (_action!=null)
            //   _action.Invoke();
        }


    }
}


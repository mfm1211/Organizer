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
        private ListModel _selectedList;
        private IDataService<ListModel> _simpleListModelsService;
        private readonly INavigator _navigator;
        private readonly IChosenIndexesStore _chosenIndexesStore;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public int ChosenListId { get; set; } = -1;
       
        public List<ListModel> ListOfListObjsForCombobox { get; set; } = new List<ListModel>();
     
        public ListModel SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                ChangeChosenList(_selectedList.Id);
            }
        }


        public SelectionBarViewModel(IDataService<ListModel> simpleListModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _simpleListModelsService = simpleListModelsService;
            _chosenIndexesStore = chosenIndexesStore;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            GetLists();
        }

        private async void GetLists()
        {
            ListModel allLists = new ListModel();
            allLists.Id = -1;
            allLists.Name = "All Lists";
           

            ListOfListObjsForCombobox = new List<ListModel>(await _simpleListModelsService.GetAll());

            ListOfListObjsForCombobox.Insert(0, allLists);

            SelectedList = ListOfListObjsForCombobox[0];
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


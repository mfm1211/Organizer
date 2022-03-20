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
using System.Windows.Input;
using OrganizerWPF.Commands;

namespace OrganizerWPF.ViewModels.MainViewModels
{
    public class SelectionBarViewModel : ViewModelBase
    {
        private ListModel _selectedList;
        private SectionModel _selectedSection;
        private IDataService<ListModel> _simpleListModelsService;
        private IDataService<SectionModel> _sectionModelsService;
        private readonly INavigator _navigator;
        private readonly IChosenIndexesStore _chosenIndexesStore;
        public bool PanelSizeIsExpanded => _navigator.ScreenIsExpanded;

        public int ChosenListId { get; set; } = -1;

        public bool ComboboxOfSectionsVisibility { get; set; } = false;


        public ObservableCollection<ListModel> ListOfListObjsForCombobox { get; set; } = new ObservableCollection<ListModel>();

        public ObservableCollection<SectionModel> ListOfSectionsForCombobox { get; set; } = new ObservableCollection<SectionModel>();

        public ListModel SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                ChangeChosenList(_selectedList.Id);
            }
        }

        public SectionModel SelectedSection
        {
            get { return _selectedSection; }
            set
            {
                _selectedSection = value;
                ChangeChosenSection(_selectedList.Id);
            }
        }

        public ICommand ChangeListCommand { get; set; }

        public SelectionBarViewModel(IDataService<ListModel> simpleListModelsService, IDataService<SectionModel> sectionModelsService, INavigator navigator, IChosenIndexesStore chosenIndexesStore)
        {
            _navigator = navigator;
            _simpleListModelsService = simpleListModelsService;
            _chosenIndexesStore = chosenIndexesStore;
            _sectionModelsService = sectionModelsService;
            _navigator.ScreenExpansionChanged += () => OnPropertyChanged(nameof(PanelSizeIsExpanded));
            ChangeListCommand = new RelayCommandWithParameter((param)=> ChangeChosenList((int)param));
            GetLists();
        }

        private async void GetLists()
        {
            ListModel allLists = new ListModel();
            allLists.Id = -1;
            allLists.Name = "All";           
            ListOfListObjsForCombobox = new ObservableCollection<ListModel>(await _simpleListModelsService.GetAll());
            ListOfListObjsForCombobox.Insert(0, allLists);
            SelectedList = ListOfListObjsForCombobox[0];
        }


        private async void GetSections(int listId)
        {
            SectionModel allSectionsModel = new SectionModel();
            allSectionsModel.Id = -1;
            allSectionsModel.Name = "All";
            List<SectionModel>AllSections = new List<SectionModel>(await _sectionModelsService.GetAll());
            ListOfSectionsForCombobox = new ObservableCollection<SectionModel>(AllSections.Where(m => m.ListModelId == listId));
            ListOfSectionsForCombobox.Insert(0, allSectionsModel);
            SelectedSection = ListOfSectionsForCombobox[0];
        }



        private void ChangeChosenList(int modelId)
        {

            //ListOfChosenListSubLists = _listOfSubList[model.Id];
            if (modelId != -1)
            {
                GetSections(modelId);
              //  ListOfSectionsForCombobox = GetSectionViewModels(true, model.Id);

                //  ListOfSectionsTuples = ListOfSectionsForCombobox.Select(section => new Tuple<int, string>(section.Id, section.Name)).ToList();
                //   SelectedSectionTuple = ListOfSectionsTuples[0];

                   ComboboxOfSectionsVisibility = true;
            }
            else
            {
                //  SelectedSectionTuple = new Tuple<int, string>(0, "");
                ComboboxOfSectionsVisibility = false;
            }
          
            if (_chosenIndexesStore != null)
            {
                _chosenIndexesStore.ChosenListId = modelId;
            }


            ///if (_action!=null)
            //   _action.Invoke();
        }

        private void ChangeChosenSection(int modelId)
        {
        }


    }
}


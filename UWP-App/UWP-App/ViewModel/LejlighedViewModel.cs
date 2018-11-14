using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using UWP_App.Common;
using UWP_App.Model;
using UWP_App.Persistency;

namespace UWP_App.ViewModel
{
    public class LejlighedViewModel : ObservableBase
    {
        private ObservableCollection<StatusRapportBase> _statusRapporter;
        private bool _isPaneOpen;
        private int _ikkeGodkendtSelectedIndex;
        private int _godkendtSelectedIndex;
        private string _newRapportNote;
        private StatusValues _newRapportStatus;
        private StatusRapportTypes _newRapportTypes;
        private ICanBeReportedOn _itemToBeRepportedOn;
        private ICommand _createStatusRapportCommand;
        private IEnumerable<StatusValues> _listStatusValue;
        private IEnumerable<StatusRapportTypes> _listRapportValues;
        private IEnumerable<ICanBeReportedOn> _rapportItems;
        private StatusRapportBase _selectedStatusRapport;


        public Lejlighed CurrentLejlighed { get; set; }
        public ObservableCollection<StatusRapportBase> GodkendteStatusRapporter { get => new ObservableCollection<StatusRapportBase>(_statusRapporter.Where(x => x.Godkendt)); }
        public ObservableCollection<StatusRapportBase> IkkeGodkendteStatusRapporter { get => new ObservableCollection<StatusRapportBase>(_statusRapporter.Where(x => !x.Godkendt)); }

        #region Properties for making a new report
        public string NewRapportNote
        {
            get => _newRapportNote; 
            set => SetProperty(ref _newRapportNote, value); 
        }
        

        public StatusValues NewRapportStatus
        {
            get { return _newRapportStatus; }
            set { SetProperty(ref _newRapportStatus, value); }
        }

        public StatusRapportTypes NewRapportType
        {
            get => _newRapportTypes;
            set
            {
                SetProperty(ref _newRapportTypes, value);
                StatusRapportTypeChanged(value);
            }
        }
        public ICanBeReportedOn ItemToBeRepportedOn
        {
            get => _itemToBeRepportedOn;
            set => SetProperty(ref _itemToBeRepportedOn, value);
        }
        #endregion

        public StatusRapportBase SelectedStatusRapport
        {
            get => _selectedStatusRapport;
            set => SetProperty(ref _selectedStatusRapport, value);
        }
        public int IkkeGodkendtSelectedIndex
        {
            get => _ikkeGodkendtSelectedIndex;
            set
            {
                SetProperty(ref _ikkeGodkendtSelectedIndex, value);
            }
        }
        public int GodkendtSelectedIndex
        {
            get => _godkendtSelectedIndex;
            set
            {
                SetProperty(ref _godkendtSelectedIndex, value);
            } 
        }
        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => SetProperty(ref _isPaneOpen, value);
        }

        #region Properties for combobox's
        // Create a list based on the values in an enum type
        public IEnumerable<StatusValues> ListStatusValues { get => _listStatusValue = _listStatusValue ?? Enum.GetValues(typeof(StatusValues)).Cast<StatusValues>(); }
        public IEnumerable<StatusRapportTypes> ListRapportTypes { get => _listRapportValues = _listRapportValues ?? Enum.GetValues(typeof(StatusRapportTypes)).Cast<StatusRapportTypes>(); }

        public IEnumerable<ICanBeReportedOn> RapportItems
        {
            get => _rapportItems;
            private set => SetProperty(ref _rapportItems, value);

        }
        #endregion
        
        public ICommand CreateStatusRapportCommand { get => _createStatusRapportCommand = _createStatusRapportCommand ?? new RelayCommand(CreateStatusRapport); }


        public LejlighedViewModel()
        {
            //DB-IMP : Change to real persistency object when implemented
            IRetrievePersistency persistency = new TempTestData();

            //Move to a class that handels all user loading/data fetching from db

            // Only selectes first lejlighed even if user owns more that one
            //TODO : Let the user select which lejlighed they want to view
            CurrentLejlighed = CurrentUser.User.Lejligheder.FirstOrDefault();

            _statusRapporter = new ObservableCollection<StatusRapportBase>(persistency.GetLejlighedsStatusRapporter(CurrentLejlighed));
            CurrentLejlighed.Faldstammer = persistency.GetLejlighedsFaldstammer(CurrentLejlighed);
            CurrentLejlighed.Vinduer = persistency.GetLejlighedsVinduer(CurrentLejlighed);

            _ikkeGodkendtSelectedIndex = -1;
            _godkendtSelectedIndex = -1;
        }

        private async void CreateStatusRapport()
        {
            IsPaneOpen = false;
            //TODO : make async handler method and call await on it
            throw new NotImplementedException("Move to a hander class");
            // Last update _statusRapporter
        }


        private void StatusRapportTypeChanged(StatusRapportTypes value)
        {
            switch (value)
            {
                case StatusRapportTypes.Faldstamme:
                    RapportItems = CurrentLejlighed.Faldstammer;
                    break;
                case StatusRapportTypes.Vindue:
                    RapportItems = CurrentLejlighed.Vinduer;
                    break;
            }
        }
    }
}
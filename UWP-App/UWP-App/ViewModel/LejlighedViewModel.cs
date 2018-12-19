using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using UWP_App.Common;
using UWP_App.Handler;
using UWP_App.Model;

namespace UWP_App.ViewModel
{
    public class LejlighedViewModel : ObservableBase
    {
        private IEnumerable<StatusRapportBase> _statusRapporter;
        private bool _isPaneOpen;
        private string _newRapportNote;
        private StatusValues _newRapportStatus;
        private StatusRapportTypes _newRapportTypes;
        private ICanBeReportedOn _itemToBeRepportedOn;
        private ICommand _createStatusRapportCommand;
        private IEnumerable<StatusValues> _listStatusValue;
        private IEnumerable<StatusRapportTypes> _listRapportValues;
        private IEnumerable<ICanBeReportedOn> _rapportItems;
        private StatusRapportBase _selectedStatusRapport;
        private StatusRapportHandler _rapportHandler;

        public Lejlighed CurrentLejlighed { get; set; }

        public IEnumerable<StatusRapportBase> GodkendteStatusRapporter
        {
            get
            {
                return _statusRapporter.Where(x => x.Godkendt);
            }
        }
        public IEnumerable<StatusRapportBase> IkkeGodkendteStatusRapporter
        {
            get
            {
                return _statusRapporter.Where(x => !x.Godkendt);
            }
        }

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
            // Only selectes first lejlighed even if user owns more that one
            //TODO : Let the user select which lejlighed they want to view
            CurrentLejlighed = CurrentUser.User.Lejligheder.FirstOrDefault();

            //DB-IMP : Move away from ViewModel
            _rapportHandler = new StatusRapportHandler();

            SetStatusRapporter(_rapportHandler.GetLejlighedsRapporter(CurrentLejlighed));
        }
        

        private async void CreateStatusRapport()
        {
            await _rapportHandler.CreateRapportAsync(NewRapportNote, NewRapportStatus, 
                NewRapportType, ItemToBeRepportedOn);

            IsPaneOpen = false;
            //TODO : Make async
            SetStatusRapporter(_rapportHandler.GetLejlighedsRapporter(CurrentLejlighed));
        }

        private void SetStatusRapporter(IEnumerable<StatusRapportBase> statusRapporter)
        {
            _statusRapporter = statusRapporter;
            OnPropertyChanged("GodkendteStatusRapporter");
            OnPropertyChanged("IkkeGodkendteStatusRapporter");
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
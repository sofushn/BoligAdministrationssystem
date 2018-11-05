using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAppWindows.Helpers;
using MainAppWindows.Models;
using MainAppWindows.Views;
using MainAppWindows.Handler;
using System.Windows.Input;

namespace MainAppWindows.ViewModels
{
    public class StatusRaportViewModel : Observable
    {
        #region Properties

        private StatusRaportTypes _currentType;
        public StatusRaportTypes CurrentType
        {
            get { return _currentType; }
            set
            {
                _currentType = value;
                OnPropertyChanged("CurrentType");
                TypeChanged();
            }
        }

        private StatusValues _currentValues;
        public StatusValues CurrentStatus
        {
            get { return _currentValues; }
            set
            {
                _currentValues = value;
                OnPropertyChanged("CurrentStatus");
            }
        }

        private string _currentNote;
        public string CurrentNote
        {
            get { return _currentNote; }
            set { Set(ref _currentNote, value); }
        }

        private int _faldstammeID;
        public int FaldstammeID
        {
            get { return _faldstammeID; }
            set { Set(ref _faldstammeID, value); }
        }
        private int _faldstammeDelID;
        public int FaldstammeDelID
        {
            get { return _faldstammeDelID; }
            set { Set(ref _faldstammeDelID, value); }
        }

        private int _vindueID;
        public int VindueID
        {
            get { return _vindueID; }
            set { _vindueID = value; }
        }
        

        #region Id fields visibility

        private bool _isFIDVisible;
        public bool IsFIDVisible
        {
            get { return _isFIDVisible; }
            set { Set(ref _isFIDVisible, value); }
        }

        private bool _isVIDVisible;
        public bool IsVIDVisible
        {
            get { return _isVIDVisible; }
            set { Set(ref _isVIDVisible, value); }
        }
        #endregion

        // Create a list based on the values in an enum type
        public IEnumerable<StatusValues> StatusValues
        {
            get
            {
                return Enum.GetValues(typeof(StatusValues)).Cast<StatusValues>();
            }
        }
        public IEnumerable<StatusRaportTypes> RaportTypes
        {
            get
            {
                return Enum.GetValues(typeof(StatusRaportTypes)).Cast<StatusRaportTypes>();
            }
        }

        // ICommand
        private ICommand _createStatusRaportCommand;
        public ICommand CreateStatusRaportCommand
        {
            get
            {
                if (_createStatusRaportCommand == null)
                {
                    _createStatusRaportCommand = new RelayCommand(CreateStatusRaport);
                }

                return _createStatusRaportCommand;
            }
        }
        #endregion Properties

        // Constructor
        public StatusRaportViewModel() { }

        #region Methods

        // Change which id fields is vilible in the UI based on the current Type
        private void TypeChanged()
        {
            IsFIDVisible = false;
            IsVIDVisible = false;

            switch (_currentType)
            {
                case StatusRaportTypes.Faldstamme:
                    IsFIDVisible = true;
                    break;
                case StatusRaportTypes.Vindue:
                    //TODO new StatusRaportVindue
                    IsVIDVisible = true;
                    break;
            }
        }

        // Create a variable based on the ReportType and then call CreateStatusRaport in the StatusRaportHandler
        private void CreateStatusRaport()
        {
            StatusRaport sr = new StatusRaport();

            switch (_currentType)
            { 
                case StatusRaportTypes.Faldstamme:
                {
                    StatusRaportFaldstamme fr = new StatusRaportFaldstamme();

                    fr.Faldstamme_ID = FaldstammeID;
                    fr.FaldstammeDel_ID = FaldstammeDelID;

                    sr = fr;
                    break;
                }
                case StatusRaportTypes.Vindue:
                {
                    throw new NotImplementedException();
                    //break;
                }
            }
            sr.RaportType = CurrentType;
            sr.Status = CurrentStatus;
            sr.Note = CurrentNote;

            StatusRaportHandler.CreateStatusRaport(sr);
            Navigate<LejlighedPage>();
        }
        #endregion
    }

}

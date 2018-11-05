using System;

using MainAppWindows.Helpers;
using MainAppWindows.Views;
using MainAppWindows.Models;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using MainAppWindows.Handler;

namespace MainAppWindows.ViewModels
{
    public class LejlighedViewModel : Observable
    {
        private Lejlighed _lejlighedData;
        public Lejlighed LejlighedData
        {
            get { return _lejlighedData; }
            set { Set(ref _lejlighedData, value); }
        }

        //TODO Convert statusRaport to specific type -- and show ID //Should only be done after PersistencyFacade.GetFaldstammeRaports() has been rewriten 
        private ObservableCollection<StatusRaport> _lejlighedsSR;
        public ObservableCollection<StatusRaport> LejlighedsStatusRaporter
        {
            get
            {
                if(_lejlighedsSR == null)
                {
                    _lejlighedsSR = new ObservableCollection<StatusRaport>(StatusRaportHandler.GetLejlighedsSR(this));
                }
                return _lejlighedsSR;
            }
            set { _lejlighedsSR = value; }
        }
        public int SelectedListViewIndex { get; set; } = -1;

        //ICommand
        private ICommand _navToStatusIndPageCommand;
        public ICommand NavToStatusIndPageCommand
        {
            get
            {
                if (_navToStatusIndPageCommand == null)
                    _navToStatusIndPageCommand = new RelayCommand(Navigate<StatusIndberetningPage>);

                return _navToStatusIndPageCommand;
            }
        }

        //Constructor
        public LejlighedViewModel()
        {
            //TODO Implement support for multiple lejligheder
            //If the andelshaver has more than one lejlighed then it should be possible to select which lejlighed they want to administrate.
            LejlighedData = CurrentUser.CurrentAndelshaver.Lejligheder.FirstOrDefault();
        }

    }
}

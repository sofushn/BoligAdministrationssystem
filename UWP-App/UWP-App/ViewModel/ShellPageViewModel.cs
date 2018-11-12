using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using UWP_App.Common;
using Microsoft.Xaml.Interactivity;
using UWP_App.View;

namespace UWP_App.ViewModel
{
    public class ShellPageViewModel : ObservableBase
    {
        private NavigationViewItem _selectedNavigationViewItem;

        public ObservableCollection<NavigationViewItemBase> PrimaryItems { get; set; }
        public NavigationViewItem SelectedNavigationViewItem
        {
            get => _selectedNavigationViewItem;
            set => SetProperty(ref _selectedNavigationViewItem, value);
        }

        public ICommand NavigationCommand { get => new RelayCommand<NavigationViewSelectionChangedEventArgs>(Navigate); }
        public ICommand LoadedCommand { get => new RelayCommand(NaviagtionViewLoaded); }
        public ICommand GoBackCommand { get => new RelayCommand(BackRequested); }

        public ShellPageViewModel()
        {
            PrimaryItems = new ObservableCollection<NavigationViewItemBase>();
            PopulateNavigationMenu();
        }


        /// <summary>
        /// Populates the navigation menu (PrimaryItems)
        /// </summary>
        private void PopulateNavigationMenu()
        {
            // creates a NavigationLink
            // implicit converts it to a NavigationViewItem
            // adds the item to the PrimaryItems list
            PrimaryItems.Add(new NavigationLink<MainPage>("Main Page", Symbol.Home));

            // adds a seperator between the MainPage and the header
            PrimaryItems.Add(new NavigationViewItemSeparator());
            // adds a NavigationViewHeader with som string content to the PrimaryItems list
            PrimaryItems.Add(new NavigationViewItemHeader() { Content = "Other Pages" });

            PrimaryItems.Add(new NavigationLink<LejlighedPage>("Lejlighed", Symbol.Home));
            PrimaryItems.Add(new NavigationLink<TempTestPage>("Temp Test Page", Symbol.Pictures));

        }

        /// <summary>
        /// Is called when NavigationView invokes its Loaded event (when the NavigationView is fully loaded)
        /// </summary>
        private void NaviagtionViewLoaded()
        {
            // Set the selected page to the first NavigationViewItem in PrimaryItems
            // This invokes the Selection changed event in the NavigationView which runs the NavigationCommand
            SelectedNavigationViewItem = (NavigationViewItem)PrimaryItems.FirstOrDefault(x => x.GetType() == typeof(NavigationViewItem));
        }

        private void Navigate(NavigationViewSelectionChangedEventArgs args)
        {
            // Check if the args is from the settings button
            if (args.IsSettingsSelected)
            {
                throw new NotImplementedException("Feature not implemented!");
            }
            // Checks if the selected item is a NavigationViewItem
            // If true convert the selected item to a NavigationViewItem
            //      then converts the NavigationViewItems's tag property to a type and navigates to the page of that type
            if (args.SelectedItem is NavigationViewItem navI)
                NavigationService.Navigate(navI.Tag as Type);
        }

        /// <summary>
        /// Is called when the BackRequested event in NavigationView is invoked
        /// </summary>
        private void BackRequested()
        {
            // Navigates one page back
            NavigationService.GoBack();
            // Gets type of current content in Frame
            Type t = NavigationService.Frame.Content.GetType();
            // Sets the selected navigation view item to the corosponding value from the PrimaryItem list
            SelectedNavigationViewItem = PrimaryItems.FirstOrDefault(x => (Type)x.Tag == t) as NavigationViewItem;
        }
    }


    /// <summary>
    /// A class which contains a page, lable and symbol
    /// It is a light version of NavigationViewItem
    /// </summary>
    /// <typeparam name="T">The page type the NavigationLink points to</typeparam>
    public class NavigationLink<T>
    {
        public string Lable { get; set; }
        public Type Page { get; set; }
        public Symbol Symbol { get; set; }

        public NavigationLink(string lable, Symbol symbol)
        {
            Lable = lable;
            Page = typeof(T);
            Symbol = symbol;
        }

        public static implicit operator NavigationViewItem(NavigationLink<T> link)
        {
            return new NavigationViewItem()
            {
                Icon = new SymbolIcon(link.Symbol),
                Content = link.Lable,
                Tag = link.Page
            };
        }

        public static explicit operator NavigationLink<T>(NavigationViewItem item)
        {
            try
            {
                return new NavigationLink<T>(item.Content.ToString(), ((SymbolIcon) item.Icon).Symbol);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public override string ToString()
        {
            return $"[Label: {Lable}; Page: {Page.Name}; Symbol: {Symbol}]";
        }
    }
}

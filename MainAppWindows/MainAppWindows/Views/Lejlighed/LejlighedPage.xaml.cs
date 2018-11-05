using MainAppWindows.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MainAppWindows.Views
{
    public sealed partial class LejlighedPage : Page
    {
        public LejlighedViewModel ViewModel { get; } = new LejlighedViewModel();
        public LejlighedPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}

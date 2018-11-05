using MainAppWindows.ViewModels;

using Windows.UI.Xaml.Controls;

namespace MainAppWindows.Views
{
    public sealed partial class AndelshaverPage : Page
    {
        public AndelshaverViewModel ViewModel { get; } = new AndelshaverViewModel();
        public AndelshaverPage()
        {
            InitializeComponent();
        }
    }
}

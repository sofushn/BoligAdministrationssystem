using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWP_App.Common;
using UWP_App.Model;
using UWP_App.Persistency;
using UWP_App.View;

namespace UWP_App
{
    internal class ActivationService
    {
        private readonly App _app;
        private readonly UIElement _shell;
        private readonly Type _defaultNavItem;

        /// <summary>
        /// Run as the first thing in the app if PrelaunchActivated == false
        /// </summary>
        /// <param name="app">This apps App.xaml.cs</param>
        /// <param name="defaultNavItem">The first page the app navigates to.</param>
        /// <param name="shell">The navigation shell that contains the NavigationView. If null creates a new frame.
        /// </param>
        public ActivationService(App app, Type defaultNavItem, UIElement shell = null)
        {
            _app = app;
            _shell = shell ?? new Frame();
            _defaultNavItem = defaultNavItem;
        }

        public async Task ActivateAsync(LaunchActivatedEventArgs activationArgs)
        {
            // Initialize things like registering background task before the app is loaded
            await InitializeAsync();

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (Window.Current.Content == null)
            {
                // Place the frame in the current Window
                Window.Current.Content = _shell;

                NavigationService.Frame.NavigationFailed += (sender, e) =>
                {
                    throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
                };
            }

            // Ensure the current window is active
            Window.Current.Activate();

            // Tasks after activation
            await StartupAsync();
        }

        // Startup
        // Everything that needs to be loaded after the app has started
        private async Task StartupAsync()
        {
            //TODO : Make it possible to login or change user
            if (!CurrentUser.IsInitialized)
            {
                // always login as andelshaver with ID == 0
                //DB-IMP : change TempTestData to real persistency facade when implemented
                CurrentUser.Initialize(0, new TempTestData());
            }

            await Task.CompletedTask;
        }

        // Initialize
        // Anything that needs to be done before anything else.
        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }
}
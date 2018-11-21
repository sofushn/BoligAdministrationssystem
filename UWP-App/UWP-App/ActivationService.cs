using System;
using System.Net.Sockets;
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
            // InitializeAsync things like registering background task before the app is loaded
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
            await Task.CompletedTask;
        }

        // InitializeAsync
        // Anything that needs to be done before anything else.
        private async Task InitializeAsync()
        {
            //TODO : Make it possible to login or change user
            if (!CurrentUser.IsInitialized)
            {
                if (PingHost("localhost", 57121))
                {
                    // always login as andelshaver with ID == 0
                    //DB-IMP : change TempTestData to real persistency facade when implemented
                    await CurrentUser.Initialize(1, new PersistencyFacade());
                }
                // Use local data if server is down
                else
                    await CurrentUser.Initialize(1, new TempTestData());
            }

            await Task.CompletedTask;
        }
        
        public static bool PingHost(string hostUri, int portNumber)
        {
            try
            {
                var client = new TcpClient(hostUri, portNumber);
                return true;
            }
            catch (SocketException ex)
            {
                //MessageBox.Show("Error pinging host:'" + hostUri + ":" + portNumber.ToString() + "'");
                return false;
            }
        }
    }
}
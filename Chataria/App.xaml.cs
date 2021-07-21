using Chataria.Core;
using Chataria.Core.Logging;
using Chataria.Relational;
using Dna;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Chataria
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs
            base.OnStartup(e);

            // Setup the main application
            await ApplicationSetupAsync();

            // Log it
            IoC.Logger.Log("Application starting up...", LogLevel.Debug);

            // Setup the application view model based on if we are logged in
            IoC.Application.GoToPage(await IoC.ClientDataStore.HasCredentials() ? ApplicationPage.Main : ApplicationPage.Login);

            // Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready to use
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                .UseClientDataStore()
                .Build();
            //new DefaultFrameworkConstruction()
            //    .AddFileLogger()
            //    .UseClientDataStore()
            //    .Build();

            // Setup IoC
            IoC.Setup();

            // Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[] 
            { 
                // TODO: Add ApplicationSettings so we can set/edit a log location
                // For now just log to the path where this application is running
                new Core.FileLogger("log.txt"),
            }));

            // Bind a task manager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            // Bind a file manager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            // Bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            // Ensure the client data store exists
            await IoC.ClientDataStore.EnsureDataStoreAsync();

            // Load new settings
            await IoC.Profile.LoadAsync();
        }

    }

    public class SettingsDataModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}

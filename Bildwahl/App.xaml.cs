using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using Bildwahl.ViewModel;
using System;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;


namespace Bildwahl
{
    public partial class App : Application
    {
        static App()
        {
            // This code is used to test the app when using other cultures.
            //
            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //    System.Threading.Thread.CurrentThread.CurrentUICulture =
            //        new System.Globalization.CultureInfo("it-IT");


            // Ensure the current culture passed into bindings is the OS culture.
            // By default, WPF uses en-US as the culture, regardless of the system settings.
            //
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
        private Host _host;
        private WpfInteractorAgent _wpfInteractorAgent;

        protected override void OnStartup(StartupEventArgs e)
        {
            _host = new Host();
            _wpfInteractorAgent = _host.InitializeWpfAgent();
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            // Create the ViewModel to which 
            // the main window binds.
            string path = "Data/standard.xml";
            var viewModel = new MainWindowViewModel(path);

            // When the ViewModel asks to be closed, 
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                viewModel.RequestClose -= handler;
                window.Close();
            };
            viewModel.RequestClose += handler;

            // Allow all controls in the window to 
            // bind to the ViewModel by setting the 
            // DataContext, which propagates down 
            // the element tree.
            window.DataContext = viewModel;

            window.Show();

        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
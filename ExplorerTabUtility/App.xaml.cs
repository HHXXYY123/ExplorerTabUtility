using System.Threading;
using System.Windows;

namespace ExplorerTabUtility
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Mutex _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            
            _mutex = new Mutex(true, "ExplorerTabUtility", out var createdNew);

            if (!createdNew)
            {
                Current.Shutdown();
                return;
            }

            base.OnStartup(e);
            _ = new UI.Views.MainWindow();
        }
    }
}
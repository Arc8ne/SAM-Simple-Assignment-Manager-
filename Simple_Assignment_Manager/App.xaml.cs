using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Simple_Assignment_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException += on_app_domain_current_domain_unhandled_exception;

            Application.Current.DispatcherUnhandledException += on_application_current_dispatcher_unhandled_exception;

            TaskScheduler.UnobservedTaskException += on_task_scheduler_unobserved_task_exception;

            MainWindow main_window = new MainWindow();

            main_window.Show();
        }

        private void on_app_domain_current_domain_unhandled_exception(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Error: An AppDomain.CurrentDomain.UnhandledException has been thrown.\nException object details: {e.ExceptionObject}");
        }

        private void on_application_current_dispatcher_unhandled_exception(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Error: An Application.Current.DispatcherUnhandledException has been thrown.\nException details: {e.Exception}");
        }

        private void on_task_scheduler_unobserved_task_exception(object sender, UnobservedTaskExceptionEventArgs e)
        {
            MessageBox.Show($"Error: A TaskScheduler.UnobservedTaskException has been thrown.\nException details: {e.Exception}");
        }
    }
}

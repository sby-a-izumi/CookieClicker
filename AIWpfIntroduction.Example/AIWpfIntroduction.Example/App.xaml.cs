using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AIWpfIntroduction.Example
{
    using System.Windows;
    using AIWpfIntroduction.Example.ViewModels;
    using AIWpfIntroduction.Example.Views;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var w = new MainView();

            var vm = new MainViewModel();

            w.DataContext = vm;

            w.Show();
        }
    }
}

using Reptile_Tools.Views.Pages;
using System.Collections.Generic;
using System.Windows;
using Wpf.Ui.Appearance;


namespace Reptile_Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = this;

            SystemThemeWatcher.Watch(this);
            //CurlToRequests("");
            InitializeComponent();
            Loaded += (_, _) => RootNavigation.Navigate(typeof(CurlToRequestsPage)); ;
        }
    }
}

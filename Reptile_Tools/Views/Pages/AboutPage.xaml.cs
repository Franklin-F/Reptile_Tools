using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;

namespace Reptile_Tools.Views.Pages
{
    /// <summary>
    /// AboutPage.xaml 的交互逻辑
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();

            if (ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark)
            {
                DarkThemeRadioButton.IsChecked = true;
            }
            else
            {
                LightThemeRadioButton.IsChecked = true;
            }
        }

        private void OnLightThemeRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.Apply(ApplicationTheme.Light);
        }

        private void OnDarkThemeRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            ApplicationThemeManager.Apply(ApplicationTheme.Dark);
        }
    }
}

using Reptile_Tools.ViewModels;
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

namespace Reptile_Tools.Views.Pages
{
    /// <summary>
    /// DataPage.xaml 的交互逻辑
    /// </summary>
    public partial class CurlToRequestsPage : Page
    {

        public CurlToRequestsPage()
        {
            InitializeComponent();
            this.DataContext = new MVVMCurlToRequestsViewModel();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var viewmodels = DataContext as MVVMCurlToRequestsViewModel;
            if (viewmodels != null)
            {
                viewmodels.Textboxmaxheight = ((ActualHeight - 48) / 19 * 9) + 10;
            }
        }
    }
}

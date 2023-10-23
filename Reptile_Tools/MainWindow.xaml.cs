using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Reptile_Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //CurlToRequests("");
            InitializeComponent();
        }
        public List<object> CurlToRequests(string curlstr)
        {
            //PythonCodeTextbox.Text = curlstr;
            List<object> Array_data = new List<object> { };
            CurlProcess curldata = new CurlProcess(curlstr);
            PythonCodeTextbox.Text +=("url:\r\n");
            PythonCodeTextbox.Text +=(curldata.url + "\r\n");
            PythonCodeTextbox.Text += ("headers:\r\n");
            Dictionary<string, string> header = curldata.headers;
            PythonCodeTextbox.Text += "{\r\n";
            foreach (var item in header)
            {
                PythonCodeTextbox.Text += $"    \"{item.Key}\": \"{item.Value}\",\r\n";
            }
            PythonCodeTextbox.Text += "}\r\n";
            return Array_data;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurlToRequests("curl 'https://next.platform.mediastre.am/graphql' \\\r\n  -H 'authority: next.platform.mediastre.am' \\\r\n  -H 'accept: */*' \\\r\n  -H 'accept-language: zh-CN,zh;q=0.9' \\\r\n  -H 'authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDA2MTcwNjUsImRhdGEiOnsiY3VzdG9tZXIiOnsiX2lkIjoiNjUzMzljNzg2OWFhY2IwOGI2MDViMGRiIiwiZmlyc3RfbmFtZSI6ImF1c3RpbiIsImxhc3RfbmFtZSI6InBlYWtpbnMiLCJlbWFpbCI6ImFydGh1cmx1Y2Fzc2E0M0BnbWFpbC5jb20iLCJzb2NpYWwiOmZhbHNlLCJwcm9maWxlSWQiOiI2NTMzOWM3OWNjMjI1NDY5ODlkMGUzNmEifSwic2Vzc2lvbiI6eyJpZCI6IjY1MzVjZTY5ZWU4MjBmMzc4MzI2YTJmZSIsInNlc3Npb25JZCI6IjY1MzVjZTY5ZWU4MjBmMzc4MzI2YTJmZSIsInRva2VuIjoicHdyRVdPYVRWUnFlVTUzVVpoY2FqcHc5cW01STVwaWhmR1ZseFJNU3ZlZkhQR3Fxc2NocldLUmp1dGIyc09qV3RmdmFhczVEb21ZMTY5ODAyNTA2NTQ3OCIsInNlc3Npb25FeHBpcmUiOiIyMDIzLTExLTIyVDAxOjM3OjQ1LjQ3OFoifX0sImlhdCI6MTY5ODAyNTA2NX0.75OYUpjvAR9RRVkawyCyOH3Saj4xDLdRr4lg-nXs46E' \\\r\n  -H 'cache-control: no-cache' \\\r\n  -H 'content-type: application/json' \\\r\n  -H 'origin: https://play.goltv.tv' \\\r\n  -H 'pragma: no-cache' \\\r\n  -H 'referer: https://play.goltv.tv/' \\\r\n  -H 'sec-ch-ua: \"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\"' \\\r\n  -H 'sec-ch-ua-mobile: ?0' \\\r\n  -H 'sec-ch-ua-platform: \"Windows\"' \\\r\n  -H 'sec-fetch-dest: empty' \\\r\n  -H 'sec-fetch-mode: cors' \\\r\n  -H 'sec-fetch-site: cross-site' \\\r\n  -H 'user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36' \\\r\n  -H 'x-client-id: 6a58cc4f1f65b10878b2e494c6ae513bf9b89385032e7fffa9' \\\r\n  -H 'x-ott-language: es' \\\r\n  -H 'x-profile-id: 65339c79cc22546989d0e36a' \\\r\n  --data-raw '{\"operationName\":\"getSchedulesSportCalendarSlider\",\"variables\":{\"tournament\":\"63977a0dbd7374087421047c\",\"featured\":false,\"current\":false},\"query\":\"query getSchedulesSportCalendarSlider($date: ScheduleDate, $tournament: String, $featured: Boolean) {\\n  getSchedulesSport(filters: {byDate: $date, byTournament: $tournament, byFeatured: $featured}) {\\n    _id\\n    current\\n    date_start\\n    date_end\\n    sellable\\n    match {\\n      matchDay\\n      rival1 {\\n        _id\\n        code\\n        logo\\n        name\\n        __typename\\n      }\\n      rival2 {\\n        _id\\n        code\\n        logo\\n        name\\n        __typename\\n      }\\n      tournament {\\n        _id\\n        name\\n        matchBackground\\n        __typename\\n      }\\n      __typename\\n    }\\n    live {\\n      _id\\n      __typename\\n    }\\n    __typename\\n  }\\n}\\n\"}' \\\r\n  --compressed");

        }
    }
}

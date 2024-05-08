using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMCurlToRequestsViewModel:ObservableObject
    {
        [ObservableProperty]
        public string? _curlstring;
        [ObservableProperty]
        public bool _isimport;
        [ObservableProperty]
        public bool _isproxies;
        public string? _pythoncode;
        public string Pythoncode
        {
            set
            {
                
                if (Pythoncode == "") {
                    CopyButtonEnabled = false;
                }
                else
                {
                    CopyButtonEnabled = true;
                }
                SetProperty(ref _pythoncode, value);
            }
            get
            {
                if(_pythoncode == "")
                {
                    CopyButtonEnabled = false;
                }
                else
                {
                    CopyButtonEnabled = true;
                }
                return _pythoncode;
            }
        }
        public bool _copybuttonenabled;
        public bool CopyButtonEnabled
        {
            get  => _copybuttonenabled;
            set
            {
                SetProperty(ref _copybuttonenabled, value);
                CopyButtonClickCommand.NotifyCanExecuteChanged();
            }
        }
        public RelayCommand CopyButtonClickCommand { get; }
        [RelayCommand]
        public void UpdaterPythonCode()
        {
            Models.CurlProcess curlProcess = new Models.CurlProcess(Curlstring);
            string importcodes = "";
            string codes = "";
            if (Isimport)
            {
                importcodes = "import requests\r\n";
                if (curlProcess.bodycode != null && curlProcess.bodycode.Contains("json.dumps"))
                {
                    importcodes += "import json\r\n";
                }
                importcodes += "\r\n";
            }
            if (Selectedindex==1)
            {
                importcodes += "\tdef get_(self,):\r\n";
            }else if (Selectedindex == 2)
            {
                importcodes+= "def get_():\r\n";
            }
            codes += "\r\n" +curlProcess.urlcode + curlProcess.headercode + curlProcess.cookiecode + curlProcess.bodycode + curlProcess.paramcode;

            codes += $"res = requests.{curlProcess.method}(";
            if (curlProcess.urlcode != "")
            {
                codes += "url=url";
            }
            if (curlProcess.headercode != "")
            {
                codes += ", headers=headers";
            }
            if (curlProcess.cookiecode != "")
            {
                codes += ", cookies=cookies";
            }
            if (curlProcess.bodycode != "")
            {
                codes += ", data=data";
            }
            if (curlProcess.paramcode != "")
            {
                codes += ", params=params";
            }
            if (Isredirect)
            {
                codes += ", allow_redirects=False";
            }
            if (Ishttps)
            {
                codes += ", verify=False";
            }
            if (Isproxies)
            {
                codes += ", proxis={\"http\": \"http://127.0.0.1:7890\", \"https\": \"https://127.0.0.1:7890\"}";
            }
            codes += ")\r\nprint(res.text)\r\n";
            if (Selectedindex == 1)
            {
                codes = codes.Replace("\r\n", "\r\n\t");
                codes = codes.Replace("\r\n\t", "\r\n\t\t");
            }
            else if (Selectedindex == 2)
            {
                codes = codes.Replace("\r\n", "\r\n\t");
            }
            Pythoncode = importcodes + codes.ToString();
        }
        public MVVMCurlToRequestsViewModel()
        {
            CopyButtonClickCommand = new RelayCommand(() =>
            {
                Clipboard.SetText(Pythoncode);
            }, () => CopyButtonEnabled);
        }

        [ObservableProperty]
        public double _textboxmaxheight;
        [ObservableProperty]
        public int _selectedindex = 0;
        [ObservableProperty]
        public bool _isredirect = false;
        [ObservableProperty]
        public bool _ishttps = false;
        [RelayCommand]
        public void Cleared()
        {
            Curlstring = "";
            Pythoncode = "";
        }
    }
}

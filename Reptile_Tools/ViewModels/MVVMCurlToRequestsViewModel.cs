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
            string codes = "";
            if (Isimport)
            {
                codes = "import requests\r\n";
                if (curlProcess.bodycode!=null && curlProcess.bodycode.Contains("json.dumps"))
                {
                    codes += "import json\r\n";
                }
                codes += "\r\n";
            }
            codes += curlProcess.urlcode + curlProcess.headercode + curlProcess.cookiecode + curlProcess.bodycode + curlProcess.paramcode;

            codes += $"res = requests.{curlProcess.method}(";
            if (curlProcess.urlcode != "")
            {
                codes+= "url=url";
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
            if (Isproxies)
            {
                codes += ", proxis={\"http\": \"http://127.0.0.1:7890\", \"https\": \"https://127.0.0.1:7890\"}";
            }
            codes += ")\r\nprint(res.text)\r\n";
            Pythoncode = codes.ToString();

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
    }
}

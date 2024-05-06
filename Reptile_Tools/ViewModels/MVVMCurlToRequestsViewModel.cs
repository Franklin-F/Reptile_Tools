﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMCurlToRequestsViewModel:ObservableObject
    {
        public string? _curlstring;
        public string Curlstring
        {
            set 
            {
                SetProperty(ref _curlstring, value);
                Pythoncode = _curlstring;
            }
            get
            {
                if (_curlstring == null) { _curlstring = "请输入Bash格式的Curl...\r\n"; }
                return _curlstring;
            }
        }
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
            //MessageBox.Show(curlProcess.url);
            //foreach (KeyValuePair<string,string> item in curlProcess.headers)
            //{
            //    MessageBox.Show(item.Key + ":" + item.Value);
            //}
            string cookies = "{\r\n";
            int flag = 0;
            foreach (KeyValuePair<string,string> i in curlProcess.cookies)
            {
                string a = "\"";
                if (flag != 0)
                {
                    a = ",\r\n\"";
                }
                cookies += a + i.Key  + "\"" + ": \"" + i.Value +"\"";
                flag++;
            }
            cookies += "\r\n}";
            Pythoncode = cookies;

        }
        public MVVMCurlToRequestsViewModel()
        {
            CopyButtonClickCommand = new RelayCommand(() => {
                Clipboard.SetText(Pythoncode);
            }, () => CopyButtonEnabled);
        }

    }
}

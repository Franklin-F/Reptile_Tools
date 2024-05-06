using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.ViewModels
{
    public class MVVMCurlToRequestsViewModel:ObservableObject
    {
        public string? _curlstring;
        public string CurlString
        {
            set 
            {
                _curlstring = value;
                OnPropertyChanged();  
            }
            get { return _curlstring; }
        }
        public string? _pythoncode;
        public string PythonCode
        {
            set
            {
                _pythoncode = _curlstring;
                OnPropertyChanged();
            }
            get { return _curlstring; }
        }

    }
}

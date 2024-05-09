using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMHeaderToolsPageViewModel: ObservableObject
    {
        [ObservableProperty]
        public double _textboxmaxheight;
        [ObservableProperty]
        public string? _headerstring;
        [ObservableProperty]
        public string? _dictstring;
        [RelayCommand]
        public void Cleared()
        {
            Headerstring = "";
            Dictstring = "";
        }
        [RelayCommand]
        public void UpdaterDict()
        {
            if (Headerstring == null || Headerstring.Trim() == "")
            {
                Dictstring = "";
                return;
            }
            var headers = Headerstring.Split('\n');
            var dict = new Dictionary<string, string>();
            foreach (var header in headers)
            {
                var headerkv = header.Split(':');
                if (headerkv.Length == 2)
                {
                    dict.Add(headerkv[0].Trim(), headerkv[1].Trim());
                }
            }
            Dictstring = "{\n";
            foreach (var kv in dict)
            {
                Dictstring += $"\"{kv.Key}\":\"{kv.Value}\",\n";
            }
            Dictstring = Dictstring.TrimEnd(',', '\n');
            Dictstring += "\n}";
        }
    }
}

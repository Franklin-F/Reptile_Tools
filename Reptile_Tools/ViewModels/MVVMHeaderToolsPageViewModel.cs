using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            var dict = new Dictionary<string, string>();
            Regex regex = new Regex(@"^([\w-]+):\s*(.+)$", RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(Headerstring);
            foreach (Match match in matches)
            {
                dict.Add(match.Groups[1].Value, match.Groups[2].Value.Replace("\r",""));
            }
            
            if (dict.Count < 1)
            {
                Dictstring = "";
                return;
            }
            else
            { 
                string variable = "headers = {\r\n\t";
                int flag = 0;
                foreach (KeyValuePair<string, string> i in dict)
                {
                    string a = "\"";
                    if (flag != 0)
                    {
                        a = ",\r\n\t\"";
                    }
                    variable += a + i.Key.Trim() + "\"" + ": \"" + i.Value.Trim().Replace("\"","\\\"") + "\"";
                    flag++;
                }
                variable += "\r\n}\r\n";
                Dictstring = variable;
            }
            
        }
    }
}

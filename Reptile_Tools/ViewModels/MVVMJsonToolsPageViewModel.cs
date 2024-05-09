using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMJsonToolsPageViewModel:ObservableObject
    {
        [ObservableProperty]
        public double _textboxmaxheight;
        [ObservableProperty]
        public string? _ciphertext;
        [ObservableProperty]
        public string? _plaintext;
        [RelayCommand]
        public void Cleared()
        {
            Ciphertext = "";
            Plaintext = "";
        }
        [RelayCommand]
        public void FormatJson()
        {
            if (Ciphertext == null || Ciphertext.Trim() == "")
            {
                Plaintext = "";
                return;
            }
            try
            {
                Plaintext = Newtonsoft.Json.JsonConvert.SerializeObject(Newtonsoft.Json.JsonConvert.DeserializeObject(Ciphertext), Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {
                Plaintext = "Json格式化失败！检查下json是否合法。";
            }
        }
    }
}

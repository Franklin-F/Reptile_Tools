using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMUrlCodePageViewModel:ObservableObject
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
        public void Encoded()
        {
            if (Ciphertext == null || Ciphertext.Trim() == "")
            {
                Plaintext = "";
                return;
            }
            Plaintext = "完全转义：\r\n" + Models.UrlCodeTools.SecurityUrlEncode(Ciphertext) + "\r\n安全转义：\r\n" + Models.UrlCodeTools.UrlEncode(Ciphertext);
        }
        [RelayCommand]
        public void Decoded()
        {
            if (Ciphertext == null || Ciphertext.Trim() == "")
            {
                Plaintext = "";
                return;
            }
            Plaintext = Models.UrlCodeTools.UrlDecode(Ciphertext);
        }
    }
}

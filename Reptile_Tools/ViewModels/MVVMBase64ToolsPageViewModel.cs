using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMBase64ToolsPageViewModel:ObservableObject
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
            Plaintext = Models.Base64Tools.Base64Encode(Ciphertext);
        }
        [RelayCommand]
        public void Decoded()
        {
            if (Ciphertext == null || Ciphertext.Trim() == "")
            {
                Plaintext = "";
                return;
            }
            try
            {
                Plaintext = Models.Base64Tools.Base64Decode(Ciphertext);
            }
            catch (Exception)
            {
                Plaintext = "Base64解码失败！";
            }
        }
    }
}

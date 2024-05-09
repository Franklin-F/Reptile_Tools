using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMMD5ToolsPageViewModel:ObservableObject
    {
        [ObservableProperty]
        public double _textboxmaxheight;
        [ObservableProperty]
        public string? _ciphertext;
        [ObservableProperty]
        public string? _plaintext = "MD5解密是不可解的，想解去找彩虹表，算法解不了。。。";
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
            Plaintext = Models.MD5Tools.MD5Encrypt(Ciphertext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.Models
{
    public class MD5Tools
    {
        public static string MD5Encrypt(string str)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str_md5 = "";
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str_md5 += md5data[i].ToString("x").PadLeft(2, '0');
            }
            return str_md5;
        }
    }
}

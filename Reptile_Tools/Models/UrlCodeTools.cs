using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Reptile_Tools.Models
{
    public class UrlCodeTools
    {
        public static string UrlEncode(string str)
        {
            return Uri.EscapeUriString(str);
        }
        public static string UrlDecode(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }
        public static string SecurityUrlEncode(string str)
        {
            return Uri.EscapeDataString(str);
        }
    }
}
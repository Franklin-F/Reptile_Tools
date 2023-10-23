using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reptile_Tools
{
    internal class CurlProcess
    {
        public string restring;
        public readonly string url;
        public readonly Dictionary<string, string> headers;
        public readonly Dictionary<string, object> body;
        public readonly Dictionary<string, string> cookies;
        public readonly Dictionary<string, string> param;
        public CurlProcess(string restring)
        {
            this.restring = restring;
            this.url = this.CurlToUrl(this.restring);
            this.headers = this.CurlToHeaders(this.restring);

        }

        public string CurlToUrl(string restring)
        {
            string url;
            string pattern = @"'(https://[^']*)'";
            Match match = Regex.Match(restring, pattern);
            url = match.Groups[1].Value;
            return url;
        }
        public Dictionary<string, string> CurlToHeaders(string restring)
        {
            Dictionary<string,string> headers = new Dictionary<string,string>();
            string pattern = @"-H '(?<name>[\w-]+): (?<value>[^']+)'";
            MatchCollection matches = Regex.Matches(restring, pattern);
            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string value = match.Groups["value"].Value;
                if (value.Contains("\"")) { value = value.Replace("\"", "\\\"");}
                headers[name] = value;
            }
            return headers;
        }
        public Dictionary<string,string> CurlTobody(string restring)
        {
            Dictionary<string, string> body = new Dictionary<string, string>();
            string pattern = "--data-raw '(.*?)'";
            Match match = Regex.Match(restring, pattern);
            if (match.Success && match.Groups.Count > 1)
            {
                string dataRawContent = match.Groups[1].Value;

                // 将data-raw内容解析为字典
                body = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataRawContent);
            }

            return body;
        }
    }
}

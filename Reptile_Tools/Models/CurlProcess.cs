using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reptile_Tools.Models
{
    internal class CurlProcess
    {
        public string restring;
        public readonly string url;
        public readonly Dictionary<string, string> headers;
        public readonly Dictionary<string, object?> body;
        public readonly Dictionary<string, string>? cookies;
        public readonly Dictionary<string, string> param;
        public CurlProcess(string restring)
        {
            this.restring = restring;
            url = CurlToUrl(this.restring);
            headers = CurlToHeaders(this.restring);
            //body = CurlTobody(this.restring);
            param = CurlToParams(restring); 
            cookies = HeaderToCookies(headers);

        }

        public string CurlToUrl(string restring)
        {
            string url;
            string pattern = @"'(?<url>https?://[^']*)'";
            Match match = Regex.Match(restring, pattern);
            url = match.Groups["url"].Value;
            return url;
        }
        public Dictionary<string, string> CurlToHeaders(string restring)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            string pattern = @"-H '(?<name>[\w-]+): (?<value>[^']+)'";
            MatchCollection matches = Regex.Matches(restring, pattern);
            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string value = match.Groups["value"].Value;
                if (value.Contains("\"")) { value = value.Replace("\"", "\\\""); }
                headers[name] = value;
            }
            return headers;
        }
        public Dictionary<string,string>? HeaderToCookies(Dictionary<string, string> headers)
        {
            if (headers.ContainsKey("cookie"))
            {
                string cookiesString = headers["cookie"];
                if (cookiesString != null || cookiesString != "")
                {
                    headers.Remove("cookie");
                    string pattern = @"(?<key>[^=;]+)=(?<value>[^;]+)";
                    MatchCollection matches = Regex.Matches(cookiesString, pattern);
                    Dictionary<string, string> cookies = new Dictionary<string, string>();
                    foreach (Match match in matches)
                    {
                        string key = match.Groups["key"].Value;
                        string value = match.Groups["value"].Value;
                        cookies.Add(key, value);
                    }
                    return cookies;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public Dictionary<string, object> CurlTobody(string restring)
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            string pattern = "--data-raw '(.*?)'";
            Match match = Regex.Match(restring, pattern);
            if (match.Success && match.Groups.Count > 1)
            {
                string dataRawContent = match.Groups[1].Value;
                body = JsonConvert.DeserializeObject<Dictionary<string, object?>>(dataRawContent);
            }

            return body;
        }
        public Dictionary<string, string> CurlToParams(string restring)
        {
            string paramsPattern = @"(?<=\?|&)(?<key>[^=&]+)=(?<value>[^&']+)";
            MatchCollection paramsMatches = Regex.Matches(restring, paramsPattern);
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            foreach (Match match in paramsMatches)
            {
                string key = match.Groups["key"].Value;
                string value = match.Groups["value"].Value;
                queryParams[key] = value;
            }
            return queryParams;
        }
    }
}

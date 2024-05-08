using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reptile_Tools.Models
{
    internal class CurlProcess
    {
        public string restring;
        public string url;
        public readonly Dictionary<string, string> headers;
        public readonly string body;
        public readonly Dictionary<string, string>? cookies;
        public readonly Dictionary<string, string> param;
        public readonly JObject? jsonobj;
        public string bodytype;

        public readonly string? urlcode;
        public readonly string? headercode;
        public readonly string? cookiecode;
        public readonly string? paramcode;
        public readonly string? bodycode;
        public readonly string? jsoncode;
        public CurlProcess(string restring)
        {
            this.restring = restring;
            url = CurlToUrl(this.restring);
            headers = CurlToHeaders(this.restring);
            body = CurlTobody(this.restring);
            param = UrlToParams(url); 
            cookies = HeaderToCookies(headers);
            jsonobj = CurlToJson(restring);
            var bodytype1 = BodyTypeDetector.Detect(body);
            bodytype = bodytype1.ToString();

            this.urlcode = UrlToCode(url);
            headercode = HeaderToCode(headers);
            cookiecode = CookieToCode(cookies);
            paramcode = ParamToCode(param);
            if (jsonobj != null)
            {jsoncode = jsonobj.ToString();}else { jsoncode = null; }
            bodycode = BodyToCode(body, bodytype);
        }

        public string CurlToUrl(string restring)
        {
            string url;
            string pattern = @"'(?<url>https?://[^']*)'";
            Match match1 = Regex.Match(restring, pattern);
            url = match1.Groups["url"].Value;
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
        public string CurlTobody(string restring)
        {
            string body = "";
            string bodypattern = "--data-raw '(.*?)'";
            Match match = Regex.Match(restring, bodypattern);
            if (match.Success && match.Groups.Count > 1)
            {
                string dataRawContent = match.Groups[1].Value;
                body = dataRawContent ;
            }

            return body;
        }
        public Dictionary<string, string> UrlToParams(string url)
        {
            if (url.Contains("?"))
            {
                string u = "";
                string p = "";
                Match match = Regex.Match(url, @"^(.*?)\?(.*)$");
                u = match.Groups[1].Value;
                p = match.Groups[2].Value;
                this.url = u;
                string paramsPattern = @"(?<=\?|&)(?<key>[^=&]+)=(?<value>[^&']+)";
                MatchCollection matches = Regex.Matches(url, paramsPattern);
                Dictionary<string, string> queryParams = new Dictionary<string, string>();
                foreach (Match item in matches)
                {
                    string key = item.Groups["key"].Value;
                    string value = item.Groups["value"].Value;
                    queryParams[key] = value;
                }
                return queryParams;
            }
            else
            {
                return null;
            }
        }
        public JObject? CurlToJson(string restring)
        {
            string jsonPattern = @"-d '(.*?)'";
            Match match = Regex.Match(restring, jsonPattern);
            if (match.Success && match .Groups.Count > 1)
            {
                string jsonstring = match.Groups[1].Value;
                JObject keyValuePairs = JObject.Parse(jsonstring);
                return keyValuePairs;
            }
            else
            {
                return null;
            }

        }

        public string UrlToCode(string url)
        {
            string variable = $"url = \"{url}\"\r\n";
            return variable;
        }
        public string? HeaderToCode(Dictionary<string, string> headers)
        {
            string variable = "headers = {\r\n\t";
            int flag = 0;
            foreach (KeyValuePair<string, string> i in headers)
            {
                string a = "\"";
                if (flag != 0)
                {
                    a = ",\r\n\t\"";
                }
                variable += a + i.Key.Trim() + "\"" + ": \"" + i.Value.Trim() + "\"";
                flag++;
            }
            variable += "\r\n}\r\n";
            return variable;
        }
        public string? CookieToCode(Dictionary<string, string> cookies)
        {
            if (cookies == null) return "";
            string variable = "cookies = {\r\n\t";
            int flag = 0;
            foreach (KeyValuePair<string, string> i in cookies)
            {
                string a = "\"";
                if (flag != 0)
                {
                    a = ",\r\n\t\"";
                }
                variable += a + i.Key.Trim() + "\"" + ": \"" + i.Value.Trim() + "\"";
                flag++;
            }
            variable += "\r\n}\r\n";
            return variable;
        }
        public string? ParamToCode(Dictionary<string, string> parames)
        {
            if (parames==null || parames.Count < 1) return "";
            string variable = "params = {\r\n\t";
            int flag = 0;
            foreach (KeyValuePair<string, string> i in parames)
            {
                string a = "\"";
                if (flag != 0)
                {
                    a = ",\r\n\t\"";
                }
                variable += a + i.Key.Trim() + "\"" + ": \"" + i.Value.Trim() + "\"";
                flag++;
            }
            variable += "\r\n}\r\n";
            return variable;
        }
        public string BodyToCode(string bodysting, string bodytype)
        {
            if (bodysting == "") return "";
            string variable = "";
            switch (bodytype)
            {
                case "String":
                    variable = $"data = \"{bodysting.ToString()}\".encode('unicode_escape')";
                    break;
                case "JSONObject":
                    variable = $"data = {JObject.Parse(bodysting).ToString()}\r\ndata = json.dumps(data, separators=(',', ':'))\r\n";
                    break;
                case "JSONArray":
                    variable = $"data = {JArray.Parse(bodysting).ToString()}\r\ndata = json.dumps(data, separators=(',', ':'))\r\n";
                    break;
                case "Invalid":
                    variable = "无法解析body,";
                    break;
                case "JSONObjectKV":
                    MatchCollection matches = Regex.Matches(bodysting, @"([^&=]+)=([^&=]+)");

                    // 构建 Dictionary
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (Match match in matches)
                    {
                        string key = match.Groups["key"].Value;
                        string value = Uri.UnescapeDataString(match.Groups[2].Value);
                        dictionary[key] = value;
                    }
                    variable = $"data={JsonConvert.SerializeObject(dictionary)}\r\ndata = json.dumps(data, separators=(',', ':'))\r\n";
                    break;
            }
            return variable;
        }
    }
}

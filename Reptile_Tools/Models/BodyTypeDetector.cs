using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reptile_Tools.Models
{
    public class BodyTypeDetector
    {
        public static BodyType Detect(string bodystring)
        {
            // 尝试解析字符串为 JSON 对象
            try
            {
                JObject jsonObject = JObject.Parse(bodystring);
                return BodyType.JSONObject;
            }
            catch (Exception)
            {
                // 解析失败，说明不是 JSON 对象
                // 尝试解析为 JSON 数组
                try
                {
                    JArray jsonArray = JArray.Parse(bodystring);
                    return BodyType.JSONArray;
                }
                catch (Exception)
                {
                    // 解析失败，说明不是 JSON 数组
                    // 检查是否是普通字符串
                    if (!string.IsNullOrWhiteSpace(bodystring))
                    {
                        MatchCollection matches = Regex.Matches(bodystring, @"([^&=]+)=([^&=]+)");
                        if (matches.Count > 0)
                        {
                            return BodyType.JSONObjectKV;
                        }
                        else
                        {
                            return BodyType.String;
                        }
                    }
                }
            }

            // 如果既不是 JSON 对象，也不是 JSON 数组，也不是普通字符串，则认为是无效数据
            return BodyType.Invalid;
        }
    }
    
}
public enum BodyType
{
    String,
    JSONObject,
    JSONArray,
    Invalid,
    JSONObjectKV
}
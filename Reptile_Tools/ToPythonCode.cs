using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
public static class ToPythonCode
{
	public static string HeaderToString(Dictionary<string, string> header)
	{
        string code = "";
        code = "{\r\n";
        foreach (var item in header)
        {
            code += $"    \"{item.Key}\": \"{item.Value}\",\r\n";
        }
        code += "}\r\n";
        return code;
    }
    public static string BodyToString(Dictionary<string, object> body)
    {
        string code = "data=";
        code = "{\r\n";
        foreach (var item in body)
        {
            string newValue = item.Value.ToString();
            if (newValue.Contains("\n"))
            {
                newValue = Regex.Replace(newValue, @"(?<!\\\r)\\\n", "大傻逼!!!!!!!!!!!!!!!!");
            }
            code += $"    \"{item.Key}\": \"{item.Value}\",\r\n";
        }
        code += "}\r\n";
        return code;
    }
}

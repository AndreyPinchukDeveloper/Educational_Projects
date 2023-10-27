using SupportLibrary;
using System.Net;

var code = "416001653";
var proxy = new WebProxy("127.0.0.1:8888");
var cookieContainer = new CookieContainer();

var postRequest = new PostRequest("https://baucenter.ru/");
postRequest.Data = $"ajax_call=y&INPUT_ID=title-search-input&q={code}&l=2";
postRequest.Accept = "*/*";
postRequest.UserAgent = "";
postRequest.ContentType = "";
postRequest.Referer = "";
postRequest.Host = "";
postRequest.Proxy = proxy;

postRequest.Headers.Add("","");
postRequest.Headers.Add("", "");
postRequest.Headers.Add("", "");
postRequest.Headers.Add("", "");
postRequest.Headers.Add("", "");
postRequest.Headers.Add("", "");

postRequest.Run(cookieContainer);

var stringStart = postRequest.Response.IndexOf("search-result-group search-result-product");
stringStart = postRequest.Response.IndexOf("<a href=", stringStart) +9;

var stringEnd = postRequest.Response.IndexOf("\"", stringStart);
var getPath = postRequest.Response.Substring(stringStart, stringEnd - stringStart);

Console.WriteLine($"getPath={getPath}");
Console.ReadLine();
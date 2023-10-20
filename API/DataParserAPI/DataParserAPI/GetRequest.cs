using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataParserAPI
{
    public class GetRequest
    {
        HttpWebRequest request;
        private string _address;
        public string Response { get; set; }
        public GetRequest(string address)
        {
            _address = address;
        }

        public void Run()
        {
            request = (HttpWebRequest)WebRequest.Create(_address);
            request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}

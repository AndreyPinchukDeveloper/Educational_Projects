using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser2.Models
{
    public class Card
    {
        public string Price { get; set; }
        public string Title { get; set; }

        public void Parse(string html)
        {
            var priceStart = html.IndexOf("Price") + 11;
            var priceEnd = html.IndexOf("<span", priceStart);
            Price = html.Substring(priceStart, priceEnd - priceStart).Trim();

            var titleStart = html.IndexOf("<h1>") + 4;
            var titleEnd = html.IndexOf("</h1>", titleStart);
            Title = html.Substring(titleStart, titleEnd - titleStart).Trim();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_Scraper.Models
{
    internal class Apartment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Link { get; set; }
    }
}

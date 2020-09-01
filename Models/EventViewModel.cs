using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventReactApp.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string KeywordForSearching { get; set; }
        public string Summary { get; set; }
        public string SortOfEvent { get; set; }
        public string CategoryName { get; set; }
    }
}

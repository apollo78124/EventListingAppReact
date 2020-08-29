using System;
using System.Collections.Generic;

namespace EventReactApp.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Events = new HashSet<Events>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EventReactApp.Models
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventKeyword { get; set; }
        public string EventSummary { get; set; }
        public int EventSort { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
    }
}

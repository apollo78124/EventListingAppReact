namespace EventReactApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [Required]
        [StringLength(50)]
        public string EventKeyword { get; set; }

        [Required]
        public string EventSummary { get; set; }

        public int EventSort { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

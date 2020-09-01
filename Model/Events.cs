using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventReactApp.Model
{
    public partial class Events
    {
        [Key]
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

       [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Categories.Events))]
        public virtual Categories Category { get; set; }

    }
}

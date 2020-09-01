using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventReactApp.Model
{
    public partial class Categories
    {
        public Categories()
        {
            Events = new HashSet<Events>();
        }

        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Events> Events { get; set; }
    }
}

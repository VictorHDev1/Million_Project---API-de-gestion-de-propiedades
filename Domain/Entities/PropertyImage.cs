using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("PropertyImage")]
    public class PropertyImage
    {
       
        [Key]
        public int IdPropertyImage { get; set; }
        [ForeignKey(nameof(Property))] // indica que esta es la FK
        public int IdProperty { get; set; }
        public string File { get; set; } = string.Empty;
        public bool Enabled { get; set; }

        // Relación N:1 con Property
        public Property? Property { get; set; } = null;

    }
}

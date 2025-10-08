using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Domain.Entities
{
    [Table("Property")]
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProperty { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string? CodeInternal { get; set; }
        public int Year { get; set; }
        // Clave foránea
        [ForeignKey(nameof(Owner))]
        public int IdOwner { get; set; }    
        
        public Owner? Owner { get; set; }
        public ICollection<PropertyImage>? PropertyImages { get; set; }
        public ICollection<PropertyTrace>? PropertyTraces { get; set; }
    }
}

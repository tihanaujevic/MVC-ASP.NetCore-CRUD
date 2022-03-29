using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp_Sport.Models
{
    [Table("Pobjednik")]
    public partial class Pobjednik
    {
        public Pobjednik()
        {
            Dogadajs = new HashSet<Dogadaj>();
        }

        [Key]
        [Column("ID_pobjednik")]
        public int IdPobjednik { get; set; }
        [Required]
        [Column("ime")]
        [StringLength(50)]
        public string Ime { get; set; }

        [InverseProperty(nameof(Dogadaj.IdPobjednikNavigation))]
        public virtual ICollection<Dogadaj> Dogadajs { get; set; }
    }
}

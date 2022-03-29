using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp_Sport.Models
{
    [Table("Utrka")]
    public partial class Utrka
    {
        public Utrka()
        {
            Dogadajs = new HashSet<Dogadaj>();
        }

        [Key]
        [Column("ID_utrka")]
        public int IdUtrka { get; set; }
        [Required]
        [Column("naziv")]
        [StringLength(50)]
        public string Naziv { get; set; }

        [InverseProperty(nameof(Dogadaj.IdUtrkaNavigation))]
        public virtual ICollection<Dogadaj> Dogadajs { get; set; }
    }
}

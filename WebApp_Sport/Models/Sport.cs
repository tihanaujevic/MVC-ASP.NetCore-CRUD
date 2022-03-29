using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp_Sport.Models
{
    [Table("Sport")]
    public partial class Sport
    {
        public Sport()
        {
            Dogadajs = new HashSet<Dogadaj>();
        }

        [Key]
        [Column("ID_sport")]
        public int IdSport { get; set; }
        [Required]
        [Column("naziv")]
        [StringLength(50)]
        public string Naziv { get; set; }

        [InverseProperty(nameof(Dogadaj.IdSportNavigation))]
        public virtual ICollection<Dogadaj> Dogadajs { get; set; }
    }
}

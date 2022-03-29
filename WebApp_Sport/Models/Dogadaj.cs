using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApp_Sport.Models
{
    [Table("Dogadaj")]
    public partial class Dogadaj
    {
        [Key]
        [Column("ID_dogadaj")]
        public int IdDogadaj { get; set; }
        [Column("ID_utrka")]
        public int IdUtrka { get; set; }
        [Column("ID_sport")]
        public int IdSport { get; set; }
        [Column("ID_pobjednik")]
        public int IdPobjednik { get; set; }
        [Column("datum", TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Datum { get; set; }

        [ForeignKey(nameof(IdPobjednik))]
        [InverseProperty(nameof(Pobjednik.Dogadajs))]
        public virtual Pobjednik IdPobjednikNavigation { get; set; }
        [ForeignKey(nameof(IdSport))]
        [InverseProperty(nameof(Sport.Dogadajs))]
        public virtual Sport IdSportNavigation { get; set; }
        [ForeignKey(nameof(IdUtrka))]
        [InverseProperty(nameof(Utrka.Dogadajs))]
        public virtual Utrka IdUtrkaNavigation { get; set; }

        public virtual string NazivSporta { get; set; }
        public virtual string NazivUtrke { get; set; }
        public virtual string NazivPobjednika { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentBikes.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Station
    {
        public Station()
        {
            this.Rental = new HashSet<Rental>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stationID { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public int stateID { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }
    }
}

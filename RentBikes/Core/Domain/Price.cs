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

    public class Price
    {
        public Price()
        {
            this.Rental_Detail = new HashSet<RentalDetail>();
        }

        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int priceID { get; set; }
        public decimal rentalPrice { get; set; }
        public string description { get; set; }
        public int hours { get; set; }

        public virtual ICollection<RentalDetail> Rental_Detail { get; set; }
    }
}

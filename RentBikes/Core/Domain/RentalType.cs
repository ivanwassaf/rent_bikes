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

    public partial class RentalType
    {
        public RentalType()
        {
            this.Rental = new HashSet<Rental>();
        }

        public int rentalTypeID { get; set; }
        public string description { get; set; }
        public decimal discount { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}

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

    public partial class Vehicle
    {
        public int vehicleID { get; set; }
        public string description { get; set; }
        public int vehicletypeID { get; set; }
        public int stateID { get; set; }
        public string serie { get; set; }

        public virtual State State { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}

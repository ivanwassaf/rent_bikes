//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentBikes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        public int vehicle_id { get; set; }
        public string description { get; set; }
        public int vehicletype_id { get; set; }
        public int state_id { get; set; }
        public string serie { get; set; }
    
        public virtual State State { get; set; }
        public virtual Vehicle_Type Vehicle_Type { get; set; }
    }
}

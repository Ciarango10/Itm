//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubastaVehiculo
    {
        public int idSubastaVehiculos { get; set; }
        public int idTipoVehiculo { get; set; }
        public string Vehiculo { get; set; }
        public string Vendedor { get; set; }
        public string Comprador { get; set; }
        public float ValorVenta { get; set; }
        public string PlacaVehiculo { get; set; }
        public float ValorComision { get; set; }
        public string CiudadEntrega { get; set; }
    
        public virtual TipoVehiculo TipoVehiculo { get; set; }
    }
}

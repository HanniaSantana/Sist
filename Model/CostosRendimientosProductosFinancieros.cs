//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostosRendimientosProductosFinancieros
    {
        public int CostoRendimientoId { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int RegionId { get; set; }
        public int ProductoFinancieroId { get; set; }
        public int CondicionDeProductoId { get; set; }
        public int EntidadFinancieraId { get; set; }
        public double TasaTREA { get; set; }
        public Nullable<double> Cuota { get; set; }
    
        public virtual CondicionesDeProductos CondicionesDeProductos { get; set; }
        public virtual ProductosFinancieros ProductosFinancieros { get; set; }
        public virtual Regiones Regiones { get; set; }
        public virtual EntidadesFinancieras EntidadesFinancieras { get; set; }
    }
}
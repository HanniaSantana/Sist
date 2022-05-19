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
    
    public partial class CondicionesDeProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CondicionesDeProductos()
        {
            this.CostosRendimientosProductosFinancieros = new HashSet<CostosRendimientosProductosFinancieros>();
        }
    
        public int CondicionDeProductoId { get; set; }
        public string DescripcionDeCondicion { get; set; }
        public int ProductoFinancieroId { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public int TipoDeMonedaId { get; set; }
    
        public virtual ProductosFinancieros ProductosFinancieros { get; set; }
        public virtual TiposDeMoneda TiposDeMoneda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostosRendimientosProductosFinancieros> CostosRendimientosProductosFinancieros { get; set; }
    }
}
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
    
    public partial class Regiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Regiones()
        {
            this.RelacionEntidadesFinancierasRegiones = new HashSet<RelacionEntidadesFinancierasRegiones>();
            this.CostosRendimientosProductosFinancieros = new HashSet<CostosRendimientosProductosFinancieros>();
        }
    
        public int RegionId { get; set; }
        public string NombreRegion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelacionEntidadesFinancierasRegiones> RelacionEntidadesFinancierasRegiones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostosRendimientosProductosFinancieros> CostosRendimientosProductosFinancieros { get; set; }
    }
}

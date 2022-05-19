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
    
    public partial class EntidadesFinancieras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntidadesFinancieras()
        {
            this.BeneficiosDeEntidadesFinancieras = new HashSet<BeneficiosDeEntidadesFinancieras>();
            this.CostosRendimientosProductosFinancieros = new HashSet<CostosRendimientosProductosFinancieros>();
            this.InfoPrestamos = new HashSet<InfoPrestamos>();
            this.RelacionEntidadesFinancierasRegiones = new HashSet<RelacionEntidadesFinancierasRegiones>();
            this.TasasActivasAnualesOperacionesMonedaNacional = new HashSet<TasasActivasAnualesOperacionesMonedaNacional>();
            this.TasasActivasAnualesOperacionesMonedaExtranjera = new HashSet<TasasActivasAnualesOperacionesMonedaExtranjera>();
        }
    
        public int EntidadFinancieraId { get; set; }
        public string Nombre { get; set; }
        public int Pais { get; set; }
        public string Seudonimo { get; set; }
        public int FormaLegalId { get; set; }
        public int TipoDeEntidadFinancieraId { get; set; }
        public string UrlImagenEntidadFinanciera { get; set; }
        public Nullable<bool> CorrespondeTasaDeInteresPromedio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BeneficiosDeEntidadesFinancieras> BeneficiosDeEntidadesFinancieras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CostosRendimientosProductosFinancieros> CostosRendimientosProductosFinancieros { get; set; }
        public virtual FormasLegales FormasLegales { get; set; }
        public virtual Paises Paises { get; set; }
        public virtual TiposDeEntidadesFinancieras TiposDeEntidadesFinancieras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoPrestamos> InfoPrestamos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelacionEntidadesFinancierasRegiones> RelacionEntidadesFinancierasRegiones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TasasActivasAnualesOperacionesMonedaNacional> TasasActivasAnualesOperacionesMonedaNacional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TasasActivasAnualesOperacionesMonedaExtranjera> TasasActivasAnualesOperacionesMonedaExtranjera { get; set; }
    }
}
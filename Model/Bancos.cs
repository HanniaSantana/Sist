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
    
    public partial class Bancos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bancos()
        {
            this.InfoPrestamos = new HashSet<InfoPrestamos>();
        }
    
        public int BancoId { get; set; }
        public string Nombre { get; set; }
        public int Pais { get; set; }
        public string EntidadFinanciera { get; set; }
        public string Acronimo { get; set; }
        public int FormaLegalId { get; set; }
        public int TipoDeBancoId { get; set; }
        public string UrlImagenBanco { get; set; }
    
        public virtual FormasLegales FormasLegales { get; set; }
        public virtual Paises Paises { get; set; }
        public virtual TiposDeBancos TiposDeBancos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfoPrestamos> InfoPrestamos { get; set; }
    }
}
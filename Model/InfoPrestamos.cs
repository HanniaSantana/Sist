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
    
    public partial class InfoPrestamos
    {
        public int InfoPrestamoId { get; set; }
        public string Valor { get; set; }
        public Nullable<decimal> TasaTEA { get; set; }
        public Nullable<decimal> TasaTCEA { get; set; }
        public Nullable<decimal> PagoTotalAprox { get; set; }
        public Nullable<decimal> CargoPorMes { get; set; }
        public Nullable<decimal> Desgravamen { get; set; }
        public string UrlPrestamo { get; set; }
        public int EntidadFinancieraId { get; set; }
    
        public virtual EntidadesFinancieras EntidadesFinancieras { get; set; }
    }
}

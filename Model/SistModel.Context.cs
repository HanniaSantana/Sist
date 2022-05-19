﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SistEntities : DbContext
    {
        public SistEntities()
            : base("name=SistEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BeneficiosDeEntidadesFinancieras> BeneficiosDeEntidadesFinancieras { get; set; }
        public virtual DbSet<CaracteristicasDeEntidadesFinancieras> CaracteristicasDeEntidadesFinancieras { get; set; }
        public virtual DbSet<CondicionesDeProductos> CondicionesDeProductos { get; set; }
        public virtual DbSet<FormasLegales> FormasLegales { get; set; }
        public virtual DbSet<InfoPrestamos> InfoPrestamos { get; set; }
        public virtual DbSet<MensajesDeContacto> MensajesDeContacto { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<PlanesDeSuscripcion> PlanesDeSuscripcion { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<RelacionEntidadesFinancierasRegiones> RelacionEntidadesFinancierasRegiones { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TasasActivasAnualesOperacionesMonedaExtranjera> TasasActivasAnualesOperacionesMonedaExtranjera { get; set; }
        public virtual DbSet<TasasActivasAnualesOperacionesMonedaNacional> TasasActivasAnualesOperacionesMonedaNacional { get; set; }
        public virtual DbSet<TasasAnuales> TasasAnuales { get; set; }
        public virtual DbSet<TiposDeEntidadesFinancieras> TiposDeEntidadesFinancieras { get; set; }
        public virtual DbSet<TiposDeOperaciones> TiposDeOperaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<CostosRendimientosProductosFinancieros> CostosRendimientosProductosFinancieros { get; set; }
        public virtual DbSet<ProductosFinancieros> ProductosFinancieros { get; set; }
        public virtual DbSet<TiposDeMoneda> TiposDeMoneda { get; set; }
        public virtual DbSet<EntidadesFinancieras> EntidadesFinancieras { get; set; }
    
        public virtual ObjectResult<ObtenerTasasActivasAnualesOperacionesMonedaExtranjera_Result> ObtenerTasasActivasAnualesOperacionesMonedaExtranjera(Nullable<System.DateTime> fechaSeleccionada)
        {
            var fechaSeleccionadaParameter = fechaSeleccionada.HasValue ?
                new ObjectParameter("fechaSeleccionada", fechaSeleccionada) :
                new ObjectParameter("fechaSeleccionada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerTasasActivasAnualesOperacionesMonedaExtranjera_Result>("ObtenerTasasActivasAnualesOperacionesMonedaExtranjera", fechaSeleccionadaParameter);
        }
    
        public virtual ObjectResult<ObtenerTasasActivasAnualesOperacionesMonedaNacional_Result> ObtenerTasasActivasAnualesOperacionesMonedaNacional(Nullable<System.DateTime> fechaSeleccionada)
        {
            var fechaSeleccionadaParameter = fechaSeleccionada.HasValue ?
                new ObjectParameter("fechaSeleccionada", fechaSeleccionada) :
                new ObjectParameter("fechaSeleccionada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerTasasActivasAnualesOperacionesMonedaNacional_Result>("ObtenerTasasActivasAnualesOperacionesMonedaNacional", fechaSeleccionadaParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<ObtenerCostosRendimientosProductosFinancieros_Result> ObtenerCostosRendimientosProductosFinancieros(Nullable<int> regionId, Nullable<int> productoFinancieroId, Nullable<int> condicionDeProductoId)
        {
            var regionIdParameter = regionId.HasValue ?
                new ObjectParameter("regionId", regionId) :
                new ObjectParameter("regionId", typeof(int));
    
            var productoFinancieroIdParameter = productoFinancieroId.HasValue ?
                new ObjectParameter("productoFinancieroId", productoFinancieroId) :
                new ObjectParameter("productoFinancieroId", typeof(int));
    
            var condicionDeProductoIdParameter = condicionDeProductoId.HasValue ?
                new ObjectParameter("condicionDeProductoId", condicionDeProductoId) :
                new ObjectParameter("condicionDeProductoId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerCostosRendimientosProductosFinancieros_Result>("ObtenerCostosRendimientosProductosFinancieros", regionIdParameter, productoFinancieroIdParameter, condicionDeProductoIdParameter);
        }
    
        public virtual int InsertarCostosRendimientosProductosFinancieros(Nullable<bool> actualizarDataDelDia)
        {
            var actualizarDataDelDiaParameter = actualizarDataDelDia.HasValue ?
                new ObjectParameter("actualizarDataDelDia", actualizarDataDelDia) :
                new ObjectParameter("actualizarDataDelDia", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarCostosRendimientosProductosFinancieros", actualizarDataDelDiaParameter);
        }
    
        public virtual ObjectResult<EstatusDeProductosFinancieros_Result> EstatusDeProductosFinancieros()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstatusDeProductosFinancieros_Result>("EstatusDeProductosFinancieros");
        }
    
        public virtual ObjectResult<ChartTEA_Result> ChartTEA()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ChartTEA_Result>("ChartTEA");
        }
    }
}

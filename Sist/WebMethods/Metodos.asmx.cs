using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Model;

namespace Sist.WebMethods
{
    /// <summary>
    /// Descripción breve de Metodos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Metodos : System.Web.Services.WebService
    {

        [WebMethod]
        public Object TasasMonedaNacional(DateTime fecha)
        {
            EntityAcciones ef = new EntityAcciones();
            List<ObtenerTasasActivasAnualesOperacionesMonedaNacional_Result> l = ef.ObtenerTasasActivasAnualesOperacionesMonedaNacional(fecha);

            return l;
        }

        [WebMethod]
        public Object TasasMonedaExtranjera(DateTime fecha)
        {
            EntityAcciones ef = new EntityAcciones();
            List<ObtenerTasasActivasAnualesOperacionesMonedaExtranjera_Result> l = ef.ObtenerTasasActivasAnualesOperacionesMonedaExtranjera(fecha);

            return l;
        }


        [WebMethod]
        public Object ObtenerRegiones()
        {
            EntityAcciones ef = new EntityAcciones();
            List<Regiones> l = ef.Obtener<Regiones>().ToList();

            var d = from x in l select new { x.RegionId, x.NombreRegion };

            return d;
        }

        [WebMethod]
        public Object ObtenerTiposDeOperaciones()
        {
            EntityAcciones ef = new EntityAcciones();

            var d = from x in ef.Obtener<TiposDeOperaciones>().Where(x => x.TipoDeOperacionId < 3)
                    select new { x.TipoDeOperacionId, x.DescripcionDeOperacion };

            return d;
        }

        [WebMethod]
        public Object ObtenerProductos(int tipoDeOperacionId)
        {
            EntityAcciones ef = new EntityAcciones();

            var d = from x in ef.Obtener<ProductosFinancieros>().Where(x => x.TipoDeOperacionId == tipoDeOperacionId)
                    select new { x.ProductoFinancieroId, x.NombreProductoFianciero };

            return d;
        }

        [WebMethod]
        public Object ObtenerCondicionesDeProductos(int productoFinancieroId)
        {
            EntityAcciones ef = new EntityAcciones();

            var d = from x in ef.Obtener<CondicionesDeProductos>().Where(x => x.ProductoFinancieroId == productoFinancieroId)
                    select new { x.CondicionDeProductoId, x.DescripcionDeCondicion };

            return d;
        }

        [WebMethod]
        public Object ObtenerCostosRendimientosDeProductosFinancieros(int regionId, int productoFinancieroId, int condicionDeProductoId)
        {
            EntityAcciones ef = new EntityAcciones();

            List<ObtenerCostosRendimientosProductosFinancieros_Result> l =
                ef.ObtenerCostosRendimientosProductosFinancieros(regionId, productoFinancieroId, condicionDeProductoId);

            return l;
        }

        [WebMethod]
        public Object ChartTEA()
        {
            EntityAcciones ef = new EntityAcciones();

            List<ChartTEA_Result> l = ef.ChartTEA();

            return l;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class EntityAcciones
    {
        SistEntities se = new SistEntities();
        public void Agrega<T>(T entidad) where T : class
        {
            se.Set<T>().Add(entidad);
            se.SaveChanges();
        }
        public void Delete<T>(T entidad) where T : class
        {
            se.Set<T>().Remove(entidad);
            se.SaveChanges();
        }
        public T GetSingle<T>(System.Linq.Expressions.Expression<Func<T, bool>> exp) where T : class
        {
            return se.Set<T>().FirstOrDefault(exp);
        }
        public IList<T> Obtener<T>(System.Linq.Expressions.Expression<Func<T, bool>> exp = null) where T : class
        {
            if (exp == null)
                return se.Set<T>().ToList();
            return se.Set<T>().Where(exp).ToList();
        }
        public void Update()
        {
            se.SaveChanges();     
        }

        public List<ObtenerTasasActivasAnualesOperacionesMonedaNacional_Result> ObtenerTasasActivasAnualesOperacionesMonedaNacional(DateTime fecha)
        {
            return se.ObtenerTasasActivasAnualesOperacionesMonedaNacional(fecha).ToList();
        }

        public List<ObtenerTasasActivasAnualesOperacionesMonedaExtranjera_Result> ObtenerTasasActivasAnualesOperacionesMonedaExtranjera(DateTime fecha)
        {
            return se.ObtenerTasasActivasAnualesOperacionesMonedaExtranjera(fecha).ToList();
        }

        public List<ObtenerCostosRendimientosProductosFinancieros_Result> ObtenerCostosRendimientosProductosFinancieros(int regionId, int productoFinancieroId, int condicionDeProductoId)
        {
            return se.ObtenerCostosRendimientosProductosFinancieros(regionId, productoFinancieroId, condicionDeProductoId).ToList();
        }

        public EstatusDeProductosFinancieros_Result ObtenerEstatusDeProductosFinancieros()
        {
            return se.EstatusDeProductosFinancieros().FirstOrDefault();
        }
        
        public List<ChartTEA_Result> ChartTEA()
        {
            return se.ChartTEA().ToList();
        }
    }
}

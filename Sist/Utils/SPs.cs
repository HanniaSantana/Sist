using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sist.Utils
{
    public class SPs
    {
        DataTable _dt;

        public DataTable GetSpInfo(string _sp, IList<SqlParameter> _listParameters, string _strConn)
        {
            SqlDataReader rdr;
            _dt = new DataTable();
            try
            {
                rdr = SQLHelper.ExecuteReader(CommandType.StoredProcedure, _sp, _listParameters, _strConn);
                _dt.Load(rdr);
                DataSet ds = new DataSet();
            }
            catch
            {
                throw;
            }
            return _dt;
        }

        public int GetSpInfoIns(string _sp, IList<SqlParameter> _listParameters, string _strConn)
        {
            int valor;
            try
            {
                valor = SQLHelper.ExecuteNonQuery(CommandType.StoredProcedure, _sp, _listParameters, _strConn);
            }
            catch
            {
                throw;
            }
            return valor;
        }
    }
}
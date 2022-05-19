using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Sist.Utils;
using Model;

namespace Sist
{
    public partial class Res : System.Web.UI.Page
    {

        EntityAcciones ef = new EntityAcciones();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("/Index.aspx");
            }
            else
            {
                Usuarios u = (Usuarios)Session["usuario"];
                nombreUsuario.InnerHtml = u.Nombre + " " + u.ApPaterno;
                ActualizarInformacionProductos();
            }
        }

        public void ActualizarInformacionProductos()
        {
            EstatusDeProductosFinancieros_Result elemento = ef.ObtenerEstatusDeProductosFinancieros();

            infoDepositos.InnerHtml = elemento != null ? elemento.Depositos : "No se ha actualizado";
            infoCreditos.InnerHtml = elemento != null ? elemento.Creditos : "No se ha actualizado";
            InfoTasasMonedaNacional.InnerHtml = elemento != null ? elemento.TasaMonedaNacional : "No se ha actualizado";
            InfoTasasMonedaExtranjera.InnerHtml = elemento != null ? elemento.TasaMonedaExtranjera : "No se ha actualizado";
        }

        public void InsertarEnBd(DataTable dt, string nombreProcedimiento)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["SistSp"].ConnectionString;

            //DataTable dtResults = new DataTable();
            SPs supportBd = new SPs();

            List<SqlParameter> sqlparameters = new List<SqlParameter>();
            SqlParameter param1 = new SqlParameter("@rawData", dt);
            param1.SqlDbType = SqlDbType.Structured;
            param1.TypeName = nombreProcedimiento.Contains("Operaciones") ? "dbo.DataTableTasasAnuales" : "dbo.DataTable";
            sqlparameters.Add(param1);

            DataTable dtResults = supportBd.GetSpInfo(nombreProcedimiento, sqlparameters, strConnection);
        }

        public void RaspadoRetasas(string seleccion)
        {
            DataTable dtParams = new DataTable();
            dtParams.Columns.Add("Region");
            dtParams.Columns.Add("TipoDeOperacion");
            dtParams.Columns.Add("Producto");
            dtParams.Columns.Add("Condiciones");
            dtParams.Columns.Add("Entidad");
            dtParams.Columns.Add("TREATCEA");
            dtParams.Columns.Add("Cuota");

            WebDriver nv = ObtenerNavegador();
            int numDepts;
            int numProds;


            //try
            //{
            nv.Navigate().GoToUrl("https://www.sbs.gob.pe/app/retasas/paginas/retasasInicio.aspx?p=" + seleccion);

            WebElement webDept = (WebElement)nv.FindElement(By.Id("ddlDepartamento"));
            SelectElement ddlDept = new SelectElement(webDept);
            numDepts = ddlDept.Options.Count();

            WebElement webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
            SelectElement ddlProd = new SelectElement(webProd);
            numProds = ddlProd.Options.Count();
            int indiceDepto = 1;
            int indiceProducto = 0;
            int numIntentos = 5;

            string ultimoProducto = "";
            Boolean exito;
            DateTime fecha = DateTime.Now.Date;

            CostosRendimientosProductosFinancieros ultimoCostoRegistrado;

            if (seleccion == "C")
            {
                ultimoCostoRegistrado = ef.Obtener<CostosRendimientosProductosFinancieros>().Where(x => x.FechaRegistro == fecha && x.ProductoFinancieroId > 6 && x.ProductoFinancieroId < 14).LastOrDefault();
            }
            else
            {
                ultimoCostoRegistrado = ef.Obtener<CostosRendimientosProductosFinancieros>().Where(x => x.FechaRegistro == fecha && x.ProductoFinancieroId > 0 && x.ProductoFinancieroId < 7).LastOrDefault();
            }


            if (ultimoCostoRegistrado != null)
            {
                indiceDepto = ultimoCostoRegistrado.RegionId;
                indiceProducto = ultimoCostoRegistrado.ProductoFinancieroId;
                ProductosFinancieros p = ef.Obtener<ProductosFinancieros>().Where(x => x.ProductoFinancieroId == indiceProducto).First();
                ultimoProducto = p.NombreProductoFianciero.ToUpper();
            }


            while (numIntentos > 0)
            {
                if (indiceDepto < 26)
                {
                    exito = RecorridoOpciones(nv, indiceDepto, numDepts, ultimoProducto, webDept, ddlDept, webProd, dtParams, ddlProd, seleccion);

                    if (exito)
                    {
                        indiceDepto++;
                    }
                    else
                    {
                        numIntentos--;
                    }
                }
                else
                {
                    numIntentos = 0;
                    //significa que llego a todos los departamentos y sale 
                }
            }

            Mensaje(true, "Se actualizó la información correctamente.");
            ActualizarInformacionProductos();
            //}
            //catch (Exception e)
            //{
            //    if (e.Message != null)
            //        Mensaje(false, e.Message);
            //}
            nv.Quit();
        }

        public Boolean RecorridoOpciones(WebDriver nv, int indiceDepto, int numDepts, string ultimoProducto, WebElement webDept, SelectElement ddlDept,
           WebElement webProd, DataTable dtParams, SelectElement ddlProd, string seleccion)
        {
            string departamento = "";
            string producto = "";
            string condiciones = "";
            int indexProd;
            int numProds;
            int numConds;

            try
            {

                try
                {
                    webDept = (WebElement)nv.FindElement(By.Id("ddlDepartamento"));
                    ddlDept = new SelectElement(webDept);
                }
                catch
                {
                    Thread.Sleep(1000);
                    webDept = (WebElement)nv.FindElement(By.Id("ddlDepartamento"));
                    ddlDept = new SelectElement(webDept);
                }


                string indiceStr = indiceDepto < 10 ? "0" + indiceDepto : indiceDepto.ToString();

                ddlDept.SelectByValue(indiceStr == "00" ? "01" : indiceStr);
                departamento = ddlDept.SelectedOption.Text;

                try
                {
                    webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                    ddlProd = new SelectElement(webProd);
                    if (ultimoProducto != "")
                    {
                        ddlProd.SelectByText(ultimoProducto);
                    }
                    else
                    {
                        ddlProd.SelectByIndex(1);
                    }

                    producto = ddlProd.SelectedOption.Text;
                    indexProd = ddlProd.Options.IndexOf(ddlProd.SelectedOption);
                    numProds = ddlProd.Options.Count;
                }
                catch
                {
                    Thread.Sleep(1000);
                    webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                    ddlProd = new SelectElement(webProd);
                    if (ultimoProducto != "")
                    {
                        ddlProd.SelectByText(ultimoProducto);
                    }
                    else
                    {
                        ddlProd.SelectByIndex(1);
                    }
                    producto = ddlProd.SelectedOption.Text;
                    indexProd = ddlProd.Options.IndexOf(ddlProd.SelectedOption);
                    numProds = ddlProd.Options.Count;
                }

                for (int j = indexProd; j < numProds; j++)
                {
                    try
                    {
                        webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                        ddlProd = new SelectElement(webProd);
                        ddlProd.SelectByIndex(j);
                        producto = ddlProd.SelectedOption.Text;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                        webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                        ddlProd = new SelectElement(webProd);
                        ddlProd.SelectByIndex(j);
                        producto = ddlProd.SelectedOption.Text;
                    }

                    Console.WriteLine("producto: " + producto);
                    Thread.Sleep(1000);

                    WebElement webCon = (WebElement)nv.FindElement(By.Id("ddlCondicion"));
                    SelectElement ddlCon = new SelectElement(webCon);

                    numConds = ddlCon.Options.Count();
                    WebElement webConAlt;
                    SelectElement ddlConAlt;

                    for (int k = 1; k < numConds; k++)
                    {
                        try
                        {
                            webConAlt = (WebElement)nv.FindElement(By.Id("ddlCondicion"));
                            ddlConAlt = new SelectElement(webConAlt);
                            ddlConAlt.SelectByIndex(k);
                            condiciones = ddlConAlt.SelectedOption.Text;
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                            webConAlt = (WebElement)nv.FindElement(By.Id("ddlCondicion"));
                            ddlConAlt = new SelectElement(webConAlt);
                            ddlConAlt.SelectByIndex(k);
                            condiciones = ddlConAlt.SelectedOption.Text;
                        }


                        WebElement btnConsulta = (WebElement)nv.FindElement(By.Id("btnConsultar"));
                        btnConsulta.Click();

                        nv.SwitchTo().Frame("ifrmContendedor");

                        WebElement webTbl;
                        try
                        {
                            webTbl = (WebElement)nv.FindElement(By.ClassName("tablesorter"));
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                            webTbl = (WebElement)nv.FindElement(By.ClassName("tablesorter"));
                        }

                        WebElement tblBody = (WebElement)webTbl.FindElement(By.TagName("tbody"));

                        IReadOnlyCollection<IWebElement> lstWebTblRow = tblBody.FindElements(By.TagName("tr"));

                        List<IWebElement> lstWebTblCell;

                        for (int l = 0; l < lstWebTblRow.Count; l++)
                        {
                            IWebElement webRow = lstWebTblRow.ElementAt(l);

                            lstWebTblCell = webRow.FindElements(By.TagName("td")).ToList();

                            DataRow dr = dtParams.NewRow();

                            var webCellEntidad = lstWebTblCell.ElementAt(0);
                            var webCellTreaTcea = lstWebTblCell.ElementAt(1);

                            IWebElement webCellCuota = null;
                            try
                            {
                                webCellCuota = lstWebTblCell.ElementAt(2);
                            }
                            catch
                            {
                                webCellCuota = null;
                            }

                            dr["Region"] = departamento;
                            dr["TipoDeOperacion"] = "Depositos";
                            dr["Producto"] = producto;
                            dr["Condiciones"] = condiciones;
                            dr["Entidad"] = webCellEntidad.Text;
                            dr["TREATCEA"] = webCellTreaTcea.Text.Replace(" %", "").Replace("%", "").Trim();

                            if (webCellCuota != null)
                            {
                                dr["Cuota"] = webCellCuota.Text.Replace(" %", "").Replace("%", "").Trim(); ;
                            }

                            dtParams.Rows.Add(dr);
                        }
                        nv.SwitchTo().DefaultContent();
                    }
                    InsertarEnBd(dtParams, "InsertarCostosRendimientosProductosFinancieros");
                    dtParams.Rows.Clear();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void RaspadoTasasSistemaBancario(Boolean EsNacional)
        {
            DataTable dtParams = new DataTable();

            dtParams.Columns.Add("TasaAnual");
            dtParams.Columns.Add("EntidadFinanciera");
            dtParams.Columns.Add("Valor");

            WebDriver nv = ObtenerNavegador();

            try
            {
                List<EntidadesFinancieras> listaEntidades = ef.Obtener<EntidadesFinancieras>().Where(x => x.EntidadFinancieraId < 17).ToList();
                List<TasasAnuales> listaTasas = ef.Obtener<TasasAnuales>().ToList();

                nv.Navigate().GoToUrl("https://www.sbs.gob.pe/app/pp/EstadisticasSAEEPortal/Paginas/TIActivaTipoCreditoEmpresa.aspx?tip=B");

                if (!EsNacional)
                {
                    WebElement btnTasasExtranjeras = (WebElement)nv.FindElement(By.Id("ctl00_cphContent_lbtnMex"));
                    btnTasasExtranjeras.Click();
                    Thread.Sleep(5000);

                }

                WebElement webTbl = (WebElement)nv.FindElement(By.Id(EsNacional ? "ctl00_cphContent_rpgActualMn_OT" : "ctl00_cphContent_rpgActualMex_OT"));
                WebElement tblBody = (WebElement)webTbl.FindElement(By.TagName("tbody"));
                List<IWebElement> lstWebTblRow = tblBody.FindElements(By.TagName("tr")).ToList();
                lstWebTblRow.RemoveRange(0, 2);
                lstWebTblRow.RemoveRange(46, 47);

                List<IWebElement> lstWebTblCell;
                string valor;
                for (int i = 0; i < listaTasas.Count; i++)//recorremos las tasas
                {
                    IWebElement webRow = lstWebTblRow.ElementAt(i);
                    lstWebTblCell = webRow.FindElements(By.TagName("td")).ToList();
                    lstWebTblCell.RemoveAt(lstWebTblCell.Count - 1);

                    for (int j = 0; j < listaEntidades.Count; j++)//recorremos los bancos
                    {
                        DataRow dr = dtParams.NewRow();
                        valor = (lstWebTblCell.ElementAt(j)).Text;
                        dr["TasaAnual"] = listaTasas[i].Descripcion;
                        dr["EntidadFinanciera"] = listaEntidades[j].Nombre;
                        dr["Valor"] = valor != "-" ? valor : null;
                        dtParams.Rows.Add(dr);
                    }

                }
                InsertarEnBd(dtParams, "InsertarTasasAnualesOperacionesMoneda" + (EsNacional ? "Nacional" : "Extranjera"));
                Mensaje(true, "Se actualizó la información correctamente.");
                ActualizarInformacionProductos();
            }
            catch (Exception ex)
            {
                if (ex.Message != null)
                    Mensaje(false, ex.Message);
            }
            nv.Quit();
        }

        public void RaspadoRetasasEjemplo()
        {
            DataTable dtParams = new DataTable();
            dtParams.Columns.Add("Region");
            dtParams.Columns.Add("TipoDeOperacion");
            dtParams.Columns.Add("Producto");
            dtParams.Columns.Add("Condiciones");
            dtParams.Columns.Add("Entidad");
            dtParams.Columns.Add("TREATCEA");
            dtParams.Columns.Add("Cuota");

            WebDriver nv = ObtenerNavegador();
            int numDepts;
            int numProds;
            int numConds;
            string departamento;
            string producto;
            string condiciones;

            try
            {
                nv.Navigate().GoToUrl("https://www.sbs.gob.pe/app/retasas/paginas/retasasInicio.aspx?p=C");

                WebElement webDept = (WebElement)nv.FindElement(By.Id("ddlDepartamento"));
                SelectElement ddlDept = new SelectElement(webDept);
                numDepts = ddlDept.Options.Count();

                WebElement webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                SelectElement ddlProd = new SelectElement(webProd);
                numProds = ddlProd.Options.Count();

                for (int i = 1; i < 2; i++)
                {
                    webDept = (WebElement)nv.FindElement(By.Id("ddlDepartamento"));
                    ddlDept = new SelectElement(webDept);
                    departamento = ddlDept.SelectedOption.Text;

                    ddlDept.SelectByIndex(i);

                    for (int j = 0; j < numProds; j++)
                    {
                        webProd = (WebElement)nv.FindElement(By.Id("ddlProducto"));
                        ddlProd = new SelectElement(webProd);
                        ddlProd.SelectByIndex(j);
                        producto = ddlProd.SelectedOption.Text;

                        Thread.Sleep(1000);

                        WebElement webCon = (WebElement)nv.FindElement(By.Id("ddlCondicion"));
                        SelectElement ddlCon = new SelectElement(webCon);

                        numConds = ddlCon.Options.Count();

                        for (int k = 1; k < numConds; k++)
                        {
                            WebElement webConAlt = (WebElement)nv.FindElement(By.Id("ddlCondicion"));
                            SelectElement ddlConAlt = new SelectElement(webConAlt);
                            ddlConAlt.SelectByIndex(k);
                            condiciones = ddlConAlt.SelectedOption.Text;

                            WebElement btnConsulta = (WebElement)nv.FindElement(By.Id("btnConsultar"));
                            btnConsulta.Click();

                            nv.SwitchTo().Frame("ifrmContendedor");

                            WebElement webTbl = (WebElement)nv.FindElement(By.ClassName("tablesorter"));
                            WebElement tblBody = (WebElement)webTbl.FindElement(By.TagName("tbody"));

                            WebDriverWait wt = new WebDriverWait(nv, new TimeSpan(0, 0, 5));
                            wt.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id=\"myTable\"]/tbody/tr")));
                            IReadOnlyCollection<IWebElement> lstWebTblRow = tblBody.FindElements(By.TagName("tr"));

                            List<IWebElement> lstWebTblCell;

                            for (int l = 0; l < lstWebTblRow.Count; l++)
                            {
                                IWebElement webRow = lstWebTblRow.ElementAt(l);

                                lstWebTblCell = webRow.FindElements(By.TagName("td")).ToList();

                                DataRow dr = dtParams.NewRow();

                                var webCellEntidad = lstWebTblCell.ElementAt(0);
                                var webCellTreaTcea = lstWebTblCell.ElementAt(1);

                                IWebElement webCellCuota = null;
                                try
                                {
                                    webCellCuota = lstWebTblCell.ElementAt(2);
                                }
                                catch
                                {
                                    webCellCuota = null;
                                }

                                dr["Region"] = departamento;
                                dr["TipoDeOperacion"] = "Depositos";
                                dr["Producto"] = producto;
                                dr["Condiciones"] = condiciones;
                                dr["Entidad"] = webCellEntidad.Text;
                                dr["TREATCEA"] = webCellTreaTcea.Text.Replace("%", "").Trim();

                                if (webCellCuota != null)
                                {
                                    dr["Cuota"] = webCellCuota.Text;
                                }

                                dtParams.Rows.Add(dr);
                            }
                            nv.SwitchTo().DefaultContent();
                        }
                    }
                }
                InsertarEnBd(dtParams, "InsertarCostosRendimientosProductosFinancierosCopia");
                Mensaje(true, "Se actualizó la información de prueba correctamente.");
            }
            catch (Exception e)
            {
                if (e.Message != null)
                    Mensaje(false, e.Message);
            }
            nv.Quit();
        }

        private static WebDriver ObtenerNavegador()
        {
            //usamos la libreria Selenium, para generar un navegador Chrome que navegara a las diferentes opciones.            
            var user_agent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 101.0.4951.41 Safari / 537.36";
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument($"user_agent={user_agent}");
            options.AddArgument("--ignore-certificate-errors");
            WebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
            return driver;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/Index.aspx");
        }

        protected void btnObtenerCreditos_Click(object sender, EventArgs e)
        {
            RaspadoRetasas("C");
        }

        protected void btnObtenerDepositos_Click(object sender, EventArgs e)
        {
            RaspadoRetasas("D");
        }

        protected void btnObtenerTasasNacionales_Click(object sender, EventArgs e)
        {
            RaspadoTasasSistemaBancario(true);
        }

        protected void btnObtenerTasasExtranjeras_Click(object sender, EventArgs e)
        {
            RaspadoTasasSistemaBancario(false);
        }

        protected void btnObtenerDataDeEjemplo_Click(object sender, EventArgs e)
        {
            RaspadoRetasasEjemplo();
        }

        public void Mensaje(Boolean exito, string texto)
        {
            if (exito)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('" + texto + "')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('¡Ha ocurrido un error! consulta la imagen de abajo para mas detalles.')", true);
                mensajeError.InnerHtml = "Se ha producido un error. esto generalmente sucede porque la página de donde se obtiene la data tiende a fallar. Entonces es recomendado volver a intentar obtener los datos, puesto que la página de retasas suele 'arreglarse' y 'desarreglarse' frecuentemente. ";
                imgEvidencia.ImageUrl = "/Evidences/evidencia1.png";
                infoAdicional.InnerHtml = "información adicional: " + texto;
            }
        }
    }

}
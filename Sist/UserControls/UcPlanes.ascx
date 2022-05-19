<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcPlanes.ascx.cs" Inherits="Sist.UserControls.UcPlanes" %>
<div class="tab-pane fade" id="item3" role="tabpanel" aria-labelledby="item3-tab">
    <div class="container textContent">
        <div class="my-3">
            <table class="table table-bordered table-hover table-striped table-responsive">
                <thead>
                    <tr>
                        <th>
                            <h4>Info / tipo de plan</h4>
                        </th>
                        <th>
                            <h1>Gratuito</h1>
                        </th>
                        <th>
                            <h1>Básico</h1>
                        </th>
                        <th>
                            <h1>Empresarial</h1>
                        </th>
                        <th>
                            <h1>Analítico</h1>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <h4>Precio </h4>
                        </td>
                        <td>Gratis</td>
                        <td>720 soles
                                        <br />
                            Anual
                        </td>
                        <td>980 soles
                                        <br />
                            Anual</td>
                        <td>1098 soles
                                        <br />
                            Anual</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Tasas financieras</h4>
                        </td>
                        <td>Todos: Corporativos, grandes empresas, medianas empresas, pequeñas empresas, micro empresas, consumo e hipotecarios.
                                        <br />
                            *Con información de los últimos 90 días.
                        </td>
                        <td>Micro empresas, consumo e hipotecarias</td>
                        <td>Medianas empresas, pequeñas empresas, micro empresas, consumo e hipotecarios.</td>
                        <td>Todos: Corporativos, grandes empresas, medianas empresas, pequeñas empresas, micro empresas, consumo e hipotecarios.</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Usuarios</h4>
                        </td>
                        <td>No aplican</td>
                        <td>1 usuario único</td>
                        <td>3 usuarios únicos</td>
                        <td>3 usuarios únicos</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Comparación de tasas</h4>
                        </td>
                        <td>No aplican</td>
                        <td>60 comparaciones al año</td>
                        <td>Ilimitado</td>
                        <td>Ilimitado</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Descargas</h4>
                        </td>
                        <td>No aplican</td>
                        <td>15 descargas al año</td>
                        <td>Ilimitado</td>
                        <td>Ilimitado</td>
                    </tr>
                    <tr>
                        <td>
                            <h4>Reportes mensuales</h4>
                        </td>
                        <td colspan="3">No aplican</td>
                        <td>Sí, formatos JSON, CSV, XLSX y PDF.</td>
                    </tr>
                    <tr>
                        <td>Acciones</td>
                        <td>
                            <asp:Button runat="server" ID="btnSolicitarPlanGratuito" CssClass="btn btn-warning" Text="Solicitar" OnClientClick="return false;" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="Button1" CssClass="btn btn-warning" Text="Adquirir plan" OnClientClick="return false;" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="Button2" CssClass="btn btn-warning" Text="Adquirir plan" OnClientClick="return false;" />
                        </td>
                        <td>
                            <asp:Button runat="server" ID="Button3" CssClass="btn btn-warning" Text="Adquirir plan" OnClientClick="return false;" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="my-3">
            <h3>Links de pago:</h3>
            <br />
            <a href="https://www.google.com.mx">Link 1</a>
            <br />
            <a href="https://www.google.com.mx">Link 2</a>
            <br />
            <a href="https://www.google.com.mx">Link 3</a>
            <br />
            <a href="https://www.google.com.mx">Link 4</a>
            <br />
            <a href="https://www.google.com.mx">Link 5</a>
        </div>
    </div>

</div>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Sist.Res" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administración</title>
    <script src="../Scripts/Bootstrap/bootstrap.bundle.js"></script>
    <script src="../Scripts/jQuery.js"></script>
    <link href="../Styles/Bootstrap/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/fontawesome/all.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Administración</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" runat="server" id="nombreUsuario" href="#"></a>
                        </li>
                    </ul>
                    <div class="d-flex">
                        <asp:Button runat="server" CssClass="btn btn-outline-light" Text="Salir" OnClick="btnSalir_Click" ID="btnSalir"></asp:Button>
                    </div>
                </div>
            </div>
        </nav>
        <div class="container text-center">
            <br />
            <h3 class="panel-title">Opciones de actualización</h3>
            <hr />
            <div class="row">
                <div class="col-3">
                    <div class="card" style="width: 18rem;">
                        <span class="text-center mt-3"><i class="fas fa-credit-card fa-3x"></i></span>
                        <div class="card-body">
                            <h5 class="card-title">Créditos</h5>
                            <p class="card-text" id="infoCreditos" runat="server"></p>
                            <asp:Button runat="server" data-updated="true" CssClass="btn btn-sm btn-primary" Text="Obtener" ID="btnObtenerCreditos" OnClick="btnObtenerCreditos_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="card" style="width: 18rem;">
                        <span class="text-center mt-3"><i class="fas fa-money-bill fa-3x"></i></span>
                        <div class="card-body">
                            <h5 class="card-title">Depósitos</h5>
                            <p class="card-text" id="infoDepositos" runat="server"></p>
                            <asp:Button runat="server" data-updated="true" CssClass="btn btn-sm btn-primary" Text="Obtener" ID="btnObtenerDepositos" OnClick="btnObtenerDepositos_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="card" style="width: 18rem;">
                        <span class="text-center mt-3"><i class="fas fa-flag-checkered fa-3x"></i></span>
                        <div class="card-body">
                            <h5 class="card-title">Tasas moneda nacional</h5>
                            <p class="card-text" id="InfoTasasMonedaNacional" runat="server"></p>
                            <asp:Button runat="server" data-updated="false" CssClass="btn btn-sm btn-primary" Text="Obtener" ID="btnObtenerTasasNacionales" OnClick="btnObtenerTasasNacionales_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-3">
                    <div class="card" style="width: 18rem;">
                        <span class="text-center mt-3"><i class="fas fa-flag-usa fa-3x"></i></span>
                        <div class="card-body">
                            <h5 class="card-title">Tasas moneda extranjera</h5>
                            <p class="card-text" id="InfoTasasMonedaExtranjera" runat="server"></p>
                            <asp:Button runat="server" data-updated="false" CssClass="btn btn-sm btn-primary" Text="Obtener" ID="btnObtenerTasasExtranjeras" OnClick="btnObtenerTasasExtranjeras_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <i class="text-danger">ATENCIÓN: El proceso de scraping tiene una efectividad variable y toma tiempo(10 a 20 minutos dependiendo de la seleccion). Esto debido a la naturaleza de la página de donde se extrae la data, la cantidad misma de data y a cuestiones de hardware local. Una vez iniciado el proceso de scraping, no se debe actualizar o cerrar el navegador hasta que esta pagina haya lanzado un mensaje de exito o error.</i>

            <br />
        </div>
        <br />
        <div class="container my-4">
            <i>¿Deseas obtener una data de ejemplo?
                <a href="#" onclick="$('#explicacion').toggle();">Click aqui.</a>
            </i>

            <div id="explicacion" class="mt-3" style="display: none;">
                <i class="my-3">Se hara un raspado de prueba en el apartado de créditos, correspondiente unicamente al departamento de Amazonas, en Perú.</i>

                <ol>
                    <li>Haz clic en el botón "obtener data de ejemplo".</li>
                    <li>Espera la finalización del proceso. deberia tomar de 30 segundos a 1 minuto.</li>
                    <li>En la base de datos(ir a SQL Server), revisa la tabla "CostosRendimientosProductosFinancierosCopia".</li>
                </ol>
                <asp:LinkButton runat="server" ID="btnObtenerDataDeEjemplo" CssClass="btnPrueba" OnClick="btnObtenerDataDeEjemplo_Click" OnClientClick="DeshabilitarPrueba(this);" Text="Obtener data de ejemplo" />
            </div>
        </div>
        <div class="container my-4">
            <div id="mensajeError" runat="server"></div>
            <br />
            <asp:Image runat="server" ID="imgEvidencia" Visible="false" />
            <br /><br />
            <div id="infoAdicional" runat="server"></div>
        </div>

    </form>
</body>
</html>

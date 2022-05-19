<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sist.Index" %>


<%--Estas son las etiquetas que le dicen a la página donde esta alojado cada userControl. Son generadas automaticamente.--%>
<%@ Register Src="~/UserControls/UcDatos.ascx" TagPrefix="uc1" TagName="UcDatos" %>
<%@ Register Src="~/UserControls/UcInicio.ascx" TagPrefix="uc1" TagName="UcInicio" %>
<%@ Register Src="~/UserControls/UcPlanes.ascx" TagPrefix="uc1" TagName="UcPlanes" %>
<%@ Register Src="~/UserControls/UcProductos.ascx" TagPrefix="uc1" TagName="UcProductos" %>
<%@ Register Src="~/UserControls/UcLogin.ascx" TagPrefix="uc1" TagName="UcLogin" %>
<%@ Register Src="~/UserControls/UcIndicadores.ascx" TagPrefix="uc1" TagName="UcIndicadores" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Index</title>

</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="row">
            <div class="col-12">
                <div class="d-flex justify-content-center">
                    <%--Este es el encabezado de la página, hania. Aqui se encuentran los botones que ves arriba
                        (Las opciones de inicio, datos, etc.) Haciendo clic en estos botones vas al apartado seleccionado.--%>

                    <%--El funcionamiento es el siguiente: 
                        1.- Una lista ordenada(la etiqueta ul, con las clases "nav nav-pills" y con la opción role="tablist")
                        2.- Contiene a todas las opciones(la etiqueta li con la clase "nav-item").
                        3.- la etiqueta a es el enlace en si mismo, con las clases "nav-link". solo la primera contiene la clase "active"
                            que es la que resalta al enlace de las demas. si quieres resaltar otro enlace, mueve esta clase a dicho enlace.
                        4.- Cada enlace(punto 3) contiene unos atributos que sirven para navegar al apartado correspondiente:
                            4.1.- data-bs-toggle="tab": le indica a la página que se presente al usuario como un tab. Este valor no cambia y es necesario.
                            4.2.- data-bs-target="#nombreDelItem": le dice a que apartado ir. este apartado se encontrara dentro de un userControl,
                                  los cuales veras mas abajo.
                            4.3.- aria-selected="true": le dice a la pagina si el contenido al que apunta la opción debe de estar visible. 
                                  Esta opcion trabaja de forma paralela a la clase "active" (punto 3), de manera que para complementar el punto 3,
                                  deberas poner la clase active donde quieras resaltar dicha opcion y ademas poner el aria-selected="true".
                            4.4.- Los demas elementos son cosméticos y le dan la apariencia que observas a la página.
                        5.- Si quieres agregar o quitar elementos, deberas modificar las etiquetas li con lo que contienen dentro(ver punto 4), 
                            ademas de modificar/agregar/quitar userControls.
                        6.- Notaras que hay etiquetas li(son 7) que userControls(son 5). esto se debe a que el apartado de contacto y del blog 
                            funcionan diferente: contacto abre eso, un formulario de contacto, y blog redirecciona a la pagina que me especificaste 
                            en semanas pasadas.
                    --%>

                    <ul class="nav nav-pills textContent" role="tablist">
                        <li class="nav-item fs-5">
                            <a class="nav-link active" id="item1-tab" data-bs-toggle="tab" data-bs-target="#item1" aria-controls="Item 1" href="#" aria-selected="true">Inicio</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item2-tab" data-bs-toggle="tab" data-bs-target="#item2" aria-controls="Item 2" href="#" aria-selected="false">Datos</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item3-tab" data-bs-toggle="tab" data-bs-target="#item3" aria-controls="Item 3" href="#" aria-selected="false">Suscripción</a>
                        </li>
                        <li class="nav-item fs-5" data-bs-toggle="modal" data-bs-target="#contactModal">
                            <a class="nav-link" id="item4-tab" style="cursor: pointer;">Contáctanos</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item5-tab" aria-controls="Item 5" href="https://techinnova-sac.com/blog" target="_blank" aria-selected="false">Blog</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item6-tab" data-bs-toggle="tab" data-bs-target="#item6" aria-controls="Item 6" href="#" aria-selected="false">Productos</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item7-tab" data-bs-toggle="tab" data-bs-target="#item7" aria-controls="Item 7" href="#" aria-selected="false">Indicadores</a>
                        </li>
                        <li class="nav-item fs-5">
                            <a class="nav-link" id="item8-tab" data-bs-toggle="tab" data-bs-target="#item8" aria-controls="Item 8" href="#" aria-selected="false">Iniciar sesión</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <br />
        <div class="container-fluid p-0">
            <%--Hay que poner un div con la clase "tab-content" para indicarle a la página que aqui inician los apartados.--%>
            <div class="tab-content" id="tabContent">
                <%--Inician los apartados con archivos UserControl. Revisa la carpeta "UserControls" para explorar y modificar su contenido.
                    En el archivo "UcInicio.ascx" vienen instrucciones para modificar el contenido de cualquier userControl.--%>
                <uc1:UcInicio runat="server" ID="UcInicio" />
                <uc1:UcDatos runat="server" ID="UcDatos" />
                <uc1:UcPlanes runat="server" ID="UcPlanes" />
                <uc1:UcProductos runat="server" ID="UcProductos" />
                <uc1:UcIndicadores runat="server" ID="UcIndicadores" />
                <uc1:UcLogin runat="server" ID="UcLogin" />
            </div>
        </div>
        <br />
        <br />
        <%--Este es el footer. Puedes modificarlo tambien.--%>
        <div class="row no-gutters bg-orange text-white">
            <div class="col-12 footer-links footerPage fs-4">
                <br />
                <br />
                <div class="container mx-auto p-0" style="max-width: 1440px">
                    <div class="row">
                        <div class="col-1">
                            <img src="/Images/bank.png" alt="banco" class="w-100" />
                        </div>
                        <div class="col-2 d-flex align-items-center">
                            <ul>
                                <li>Nombre del proyecto</li>
                                <li>Dirección</li>
                                <li>México / Perú</li>
                            </ul>
                        </div>
                    </div>
                    <br />
                    <div class="row-container row no-gutters mt-0">
                        <div class="col-12 col-sm-6 order-2 order-sm-1">
                            <div class="row no-gutters">
                                <div class="col-12">
                                    <p>Institución</p>
                                    <ul>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Mis bancos y financieras</span></a></li>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Inversión Social</span></a></li>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Instituto de valuadores</span></a></li>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Sala de prensa</span></a></li>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Reactiva Nuevo León</span></a></li>
                                    </ul>
                                </div>
                                <div class="col-12">
                                    <p>Unidad Especializada de Atención a Usuarios (UNE)</p>
                                    <ul>
                                        <li>Teléfono (55) 5269 5202</li>
                                        <li>whatsapp 55 7499 1178</li>
                                        <li>une@micorreo.com.mx</li>
                                    </ul>
                                </div>
                                <div class="col-12">
                                    <p>Cualquier acción violatoria a nuestro Código de Ética, leyes y reglamentos comunícate a</p>
                                    <ul>
                                        <li>800-88-54632</li>
                                        <li>(800 - TU - LINEA)</li>
                                        <li>tulineaetica@tipsanonimos.com</li>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">https://www.tipsanonimos.com/tulineaetica</span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-12 col-sm-6 order-3">
                            <div class="row no-gutters">
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Regulación</p>
                                    <ul>
                                        <li><a class="text-white" href="#">Derechos ARCO</a></li>
                                        <li><a class="text-white" href="#">Estados financieros</a></li>
                                        <li><a class="text-white" href="#">Contratos</a></li>
                                    </ul>
                                </div>
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Facturación</p>
                                    <ul>
                                        <li><a class="text-white" href="#"><span class="my-auto">Facturación</span></a></li>
                                        <li><a class="text-white" href="#">Sistema de remuneración</a></li>
                                        <li><a class="text-white" href="#" download="Despachos de Cobranza">Despachos de Cobranza</a></li>
                                    </ul>
                                </div>
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Atención al cliente</p>
                                    <ul>
                                        <li><a class="text-white" href="#">Quejas y Aclaraciones (UNE)</a></li>
                                    </ul>
                                </div>
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Privacidad</p>
                                    <ul>
                                        <li><a class="text-white" href="#">Aviso de privacidad</a></li>
                                        <li><a class="text-white" href="#">Código de Ética</a></li>
                                    </ul>
                                </div>
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Empleados</p>
                                    <ul>
                                        <li><a class="text-white" href="#" target="_blank" rel="noreferrer"><span class="my-auto">Acceso empleados</span></a></li>
                                        <li><a class="text-white" href="#">Crédito</a></li>
                                    </ul>
                                </div>
                                <div class="col-6 col-lg-4 pr-1 px-sm-2">
                                    <p>Costos y comisiones</p>
                                    <ul>
                                        <li><a class="text-white" href="#">Consulta los costos y las comisiones de nuestros productos</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-12 all-rights-reserved order-5 margin-bottom">Proyecto Mexico / Perú , S.A de C.V., S.F.P © 2022</div>
                    </div>
                </div>
            </div>
            <div class="col-12 footer-images">
                <div class="container mx-auto p-0 row d-flex justify-content-center no-gutters" style="max-width: 1440px">
                    <div class="col-auto d-none d-sm-flex align-self-center justify-content-center">
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/7pDLuhJ62W0AvlxYeXZPDp/564638826a0cd9030b7aba665ac1ba80/Condusef-logo.png" alt="logos-condusef" />
                        </a>
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/5OxwzOrdWDLcTKYqSmMcu4/61bf38446212987d58d32dd43fc2e247/une-logo.png" alt="logos-une" />
                        </a>
                        <a href="https://www.gob.mx/cnbv">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/5zrX4gVMp7yCIy4NJ6FDds/a600f51686972a0d279fce04faa1a43a/cnbv-logo.png" alt="logos-cnbv" />
                        </a><a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/13Ygtf3GuHRZRGZ130TTwO/3656b16887c310b6bbee1900842c7a64/buro-ef-logo.png" alt="logos-buro" />
                        </a>
                        <a href="https://www.banxico.org.mx/CAT/" target="_blank" rel="noreferrer">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/1XWLCtTjwJaUcCk01PnFP8/0053b2686f54286e77263ddb2fa6f4fd/banxico-logo.png" />
                        </a>
                    </div>
                    <div class="col-auto d-flex d-sm-none align-self-center justify-content-center">
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/7pDLuhJ62W0AvlxYeXZPDp/564638826a0cd9030b7aba665ac1ba80/Condusef-logo.png" alt="logos-condusef" />
                        </a>
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/5OxwzOrdWDLcTKYqSmMcu4/61bf38446212987d58d32dd43fc2e247/une-logo.png" alt="logos-une" />
                        </a>
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/5zrX4gVMp7yCIy4NJ6FDds/a600f51686972a0d279fce04faa1a43a/cnbv-logo.png" alt="logos-cnbv" />
                        </a>
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/13Ygtf3GuHRZRGZ130TTwO/3656b16887c310b6bbee1900842c7a64/buro-ef-logo.png" alt="logos-buro" />
                        </a>
                        <a href="#">
                            <img src="https://images.ctfassets.net/gmma7trgbtvb/1XWLCtTjwJaUcCk01PnFP8/0053b2686f54286e77263ddb2fa6f4fd/banxico-logo.png" alt="logos-banxico" />
                        </a>
                    </div>
                    <br />
                </div>
            </div>
        </div>

        <div class="modal fade" id="contactModal" tabindex="-1" aria-labelledby="contactModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="contactModalLabel">Contáctanos</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server">Nombre: </asp:Label>
                            </div>
                            <div class="col-8">
                                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server">Teléfono: </asp:Label>
                            </div>
                            <div class="col-8">
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server">Empresa: </asp:Label>
                            </div>
                            <div class="col-8">
                                <asp:TextBox runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server">Correo electrónico: </asp:Label>
                            </div>
                            <div class="col-8">
                                <asp:TextBox runat="server" ID="txtCorreoElectronico" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server">Mensaje: </asp:Label>
                            </div>
                            <div class="col-8">
                                <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control noResize"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning">Enviar mensaje</button>
                    </div>
                </div>
            </div>
        </div>

        <script src="Scripts/Bootstrap/bootstrap.bundle.js"></script>
        <script src="Scripts/fontawesome/all.js"></script>
        <script src="Scripts/jQuery.js"></script>
        <script src="Scripts/jquery-ui-1.13.1/jquery-ui.js"></script>
        <script src="//cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"></script>
        <link href="Styles/Bootstrap/bootstrap.css" rel="stylesheet" />
        <link href="Styles/Custom.css" rel="stylesheet" />
        <link href="Scripts/jquery-ui-1.13.1/jquery-ui.css" rel="stylesheet" />
        <link href="//cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css" rel="stylesheet" />
        <script src="Scripts/jquery.tableToExcel.js"></script>

        <script src="https://code.highcharts.com/highcharts.js"></script>
        <script src="https://code.highcharts.com/modules/series-label.js"></script>
        <script src="https://code.highcharts.com/modules/exporting.js"></script>
        <script src="https://code.highcharts.com/modules/export-data.js"></script>
        <script src="https://code.highcharts.com/modules/accessibility.js"></script>
        <script src="Scripts/Custom.js"></script>
    </form>
</body>
</html>

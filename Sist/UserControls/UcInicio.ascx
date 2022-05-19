<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcInicio.ascx.cs" Inherits="Sist.UserControls.UcDatos" %>

<%--Contenido de las secciones: 
    1.- Todas las secciones estan contenidas en un elemento div(un contenedor) con las clases "tab-pane fade". esta seccion
        ademas contiene las clases "show active", que le dicen a la pagina que se muestre dicha seccion. 
    2.- la seccion contiene un id, que esta ligado a las etiquetas li ya mencionadas en el archivo principal.--%>

<div class="tab-pane fade show active" id="item1" role="tabpanel" aria-labelledby="item1-tab">
    <%--El contenedor--%>
    <%--El resto es el contenido y puedes modificarlo como desees.--%>
    <div class="fondoImgPrincipal text-white d-flex justify-content-center">
        <div class="p-5 text-center">
            <span class="headerPage">TEXTO DE EJEMPLO</span>
            <br />
            <span class="headerPage">TEXTO DE EJEMPLO</span>
            <br />
            <asp:Button runat="server" ID="btnEjemplo" CssClass="btn btn-lg btn-warning" Text="Botón" />
        </div>
    </div>
    <div class="bg-greenAlt">
        <div class="text-white row">
            <div class="col-2"></div>
            <div class="text-center col-8">
                <br />
                <h2 class="subTitle">Texto de subtítulo</h2>
                <br />
                <span class="textContent">Proin eget tincidunt diam. Ut mattis tortor ut nisl tempor, non vestibulum enim vehicula. Etiam non varius velit, nec pulvinar nunc. Sed lacinia semper tincidunt. Suspendisse tempus tincidunt velit, id interdum elit ultrices nec. Nunc in vestibulum elit. Aliquam ultricies vel augue eget placerat. </span>
            </div>
            <div class="col-2">
            </div>
        </div>
        <br />
        <br />
        <br />
        <div class="d-flex justify-content-center textContent">
            <div class="row">
                <div class="col-3 text-center">
                    <img src="Images/Icons/item1.jpg" class="rounded-circle w-50" />
                    <br />
                    <br />
                    <p class="text-white">Descripción 1</p>
                </div>
                <div class="col-3 text-center">
                    <img src="Images/Icons/item1.jpg" class="rounded-circle w-50" />
                    <br />
                    <br />
                    <p class="text-white">Descripción 2</p>
                </div>
                <div class="col-3 text-center">
                    <img src="Images/Icons/item1.jpg" class="rounded-circle w-50" />
                    <br />
                    <br />
                    <p class="text-white">Descripción 3</p>
                </div>
                <div class="col-3 text-center">
                    <img src="Images/Icons/item1.jpg" class="rounded-circle w-50" />
                    <br />
                    <br />
                    <p class="text-white">Descripción 4</p>
                </div>
            </div>
        </div>
        <br />
    </div>
    <br />
    <br />
    <div class="text-center subTitle">
        <h2>Descripción de la sección</h2>
        <i>Donec vehicula purus nec nunc lobortis, et iaculis libero varius. Donec quis arcu sodales, rutrum elit a, rhoncus sem. Integer tristique rutrum nulla tincidunt placerat.</i>
    </div>
    <br />
    <br />
    <br />
    <div class="row textContent">
        <div class="col-3">
            <div class="d-flex justify-content-center">
                <div class="card" style="width: 18rem;">
                    <img src="Images/Icons/item3.jpg" class="card-img-top" alt="" />
                    <div class="card-body">
                        <h5 class="card-title">Card title</h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="#" class="btn btn-success">Adquirir</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="d-flex justify-content-center">
                <div class="card" style="width: 18rem;">
                    <img src="Images/Icons/item4.jpg" class="card-img-top" alt="" />
                    <div class="card-body">
                        <h5 class="card-title">Card title</h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="#" class="btn btn-success">Adquirir</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="d-flex justify-content-center">
                <div class="card" style="width: 18rem;">
                    <img src="Images/Icons/item3.jpg" class="card-img-top" alt="" />
                    <div class="card-body">
                        <h5 class="card-title">Card title</h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="#" class="btn btn-success">Adquirir</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="d-flex justify-content-center">
                <div class="card" style="width: 18rem;">
                    <img src="Images/Icons/item4.jpg" class="card-img-top" alt="" />
                    <div class="card-body">
                        <h5 class="card-title">Card title</h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <a href="#" class="btn btn-success">Adquirir</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--Fin del contenedor--%>

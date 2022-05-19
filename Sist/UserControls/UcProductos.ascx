<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcProductos.ascx.cs" Inherits="Sist.UserControls.UcProductos" %>
<div class="tab-pane fade" id="item6" role="tabpanel" aria-labelledby="item6-tab">
    <div class="container">
        <div class="row">
            <div class="col-3">
                <i>Región:</i>
                <select class="form-control form-control-sm" id="ddlRegion"></select>
            </div>
            <div class="col-3">
                <i>Tipo de operación:</i>
                <select class="form-control form-control-sm" id="ddlTipoOperacion"></select>
            </div>
            <div class="col-3">
                <i>Producto:</i>
                <select class="form-control form-control-sm" id="ddlProducto"></select>
            </div>
            <div class="col-3">
                <i>Condiciones:</i>
                <select class="form-control form-control-sm" id="ddlCondiciones"></select>
            </div>
        </div>
        <br />
        <button class="btn btn-sm btn-warning" id="btnConsultarProductos">Consultar</button>
        <hr />
        <div class="row">
            <div class="col-7">
                <table class="display" id="tblProductos">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Nombre</th>
                            <th id="tdTasa">Tasa TREA</th>
                            <th>Cuota</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-5">
                <div id="grafica">
                </div>
            </div>
        </div>

    </div>
</div>

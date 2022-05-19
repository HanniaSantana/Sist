<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Sist.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-2">
            <i>Región: </i>
            <select id="ddlRegion1" class="form-control form-control-sm"></select>
        </div>
        <div class="col-2">
            <i>Tipo de operación: </i>
            <select id="ddlTipoOperacion" class="form-control form-control-sm"></select>
        </div>
        <div class="col-2">
            <i>Producto: </i>
            <select id="ddlProducto" class="form-control form-control-sm"></select>
        </div>
        <div class="col-2">
            <i>Condiciones: </i>
            <select id="ddlCondiciones" class="form-control form-control-sm"></select>
        </div>
        <div class="col-2 d-flex align-items-end">
            <button id="btnConsulta" class="btn btn-primary btn-sm">Consultar</button>
        </div>
    </div>


    <div class="container textContent">
        <div class="row">
            <div class="col-4 d-flex align-items-center">
                <label class="form-label">Moneda: </label>
                <div class="btn-group mx-2" role="group">
                    <input type="radio" class="btn-check" name="moneda" id="btncheck1" autocomplete="off" checked="checked" />
                    <label class="btn btn-sm btn-outline-warning" for="btncheck1">Soles</label>

                    <input type="radio" class="btn-check" name="moneda" id="btncheck2" autocomplete="off" />
                    <label class="btn btn-sm btn-outline-warning" for="btncheck2">Dólares</label>

                </div>
            </div>
            <div class="col-4">
                <label for="rangoMontos" class="form-label">Monto: </label>
                <label class="form-label float-end rangoMontos">$0.00 </label>
                <input type="range" class="form-range" value="0" min="0" max="5000" step="5" id="rangoMontos" />
            </div>
            <div class="col-4">
                <label for="rangoPlazos" class="form-label">Plazo: </label>
                <label class="form-label float-end plazos">6 cuotas</label>
                <input type="range" class="form-range" value="6" min="6" max="96" step="6" id="rangoPlazos" />
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                <label class="form-label">Región: </label>
                <asp:DropDownList runat="server" ID="ddlRegion" CssClass="form-control form-control-sm">
                    <asp:ListItem Text="Región 1"></asp:ListItem>
                    <asp:ListItem Text="Región 2"></asp:ListItem>
                    <asp:ListItem Text="Región 3"></asp:ListItem>
                    <asp:ListItem Text="Región 4"></asp:ListItem>
                    <asp:ListItem Text="Región 5"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-4">
                <label for="rangoIngresos" class="form-label">Ingresos: </label>
                <label class="form-label float-end">$100.00 </label>
                <input type="range" class="form-range" value="100" min="100" max="5000" step="10" id="rangoIngresos" />
            </div>
            <div class="col-4 d-flex align-items-center justify-content-end">
                <label for="rangoTasas" class="form-label">Considerar tasa: </label>
                <div class="btn-group mx-2" role="group">
                    <input type="radio" class="btn-check" name="tasa" id="btnMinima" autocomplete="off" checked="checked" />
                    <label class="btn btn-sm btn-outline-warning" for="btnMinima">Mínima</label>

                    <input type="radio" class="btn-check" name="tasa" id="btnMaxima" autocomplete="off" />
                    <label class="btn btn-sm btn-outline-warning" for="btnMaxima">Máxima</label>
                </div>
            </div>
        </div>
        <br />
        <div class="row d-flex align-items-center">
            <div class="col-6">
                <asp:Button runat="server" Text="Filtrar resultados" CssClass="btn btn-sm btn-warning" OnClientClick="return false;" />
            </div>
            <div class="col-6">
                <label class="control-label float-end">
                    Mostrando 5 resultados
                </label>
            </div>
        </div>
        <hr />
        <table class="table table-table-bordered table-hover table-responsive fs-7" id="">
            <thead>
                <tr>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td colspan="18">
                        <i>Selecciona una fecha para ver sus costos.</i>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</asp:Content>

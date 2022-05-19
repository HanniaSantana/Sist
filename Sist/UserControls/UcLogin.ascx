<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcLogin.ascx.cs" Inherits="Sist.UserControls.UcLogin" %>
<div class="tab-pane fade" id="item8" role="tabpanel" aria-labelledby="item7-tab">
    <div class="container textContent">
        <div class="d-flex justify-content-center">
            <div class="card w-50">
                <div class="card-body">
                    <div class="card-title">
                        <h4>Acceso a usuarios</h4>
                        <br />
                        <label class="control-label">Correo electrónico: </label>
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control"></asp:TextBox>
                        <label class="control-label">Contraseña: </label>
                        <asp:TextBox runat="server" ID="txtContraseña" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <br />
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnIniciarSesion" Text="Acceder" CssClass="btn btn-sm btn-warning" OnClick="btnIniciarSesion_Click" />
                            <asp:Button runat="server" ID="btnRecuperarCuenta" Text="Recuperar cuenta" CssClass="btn btn-sm btn-warning" />
                            <br />
                            <br />
                            <a href="#">Clic aqui para registrarse
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

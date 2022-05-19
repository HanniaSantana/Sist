<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcDatos.ascx.cs" Inherits="Sist.UserControls.UcDatos1" %>
<div class="tab-pane fade" id="item2" role="tabpanel" aria-labelledby="item2-tab">
    <div class="container textContent">
        <div class="row">
            <div class="col-12">
                <h4 class="my-2">Tasas de interés promedio del sistema bancario</h4>
                <span>Tasas Activas Anuales de las Operaciones en Moneda Nacional Realizadas en los Últimos 30 Días Útiles Por Tipo de Crédito.</span>
                <i class="fechaTasaActiva">Al día de hoy.</i>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-1">
                <i>Fecha: </i>
            </div>
            <div class="col-2">
                <input type="text" class="form-control form-control-sm" id="txtFecha" />
            </div>
            <div class="col-7">
                <a class="btn btn-sm btn-warning" href="#" role="button" id="btnConsultar">Consultar</a>
                <a class="btn btn-sm btn-success" style="display: none" href="#" role="button" id="btnExcelNac">Excel de data nacional</a>
                <a class="btn btn-sm btn-success" style="display: none" href="#" role="button" id="btnExcelExt">Excel de data extranjera</a>
            </div>
        </div>

        <ul class="nav nav-tabs my-4">
            <li class="nav-item">
                <button class="nav-link active" id="monNacTab" data-bs-toggle="tab" data-bs-target="#monedaNacional" type="button" role="tab" aria-controls="monedaNacional" aria-selected="true">Moneda nacional</button>
            </li>
            <li class="nav-item">
                <button class="nav-link" id="monExtTab" data-bs-toggle="tab" data-bs-target="#monedaExtranjera" type="button" role="tab" aria-controls="monedaExtranjera" aria-selected="false">Moneda extranjera</button>
            </li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane fade show active" id="monedaNacional" role="tabpanel">
                <table class="table table-table-bordered table-hover table-responsive fs-7" id="tblDatosNac">
                    <thead>
                        <tr>
                            <th>Tasa Anual (%)</th>
                            <th>BBVA</th>
                            <th>Comercio</th>
                            <th>Crédito</th>
                            <th>Pichincha</th>
                            <th>BIF</th>
                            <th>Scotiabank</th>
                            <th>Citibank</th>
                            <th>Interbank</th>
                            <th>Mibanco</th>
                            <th>GNB</th>
                            <th>Fallabella</th>
                            <th>Santander</th>
                            <th>Ripley</th>
                            <th>Alfin</th>
                            <th>ICBC</th>
                            <th>Bank of china</th>
                            <th>Promedio</th>
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
            <div class="tab-pane fade" id="monedaExtranjera" role="tabpanel">
                <table class="table table-table-bordered table-hover table-responsive fs-7" id="tblDatosExt">
                    <thead>
                        <tr>
                            <th>Tasa Anual (%)</th>
                            <th>BBVA</th>
                            <th>Comercio</th>
                            <th>Crédito</th>
                            <th>Pichincha</th>
                            <th>BIF</th>
                            <th>Scotiabank</th>
                            <th>Citibank</th>
                            <th>Interbank</th>
                            <th>Mibanco</th>
                            <th>GNB</th>
                            <th>Fallabella</th>
                            <th>Santander</th>
                            <th>Ripley</th>
                            <th>Alfin</th>
                            <th>ICBC</th>
                            <th>Bank of china</th>
                            <th>Promedio</th>
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
        </div>
    </div>
</div>

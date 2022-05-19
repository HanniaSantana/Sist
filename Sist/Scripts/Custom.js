$(document).ready(function () {
    ObtenerDataDdl();
    $("#txtFecha").datepicker();
    $('#tblProductos').DataTable({
        language: {
            //esta url cambia el lenguaje de la tabla. no borrar este parametro o la tabla tendra lenguaje en ingles!!!
            url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json'
        }
    });


    Highcharts.setOptions({
        colors: ['#3dc4dd', '#d62d0e']
    });

    PrepararGrafica();
    GraficarTasasTEA();

});

$(".form-range").on("change mousemove", function () {
    var value = $(this).val();
    $(this).prev()
        .html(!$(this).prev().hasClass("plazos") ? "$" + value + ".00" : value + " cuotas");
});

var parameters = {};

function ObtenerDataDdl() {
    var datos;

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ObtenerRegiones',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: "{}",
        success: function (data) {
            datos = data.d;
            var ddl = $("#ddlRegion")
            $.each(datos, function (i, v) {
                ddl.append($('<option>', {
                    value: v.RegionId,
                    text: v.NombreRegion
                }));
            });
        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });

    var ddlTpOp = $('#ddlTipoOperacion');
    var ddlPrFn = $('#ddlProducto');
    var ddlCnPr = $('#ddlCondiciones');

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ObtenerTiposDeOperaciones',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: "{}",
        success: function (data) {
            datos = data.d;

            $.each(datos, function (i, v) {
                ddlTpOp.append($('<option>', {
                    value: v.TipoDeOperacionId,
                    text: v.DescripcionDeOperacion
                }));
            });

            parameters = { tipoDeOperacionId: parseInt(ddlTpOp.val()) };
            ObtenerProductosFinancieros(parameters)
        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });


    ddlTpOp.on('change', function () {
        ddlPrFn.html("");
        ddlCnPr.html("");
        parameters = { tipoDeOperacionId: $(this).val() };
        ObtenerProductosFinancieros(parameters);
    });


    ddlPrFn.on('change', function () {
        ddlCnPr.html("");
        parameters = { productoFinancieroId: $(this).val() };
        ObtenerCondicionesDeProductos($(this).val())
    });
}

function ObtenerProductosFinancieros(parameters) {

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ObtenerProductos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;
            var ddl = $("#ddlProducto")
            $.each(datos, function (i, v) {
                ddl.append($('<option>', {
                    value: v.ProductoFinancieroId,
                    text: v.NombreProductoFianciero
                }));
            });
            ObtenerCondicionesDeProductos(datos[0].ProductoFinancieroId);

        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });
}

function ObtenerCondicionesDeProductos(productoFinancieroId) {
    parameters = { productoFinancieroId: productoFinancieroId };

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ObtenerCondicionesDeProductos',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;
            var ddl = $("#ddlCondiciones")
            $.each(datos, function (i, v) {
                ddl.append($('<option>', {
                    value: v.CondicionDeProductoId,
                    text: v.DescripcionDeCondicion
                }));
            });
        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });
}

$("#btnConsultarProductos").on("click", function () {
    Consultar();
    return false;
});


function Consultar() {
    var regionId = $("#ddlRegion").val();
    var tipoDeOperacionId = $("#ddlTipoOperacion").val();
    var productoFinancieroId = $("#ddlProducto").val();
    var condicionDeProductoId = $("#ddlCondiciones").val();

    var titulo = $("#ddlCondiciones option:selected").text();
    var subTitulo = $("#ddlRegion option:selected").text();

    parameters = { regionId: regionId, productoFinancieroId: productoFinancieroId, condicionDeProductoId: condicionDeProductoId };

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ObtenerCostosRendimientosDeProductosFinancieros',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;
            GenerarTabla(tipoDeOperacionId, datos);
            ActualizarGrafica(titulo, subTitulo, datos);
        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });
}

function GenerarTabla(opcion, datos) {
    var dt = $("#tblProductos").DataTable();
    dt.clear();

    if (opcion == 1) {
        $("#tdTasa").html("Tasa TREA");
        dt.column(3).visible(false);
        $.each(datos, function (i, v) {
            dt.rows.add([["<i class='" + v.Icono + " fa-3x'></i>", v.Nombre, v.TasaTREA + '%', null]]);
        });
    }
    else {
        $("#tdTasa").html("TCEA máxima");
        dt.column(3).visible(true);
        $.each(datos, function (i, v) {
            dt.rows.add([["<i class='" + v.Icono + " fa-3x'></i>", v.Nombre, v.TasaTREA + '%', '$' + v.Cuota]]);
        });
    }

    dt.draw();
}

function PrepararGrafica() {
    Highcharts.chart('grafica', {

        title: {
            text: '',
            widthAdjust: -200
        },

        subtitle: {
            useHTML: true,
            text: "",
            style: {
                paddingTop: "10px"
            }
        },

        yAxis: {
            title: {
                text: ''
            }
        },

        xAxis: {
            accessibility: {
                rangeDescription: ''
            }
        },

        legend: {
            enabled: false
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                }
            }
        },

        series: [{
            name: 'Valor',
            data: []
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
    $("#grafica").hide();
}

function ActualizarGrafica(titulo, subTitulo, datos) {

    var jsonGrafica = [];
    var item = [];
    var xAxis = [];

    $.each(datos, function (i, v) {
        item = [v.Nombre, v.TasaTREA];
        jsonGrafica[i] = item;
        xAxis[i] = v.Nombre;
    });


    var grafica = Highcharts.charts[0];
    grafica.series[0].update({
        data: jsonGrafica
    });

    grafica.update({
        xAxis:
        {
            categories: xAxis
        }
    });

    grafica.setTitle({ text: titulo });
    grafica.setTitle(null, {
        text: 'En ' + subTitulo
    });

    grafica.redraw();
    $("#grafica").show();
}


$("#btnConsultar").on("click", function () {

    var fechaSel = $("#txtFecha").val();
    var parameters = { fecha: fechaSel };

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/TasasMonedaNacional',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;
            var tablaDatos = $("#tblDatosNac tbody");

            tablaDatos.html("");

            $.each(datos, function (i, v) {
                tablaDatos.append("<tr>"
                    + "<td>" + v.Descripcion + "</td>"
                    + "<td>" + v.BBVA + "</td>"
                    + "<td>" + v.Comercio + "</td>"
                    + "<td>" + v.Crédito + "</td>"
                    + "<td>" + v.Pichincha + "</td>"
                    + "<td>" + v.BIF + "</td>"
                    + "<td>" + v.Scotiabank + "</td>"
                    + "<td>" + v.Citibank + "</td>"
                    + "<td>" + v.Interbank + "</td>"
                    + "<td>" + v.Mibanco + "</td>"
                    + "<td>" + v.GNB + "</td>"
                    + "<td>" + v.Falabella + "</td>"
                    + "<td>" + v.Santander + "</td>"
                    + "<td>" + v.Ripley + "</td>"
                    + "<td>" + v.Alfin + "</td>"
                    + "<td>" + v.ICBC + "</td>"
                    + "<td>" + v.BankOfChina + "</td>"
                    + "<td>" + v.Promedio + "</td>"
                    + "</tr>");
            });
            $("#btnExcelNac").show();
        },
        error: function (jqXHR) {
            alert("selecciona una fecha válida.");
            $("#btnExcelNac").hide();
            return false;
        }
    });

    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/TasasMonedaExtranjera',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;
            var tablaDatos = $("#tblDatosExt tbody");

            tablaDatos.html("");

            $.each(datos, function (i, v) {
                tablaDatos.append("<tr>"
                    + "<td>" + v.Descripcion + "</td>"
                    + "<td>" + v.BBVA + "</td>"
                    + "<td>" + v.Comercio + "</td>"
                    + "<td>" + v.Crédito + "</td>"
                    + "<td>" + v.Pichincha + "</td>"
                    + "<td>" + v.BIF + "</td>"
                    + "<td>" + v.Scotiabank + "</td>"
                    + "<td>" + v.Citibank + "</td>"
                    + "<td>" + v.Interbank + "</td>"
                    + "<td>" + v.Mibanco + "</td>"
                    + "<td>" + v.GNB + "</td>"
                    + "<td>" + v.Falabella + "</td>"
                    + "<td>" + v.Santander + "</td>"
                    + "<td>" + v.Ripley + "</td>"
                    + "<td>" + v.Alfin + "</td>"
                    + "<td>" + v.ICBC + "</td>"
                    + "<td>" + v.BankOfChina + "</td>"
                    + "<td>" + v.Promedio + "</td>"
                    + "</tr>");
            });

            $("#btnExcelExt").show();

        },
        error: function (jqXHR) {
            alert("selecciona una fecha válida.");
            $("#btnExcelExt").hide();
            return false;
        }
    });
});

$("#btnExcelNac").on("click", function () {
    $('#tblDatosNac').tblToExcel();
});

$("#btnExcelExt").on("click", function () {
    $('#tblDatosExt').tblToExcel();
});


function GraficarTasasTEA() {
    $.ajax({
        type: 'POST',
        url: 'WebMethods/Metodos.asmx/ChartTEA',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        data: JSON.stringify(parameters),
        success: function (data) {
            datos = data.d;

            var jsonGrafica = [];
            var itemMejor = [];
            var itemPeor = [];
            var xAxis = [];

            $.each(datos, function (i, v) {
                itemMejor = [v.MejorFinanciera, v.valorMejorFinanciera];
                itemPeor = [v.peorFinanciera, v.valorPeorFinanciera];
                jsonGrafica.push(itemMejor);
                jsonGrafica.push(itemPeor);
                xAxis.push(v.Descripcion + " (mejor): " + v.MejorFinanciera);
                xAxis.push(v.Descripcion + " (peor): " + v.peorFinanciera);
            });

            Graficar("grTEA", "Comparativa tasas TEA", jsonGrafica, xAxis);
        },
        error: function (jqXHR) {
            alert(jqXHR.status + " - " + jqXHR.statusText);
            return false;
        }
    });
}

function Graficar(nombre, titulo, dataSource, xAxisSource) {

    Highcharts.chart(nombre, {
        chart: {
            type: 'bar',
            height: (16 / 9 * 100) + '%'
        },
        title: {
            text: titulo,
            widthAdjust: -200
        },

        subtitle: {
            useHTML: true,
            text: "",
            style: {
                paddingTop: "10px"
            }
        },

        yAxis: {
            title: {
                text: ''
            }
        },

        xAxis: {
            categories: xAxisSource,
            accessibility: {
                rangeDescription: ''
            }
        },

        legend: {
            enabled: false
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                dataLabels: {
                    enabled: true,
                    format: '{y} %'
                }
            }
        },

        series: [{
            name: 'Valor',
            data: dataSource
        }]
    });
}
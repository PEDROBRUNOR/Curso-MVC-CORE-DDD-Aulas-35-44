$(document).ready(function () {
    $('.moeda').mask("#.##0,00", { reverse: true });
    $('.data').mask("00/00/0000", { reverse: false });
    $('.int3').mask("000", { reverse: true });
});

function ConfigData() {
    $(".data").datepicker({
        format: "dd/mm/yyyy",
        language: "pt-BR",
        orientation: "bottom left",
        autoclose: true,
        useCurrent: true
    });
}



function ListagemConsulta(table, url, colunas) {
    LigaAguarde();
    $('#' + table).dataTable().fnDestroy();
    $.ajax({
        url: url,
        type: "post",
        dataType: 'json',
        success: function (data) {
            oTable = $("#" + table).dataTable({
                dom: 'Blfrtip',
                buttons: [
                    'excel', 'pdf', 'print'
                ],

                "fnDrawCallback": function (settings) {
                    DesligaAguarde();
                },

                "bAutoWidth": true,
                "destroy": true,
                "stateSave": true,
                "Info": false,
                "bPaginate": true,
                "bLengthChange": true,
                "pageLength": 5,
                "lengthMenu": [02, 05, 10, 20, 30, 40, 50, 70, 80, 90, 100],
                "oLanguage": {
                    "decimal": ",",
                    "thousands": ".",
                    "sProcessing": "Aguarde o Processamento...",
                    "sLengthMenu": "Por Página _MENU_",
                    "sInfo": "",
                    "sZeroRecords": "Não foram encontrados resultados",
                    "sInfoEmpty": "",
                    "sInfoFilterede": "(Filtrado de _MAX_ registros no total",
                    "sInfoFiltered": "",
                    "sInfoPosFix": "",
                    "sSearch": "Buscar",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "Primeiro",
                        "sPrevious": "Anterior",
                        "sNext": "Próximo",
                        "sLast": "Último"
                    },
                },
                data: data,
                columns: colunas
            });
        },
        error: function (data) {

        }
    });

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "currency-pre": function (a) {
            a = replaceall(a, ".", "");
            a = (a === "-") ? 0 : a.replace(/[^\d\-\.]/g, "");
            return parseFloat(a);
        },

        "currency-asc": function (a, b) {
            return a - b;
        },

        "currency-desc": function (a, b) {
            return b - a;

        },

        "date-uk-pre": function (a) {
            var ukDatea = a.split('/');
            return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
        },

        "date-uk-asc": function (a, b) {
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        },

        "date-uk-desc": function (a, b) {
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        }

    });
}

function replaceall(str, replace, with_this) {
    var str_hasil = "";
    var temp;
    if (str != undefined) {
        for (var i = 0; i < str.length; i++) // not need to be equal. it causes the last change: undefined..
        {
            if (str[i] == replace) {
                temp = with_this;
            }
            else {
                temp = str[i];
            }
            str_hasil += temp;
        }
    }
    return str_hasil;
}

function LigaAguarde() {
    $("#aguarde").modal('show');
}

function DesligaAguarde() {
    $("#aguarde").modal('hide');
}

function clearForm() {
    $('.limpa').val('');
}

function ExibeMensagem(tipo, msg) {
    toastr.options = {
        "closeButton": false,
        "debug": true,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    toastr[tipo](msg);
}

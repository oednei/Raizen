// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#tabela-clientes').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
});

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$('.cliente-cep').keydown(function () {
    $('.cep-info, .cep-alert').hide();
});

$('.cliente-cep').focusout(function () {
    $('.cep-alert').show();

    var cep = $(this).val();

    if (cep.length == 8) {
        $.getJSON('https://viacep.com.br/ws/'+ cep +'/json/', function (json_data) {
            console.log(JSON.stringify(json_data));
            console.log(json_data.cep);

            var retMsg = '<b>CEP: </b>' + json_data.cep + '; <b>Logradouro: </b>' + json_data.logradouro + '; <b>Bairro: </b>' + json_data.bairro + ', <b>Cidade: </b>' + json_data.localidade + ', <b>UF: </b>' + json_data.uf;

            $('.cep-alert').hide();
            $('.cep-info').show();

            $('.cep-info .texto').html(retMsg);
        });
    } else
    {
        $('.cep-alert').hide();
        $('.cep-info #texto').show('Não foi encontrado o CEP informado.');
    }
});


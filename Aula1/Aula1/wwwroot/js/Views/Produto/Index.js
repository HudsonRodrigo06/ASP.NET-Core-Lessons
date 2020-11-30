$(function () {
    $("#product-table").DataTable({
        "responsive": true,
        "autoWidth": false,
    });
});

$(document).ready(function () {
    $("#table-filter").on("keyup", function () {
        var value = $(this).val().toUpperCase();
        $("#products-table tbody tr").filter(function () {
            $(this).toggle($(this).text().toUpperCase().indexOf(value) > -1)
        });
    });
});

// JSON
let index = {

    formatar: function (valor) {
        valor = parseFloat(valor);
        return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
    },

    produtos: function () {

        HTTPClient.get("/Produto/Consultar").then(function (retornoServidor) {

            return retornoServidor.json();

        }).then(function (objJson) {

            if (objJson.operacao)
                index.carregarTabela(objJson.lista);
            else
                myalert.errorMsg("Erro ao obter dados dos Produtos!");

        })

    },

    carregarTabela: function (lista) {

        var vCompra = "0";
        var vVenda = "0";
        var novaLinha = "";

        if (lista != null && lista.length > 0) {
            lista.forEach((item) => {

                vCompra = item.precoCompra;
                vVenda = item.precoVenda;

                vCompra = index.formatar(vCompra);
                vVenda = index.formatar(vVenda);

                novaLinha +=
            `<tr>
                <td>${item.id}</td>
                <td>${item.nome}</td>
                <td style="text-align: center">${item.categoria.nome}</td>
                <td style="text-align: right">${vCompra}</td>
                <td style="text-align: right">${vVenda}</td>
                <td id="acoes">
                    <img onclick = "index.telaEditar('${item.id}')" title="Alterar Produto" src="/images/icons/edit-solid.svg" width="20" height="20" />
                    <img  onclick = "index.remover('${item.id}', this)" title="Remover Produto" src="/images/icons/trash-alt-solid.svg" width="20" height="20" style="margin-left: 10px;" />
                </td>
            </tr>`;
                
            });
        }
        else {
            novaLinha += 
                `<tr>
                    <td style="text-align: center">Vazio</td>
                    <td style="text-align: center">Vazio</td>
                    <td style="text-align: center">Vazio</td>
                    <td style="text-align: center">Vazio</td>
                    <td style="text-align: center">-</td>
                </tr>`;
		}
        $("#products-table").append(novaLinha);
        
    },

    // Torna possivel passar a string Json por parametro sem conflitar aspas
    formatarJsonHTML: (str) => {

        return str.replaceAll('"', '*');
    },

    telaCadastrar: function () {
        $.fancybox.open({
            src: '/Produto/Cadastrar',
            type: 'iframe',
            smallBtn: true,
            opts: {
                preload: true
            }
        });
    },

    telaEditar: function (id) {

        //renderiza tela com dados das ViewBags
        $.fancybox.open({
            src: '/Produto/Cadastrar?q=' + id,
            type: 'iframe',
            smallBtn: true,
            opts: {
                preload: true
            }
        });

    },

    // $(elem).closest('tr').find('td').eq('2').text()

    remover: function (produtoId, elem) {


        Swal.fire({
            title: 'Confirma?',
            text: "Realmente deseja remover o produto da base de dados?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sim, remover!'
        }).then((result) => {
            if (result.isConfirmed) {

                HTTPClient.get("/Produto/Remover?q=" + produtoId).then(function (response) {
                    return response.json();
                }).then(function (objJson) {

                    if (objJson.operacao) {
                        $(elem).closest('tr').remove();
                        myalert.onlySucessMsg("Produto removido com sucesso!");
                    }
                    else
                        myalert.errorMsg("Houve algum problema ao remover o produto!");
                })

                
            }
        })



       

	}

}

document.onload = index.produtos();




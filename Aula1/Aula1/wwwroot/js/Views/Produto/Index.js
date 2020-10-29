$(function () {
    $("#product-table").DataTable({
        "responsive": true,
        "autoWidth": false,
    });
});

// JSON
let exibir = {

    formatar: function (valor) {
        return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
	},

    produtos: function () {

        HTTPClient.get("Produto/Consultar").then(function (retornoServidor) {

            return retornoServidor.json();

        }).then(function (objJson) {

            if (objJson.operacao) {

                var novaLinha;
                var cols;

                var lista = JSON.parse(objJson.lista);

                for (var i in lista) {

                    cols = "";
                    novaLinha = $("<tr>");

                    var vCompra = lista[i].PrecoCompra;
                    var vVenda = lista[i].PrecoVenda;

                    vCompra = exibir.formatar(vCompra);
                    vVenda = exibir.formatar(vVenda);

                    cols += "<td>" + lista[i].Nome + "</td>";
                    cols += "<td style='text-align: right'>" + lista[i].Categoria.Nome + "</td>";
                    cols += "<td style='text-align: center'>" + vCompra + "</td>";
                    cols += "<td style='text-align: center'>" + vVenda  + "</td>";

                    var tdAcoes = document.getElementById("acoes");

                    cols += "<td>" + tdAcoes.innerHTML + "</td>";

                    novaLinha.append(cols);
                    $("#products-table").append(novaLinha);
                }
			}

        })

    }
}

document.onload = exibir.produtos();

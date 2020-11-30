$(document).ready(function () {
    $("#table-filter").on("keyup", function () {
        var value = $(this).val().toUpperCase();
        $("#products-table tbody tr").filter(function () {
            $(this).toggle($(this).text().toUpperCase().indexOf(value) > -1)
        });
    });
});

let carrinho = [];

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
                <td id="acoes" style="text-align: center">
                    <img onclick = "index.telaDetalhes('${item.id}')" title="Visualizar" src="/images/icons/eye-regular.svg" width="20" height="20" />
                    <img onclick = "index.adicionarAoCarrinho('${item.id}')" title="Adicionar ao Carrinho de Compras" src="/images/icons/cart-plus-solid.svg" height="20" style="margin-left: 10px" />
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

    exibirCarrinho: function () {


        if (localStorage.getItem("carrinho") != null) {
            $.fancybox.open({
                src: '/Produto/Carrinho',
                type: 'iframe',
                smallBtn: true,
                opts: {
                    preload: true
                }
            });
        }
        else
            myalert.errorMsg("Ocarrinho esta vazio!");
	},

    adicionarAoCarrinho: function (id) {

        //let carrinho = [ { prodid: 12, qtde: 2 } ];
        var repetido = false;

        // existe itens no carrinho
        if (localStorage.getItem("carrinho") != null) {
            carrinho = JSON.parse(localStorage.getItem("carrinho"));

            //verifica se é id repetido para incrementar apenas qtde
            carrinho.forEach( (item) => {

                if (id == item.prodid) {
                    item.qtde++;
                    repetido = true;
				}

            });


            // novo id
            if (!repetido)
                carrinho.push({ prodid: id, qtde: 1});
        }
        // cria localstorage com item
        else
            carrinho.push( { prodid: id, qtde: 1} );

        localStorage.setItem("carrinho", JSON.stringify(carrinho));
        myalert.sucessMsg("Produto adicionado ao carrinho!");

	}


};


document.onload = index.produtos();
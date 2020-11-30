let index = {


    formatar: function (valor) {
        valor = parseFloat(valor);
        return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
    },

    produtos: function () {

        var carrinho = [];
        if (localStorage.getItem("carrinho") != null) {
            carrinho = JSON.parse(localStorage.getItem("carrinho"));

            HTTPClient.post("/Produto/ConsultarCarrinho", carrinho).then(function (retornoServidor) {

                return retornoServidor.json();

            }).then(function (objJson) {

                if (objJson.operacao)
                    index.carregarTabela(objJson.lista);
                else
                    myalert.errorMsg("Erro ao obter dados dos Produtos!");



            });
        }

    },

    carregarTabela: function (lista) {

        var vCompra = "0";
        var vVenda = "0";
        var novaLinha = "";

        var carrinho = [];
        if (localStorage.getItem("carrinho") != null) {

            carrinho = JSON.parse(localStorage.getItem("carrinho"));

            if (lista != null && lista.length > 0) {
                lista.forEach((item) => {

                    vVenda = item.precoVenda;
                    vVenda = index.formatar(vVenda);
                    var qtde = -1;
                    var total = 0;

                    //pega qtde do item no ls
                    carrinho.forEach((itemls) => {

                        if (item.id == itemls.prodid) {
                            qtde = itemls.qtde;
                            total = item.precoVenda * qtde;
                        }

                    });

                    total = index.formatar(total);

                    novaLinha +=
                        `<tr>
                            <td>${item.id}</td>
                            <td>${item.nome}</td>
                            <td style="text-align: center">${item.categoria.nome}</td>
                            <td style="text-align: right">${vVenda}</td>
                            <td style="text-align: right">${qtde}</td>
                            <td style="text-align: right">${total}</td>
                            <td id="acoes" style="text-align: center">
                                <img onclick = "index.remover('${item.id}', this)" title="Remover" src="/images/icons/minus-solid.svg" width="20" height="20" />
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
                        <td style="text-align: center">Vazio</td>
                        <td style="text-align: center">Vazio</td>
                        <td style="text-align: center">-</td>
                    </tr>`;    
            }
            $("#products-table").append(novaLinha);

		}

    }
    

};

document.onload = index.produtos();
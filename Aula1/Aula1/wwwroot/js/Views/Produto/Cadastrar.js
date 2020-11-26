//Nome, Categoria, vCompra, vVenda

let cadastrar = {

	formatarReal: function (valor) {
		valor = parseFloat(valor);
		return valor.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' });
	},

	gravar: function () {

		var _id = document.getElementById("id").value;
		var select = document.getElementById("Categoria");

		var nome = document.getElementById("Nome").value;
		var catid = select.value;
		var cat = select.options[select.selectedIndex].text;
		var vcompra = document.getElementById("vCompra").value;
		var vvenda = document.getElementById("vVenda").value;


		//**** add masks
		
		dados = {
			ProdId: _id,
			Nome: nome,
			catId: catid,
			Categoria: cat,
			vCompra: vcompra,
			vVenda: vvenda
		};

		HTTPClient.post("/Produto/Gravar", dados)
			.then(function (serverResponse) {

				return serverResponse.json();

			}).then(function (objResponse) {

				var vc = cadastrar.formatarReal(dados.vCompra);
				var vv = cadastrar.formatarReal(dados.vVenda);

				myalert.onlySucessMsg(objResponse.msg);

				if (objResponse.operacao)
				{
					// nova linha
					if (_id == null | _id == "0") {

						var novaLinha =
							`<tr>
								<td>${objResponse.id}</td>
								<td>${dados.Nome}</td>
								<td style="text-align: center">${dados.Categoria}</td>
								<td style="text-align: right">${vc}</td>
								<td style="text-align: right">${vv}</td>
								<td id="acoes">
									<img onclick = "index.telaEditar('${objResponse.id}')" title="Alterar Produto" src="/images/icons/edit-solid.svg" width="20" height="20" />
									<img onclick = "index.remover('${objResponse.id}', this)" title="Remover Produto" src="/images/icons/trash-alt-solid.svg" width="20" height="20" style="margin-left: 10px;" />
								</td>
							</tr>`;

						//var table = window.parent.document.getElementById("products-table");
						//table.append(novaLinha);

						$('#products-table', window.parent.document).append(novaLinha);

					}
					// linha alterada
					else {

						$('#products-table > tbody  > tr', window.parent.document).each(function () {

							// aqui tem a linha percorrida (tr)
							var linha = $(this);
																		// $(elem).closest('tr').find('td').eq('2').text()
							// pega valor da coluna do Id
							var vId = linha.find('td').eq(0).text();

							//encontrou linha
							if (vId == _id) {
								//altera os valores
								linha.find('td').eq(1).text(dados.Nome);
								linha.find('td').eq(2).text(dados.Categoria);
								linha.find('td').eq(3).text(vc);
								linha.find('td').eq(4).text(vv);
								return;
							}
						});


					}

					



				}
				else
					myalert.errorMsg(objResponse.msg);

			})

	}





}

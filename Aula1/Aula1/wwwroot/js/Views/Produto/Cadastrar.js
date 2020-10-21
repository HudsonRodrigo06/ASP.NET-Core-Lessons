//Nome, Categoria, vCompra, vVenda

let cadastrar = {

	gravar: function () {

		var nome = document.getElementById("Nome").value;
		var cat = document.getElementById("Categoria").value;
		var vcompra = document.getElementById("vCompra").value;
		var vvenda = document.getElementById("vVenda").value;

		//**** add masks
		
		dados = {
			Nome: nome,
			Categoria: cat,
			vCompra: vcompra,
			vVenda: vvenda
		};

		HTTPClient.post("/Produto/Gravar", dados)
			.then(function (serverResponse) {

				return serverResponse.json();

			}).then(function (objResponse) {

				if (objResponse.operacao)
					myalert.onlySucessMsg(objResponse.msg);
				else
					myalert.errorMsg(objResponse.msg);

			})

	}





}
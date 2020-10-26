//Nome, Categoria, vCompra, vVenda

let cadastrar = {

	gravar: function () {


		var select = document.getElementById("Categoria");

		var nome = document.getElementById("Nome").value;
		var catid = select.value;
		var cat = select.options[select.selectedIndex].text;
		var vcompra = document.getElementById("vCompra").value;
		var vvenda = document.getElementById("vVenda").value;


		alert(document.getElementById("Categoria").innerHTML);

		//**** add masks
		
		dados = {
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

				if (objResponse.operacao)
					myalert.onlySucessMsg(objResponse.msg);
				else
					myalert.errorMsg(objResponse.msg);

			})

	}





}
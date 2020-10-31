let editar = {


	salvarAlteracao: function() {

		let pID = document.getElementById("#id");
		let pNome = document.getElementById("#Nome");
		let vCompra = document.getElementById("#vCompra");
		let vVenda = document.getElementById("#vVenda");

		let sel = document.getElementById("#Categoria");
		let cNome = sel.options[sel.selectedIndex].text;
		let cId = sel.value;

		dados = {
			ID: pID,
			Nome: pNome,
			CatId: cId,
			Categoria: cNome,
			vCompra: vCompra,
			vVenda: vVenda
		};

		HTTPClient.post("Produto/SalvarEdicao", dados).then((response) => {

			return response.json();
		}).then((obJson) => {

			if (obJson.operacao)
				myalert.onlySucessMsg("Alterado com sucesso!");
			else
				myalert.errorMsg("houve algum erro ao reealizar alteração na base de dados!");
		})

	}

}
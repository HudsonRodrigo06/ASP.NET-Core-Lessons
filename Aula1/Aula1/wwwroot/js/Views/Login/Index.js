
$(document).keypress(function (e) {

	var i = $('.swal2-header').length;

	if (i == 0 && e.which == 13) 
		$('#btnEntrar').click();
});





// objeto JS 
// objeto literal: que não nasce da instancia de uma classe

// utilizando objeto como contexto para proteger
let index = {

	logar: function () {

		var email = document.getElementById("email");
		var senha = document.getElementById("senha");
		

		if (email.value.trim() == "" || senha.value.trim() == "") {
			myalert.errorMsg("Todos os campos devem ser preenchidos!");
		}
		else {

			// AJAX - Fetch API
			// fetch("controller/action", config);

			dados = {
				Email: email.value,
				Senha: senha.value,
			}

			HTTPClient.post("Login/Logar", dados)
				.then(function (retornoServidor) {

					return retornoServidor.json(); 

				})
				.then(function (objJson) {


					if (objJson.operacao)
					{
						//dados.Nome = objJson.userName;
						//HTTPClient.post("Default/AtribuirNome", dados).then();
						myalert.sucessMsg("Login efetuado com sucesso!", "default");
					}
					else
						myalert.errorMsg("Login inválido");
					

				})
				.catch(function () {

					myalert.errorMsg("[POST]: Houve algum erro de consistência.");

				})
			
		}
		
	},

	recuperarSenha: function () {

	}


}






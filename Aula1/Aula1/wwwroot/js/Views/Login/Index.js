
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
				Senha: senha.value
			}

			HTTPClient.post("Login/Logar", dados)
				.then(function (retornoServidor) {
					
					return retornoServidor.json(); 

				})
				.then(function (objJson) {

					
					if (objJson.operacao)
					{
						myalert.sucessMsg("Login efetuado com sucesso!", "default");
					}
					else
						myalert.errorMsg("Login inválido");
					

				})
				.catch(function () {

					myalert.errorMsg("[POST]: Houve algum erro de consistência.");

				})

			

			//var url = "Login/Logar?Email='" + dados.Email + "'&Senha='" + dados.Senha + "'";

			//HTTPClient.get(url)
			//	.then(function (retornoServidor) {

			//		return retornoServidor.json();

			//	})
			//	.then(function (objJson) {


			//		if (objJson.operacao) {
			//			index.sucessMsg("Login efetuado com sucesso!");

			//		}


			//	})
			//	.catch(function () {

			//		index.errorMsg("[GET]: Houve algum erro de consistência.");

			//	})

			

			
		}
		
	},

	recuperarSenha: function () {

	}


}



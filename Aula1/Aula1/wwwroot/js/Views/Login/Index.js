
// objeto JS 
// objeto literal: que não nasce da instancia de uma classe

//import { localeData } from "../../../template/plugins/moment/moment-with-locales";

// utilizando objeto como contexto para proteger
let index = {

	errorMsg: function () {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Dados inválidos!'
		})
	},

	sucessMsg: function () {
		Swal.fire(
			'Good job!',
			'Login efetuado com sucesso!',
			'success'

		)
	},

	logar: function () {

		var email = document.getElementById("email");
		var senha = document.getElementById("senha");
		

		if (email.value.trim() == "" || senha.value.trim() == "") {
			this.errorMsg();
		}
		else {

			// AJAX - Fetch API
			// fetch("controller/action", config);

			// configura dados a enviar pro servidor (request)
			let config = {
				method: "POST",
				body: JSON.stringify({
					Email: email.value,
					Senha: senha.value
				}),
				headers: {
					"Content-Type": "application/json"
				}
			}

			//função que envia os dados e recebe o retorno (response)
			fetch("Login/Logar", config) 
				.then(function (retornoServidor) {
					// pega o json string retornado do servidor e transforma em objeto literal
					return retornoServidor.json(); 

				})
				.then(function (objJson) {

					

					this.sucessMsg();

				})
				.catch(function () {

					alert("um erro ocorreu");

				})



			
		}
		
	},

	recuperarSenha: function () {

	}


}



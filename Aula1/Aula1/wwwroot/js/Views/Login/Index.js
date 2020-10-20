
// objeto JS 
// objeto literal: que não nasce da instancia de uma classe

// utilizando objeto como contexto para proteger
let index = {

	logar: function () {

		var email = document.getElementById("email");
		var senha = document.getElementById("senha");

		if (email.value.trim() == "" || senha.value.trim() == "") {
			Swal.fire({
				icon: 'error',
				title: 'Oops...',
				text: 'Dados inválidos!'
			})

			email.focus();
		}
		else {
			/*
				Swal.fire({
				position: 'top-end',
				icon: 'success',
				title: 'Your work has been saved',
				showConfirmButton: false,
				timer: 1500
			})
			*/

			Swal.fire(
				'Good job!',
				'Login efetuado com sucesso!',
				'success'
			)

			//redirect
		}



		
		

	},

	recuperarSenha: function () {

	}


}




// objeto JS 
// objeto literal: que não nasce da instancia de uma classe

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

		/*
				Swal.fire({
				position: 'top-end',
				icon: 'success',
				title: 'Your work has been saved',
				showConfirmButton: false,
				timer: 1500
				})
		*/
	},

	logar: function () {

		var email = document.getElementById("email");
		var senha = document.getElementById("senha");

		

		if (email.value.trim() == "" || senha.value.trim() == "") {
			this.errorMsg();
		}
		else {
			this.sucessMsg();
			//redirect
		}



		
		

	},

	recuperarSenha: function () {

	}


}



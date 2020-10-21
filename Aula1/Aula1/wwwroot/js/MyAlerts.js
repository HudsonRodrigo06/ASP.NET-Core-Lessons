let myalert = {

	// mensagem de erro
	errorMsg: function (msg) {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: msg
		})
	},

	// mensagem de sucesso com redirect
	sucessMsg: function (msg, redirect) {
		Swal.fire(
			'Good job!',
			msg,
			'success'
		).then(function () {
			window.location.href = redirect;
		})

	},

	// apenas mensagem de sucesso
	onlySucessMsg: function (msg) {
		Swal.fire(
			'Good job!',
			msg,
			'success'
		)
	}

}
let myalert = {

	errorMsg: function (msg) {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: msg
		})
	},

	// mensagem e href de redirecionamento, exemplo: login -> default: rediect = "default"
	sucessMsg: function (msg, redirect) {
		Swal.fire(
			'Good job!',
			msg,
			'success'
		).then(function () {
			window.location.href = redirect;
		})

	},

	onlySucessMsg: function (msg) {
		Swal.fire(
			'Good job!',
			msg,
			'success'
		)
	}

}
let myalert = {

	//perguntaMsg: function (elem) {

	//	Swal.fire({
	//		title: 'Confirma?',
	//		text: "Realmente deseja remover o produto da base de dados?",
	//		icon: 'warning',
	//		showCancelButton: true,
	//		confirmButtonColor: '#3085d6',
	//		cancelButtonColor: '#d33',
	//		confirmButtonText: 'Sim, remover!'
	//	}).then((result) => {
	//		if (result.isConfirmed) {

	//			$(elem).closest('tr').remove();

	//			Swal.fire(
	//				'Produto removido!',
	//				'Produto removido com sucesso!',
	//				'success'
	//			)
	//		}
	//	})

	//},

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
			//window.location = redirect;
		})

	},

	// apenas mensagem de sucesso
	onlySucessMsg: function (msg) {
		Swal.fire(
			'Good job!',
			msg,
			'success'
		).then(() => {

			var existeFancy = document.getElementsByClassName("fancybox-iframe");

			if (existeFancy != null)
				window.parent.$.fancybox.close();

		})
	}

}
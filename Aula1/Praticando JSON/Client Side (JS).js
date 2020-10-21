// JavaScript source code


// JS


var index = {


	logar: function () {



		var objClientSide = {
			email: "hud@hud.com",
			senha: "123"
		}


		/* EXEMPLO POST */
		var config = {
			method: "POST",
			body: JSON.stringify(objClientSide),
			headers: {
				"Content-Type" : "application/json"
			}
		}

		fetch("Login/Logar", config)
			.then(function (retornoServidor) {
				return retornoServidor.json();
			})
			.then(function () {

				if (retornoServidor.caraio)
					alert(retornoServidor.msg);
			})
			.catch(function () {
				alert("erro");
			})

		/* EXEMPLO GET */
		var config = {
			method: "GET",  // não tem body
			headers: {
				"Content-Type" : "application/json"
			}
		}

		fetch("Login/Logar?email=hud@hud.com&senha=1234", config)
			.then(function (retornoServidor) {

				return retornoServidor.json();

			})
			.then(function (objJson) {
				if (objJson.caraio)
					alert(objJson.msg);
			})
			.catch(function () {
				alert("erro");
			})


	}

};
let HTTPClient = {

	post: async function (url, obj) {

		HTTPClient.toggleLoading();

		let config = {
			method: "POST",
			body: JSON.stringify(obj),
			headers: {
				"Content-Type": "application/json"
			}
		}

		let p = await fetch(url, config);

		HTTPClient.toggleLoading();

		return p;
	},

	get: async function (url) {


		let config = {
			method: "GET",
			headers: {
				"Content-Type": "application/json"
			}
		}

		HTTPClient.toggleLoading();

		let p = await fetch(url, config);

		HTTPClient.toggleLoading();

		return p;
	},

	toggleLoading: () => {

		var divExiste = document.getElementById("divLoading");

		if (divExiste == null) {

			let div = document.createElement('div');
			div.id = "divLoading";
			div.className = "container-loading";

			let img = document.createElement('img');
			img.src = "/images/gifs/loading.gif";

			div.appendChild(img);
			document.body.appendChild(div);
		}
		else {
			document.body.removeChild(divExiste);
		}
		

	}

}
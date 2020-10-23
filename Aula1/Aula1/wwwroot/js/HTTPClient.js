let HTTPClient = {

	post: function (url, obj) {

		let config = {
			method: "POST",
			body: JSON.stringify(obj),
			headers: {
				"Content-Type": "application/json"
			}
		}

		let p = fetch(url, config);
		return p;
	},

	get: function (url) {


		let config = {
			method: "GET",
			headers: {
				"Content-Type": "application/json"
			}
		}

		let p = fetch(url, config);
		return p;
	}
}
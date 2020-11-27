using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
	public class DefaultController : Controller
	{
		//[Authorize("CookieAuth")]
		public IActionResult Index()
		{
			return View();
		}


		public void AtribuirNome([FromBody] System.Text.Json.JsonElement dados)
		{
			string userName = dados.GetProperty("Nome").ToString();

			if (userName != "")
				ViewData["userName"] = userName;
			else
				ViewData["userName"] = "Bem vindo(a)";
		}

		public IActionResult ExemploJSStorage()
		{
			return View();
		}

	}

}

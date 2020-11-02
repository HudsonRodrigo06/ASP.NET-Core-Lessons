using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aula1.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;

namespace Aula1.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Logar( [FromBody] System.Text.Json.JsonElement dados)
		{
			Usuario user = new Usuario();
			user.Email = dados.GetProperty("Email").ToString();
			user.Senha = dados.GetProperty("Senha").ToString();

			//Thread.Sleep(5000);

			ViewData["userName"] = "";
			if (user.ValidarLogin() && user.getUsuario(user.Email))
				ViewData["userName"] = user.Nome;

			bool ok = ViewBag.userName != "";

			//retorna objeto anonimo
			return Json(new
			{
				operacao = ok,
				userName = user.Nome
			}); 

		}

	}
}

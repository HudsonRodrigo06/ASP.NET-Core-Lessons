using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula1.Models;
using Microsoft.AspNetCore.Mvc;

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

			//retorna objeto anonimo C#
			return Json(new
			{
				operacao = user.ValidarLogin()
			});

		}
	}
}

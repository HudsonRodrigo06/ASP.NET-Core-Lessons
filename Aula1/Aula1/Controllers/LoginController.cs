using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Logar(string usuario, string senha)
		{
			if(usuario == "adm" && senha == "123")
			{

			}
			else
			{
				ViewBag.ErrorLogin = "Dados inválidos";
			}



			return View("Index");
		}
	}
}

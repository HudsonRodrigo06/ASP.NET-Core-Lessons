using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pratice_Aula1.Controllers
{
	public class PrincipalController : Controller
	{
		public IActionResult Index()
		{
			return View("Principal");
		}

		public IActionResult Logar(string user, string pwd)
		{
			if (user == "123")
				ViewBag.Msg = "Login efetuado com sucesso!";
			else
				ViewBag.Msg = "Dados inválidos!";

			return View("Principal");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
	public class UsuarioController : Controller
	{
		//[Authorize("CookieAuth")]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Pesquisar()
		{
			return View();
		}
	}
}

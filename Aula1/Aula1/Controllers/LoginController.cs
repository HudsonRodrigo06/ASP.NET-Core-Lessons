﻿using System;
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

		public IActionResult Logar(Usuario usuario)
		{
			
			if(usuario.Nome == "adm" && usuario.Senha == "123")
			{

			}


			return View("Index");
		}
	}
}

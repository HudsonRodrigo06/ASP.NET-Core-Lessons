﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
	public class CategoriaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Cadastrar()
		{
			return View();
		}
		
	}
}

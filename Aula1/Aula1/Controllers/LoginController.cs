using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
			if(Request.Cookies["CookieAuth"] != null)
				return Redirect("/Default/Index");

			return View();
		}

		public IActionResult Logar( [FromBody] System.Text.Json.JsonElement dados)
		{
			Usuario user = new Usuario();
			bool ok = false;
			user.Email = dados.GetProperty("Email").ToString();
			user.Senha = dados.GetProperty("Senha").ToString();

			
			if (user.ValidarLogin() && user.getUsuario(user.Email))
			{
				ok = true;

				#region gerando Cookie de Autorização

				var userClaims = new List<Claim>();
				
				userClaims.Add(new Claim("id", user.Email));
				userClaims.Add(new Claim("nome", user.Nome));

				//identidades - é possível ter varias
				var identity = new ClaimsIdentity(userClaims, "Identificação do Usuário");

				//define identity princiapal
				ClaimsPrincipal principal = new ClaimsPrincipal(identity);

				//Gerando o cookie.
				Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);

				#endregion


			}



			//retorna objeto anonimo
			return Json(new
			{
				operacao = ok,
				userName = user.Nome
			}); 

		}

	}
}

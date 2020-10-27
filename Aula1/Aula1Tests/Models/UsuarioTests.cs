using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using NuGet.Frameworks;

namespace Aula1.Models.Tests
{
	[TestClass()]
	public class UsuarioTests
	{

		public UsuarioTests()
		{
			Environment.SetEnvironmentVariable("STR_CON", "Server=den1.mysql5.gear.host;Database=lojavirtual1;Uid=lojavirtual1;Pwd=$123456;");
		}

		[TestMethod()]
		public void GravarTest()
		{

			Usuario user = new Usuario(0, "Hud Teste", "hud@hud.com", "123");

			bool ok = user.Gravar();

			Assert.IsTrue(ok);
		}

		[TestMethod()]
		public void ValidarLoginTest()
		{
			Usuario user = new Usuario(0, "Hud Teste", "hud@hud.com", "123");

			bool ok = user.ValidarLogin();

			Assert.IsTrue(ok);
		}

		[TestMethod()]
		public void ValidarLoginErradoTest()
		{
			Usuario user = new Usuario(0, "Hud Teste", "hud@hud.com", "1234");

			bool ok = user.ValidarLogin();

			Assert.IsFalse(ok);
		}

		[TestMethod()]
		public void getUsuarioTest()
		{
			Usuario user = new Usuario();
			bool ok = user.getUsuario(2);

			Assert.IsTrue(ok);
		}

		[TestMethod()]
		public void getUsuariosTest()
		{
			bool ok = false;
			Usuario usr = new Usuario();

			var list = usr.getUsuarios("hud");

			Assert.IsTrue(list.Count > 0);
		}
	}
}
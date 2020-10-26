using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula1.Models.Tests
{
	[TestClass()]
	public class UsuarioTests
	{
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
	}
}
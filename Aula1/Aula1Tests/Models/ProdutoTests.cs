using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aula1.Models.Tests
{
	[TestClass()]
	public class ProdutoTests
	{
		[TestMethod()]
		public void GravarTest()
		{
			Produto prod = new Produto("Tenis XDXD", new Categoria(1, "Calçados"), 333, 666);


			bool ok = prod.Gravar();

			Assert.IsTrue(ok);
		}
	}
}
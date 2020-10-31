using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Aula1.DAL;

namespace Aula1.Models.Tests
{
	[TestClass()]
	public class ProdutoTests
	{

		public ProdutoTests()
		{
			Environment.SetEnvironmentVariable("STR_CON", "Server=den1.mysql5.gear.host;Database=lojavirtual1;Uid=lojavirtual1;Pwd=$123456;");
		}

		[TestMethod()]
		public void GravarTest()
		{
			Produto prod = new Produto("Tenis XDXD", new Categoria(1, "Calçados"), 333, 666);


			bool ok = prod.Gravar();

			Assert.IsTrue(ok);
		}

		[TestMethod()]
		public void getProdutosTest()
		{
			ProdutoDAL pd = new ProdutoDAL();
			List<Produto> prods = pd.getProdutos();

			Assert.IsTrue(prods.Count > 0);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			bool ok = false;

			Produto p = new Produto();
			p.Id = 2;

			ok = p.Remover();

			Assert.IsTrue(ok);
		}
	}
}
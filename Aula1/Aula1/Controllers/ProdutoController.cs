using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula1.DAL;
using Aula1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Aula1.Controllers
{
	public class ProdutoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Cadastrar(string q)
		{
			//edit
			if (q != null && !q.Equals("0"))
			{
				int id = Convert.ToInt32(q);

				Produto p = new Produto().getProduto(id);

				ViewBag.Title = "Editar Produto";
				ViewBag.Produto = p;
			}
			//new
			else
			{
				ViewBag.Title = "Cadastrar Produto";
				ViewBag.Produto = null;
			}



			return View();
		}

		public IActionResult Gravar([FromBody] System.Text.Json.JsonElement dados)
		{
			string msg = "";
			bool operacao = false;
			Produto prod = new Produto();

			string sId = dados.GetProperty("ProdId").ToString();
			int id = 0;

			if (sId != null && !sId.Equals("0"))
				id = Convert.ToInt32(sId);

			try
			{
				int catId = Convert.ToInt32(dados.GetProperty("catId").ToString());
				
				prod.Nome = dados.GetProperty("Nome").ToString();
				prod.Categoria = new Categoria(catId, dados.GetProperty("Categoria").ToString());
				prod.PrecoCompra = decimal.Parse(dados.GetProperty("vCompra").ToString());
				prod.PrecoVenda = decimal.Parse(dados.GetProperty("vVenda").ToString());


				if(id > 0)
				{
					prod.Id = id;
					if (prod.Alterar())
					{
						operacao = true;
						msg = "Produto " + prod.Nome + " foi alterado com sucesso!";
					}
					else
						msg = "Houve algum problema ao alterar " + prod.Nome + " no Banco de Dados.";
				}
				else
				{
					if (prod.Gravar())
					{
						prod.Id = prod.getMaxPK();
						operacao = true;
						msg = "Produto " + prod.Nome + " foi cadastrado com sucesso!";
					}
					else
						msg = "Houve algum problema ao gravar " + prod.Nome + " no Banco de Dados.";
				}


				

			}
			catch (Exception ex)
			{
				msg = "[Produto/Cadastrar]: " + ex.Message;
			}



			return Json(new
			{
				operacao = operacao,
				msg = msg,
				id = prod.Id

			});
		}

		public IActionResult Consultar() // refazer usando Produto e nao Produto DAL
		{
			ProdutoDAL pd = new ProdutoDAL();
			List<Produto> lista = new List<Produto>();

			lista = pd.getProdutos();

			//string sLista = JsonSerializer.Serialize(lista);
			bool ok = (lista != null);

			return Json(new
				{
					operacao = ok,
					lista = lista
			}
			);
		}

		public IActionResult Remover(string q)
		{
			Produto p = new Produto();

			p.Id = Convert.ToInt32(q);

			bool ok = p.Remover();

			return Json(new
			{
				operacao = ok
			});

		}

		/// <summary>
		/// Alimenta ViewBags
		/// </summary>
		/// <param name="dados">Dados json frombody</param>
		public void AlimentarDados([FromBody] System.Text.Json.JsonElement dados)
		{
			Produto prod = new Produto();
			Categoria cat = new Categoria();

			try
			{
				cat.Id = Convert.ToInt32(dados.GetProperty("CatId").ToString());
				cat.Nome = dados.GetProperty("Categoria").ToString();

				prod.Id = Convert.ToInt32(dados.GetProperty("ProdutoId").ToString());
				prod.Nome = dados.GetProperty("Nome").ToString();
				prod.PrecoCompra = decimal.Parse(dados.GetProperty("vCompra").ToString());
				prod.PrecoVenda = decimal.Parse(dados.GetProperty("vVenda").ToString());

				/* ALIMENTA VIEWBAGS */
				ViewBag.Produto = prod;
				ViewBag.Categoria = cat;
			}
			catch
			{ }
		}

		public IActionResult Editar()
		{

			return View();
		}


		public IActionResult SalvarEdicao([FromBody] System.Text.Json.JsonElement dados)
		{
			Produto prod = new Produto();
			bool ok = false;

			try
			{
				int catId = Convert.ToInt32(dados.GetProperty("CatId").ToString());

				prod.Id = Convert.ToInt32(dados.GetProperty("ID").ToString());
				prod.Nome = dados.GetProperty("Nome").ToString();
				prod.Categoria = new Categoria(catId, dados.GetProperty("Categoria").ToString());
				prod.PrecoCompra = decimal.Parse(dados.GetProperty("vCompra").ToString());
				prod.PrecoVenda = decimal.Parse(dados.GetProperty("vVenda").ToString());

				ok = prod.Alterar();
			}
			catch (Exception)
			{

			}

			return Json(new
			{
				operacao = ok
			});
		}
	

	}
}

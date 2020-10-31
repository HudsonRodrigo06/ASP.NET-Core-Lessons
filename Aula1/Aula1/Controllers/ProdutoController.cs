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


		public IActionResult Cadastrar()
		{	
			
			return View();
		}

		public IActionResult Gravar([FromBody] System.Text.Json.JsonElement dados)
		{
			string msg = "";
			bool operacao = false;
			Produto prod = new Produto();

			try
			{
				int catId = Convert.ToInt32(dados.GetProperty("catId").ToString());
				
				prod.Nome = dados.GetProperty("Nome").ToString();
				prod.Categoria = new Categoria(catId, dados.GetProperty("Categoria").ToString());
				prod.PrecoCompra = decimal.Parse(dados.GetProperty("vCompra").ToString());
				prod.PrecoVenda = decimal.Parse(dados.GetProperty("vVenda").ToString());

				if (prod.Gravar())
				{
					operacao = true;
					msg = "Produto " + prod.Nome + " foi cadastrado com sucesso!";
				}
				else
					msg = "Houve algum problema ao gravar " + prod.Nome + " no Banco de Dados.";

			}
			catch (Exception ex)
			{
				msg = "[Produto/Cadastrar]: " + ex.Message;
			}



			return Json(new
			{
				operacao = operacao,
				msg = msg

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


	}
}

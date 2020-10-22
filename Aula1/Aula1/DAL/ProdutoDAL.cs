using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class ProdutoDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();

		public int Gravar(Produto prod)
		{
			// Mapeamento Objeto-Relacional --> transformar objeto em linha de tabela do banco
			string sql =
				@"insert usuario (Nome, Categoria, vCompra, vVenda) 
					values (@Nome, @Categoria, @vCompra, @vVenda)";

			Dictionary<string, object> parametros = new Dictionary<string, object>();

			parametros.Add("@Nome", prod.Nome);
			parametros.Add("@Categoria", prod.Categoria.Id);
			parametros.Add("@vCompra", prod.PrecoCompra);
			parametros.Add("@vVenda", prod.PrecoVenda);

			return _bd.ExecuteNonQuery(sql, parametros);
		}
	}
}

using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class ProdutoDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();

		public bool Gravar(Produto prod)
		{
			// Mapeamento Objeto-Relacional --> transformar objeto em linha de tabela do banco
			string sql =
				@"insert into produto (Nome, CategoriaId, vCompra, vVenda) 
					values (@Nome, @CategoriaId, @vCompra, @vVenda)";

			Dictionary<string, object> parametros = new Dictionary<string, object>();

			parametros.Add("@Nome", prod.Nome);
			parametros.Add("@CategoriaId", prod.Categoria.Id);
			parametros.Add("@vCompra", prod.PrecoCompra);
			parametros.Add("@vVenda", prod.PrecoVenda);

			return _bd.ExecuteNonQuery(sql, parametros) > 0;
		}

		public bool Remover(int id)
		{
			string sql = "DELETE from produto where ProdutoId = " + id;

			return _bd.ExecuteNonQuery(sql) > 0;

		}

		public bool Alterar(Produto p)
		{
			string sql = @"UPDATE 
								produto 
							SET
								Nome = @pNome,
								CategoriaId = @cID,
								vCompra = @pCompra,
								vVenda = @pVenda
							WHERE
								ProdutoId = @pId";

			try
			{
				Dictionary<string, object> parametros = new Dictionary<string, object>();


				parametros.Add("@pId", p.Id);
				parametros.Add("@pNome", p.Nome);
				parametros.Add("@cID", p.Categoria.Id);
				parametros.Add("@pCompra", p.PrecoCompra);
				parametros.Add("@pVenda", p.PrecoVenda);

				return _bd.ExecuteNonQuery(sql, parametros) > 0;
			}
			catch {	}

			return false;
		}

		public int getMaxPK()
		{
			int maxPK = -1;
			string sql = @"SELECT 
								MAX(ProdutoId) as MaxPK
							FROM
								produto";

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);
				if (dr.Read())
					maxPK = Convert.ToInt32(dr["MaxPK"]);
			}
			catch { }
			finally
			{
				_bd.Fechar();
			}

			return maxPK;
		}

		private List<Produto> Map(DbDataReader dr)
		{
			List<Produto> prods = new List<Produto>();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Produto p = new Produto();
					Categoria cat = new Categoria();

					int catId = Convert.ToInt32(dr["CategoriaId"]);
					if (cat.getCategoria(catId))
					{
						p.Categoria = cat;

						p.Id = Convert.ToInt32(dr["ProdutoId"]);
						p.Nome = Convert.ToString(dr["NomeProd"]);
						p.PrecoCompra = Convert.ToDecimal(dr["vCompra"].ToString());
						p.PrecoVenda = Convert.ToDecimal(dr["vVenda"].ToString());

						prods.Add(p);
					}
					else
						throw new Exception("[ProdutoDAL/Map]: " + "Erro ao buscar CategoriaId");
				}
			}

			return prods;
		}



		/// <summary>
		/// Retorna todos os produtos da base de dados
		/// </summary>
		/// <returns></returns>
		public List<Produto> getProdutos()
		{
			string sql =
					@"select 
						ProdutoId, p.Nome AS NomeProd, c.Nome AS NomeCat, vCompra, vVenda, p.CategoriaId 
					  from 
						produto p 
					  JOIN 
						categoria c 
					  ON 
						p.CategoriaId = c.CategoriaId
					  ORDER BY 
						p.ProdutoId";

			List<Produto> lista = new List<Produto>();

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);
				lista = Map(dr);	
			}
			catch
			{
				
			}
			finally
			{
				if(!_bd._manterConexaoAberta)
					_bd.Fechar();
			}

			return lista;
		}

		public Produto getProduto(int id)
		{
			string sql =
					@"select 
						*
					  from 
						produto p 
					  WHERE
						p.ProdutoId = " + id;

			Produto p = new Produto();

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);

				if (dr.Read())
				{
					Categoria cat = new Categoria();

					int catId = Convert.ToInt32(dr["CategoriaId"]);
					if (cat.getCategoria(catId))
					{
						p.Categoria = cat;

						p.Id = Convert.ToInt32(dr["ProdutoId"]);
						p.Nome = Convert.ToString(dr["Nome"]);
						p.PrecoCompra = Convert.ToDecimal(dr["vCompra"].ToString());
						p.PrecoVenda = Convert.ToDecimal(dr["vVenda"].ToString());
					}
					else
						throw new Exception("[ProdutoDAL/getProduto]: " + "Erro ao buscar CategoriaId");
				}


			}
			catch
			{

			}
			finally
			{
				if (!_bd._manterConexaoAberta)
					_bd.Fechar();
			}

			return p;
		}
	}
}

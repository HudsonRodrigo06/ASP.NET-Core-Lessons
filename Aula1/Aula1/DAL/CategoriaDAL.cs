using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class CategoriaDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();


		public bool getCategoria(int id, Categoria cat)
		{
			string sql = $"select * from categoria where CategoriaId = {id}";
			bool ok = false;

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);

				if (dr.HasRows)
				{
					ok = dr.Read();
					cat.Id = id;
					cat.Nome = dr["Nome"].ToString();

					ok = true;
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

			return ok;
		}
		
	}
}

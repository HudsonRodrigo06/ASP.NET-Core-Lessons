using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class UsuarioDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();

		public int Gravar(Usuario usuario)
		{
			// Mapeamento Objeto-Relacional --> transformar objeto em linha de tabela do banco
			string sql =
				@"insert usuario (Nome, Email, Senha) 
					values (@Nome, @Email, @Senha)";

			Dictionary<string, object> parametros = new Dictionary<string, object>();
			
			parametros.Add("@Nome", usuario.Nome);
			parametros.Add("@Email", usuario.Email);
			parametros.Add("@Senha", usuario.Senha);

			return _bd.ExecuteNonQuery(sql, parametros);
		}


	}
}

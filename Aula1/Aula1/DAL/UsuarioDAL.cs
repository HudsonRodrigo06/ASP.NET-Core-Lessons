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
				@"INSERT usuario (Nome, Email, Senha) 
					VALUES (@Nome, @Email, @Senha)";

			Dictionary<string, object> parametros = new Dictionary<string, object>();
			
			parametros.Add("@Nome", usuario.Nome);
			parametros.Add("@Email", usuario.Email);
			parametros.Add("@Senha", usuario.Senha);

			return _bd.ExecuteNonQuery(sql, parametros);
		}

		public int Existe(Usuario usuario)
		{
			string sql =

				@"SELECT * FROM usuario WHERE Email = `@Email` AND Senha = `@Senha`";

			Dictionary<string, object> parametros = new Dictionary<string, object>();

			parametros.Add("@Email", usuario.Email);
			parametros.Add("@Senha", usuario.Senha);

			return _bd.ExecuteNonQuery(sql, parametros);
		}


	}
}

using Aula1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class UsuarioDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();

		public bool Gravar(Usuario usuario)
		{
			// Mapeamento Objeto-Relacional --> transformar objeto em linha de tabela do banco
			string sql =
				@"INSERT usuario (Nome, Email, Senha) 
					VALUES (@Nome, @Email, @Senha)";

			Dictionary<string, object> parametros = new Dictionary<string, object>();
			
			parametros.Add("@Nome", usuario.Nome);
			parametros.Add("@Email", usuario.Email);
			parametros.Add("@Senha", usuario.Senha);

			return _bd.ExecuteNonQuery(sql, parametros) > 0;
		}

		public bool getUsuario(int id, Usuario usr)
		{
			string sql =

				 $"SELECT * FROM usuario WHERE UsuarioId = {id}";


			try
			{
				MySqlDataReader dr = _bd.ExecuteQuery(sql);
				dr.Read();

				if (dr.HasRows)
				{
					usr.Id = Convert.ToInt32(dr["UsuarioId"]);
					usr.Nome = Convert.ToString(dr["Nome"]);
					usr.Email = Convert.ToString(dr["Email"]);
					usr.Senha = Convert.ToString(dr["Senha"]);

					return true;
				}
				return false;
			}
			catch(Exception ex)
			{
				return false;
			}
			finally
			{
				_bd.Fechar();
			}
		}

		public bool ValidarUsuario(Usuario usuario)
		{
			string sql =

				@"SELECT * FROM usuario WHERE Email = @Email AND Senha = @Senha";

			Dictionary<string, object> parametros = new Dictionary<string, object>();

			parametros.Add("@Email", usuario.Email);
			parametros.Add("@Senha", usuario.Senha);

			object dados = _bd.ExecuteQueryScalar(sql, parametros);

			return (dados != null && Convert.ToInt32(dados) > 0);
		}


	}
}

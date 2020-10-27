using Aula1.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

		public List<Usuario> getUsuarios(string nome)
		{
			_bd.Abrir();

			List<Usuario> users = new List<Usuario>();
			string sql = $@"select *
							from usuario
							where nome like @Nome";

			Dictionary<string, object> parametros = new Dictionary<string, object>();

			parametros.Add("@Nome", "%" + nome + "%");

			DbDataReader dr = _bd.ExecuteQuery(sql, parametros);

			users = Map(dr);

			_bd.Fechar();

			return users;
		}

		/// <summary>
		/// Coleta os dados de Usuarios e alimenta uma lista para o retorno
		/// </summary>
		/// <param name="dr">DataReader com dados</param>
		/// <returns></returns>
		private List<Usuario> Map(DbDataReader dr)
		{
			List<Usuario> users = new List<Usuario>();

			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Usuario usr = new Usuario();

					usr.Id = Convert.ToInt32(dr["UsuarioId"]);
					usr.Nome = Convert.ToString(dr["Nome"]);
					usr.Email = Convert.ToString(dr["Email"]);
					usr.Senha = Convert.ToString(dr["Senha"]);

					users.Add(usr);
				}
			}

			return users;
		}

		/// <summary>
		/// Busca dados do usuario por Id e preenche no objeto Usuario passado por parâmetro
		/// </summary>
		/// <param name="id">Usuario Id</param>
		/// <param name="usr">Objeto a ser preenchido</param>
		/// <returns></returns>
		public bool getUsuario(int id, Usuario usr)
		{
			string sql =

				 $"SELECT * FROM usuario WHERE UsuarioId = {id}";

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);
				
				dr.Read();
				usr = Map(dr).First();

				return true;
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

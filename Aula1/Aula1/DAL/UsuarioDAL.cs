using Aula1.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Aula1.DAL
{
	public class UsuarioDAL
	{
		MySqlPersistence _bd = new MySqlPersistence();

		public bool Gravar(Usuario usuario)
		{
			bool ok = false;

			#region Usar outra conexão para transações que precisam se manterem abertas, como o Gravar() varios itens de tabelas diferentes ou vários selects

			MySqlPersistence _localbd = new MySqlPersistence(true); // true mantem a conexao aberta
			
			#endregion

			try
			{
				_localbd.IniciarTransacao(); // a partir daqui, abre transação e o codigo está protegido

				// Mapeamento Objeto-Relacional --> transformar objeto em linha de tabela do banco
				string sql =
					@"INSERT usuario (Nome, Email, Senha) 
					VALUES (@Nome, @Email, @Senha)";

				Dictionary<string, object> parametros = new Dictionary<string, object>();

				parametros.Add("@Nome", usuario.Nome);
				parametros.Add("@Email", usuario.Email);
				parametros.Add("@Senha", usuario.Senha);

				int qtdeLinhas = _localbd.ExecuteNonQuery(sql, parametros);
				ok = qtdeLinhas > 0;

				// confirma transacao
				_localbd.TransacaoCommit();

			}
			catch
			{

				_localbd.TransacaoRollback();
			}
			finally
			{
				_localbd.Fechar();
				
			}

			return ok;
		}

		public List<Usuario> Pesquisar(string nome)
		{
			List<Usuario> users = new List<Usuario>();
			string sql = $@"select *
							from usuario
							where nome like @Nome";

			try
			{
				Dictionary<string, object> parametros = new Dictionary<string, object>();

				parametros.Add("@Nome", "%" + nome + "%");

				DbDataReader dr = _bd.ExecuteQuery(sql, parametros);

				users = Map(dr);
			}
			catch
			{

				return null;
			}
			finally
			{
				if (!_bd._manterConexaoAberta)
					_bd.Fechar();
			}

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

				 @$"SELECT * FROM usuario WHERE UsuarioId = {id}";

			try
			{
				DbDataReader dr = _bd.ExecuteQuery(sql);
				
				//dr.Read();
				usr = Map(dr).First();

				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if (!_bd._manterConexaoAberta)
					_bd.Fechar();
			}
		}

		public bool getUsuario(string email, Usuario usr)
		{
			string sql =
				 @$"SELECT * FROM usuario WHERE Email = @Email and Senha = @Senha";

			try
			{
				Dictionary<string, object> parametros = new Dictionary<string, object>();

				parametros.Add("@Email", email);
				parametros.Add("@Senha", usr.Senha);

				DbDataReader dr = _bd.ExecuteQuery(sql, parametros);

				usr.Nome = Map(dr).First().Nome;

				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				if (!_bd._manterConexaoAberta)
					_bd.Fechar();
			}
		}

		public bool ValidarUsuario(Usuario usuario)
		{
			string sql =

				@"SELECT * FROM usuario WHERE Email = @Email AND Senha = @Senha";

			bool ok = false;

			try
			{
				Dictionary<string, object> parametros = new Dictionary<string, object>();

				parametros.Add("@Email", usuario.Email);
				parametros.Add("@Senha", usuario.Senha);

				object dados = _bd.ExecuteQueryScalar(sql, parametros);

				ok = (dados != null && Convert.ToInt32(dados) > 0);
			}
			catch(Exception ex)
			{
				Console.WriteLine("UsuarioDAL/ValidarUsuaio: " + ex.Message);
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

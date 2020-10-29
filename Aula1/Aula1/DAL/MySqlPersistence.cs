using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula1.Models;
using MySql.Data.MySqlClient;

namespace Aula1.DAL
{
	public class MySqlPersistence
	{
		MySqlConnection _conexao { get; set; }
		MySqlCommand _cmd { get; set; }
		MySqlTransaction _transacao { get; set; }

		public int _ultimoId { get; set; }
		
		public bool _manterConexaoAberta = false;


		public MySqlPersistence(bool manterConexaoAberta = false)
		{
			string StrCon = Environment.GetEnvironmentVariable("STR_CON");
			_manterConexaoAberta = manterConexaoAberta;

			_conexao = new MySqlConnection(StrCon);
			_cmd = _conexao.CreateCommand();

		}

		public void IniciarTransacao()
		{
			Abrir();
			_transacao = _conexao.BeginTransaction();
			_cmd.Transaction = _transacao;
		}

		public void TransacaoCommit()
		{
			if(_transacao != null)
			{
				_transacao.Commit();
				_transacao.Dispose();
				_transacao = null;
			}
		}

		public void TransacaoRollback()
		{
			if (_transacao != null)
			{
				_transacao.Rollback();
				_transacao.Dispose();
				_transacao = null;
			}
		}

		public void Abrir()
		{
			if (_conexao.State != System.Data.ConnectionState.Open)
				_conexao.Open();
		}

		public void Fechar()
		{
			_conexao.Close();
		}

		/// <summary>
		///		Executa INSERT, DELETE, UPDATE ou Stored Procedures
		/// </summary>
		/// <param name="sql">Comando SQL</param>
		/// <returns>Quantidade de linhas afetadas</returns>
		public int ExecuteNonQuery(string sql, Dictionary<string, object> parametros = null)
		{
			Abrir();

			_cmd.CommandText = sql;

			if(parametros != null)
				foreach (var p in parametros)
				{
					_cmd.Parameters.AddWithValue(p.Key, p.Value);
				}


			int linhasAfetadas = _cmd.ExecuteNonQuery();
			_ultimoId = (int)_cmd.LastInsertedId;

			if(!_manterConexaoAberta)
				Fechar();

			return linhasAfetadas;
		}

		public object ExecuteQueryScalar(string sql, Dictionary<string, object> parametros = null)
		{
			Abrir();

			_cmd.CommandText = sql;

			if (parametros != null)
				foreach (var p in parametros)
				{
					_cmd.Parameters.AddWithValue(p.Key, p.Value);
				}


			object retorno = _cmd.ExecuteScalar();

			//if (!_manterConexaoAberta)
			//	Fechar();

			return retorno;
		}

		public DbDataReader ExecuteQuery(string sql, Dictionary<string, object> parametros = null)
		{
			Abrir();

			_cmd.CommandText = sql;

			if (parametros != null)
				foreach (var p in parametros)
				{
					_cmd.Parameters.AddWithValue(p.Key, p.Value);
				}

			MySqlDataReader leitor = _cmd.ExecuteReader();

			//if (!_manterConexaoAberta)
				//Fechar();

			return leitor;
		}

		public void limparParametros()
		{
			_cmd.Parameters.Clear();
		}
		

	}
}

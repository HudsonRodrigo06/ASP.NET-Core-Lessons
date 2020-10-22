using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula1.Models;
using MySql.Data.MySqlClient;

namespace Aula1.DAL
{
	public class MySqlPersistence
	{
		public MySqlConnection _conexao { get; set; }
		public MySqlCommand _cmd { get; set; }

		public int _ultimoId { get; set; }


		public MySqlPersistence()
		{
			_conexao = new MySqlConnection("Server=den1.mysql5.gear.host;Database=lojavirtual1;Uid=lojavirtual1;Pwd=$123456;");
			_cmd = _conexao.CreateCommand();

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

			Fechar();

			return linhasAfetadas;
		}

		/// <summary>
		/// Executa Consultas SELECT
		/// </summary>
		/// <param name="sql">Comando SQL</param>
		/// <param name="parametros">Chave para substituir e Valor ex: ("@Email", "a@a.com")</param>
		/// <returns>Quantidade de linhas afetadas</returns>
		public int ExecuteQuery(string sql, Dictionary<string, object> parametros = null)
		{
			Abrir();

			_cmd.CommandText = sql;

			if (parametros != null)
				foreach (var p in parametros)
				{
					_cmd.Parameters.AddWithValue(p.Key, p.Value); // <-- AQUI PARECE NAO ESTAR SUBSTITUINDO
				}


			int linhasAfetadas = _cmd.ExecuteNonQuery();
			_ultimoId = (int)_cmd.LastInsertedId;

			Fechar();

			return linhasAfetadas;
		}

	}
}

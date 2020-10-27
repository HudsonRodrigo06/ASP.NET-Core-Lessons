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
		public MySqlConnection _conexao { get; set; }
		public MySqlCommand _cmd { get; set; }

		public int _ultimoId { get; set; }


		public MySqlPersistence()
		{
			string StrCon = Environment.GetEnvironmentVariable("STR_CON");

			_conexao = new MySqlConnection(StrCon);
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

			Fechar();

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

			//Fechar();

			return leitor;
		}

		public List<Produto> getProdutos(string sql)
		{
			List<Produto> produtos = new List<Produto>();
			Abrir();

			_cmd.CommandText = sql;

			MySqlDataReader reader = _cmd.ExecuteReader();

			while (reader.Read())
			{   // ProdutoId, p.Nome AS NomeProd, c.Nome AS NomeCat, vCompra, vVenda, p.CategoriaId

				Categoria cat = new Categoria( (int)reader["p.CategoriaId"], (string)reader["NomeCat"] );

				produtos.Add(
					new Produto( (int)reader["ProdutoId"], (string)reader["Nome"], 
						cat, (decimal)reader["vCompra"], (decimal)reader["vVenda"])
				);
			}

			reader.Close();
			Fechar();

			return produtos;

		}

	}
}

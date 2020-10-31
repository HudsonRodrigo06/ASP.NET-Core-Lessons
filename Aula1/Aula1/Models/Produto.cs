using Aula1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class Produto
	{
		int _id;
		string _nome;
		Categoria _categoria;
		decimal _precoCompra, _precoVenda;


		public Produto()
		{

		}

		public Produto(string nome, Categoria categoria, decimal precoCompra, decimal precoVenda)
		{
			_nome = nome;
			_categoria = categoria;
			_precoCompra = precoCompra;
			_precoVenda = precoVenda;
		}

		public Produto(int id, string nome, Categoria categoria, decimal precoCompra, decimal precoVenda)
		{
			Id = id;
			Nome = nome;
			Categoria = categoria;
			PrecoCompra = precoCompra;
			PrecoVenda = precoVenda;
		}

		public Produto(int id, string nome, string nomeCategoria, decimal precoCompra, decimal precoVenda)
		{
			Id = id;
			Nome = nome;
			Categoria = new Categoria(-1, nomeCategoria);
			PrecoCompra = precoCompra;
			PrecoVenda = precoVenda;
		}

		public int Id { get => _id; set => _id = value; }
		public string Nome { get => _nome; set => _nome = value; }
		public Categoria Categoria { get => _categoria; set => _categoria = value; }
		public decimal PrecoCompra { get => _precoCompra; set => _precoCompra = value; }
		public decimal PrecoVenda { get => _precoVenda; set => _precoVenda = value; }


		public bool Gravar()
		{
			ProdutoDAL pd = new ProdutoDAL();

			return pd.Gravar(this);
		}

		public bool Alterar()
		{
			ProdutoDAL pd = new ProdutoDAL();

			return pd.Alterar(this);
		}

		public List<Produto> getProdutos()
		{
			ProdutoDAL pd = new ProdutoDAL();
			return pd.getProdutos();
		}

		public bool Remover()
		{
			ProdutoDAL pd = new ProdutoDAL();
			return pd.Remover(_id);
		}

	}
}

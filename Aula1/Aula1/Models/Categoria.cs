using Aula1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class Categoria
	{
		int _id;
		string _nome;

		public Categoria()
		{
			_id = -1;
			_nome = "";
		}

		public Categoria(string nome)
		{
			_id = -1;
			_nome = nome;
		}

		public Categoria(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public bool getCategoria(int id)
		{
			CategoriaDAL cd = new CategoriaDAL();

			return cd.getCategoria(id, this);
		}

		public override string ToString() {

			return _nome;
		
		}

		public int Id { get => _id; set => _id = value; }
		public string Nome { get => _nome; set => _nome = value; }


	}
}

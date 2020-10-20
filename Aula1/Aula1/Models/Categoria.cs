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

		}

		public Categoria(int id, string nome)
		{
			Id = id;
			Nome = nome;
		}

		public override string ToString() {

			return _nome;
		
		}

		public int Id { get => _id; set => _id = value; }
		public string Nome { get => _nome; set => _nome = value; }


	}
}

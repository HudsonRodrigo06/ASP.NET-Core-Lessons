using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class Usuario
	{
		int id;
		string nome;
		string email;
		string senha;

		public Usuario()
		{
			this.Id = -1;
			this.Nome = this.Email = this.Senha = "";
		}

		public Usuario(int id, string nome, string email, string senha)
		{
			this.Id = id;
			this.Nome = nome;
			this.Email = email;
			this.Senha = senha;
		}

		public int Id { get => id; set => id = value; }
		public string Nome { get => nome; set => nome = value; }
		public string Email { get => email; set => email = value; }
		public string Senha { get => senha; set => senha = value; }


	}
}

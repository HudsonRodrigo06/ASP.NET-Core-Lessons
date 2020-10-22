using Aula1.DAL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class Usuario
	{
		int _id;
		string _nome;
		string _email;
		string _senha;

		public int Id { get => _id; set => _id = value; }
		public string Nome { get => _nome; set => _nome = value; }
		public string Email { get => _email; set => _email = value; }
		public string Senha { get => _senha; set => _senha = value; }

		public Usuario()
		{
			Id = -1;
			Nome = Email = Senha = "";
		}

		public Usuario(int id, string nome, string email, string senha)
		{
			Id = id;
			Nome = nome;
			Email = email;
			Senha = senha;
		}



		public bool ValidarSenha()
		{
			return _email.Equals("hud") && _senha.Equals("123");
		}

		public int Gravar()
		{
			UsuarioDAL ud = new UsuarioDAL();
			
			return ud.Gravar(this);
		}

	}
}

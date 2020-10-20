using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class Venda
	{
		Usuario _usuario;
		DateTime _data;
		decimal total;
		List<VendaItem> produtos = new List<VendaItem>();


		public bool Gravar()
		{
			return true;
		}

		public List<Venda> ObterTodos()
		{

			return new List<Venda>();
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1.Models
{
	public class VendaItem
	{
		Produto _produto;
		int _qtde;
		decimal valor;

		public Produto Produto { get => _produto; set => _produto = value; }
		public int Qtde { get => _qtde; set => _qtde = value; }
		public decimal Valor { get => valor; set => valor = value; }
	}
}

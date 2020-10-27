using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1
{
	public class Configuracao : IConfiguracao
	{
		public string StrCon { get; set; }
	}

	public interface IConfiguracao
	{
		public string StrCon { get; set; }
	}
}

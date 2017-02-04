using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marada.Schedulator.Core
{
	public class Station
	{
		public Station(string name, string abbreviation)
		{
			Name = name;
			Abbreviation = abbreviation;
		}

		public string Name { get; set; }
		public string Abbreviation { get; set; }


	}
}

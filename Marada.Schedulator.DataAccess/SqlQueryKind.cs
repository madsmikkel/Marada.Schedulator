using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marada.Schedulator.DataAccess
{
	internal enum SqlQueryKind
	{
		SelectAll,
		SelectDistinct,
		Insert,
		Update,
		Delete
	}
}

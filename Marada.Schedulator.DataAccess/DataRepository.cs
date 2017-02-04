using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marada.Schedulator.DataAccess
{
	public abstract class DataRepository<T>
	{
		private QueryExecutor executor;

		public DataRepository()
		{
			executor = new QueryExecutor();
		}

		internal QueryExecutor Executor
		{
			get
			{
				return executor;
			}

			set
			{
				executor = value;
			}
		}

		internal string BuildSqlString(SqlQueryKind queryKind)
		{
			string sqlString = String.Empty;
			switch(queryKind)
			{
				case SqlQueryKind.SelectAll:
					sqlString = $"SELECT * FROM {typeof(T).Name}s";
					break;
				case SqlQueryKind.SelectDistinct:
					break;
				case SqlQueryKind.Insert:
					break;
				case SqlQueryKind.Update:
					break;
				case SqlQueryKind.Delete:
					break;
				default:
					break;
			}
			return sqlString;
		}

		public abstract List<T> GetAll();


	}
}

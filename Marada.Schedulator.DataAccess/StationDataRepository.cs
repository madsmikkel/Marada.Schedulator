using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Marada.Schedulator.Core;

namespace Marada.Schedulator.DataAccess
{
	public class StationDataRepository: DataRepository<Station>
	{

		public StationDataRepository() : base()
		{

		}

		public override List<Station> GetAll()
		{
			DataTable table;
			try
			{
				table = Executor.GetDataTable(BuildSqlString(SqlQueryKind.SelectAll));
			}
			catch(Exception)
			{
				throw;
			}
			List<Station> stations = new List<Station>(0);
			if(table != null && table.Rows.Count > 0)
			{
				foreach(DataRow row in table.Rows)
				{
					Station s = new Station(row[1].ToString(), row[2].ToString());
					stations.Add(s);
				}
			}
			return stations;
		}
	}
}

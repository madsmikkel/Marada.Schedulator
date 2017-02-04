using System;
using System.Collections.Generic;
using System.Configuration;	// ConfigurationManager
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marada.Schedulator.DataAccess
{
	/// <summary>
	/// Represents a SQL Server transaction executor.
	/// </summary>
	internal class QueryExecutor
	{

		#region Fields
		/// <summary>
		/// The connection string.
		/// </summary>
		private static readonly string connectionString;

		/// <summary>
		/// The sql connection.
		/// </summary>
		protected SqlConnection connection;

		#endregion


		#region Constructor
		/// <summary>
		/// Gets the connection string from the config file.
		/// </summary>
		static QueryExecutor()
		{
			/* TODO: read more about securering connection strings:
         *  https://msdn.microsoft.com/en-us/library/ms254494(v=vs.110).aspx */
			string name = "connectionStringSchedulatorDb";
			try
			{
				connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
			}
			catch(Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Initializes a new instance of this class, and attempts to connect to a database, using
		/// a connection string defined in the config file.
		/// </summary>
		internal QueryExecutor()
		{
			try
			{
				connection = new SqlConnection(connectionString);
				connection.Open();
				connection.Close();
			}
			catch(SqlException)
			{
				throw;
			}
			catch(InvalidOperationException)
			{
				throw;
			}
			catch(System.Configuration.ConfigurationException)
			{
				throw;
			}
		}
		#endregion


		#region Methods
		/// <summary>
		/// Gets a filled dataset using the provided SQL statement.
		/// </summary>
		/// <param name="queryString">A SELECT type of SQL statement.</param>
		/// <returns>A DataSet containing the data tables, containing the data rows.</returns>
		internal DataSet GetDataSet(string queryString)
		{
			using(SqlDataAdapter adapter = new SqlDataAdapter())
			{
				try
				{
					DataSet set = new DataSet();
					adapter.SelectCommand = new SqlCommand();
					adapter.SelectCommand.CommandText = queryString;
					adapter.SelectCommand.Connection = connection;
					DataTable table = new DataTable();
					table.BeginLoadData();
					adapter.Fill(table);
					table.EndLoadData();
					set.EnforceConstraints = false;
					set.Tables.Add(table);
					return set;
				}
				catch(InvalidOperationException)
				{
					throw;
				}
			}
		}

		/// <summary>
		/// Gets a data table containing rows.
		/// </summary>
		/// <param name="query">A SELECT type of SQL statement.</param>
		/// <returns>A data table containing data rows.</returns>
		internal DataTable GetDataTable(string query)
		{
			return GetDataSet(query).Tables[0];
		}
		#endregion
	}
}

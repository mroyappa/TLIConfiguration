using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/*
 * CLASS SUMMARY:	GridDataTable
 * 
 * This is an override of the .NET DataTable class which encompasses functionality to aid with the XceedGrid.
 * 
 */

namespace TLIConfiguration
{
	class GridDataTable : DataTable
	{
		private SqlConnection sqlConnection;
		private SqlDataAdapter sqlDataAdapter;


		public GridDataTable(SqlConnection sqlConnection, SqlDataAdapter sqlDataAdapter)
		{
			this.sqlConnection = sqlConnection;
			this.sqlDataAdapter = sqlDataAdapter;
		}


		// The seemingly-unused foobar params are needed to provide signatures that match the delegates from CustomXceedGridControl
		public DataTable Fill() { return Fill("", null); }
		public DataTable Fill(string foobar) { return Fill(foobar, null); }
		public DataTable Fill(IList parameters) { return Fill("", parameters); }
		public DataTable Fill(string foobar, IList parameters)
		{
			try
			{
				sqlConnection.Open();

				SqlCommand sqlCommand = null;
				sqlCommand = sqlDataAdapter.SelectCommand;
				sqlCommand.Connection = sqlConnection;

				if (parameters != null)
				{
					// Having this line here is actually a bug that was propagated from Database.cs, upon which this object was based
					// The "bug" functionality though is actually used by the grid pages in this app, since the custom grid issues
					// subsequent calls to fill (after performing updates) without passing parameters.  If a grid is used to maintain a
					// subset of records in a table, it is important that the original parameters remain intact, hence the persistence
					// of this "bug".
					// Cliff notes: This is a bug, but don't fix it.
					sqlCommand.Parameters.Clear();

					foreach (SqlParameter sqlParameter in parameters)
					{
						sqlCommand.Parameters.Add(sqlParameter);
					}
				}

				Clear();

				this.BeginInit();
				sqlDataAdapter.Fill(this);
				this.AcceptChanges();
				this.EndInit();
			}
			finally
			{
				sqlConnection.Close();
			}

			return this as DataTable;
		}


		public new void Clear() { Clear(this); }
		private void Clear(DataTable dataTable)
		{
			this.BeginInit();
			foreach (DataRelation dataRelation in dataTable.ChildRelations)
				Clear(dataRelation.ChildTable);

			this.ChildRelations.Clear();
			base.Clear();
			this.EndInit();
		}


		// The seemingly-unused foobar params are needed to provide signatures that match the delegates from CustomXceedGridControl
		public void Update() { Update(""); }
		public void Update(string foobar)
		{
			try
			{
				sqlConnection.Open();

				if (sqlDataAdapter.DeleteCommand != null)
					sqlDataAdapter.DeleteCommand.Connection = sqlConnection;
				if (sqlDataAdapter.InsertCommand != null)
					sqlDataAdapter.InsertCommand.Connection = sqlConnection;
				if (sqlDataAdapter.UpdateCommand != null)
					sqlDataAdapter.UpdateCommand.Connection = sqlConnection;

				sqlDataAdapter.Update(this);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		// The seemingly-unused foobar params are needed to provide signatures that match the delegates from CustomXceedGridControl
		public new void Reset() { Reset(""); }
		public void Reset(string foobar)
		{
			this.BeginInit();
			this.RejectChanges();
			this.EndInit();
		}
	}
}

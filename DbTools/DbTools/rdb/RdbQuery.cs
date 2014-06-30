using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using Rade.DbTools.intf;

namespace Rade.DbTools.rdb
{
    public class RdbQuery : IQuery
    {
        public RdbQuery(FbConnection aConnection, FbTransaction aTransaction) 
        { 
            connection = aConnection; 
            transaction = aTransaction;
            fCommand = connection.CreateCommand();
            fCommand.Transaction = transaction;
        }
        public void Dispose() { }

        private FbConnection connection = null;

        private FbTransaction transaction = null;

        private DataTable fDataTable = new DataTable();
        public DataTable DataTable { get { return fDataTable; } }

        private FbCommand fCommand = null;

        public string SqlText { get { return fCommand.CommandText; } set { fCommand.CommandText = value; } }

        public void Execute()
        {
            fCommand.CommandText = SqlText;
            fCommand.ExecuteNonQuery();
        }

        public DataTable ExecuteDataTable()
        {
            fCommand.CommandText = SqlText;
            FbDataAdapter adapter = new FbDataAdapter(fCommand);
            adapter.Fill(DataTable);
            return DataTable;
        }

        public void CreateParams(IQuery sourceQuery)
        { 
        
        }
    }
}

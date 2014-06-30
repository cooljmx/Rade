using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Rade.DbTools.rdb
{
    public class RdbData
    {
        public static Object GetFieldValue(FbConnection aConnection, FbTransaction aTransaction, string aSqlText, int aFieldNum = 0)
        {
            using (RdbQuery query = new RdbQuery(aConnection, aTransaction))
            {
                query.SqlText = aSqlText;
                DataTable dataTable = query.ExecuteDataTable();
                DataRow row = dataTable.Rows[0];
                return row[aFieldNum];
            }
        }

        public static void ExecuteQuery(FbConnection aConnection, FbTransaction aTransaction, string aSqlText)
        {
            using (RdbQuery query = new RdbQuery(aConnection, aTransaction))
            {
                query.SqlText = aSqlText;
                query.Execute();
            }
        }
    }
}

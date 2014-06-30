using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Rade.DbTools
{
    public class DbData
    {
        public static Object GetFieldValue(DbConnection aConnection, DbTransaction aTransaction, string aSqlText, int aFieldNum = 0)
        {
            using (var query = new DbQuery(aConnection, aTransaction))
            {
                query.SqlText = aSqlText;
                query.ExecuteDataReader();
                return query.DataReader.Read() ? query.DataReader[aFieldNum] : null;
            }
        }
        public static void ExecuteQuery(DbConnection aConnection, DbTransaction aTransaction, string aSqlText)
        {
            using (var query = new DbQuery(aConnection, aTransaction))
            {
                query.SqlText = aSqlText;
                query.Execute();
            }
        }
        public static bool IsRecordExists(DbConnection aConnection, DbTransaction aTransaction, string sqlText)
        {
            using (var query = new DbQuery(aConnection, aTransaction))
            {
                query.SqlText = sqlText;
                query.ExecuteDataReader();
                return query.DataReader.Read();
            }
        }
    }
}

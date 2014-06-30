using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Rade.DbTools
{
    public delegate void ExecuteEventHandler(object aSender);

    public class DbQuery:IDisposable
    {
        public DbQuery(DbConnection aConnection, DbTransaction aTransaction) 
        {
            DataReader = null;
            _fCommand = aConnection.CreateCommand();
            _fCommand.CommandTimeout = 120;
            _fCommand.Transaction = aTransaction;
        }

        public void Dispose() 
        {            
            if (DataReader != null)
                DataReader.Dispose();
            if (_fCommand != null)
                _fCommand.Dispose();
        }

        public event ExecuteEventHandler BeforeExecute;
        public event ExecuteEventHandler AfterExecute;

        public DbDataReader DataReader { get; private set; }

        private readonly DbCommand _fCommand = null;

        public string SqlText { get { return _fCommand.CommandText; } set { _fCommand.CommandText = value; } }

        public void Execute()
        {
            _fCommand.CommandText = SqlText;

            if (BeforeExecute != null) BeforeExecute(this);
            _fCommand.ExecuteNonQuery();
            if (AfterExecute != null) AfterExecute(this);
        }       

        public DbDataReader ExecuteDataReader()
        {
            _fCommand.CommandText = SqlText;
            _fCommand.CommandTimeout = 600;
            if (BeforeExecute != null) BeforeExecute(this);
            DataReader = _fCommand.ExecuteReader();
            if (AfterExecute != null) AfterExecute(this);

            return DataReader;
        }

        public DbParameterCollection Parameters { get { return _fCommand.Parameters; } }

        public DbParameter GetNewParameter(string parameterName, Object value)
        {
            var result = _fCommand.CreateParameter();
            result.ParameterName = parameterName;
            result.Value = value;return result;
        }
    }
}

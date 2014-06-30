using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Rade.DbTools.intf
{
    public interface IQuery : IDisposable
    {
        DataTable DataTable { get; }
        string SqlText { get; set; }
        void CreateParams(IQuery sourceQuery);
        void Execute();
        DataTable ExecuteDataTable();
    }
}

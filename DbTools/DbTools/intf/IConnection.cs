using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Rade.DbTools.intf
{
    public interface IConnection
    {
        DbTransaction BeginTransaction();
    }
}

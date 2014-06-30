using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rade.DbTools.intf
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}

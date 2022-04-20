using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface IDataTransfer: IDisposable
    {
        public int Save();
    }
}

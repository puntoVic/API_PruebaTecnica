using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface I_DataTransfer: IDisposable
    {
        public bool Guardar();
    }
}

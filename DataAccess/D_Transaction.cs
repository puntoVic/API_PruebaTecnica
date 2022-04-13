using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class D_Transaction
    {
        private Context db;
        public D_Transaction(Context db)
        {
            this.db = db;
        }
    }
}

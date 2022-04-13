using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class D_Account 
    {
        private Context db;
        public D_Account(Context db)
        {
            this.db = db;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class D_DataTransfer : I_DataTransfer
    {
        private readonly Context _db;
        public D_Account accounts;
        public D_Issuer issuers;
        public D_Transaction transactions;

        public D_DataTransfer(Context db)
        {
            _db = db;
            accounts = new D_Account(_db);
            issuers = new D_Issuer(_db);
            transactions = new D_Transaction(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool Guardar()
        {
            _db.SaveChanges();
        }
    }
}

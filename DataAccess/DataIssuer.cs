using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DataIssuer: DataTransfer
    {
        public int CeateIssuer(Issuer issuer)
        {
            try
            {
                Context.Instance.Issuers.Add(issuer);
                return Save();
            }
            catch
            {
                return 0;
            }
        }
        public void UpdateIssuer(Issuer issuer)
        {
            Context.Instance.Issuers.Update(issuer);
            Save();
        }
    }                                                                                    
}

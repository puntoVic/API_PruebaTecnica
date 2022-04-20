using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DataTransfer : IDataTransfer
    {
        
        public void Dispose()
        {
            Context.Instance.Dispose();
        }

        public int Save()
        {
            try
            {
                return Context.Instance.SaveChanges();
                
            }
            catch 
            {
                return 0;
            }
        }
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DataAccount: DataTransfer 
    {
        public int CeateAccount(Account account)
        {
            try
            {
                account.Issuers = new List<Issuer>();
                if (account.Cash < 0)
                {
                    account.Cash = 0;
                    return 0;
                }
                else
                {
                    Context.Instance.Accounts.Add(account);
                    return Save();
                }
            }
            catch
            {
                return 0;
            }
        }
        public Account SearchAccountById(Int32 id)
        {
            try
            {
                Account account = Context.Instance.Accounts.AsEnumerable().LastOrDefault(x => x.AccountId == id);
                account.Issuers = Context.Instance.Issuers.Where(x => x.AccountId == account.AccountId).ToList();
                return account;
            }
            catch
            {
                return null;
            }
        }
        public void UpdateAccount(Account account)
        {
            Context.Instance.Accounts.Update(account);
            Save();
        }
    }
}

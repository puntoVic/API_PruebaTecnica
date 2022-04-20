using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;

namespace Business
{
    public static class BusinessAccount
    {
        /// <summary>
        /// Initial function to create an account 
        /// </summary>
        /// <param name="account">Account to create</param>
        /// <returns></returns>
        public static int CeateAccount(Account account)
        {
            using var dataAccount = new DataAccount();
            return dataAccount.CeateAccount(account);
           
        }
        /// <summary>
        /// Function for search an account by its Id in DB
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns></returns>
        public static Account SearchAccountById(Int32 id)
        {
            using var dataAccount = new DataAccount();
            return dataAccount.SearchAccountById(id);
        }
        /// <summary>
        /// Function for update an account
        /// </summary>
        /// <param name="account">Account to update</param>
        public static void UpdateAccount(Account account)
        {
            using var dataAccount = new DataAccount();
            dataAccount.UpdateAccount(account);
        }
        /// <summary>
        /// Function for review founds on balance
        /// </summary>
        /// <param name="account">account to review</param>
        /// <param name="totalSharePrice">Ammount total of shares to buy</param>
        /// <returns></returns>
        public static bool CheckBalance(Account account, int totalSharePrice)
        {
            return account.Cash > totalSharePrice;
        }

        public static bool IsValidAccount(Account account)
        {
            return account != null && account.AccountId >= 0 && account.Issuers != null;
        }


    }
}

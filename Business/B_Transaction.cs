using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Responses;


namespace Business
{
    public static class B_Transaction
    {

        /// <summary>
        /// Function to execute a sale 
        /// </summary>
        /// <param name="transaction">Sale data</param>
        public static Response ExecuteSale(Transaction transaction)
        {
            Response response = new Response();
            if (transaction.Shares_Prices <= 0 || transaction.Total_Shares <= 0)
                response.Bussines_Errors.Add(new Business_Error() { Error = "WRONG_SHARES_VALUES" });
            else
            {
                try
                {
                    Account account = B_Account.SearchAccountById(transaction.AccountId);
                    if (account != null)
                    {
                        if (account.Issuers == null)
                        {
                            account.Issuers = new List<Issuer>();
                        }
                        Issuer issuer = B_Issuer.SearchIssuerByName(account.Issuers, transaction.Issuer_Name);
                        if (issuer != null && B_Issuer.CheckStock(issuer, transaction.Total_Shares))
                        {
                            issuer.Total_Shares -= transaction.Total_Shares;
                            account.Cash += transaction.Total_Shares * transaction.Shares_Prices;
                            response = GenerateSuccessResponse(issuer, account);
                        }
                        else
                        {
                            response.Bussines_Errors.Add(new Business_Error() { Error = "NO_STOCK" });
                        }
                    }
                    else
                    {
                        response.Bussines_Errors.Add(new Business_Error() { Error = "NON-EXISTENT_ACCOUNT" });
                    }
                }
                catch (Exception e)
                {
                    response.Bussines_Errors.Add(new Business_Error() { Error = "CLOSE_MARKET" });
                }
            }
            return response;

        }
        /// <summary>
        /// Function to excute a purchase
        /// </summary>
        /// <param name="transaction">Purchase data</param>
        public static Response ExecutePurchase(Transaction transaction)
        {
            Response response = new Response();
            if (transaction.Shares_Prices <= 0 || transaction.Total_Shares <= 0)
                response.Bussines_Errors.Add(new Business_Error() { Error = "WRONG_SHARES_VALUES" });
            else
            {
                try
                {
                    int total = transaction.Total_Shares * transaction.Shares_Prices;
                    Account account = B_Account.SearchAccountById(transaction.AccountId);
                    if (account != null && B_Account.CheckBalance(account, total))
                    {
                        if (account.Issuers == null)
                        {
                            account.Issuers = new List<Issuer>();
                        }
                        Issuer issuer = B_Issuer.SearchIssuerByName(account.Issuers, transaction.Issuer_Name);
                        if (issuer == null)
                        {
                            issuer = new Issuer() { Issuer_Name = transaction.Issuer_Name, AccountId = account.AccountId, Total_Shares = 0 };
                            B_Issuer.CeateIssuer(issuer);
                            account.Issuers.Add(issuer);
                        }
                        issuer.Total_Shares += transaction.Total_Shares;
                        issuer.Shares_Price = transaction.Shares_Prices;
                        account.Cash -= total;
                        response = GenerateSuccessResponse(issuer, account);
                    }
                    else
                    {
                        response.Bussines_Errors.Add(new Business_Error() { Error = "NON-EXISTENT_ACCOUNT_OR_NO_FOUNDS" });
                    }
                }
                catch (Exception e)
                {
                    response.Bussines_Errors.Add(new Business_Error() { Error = e.Message });
                }
            }
            return response;
        }

        private static Response GenerateSuccessResponse(Issuer issuer, Account account)
        {
            Response response = new Response();
            try
            {
                B_Issuer.UpdateIssuer(issuer);
                B_Account.UpdateAccount(account);
                response.Current_Balance.Cash = account.Cash;
                response.Current_Balance.Issuers = account.Issuers;
            }
            catch (Exception e)
            {
                response.Bussines_Errors.Add(new Business_Error() { Error = e.Message });
            }
            return response;
        }

        public static bool IsValidResponse(Response response)
        {
            return response != null && response.Current_Balance != null && response.Bussines_Errors != null && response.Current_Balance.Issuers != null;
        }
        

    }
}

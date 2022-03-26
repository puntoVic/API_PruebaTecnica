using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Entities.Responses;
using Business;

namespace API_GBM_Test
{

    public class TransactionTest
    {
        private readonly TransactionController _transactionController = new TransactionController();
        Transaction RightPurchase = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "BUY",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 2
        };
        Transaction RightSale = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "SELL",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 2
        };


        [Fact]
        public void IsAValidOkPurchaseResponse()
        {
            Response response = _transactionController.Transaction(RightPurchase);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count == 0);
        }


        [Fact]
        public void IsAValidOkSaleResponse()
        {
            Response response = _transactionController.Transaction(RightSale);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count == 0);
        }

    }
}

using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Entities.Responses;
using Business;

namespace API_GBM_Test
{
    public class InvalidTransactionsTest
    {
        private readonly TransactionController _transactionController = new TransactionController();
        Transaction transactionWrongOperation = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "sss",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 2
        };
        Transaction PurchaseWrongShares = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "BUY",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = -50,
            AccountId = 2
        };
        Transaction PurchaseWrongTotalShares = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "BUY",
            Issuer_Name = "AAPL",
            Total_Shares = -2,
            Shares_Prices = 50,
            AccountId = 2
        };
        Transaction PurchaseWrongAccount = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "BUY",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 0
        };
        Transaction sellWrongShares = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "SELL",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = -50,
            AccountId = 2
        };
        Transaction sellWrongTotalShares = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "SELL",
            Issuer_Name = "AAPL",
            Total_Shares = -2,
            Shares_Prices = 50,
            AccountId = 2
        };
        Transaction sellWrongAccount = new Transaction()
        {
            Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssffff"),
            Operation = "SELL",
            Issuer_Name = "AAPL",
            Total_Shares = 2,
            Shares_Prices = 50,
            AccountId = 0
        };
        [Fact]
        public void WrongOperationTransaction()
        {
            Response response = _transactionController.Transaction(transactionWrongOperation);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
        [Fact]
        public void WrongSharesPricesPurchase()
        {
            Response response = _transactionController.Transaction(PurchaseWrongShares);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count>0);
        }
        [Fact]
        public void WrongTotalSharesPurchase()
        {
            Response response = _transactionController.Transaction(PurchaseWrongTotalShares);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
        [Fact]
        public void WrongAccountPurchase()
        {
            Response response = _transactionController.Transaction(PurchaseWrongAccount);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
        [Fact]
        public void WrongSharesPricesSale()
        {
            Response response = _transactionController.Transaction(sellWrongShares);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
        [Fact]
        public void WrongTotalSharesSale()
        {
            Response response = _transactionController.Transaction(sellWrongTotalShares);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
        [Fact]
        public void WrongAccountSale()
        {
            Response response = _transactionController.Transaction(sellWrongAccount);

            Assert.True(B_Transaction.IsValidResponse(response) && response.Bussines_Errors.Count > 0);
        }
    }
}

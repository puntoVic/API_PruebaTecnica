using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Business;

namespace API_GBM_Test
{
    public class InvalidAccountTest
    {
        private readonly AccountController _accountController = new AccountController();
        [Fact]
        public void WrongData()
        {
            Account account = new Account() { Cash = -50 };

            Account response = _accountController.Post(account);

            Assert.True(B_Account.IsValidAccount(response) && response.Cash == 0 && response.AccountId == 0);
        }
    }
}

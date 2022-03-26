using System;
using Xunit;
using API_TestGBM.Controllers;
using Entities;
using Business;

namespace API_GBM_Test
{
    public class AccountTest
    {
        private readonly AccountController _accountController = new AccountController();
        
        [Fact]
        public void ResponseIsAValidAccount()
        {
            Account account = new Account() { Cash = 60000 };

            Account response = _accountController.Post(account);

            Assert.True(B_Account.IsValidAccount(response));
        }
        [Fact]
        public void ResponseIsRightAccount()
        {
            Account account = new Account() { Cash = 60000 };

            Account response = _accountController.Post(account);

            Assert.True(B_Account.IsValidAccount(response) && response.Cash == 60000);
        }
    }
}

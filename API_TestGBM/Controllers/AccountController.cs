using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_TestGBM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        

        // POST api/<AccountController>
        [HttpPost]
        public Account Post([FromBody] Account account)
        {
            
            if (B_Account.CeateAccount(account) == 0)
            {
                account.Cash = 0;
            }
            return account;
        }

        
    }
}

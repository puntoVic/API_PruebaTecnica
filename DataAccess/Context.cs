using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class Context : DbContext
    {
        
        public DbSet<Issuer> Issuers { get; set; }
        public DbSet<Issuer> Stocks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuiulder)
        {
            if (!optionsBuiulder.IsConfigured)
            {
                if (GeneralConfig.Connstring == null)
                {
                    // Only used when generating migrations
                    optionsBuiulder.UseSqlServer("Set connection string only for migration");
                }
                else
                {
                    optionsBuiulder.UseSqlServer(GeneralConfig.Connstring);
                }
            
                    
            }
        }

        
    }
}


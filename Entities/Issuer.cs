using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Issuer
    {
        [Key]
        public string Issuer_Name { get; set; }
        public int Total_Shares { get; set; }
        public int Shares_Price { get; set; }
        public Int32 AccountId { get; set; }
        private Account Account { get; set; }
    }
}

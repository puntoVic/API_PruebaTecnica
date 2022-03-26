using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 AccountId { get; set; }

        public int Cash { get; set; }

        public ICollection<Issuer> Issuers { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}

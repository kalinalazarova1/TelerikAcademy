﻿namespace Atm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        public int Id { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}

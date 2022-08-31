using Chainblock.Contracts;
using System;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender name cannot be null or whitespace string!");
                }

                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Receiver name cannot be null or whitespace string!");
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Transaction amount must be a positive number!");
                }

                this.amount = value;
            }
        }
    }
}

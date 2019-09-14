using Common.Domain;
using Common.Domain.ValueObjects;
using MobileMoney.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileMoney.Domain.Entities
{
    public class Transaction : EntityBase
    {
        public static Transaction Create(string phone, TransactionType transactionType, string reference,
            DateTime txnTime, Money amount, Guid internalRefId) =>
            new Transaction(phone, transactionType, reference, txnTime, amount, internalRefId);
        private Transaction(string phone, TransactionType transactionType, string reference,
            DateTime txnTime, Money amount, Guid internalRefId)
        {
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            TransactionType = transactionType;
            Reference = reference ?? throw new ArgumentNullException(nameof(reference));
            TxnTime = txnTime;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            InternalRefId = internalRefId;
        }

        private Transaction() { }
        public string Phone { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Reference { get; set; }
        public DateTime TxnTime { get; set; }
        public Money Amount { get; set; }
        public Guid InternalRefId { get; set; }
    }
}

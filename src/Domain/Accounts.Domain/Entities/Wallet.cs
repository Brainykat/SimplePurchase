using Common.Domain;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Domain.Entities
{
    public class Wallet : EntityBase
    {
        private Wallet() { }
        private Wallet(Guid accountId, Money credit, Money debit,
            Guid txnRefrence, Guid externalReference, string narration, Guid transactingUser)
        {
            if (credit.Amount == debit.Amount) throw new Exception("Invalid Entry Debit Equal Credit");
            if (string.IsNullOrWhiteSpace(narration)) throw new ArgumentNullException(nameof(narration));
            if (txnRefrence == Guid.Empty) throw new ArgumentNullException(nameof(txnRefrence));
            if (transactingUser == Guid.Empty) throw new ArgumentNullException(nameof(transactingUser));
            GenerateNewIdentity();
            AccountId = accountId;
            TxnTime = DateTimeRangeExtensions.GetDate();
            Credit = credit ?? throw new ArgumentNullException(nameof(credit));
            Debit = debit ?? throw new ArgumentNullException(nameof(debit));
            TxnRefrence = txnRefrence;
            ExternalReference = externalReference;
            Narration = narration;
            TransactingUser = transactingUser;
        }
        public static Wallet Create(Guid accountId, Money credit, Money debit,
            Guid txnRefrence, Guid externalReference, string narration, Guid transactingUser) =>
            new Wallet(accountId, credit, debit, txnRefrence, externalReference, narration, transactingUser);
        public Guid AccountId { get; set; }
        public DateTime TxnTime { get; set; }
        public Money Credit { get; set; }
        public Money Debit { get; set; }
        public Guid TxnRefrence { get; set; }
        public Guid ExternalReference { get; set; }
        public string Narration { get; set; }
        public Guid TransactingUser { get; set; }
    }
}

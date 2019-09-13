using Accounts.Domain.Enums;
using Common.Domain;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Domain.Entities
{
    public class Account : EntityBase
    {
        private Account() { }
        private Account(Guid wholeSalerId, Guid oMCId, Guid retailerId, string name,
            AccountNumber accountNumber, AccountBearerType accountBearerType,
            Guid chartOfAccountId, Money accountTransactionLimit, int signatories)
        {
            if (accountBearerType != AccountBearerType.Office && wholeSalerId == Guid.Empty &&
                oMCId == Guid.Empty && retailerId == Guid.Empty)
                throw new Exception("A non-office account must have a bearer");
            if (signatories <= 0) throw new ArgumentOutOfRangeException(nameof(signatories));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            GenerateNewIdentity();
            Name = name;
            WholeSalerId = wholeSalerId;
            OMCId = oMCId;
            RetailerId = retailerId;
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            AccountBearerType = accountBearerType;
            CreatedOn = DateTimeRangeExtensions.GetDate();
            ChartOfAccountId = chartOfAccountId;
            AccountTransactionLimit = accountTransactionLimit ?? throw new ArgumentNullException(nameof(accountTransactionLimit));
            Signatories = signatories;
        }
        public static Account Create(Guid wholeSalerId, Guid oMCId, Guid retailerId, string name,
            AccountNumber accountNumber, AccountBearerType accountBearerType,
            Guid chartOfAccountId, Money accountTransactionLimit, int signatories) =>
            new Account(wholeSalerId, oMCId, retailerId, name, accountNumber, accountBearerType,
                chartOfAccountId, accountTransactionLimit, signatories);

        public Guid? WholeSalerId { get; set; }
        public Guid? OMCId { get; set; }
        public Guid? RetailerId { get; set; }
        public string Name { get; set; }
        public AccountNumber AccountNumber { get; set; }
        public AccountBearerType AccountBearerType { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ChartOfAccountId { get; set; }
        public Money AccountTransactionLimit { get; set; }
        public int Signatories { get; set; }
        public ChartOfAccount ChartOfAccount { get; set; }
        public List<Wallet> Wallets { get; set; }

    }
}

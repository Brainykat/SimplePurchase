using Accounts.Domain.Enums;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Domain.Entities
{
    public class ChartOfAccount : EntityBase
    {
        private ChartOfAccount() { }
        private ChartOfAccount(int number, string description, AccountType accountType, Statement statement)
        {
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
            GenerateNewIdentity();
            Number = number;
            Description = description;
            AccountType = accountType;
            Statement = statement;
        }
        public static ChartOfAccount Create(int number, string description, AccountType accountType, Statement statement) =>
            new ChartOfAccount(number, description, accountType, statement);

        public int Number { get; set; }
        public string Description { get; set; }
        public AccountType AccountType { get; set; }
        public Statement Statement { get; set; }
        public List<Account> Accounts { get; set; }
    }
}

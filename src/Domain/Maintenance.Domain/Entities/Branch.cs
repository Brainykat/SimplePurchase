using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maintenance.Domain.Entities
{
    public class Branch : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
        public Branch() { }

        internal Branch(string code, string name, Guid bankId)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (bankId == Guid.Empty) throw new ArgumentNullException(nameof(bankId));
            Code = code;
            Name = name;
            BankId = bankId;
        }

    }
}

using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class Supplier : EntityBase
    {
        public static Supplier Create(string name, string email, string phone, Guid branchId, string accountNumber)
            => new Supplier(name, email, phone, branchId, accountNumber);
        private Supplier(string name, string email, string phone, Guid branchId, string accountNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            BranchId = branchId;
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            AddedOn = DateTimeRangeExtensions.GetDate();
        }
        private Supplier() { }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid BranchId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime AddedOn { get; set; }
        public Branch Branch { get; set; }
    }
}

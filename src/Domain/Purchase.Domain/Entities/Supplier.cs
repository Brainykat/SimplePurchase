using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class Supplier : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid BranchId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime AddedOn { get; set; }
        public Branch Branch { get; set; }
    }
}

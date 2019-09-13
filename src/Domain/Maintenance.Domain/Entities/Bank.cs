using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maintenance.Domain.Entities
{
    public class Bank : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();
        private Bank() { }

        private Bank(string code, string name)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Code = code;
            Name = name;
        }

        public void AddBranch(string code, string name) =>
            Branches.Add(new Branch(code, name, this.Id));
        public static Bank Create(string code, string name) => new Bank(code, name);
    }
}

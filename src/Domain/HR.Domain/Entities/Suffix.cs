using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Domain.Entities
{
    public class Suffix : EntityBase
    {
        public string Name { get; set; }
        private Suffix() { }
        private Suffix(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            GenerateNewIdentity();
            Name = name.Trim();
        }
        public static Suffix Create(string name)
        {
            return new Suffix(name);
        }
    }
}

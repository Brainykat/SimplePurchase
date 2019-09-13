using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Domain.Entities
{
    public class JobTitle : EntityBase
    {
        private JobTitle() { }
        private JobTitle(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            GenerateNewIdentity();
            Name = name;
        }
        public static JobTitle Create(string name) => new JobTitle(name);
        public string Name { get; set; }
    }
}

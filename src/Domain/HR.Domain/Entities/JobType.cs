using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Domain.Entities
{
    public class JobType : EntityBase
    {
        private JobType() { }
        private JobType(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            GenerateNewIdentity();
            Name = name;
        }
        public static JobType Create(string name) => new JobType(name);
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class Account
    {
        public virtual Guid AccountId { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Purchase.Domain.Entities
{
    public class User
    {
        public virtual Guid UserId { get; private set; }
    }
}

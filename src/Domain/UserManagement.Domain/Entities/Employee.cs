using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Entities
{
    public class Employee
    {
        public virtual Guid EmployeeId { get; private set; }
    }
}

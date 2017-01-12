using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class Employee
    {
        public Employee()
        {
            this.Orders = new List<Order>();
        }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

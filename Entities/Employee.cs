using System;
using System.Collections.Generic;

namespace Entities
{
    public class Employees 
    {
        public Employees()
        {
            Customers = new HashSet<Customer>();
            InverseReportsToNavigation = new HashSet<Employees>();
        }

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public int? ReportsTo { get; set; }
        public byte[] BirthDate { get; set; }
        public byte[] HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public virtual Employees ReportsToNavigation { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employees> InverseReportsToNavigation { get; set; }
    }
}

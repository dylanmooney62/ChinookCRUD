using System;
using System.Collections.Generic;

namespace Entities
{
    public class Invoice 
    {
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public byte[] InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public byte[] Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities
{
    public class InvoiceItem
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Track Track { get; set; }
    }
}

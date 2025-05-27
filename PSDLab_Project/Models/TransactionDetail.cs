

namespace PSDLab_Project.Models
{
    using System;
    using System.Collections.Generic;

    public partial class TransactionDetail
    {
        public int TransactionDetailID { get; set; }
        public Nullable<int> TransactionID { get; set; }
        public Nullable<int> JewelID { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Jewel Jewel { get; set; }
        // It uses 'TransactionHeader'
        public virtual TransactionHeader TransactionHeader { get; set; }
    }
}
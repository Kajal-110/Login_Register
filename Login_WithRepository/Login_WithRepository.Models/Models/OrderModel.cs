using Login_WithRepository.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_WithRepository.Models.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ItemId { get; set; }
        public Nullable<int> CouponCode { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> OrdertotalQuantity { get; set; }
        public int OrderItemQuantity { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> AfterGST { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }
        public List<Item> itemList { get; set; }

    }
}

using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_WithRepository.Helpers.Helpers
{
    public static class OrderHelper
    {

        public static Order ConvertOrderModelToOrder(OrderModel orderModel,int CouponId)
        {
            Order order = new Order();
            order.OrderId = orderModel.OrderId;
            order.UserId = orderModel.UserId;
            order.ItemId = orderModel.ItemId;
            if(CouponId == 0)
            {
                order.CouponCode = null;
            }
            else
            {
                order.CouponCode = CouponId;
            }
            //order.CouponCode = orderModel.CouponCode;
            order.OrderDate = orderModel.OrderDate;
            order.OrdertotalQuantity = orderModel.OrdertotalQuantity;
            order.TotalAmount = orderModel.TotalAmount;
            order.AfterGST = orderModel.AfterGST;
            order.TotalPayable = orderModel.TotalPayable;
            return order;
        }
    }
}

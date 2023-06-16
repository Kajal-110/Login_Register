using Login_WithRepository.Helpers.Helpers;
using Login_WithRepository.Models.Context;
using Login_WithRepository.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_WithRepository.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order

        Theam_Login_RegisterEntities db = new Theam_Login_RegisterEntities();
        public ActionResult AddOrder()
        {

            try
            {
                OrderModel orderModel = new OrderModel();
                int UserId;
                if(Session["Id"] == null)
                {
                    UserId = db.Users.Where(x => x.Email.Equals("Kajal@gmail.com")).FirstOrDefault().Id;
                }
                else
                {
                    UserId = Convert.ToInt32(Session["Id"]) + 0;
                }
                orderModel.UserId = UserId;
                orderModel.itemList = db.Item.ToList();
                return View(orderModel);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;

                return View("Error");
            }
            
        }
        [HttpPost]
        public ActionResult AddOrder(OrderModel orderModel)
        {
            try
            {
                if(orderModel.CouponCode != null)
                {
                    int couponcode = db.CouponCodeMaster.Where(x => x.CouponCode.Equals(orderModel.CouponCode)).FirstOrDefault().CouponId;
                    CouponCodeMaster decreaseCouponCode = db.CouponCodeMaster.Where(x => x.CouponId == couponcode).FirstOrDefault();
                    decreaseCouponCode.CouponUsageLimit = decreaseCouponCode.CouponUsageLimit - 1;
                    Order order = OrderHelper.ConvertOrderModelToOrder(orderModel, couponcode);
                    db.Order.Add(order);
                    db.SaveChanges();
                    TempData["success"] = "Order added Successfully";
                }
                else
                {
                    Order order = OrderHelper.ConvertOrderModelToOrder(orderModel,0);
                    db.Order.Add(order);
                    db.SaveChanges();
                    TempData["success"] = "Order added Successfully";

                }
                return RedirectToAction("OrderList");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
           
        }

        public ActionResult OrderList()
        {
            try
            {
                int UserId;
                if(Session["Id"] == null)
                {
                    UserId = db.Users.Where(x => x.Id.Equals("Kajal@gmail.com")).FirstOrDefault().Id;
                    
                }
                else
                {
                    UserId = Convert.ToInt32(Session["Id"]) + 0;
                }
                List<Order> OrderList = db.Order.Where(x => x.UserId == UserId).ToList();
                return View(OrderList);
            }
            catch (Exception e)
            {

                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

    }

}
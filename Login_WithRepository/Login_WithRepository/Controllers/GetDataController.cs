using Login_WithRepository.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_WithRepository.Controllers
{
    public class GetDataController : Controller
    {

        // GET: GetData

        Theam_Login_RegisterEntities db = new Theam_Login_RegisterEntities();
        public JsonResult GetItemPrice(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Item item = db.Item.Find(id);
            return Json(item,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCouponDiscount(string couponCode)
        {
            db.Configuration.ProxyCreationEnabled = false;
            CouponCodeMaster couponCodeMaster = db.CouponCodeMaster.Where(x =>x.CouponCode.Equals(couponCode)).FirstOrDefault();
            if(couponCodeMaster != null)
            {
                return Json(couponCodeMaster, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
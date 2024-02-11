using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjTravelPlatformV3.Models;

namespace prjTravelPlatformV3.Areas.Employee.Controllers.Visa
{
    [Area("Employee")]
    public class VProductController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public VProductController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        //view
        public IActionResult Index()
        {
            return View();
        }

        //api
        public JsonResult getPrInEnByProductName(string p)
        {
            var Info = _context.TVproducts.Where(t => t.FName == p).Select(t => new {price = t.FPrice, interview = t.FInterviewRequirement,entity = t.FEntityOrElectronic}).FirstOrDefault();
            return Json(Info);
        }

        public JsonResult getPrInEnByProductId(int id)
        {
            var Info = _context.TVproducts.Where(t => t.FId == id).Select(t => new { price = t.FPrice, interview = t.FInterviewRequirement, entity = t.FEntityOrElectronic }).FirstOrDefault();
            return Json(Info);
        }

        public IActionResult getDiscount(string coupon)
        {
            var discount = _context.TCouponLists.Where(t => t.FCouponName == coupon).Select(t => t.FDiscount).FirstOrDefault();
            return Json(discount);
        }
    }
}

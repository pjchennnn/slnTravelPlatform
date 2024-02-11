using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjTravelPlatformV3.Areas.Employee.ViewModels.Hotel;
using prjTravelPlatformV3.Areas.Employee.ViewModels.Visa;
using prjTravelPlatformV3.Models;

namespace prjTravelPlatformV3.Areas.Employee.Controllers.Visa
{
    [Area("Employee")]
    public class VOrderController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public VOrderController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        //view
        public IActionResult Index()
        {
            return View();
        }


        //api
        public JsonResult allVOrders()
        {
            var VOrders = _context.VVorderViews;
            return Json(VOrders);
        }




        //get modal partial
        public IActionResult GetPartial(int? id)
        {
            if (id == 0)
            {
                ViewBag.FCouponId = new SelectList(_context.TCouponLists.Where(t => t.FProductType == 6), "FCouponId", "FCouponName");
                ViewBag.FCustomerId = new SelectList(_context.TCustomers, "FCustomerId", "FName");
                ViewBag.FProductId = new SelectList(_context.TVproducts, "FId", "FName");
                ViewBag.FStatusId = new SelectList(_context.TVorderStatuses, "FId", "FVorderStatus");
                var travelerInfo = _context.TVtravelerInfos.Where(t => t.FOrderId == id).ToList();
                ViewBag.TVtravelerInfos = travelerInfo;
                ViewBag.formId = "Create";
                ViewBag.title = "新增訂單";
                return PartialView("_ModalPartial", new VOrderViewModel());
            }
            if (_context.TVorders == null)
            {
                return NotFound();
            }
            var TVorder = _context.TVorders.Find(id);
            if (TVorder == null)
            {
                return NotFound();
            }
            VOrderViewModel vo = new VOrderViewModel
            {
                FProductId = TVorder.FProductId,
                FCustomerId = TVorder.FCustomerId,
                FPrice = TVorder.FPrice,
                FQuantity = TVorder.FQuantity,
                FDepartureDate = TVorder.FDepartureDate,
                FForPickupOrDeliveryAddress = TVorder.FForPickupOrDeliveryAddress,
                FInterviewReminder = TVorder.FInterviewReminder,
                FEvaluate = TVorder.FEvaluate,
                FMemo = TVorder.FMemo,
                FStatusId = TVorder.FStatusId,
                FCouponId = TVorder.FCouponId,
                TVtravelerInfos = TVorder.TVtravelerInfos
            };
            ViewBag.FCouponId = new SelectList(_context.TCouponLists.Where(t => t.FProductType == 6), "FCouponId", "FCouponName");
            ViewBag.FCustomerId = new SelectList(_context.TCustomers, "FCustomerId", "FName");
            ViewBag.FProductId = new SelectList(_context.TVproducts, "FId", "FName");
            ViewBag.FStatusId = new SelectList(_context.TVorderStatuses, "FId", "FVorderStatus");
            var travelerInfos = _context.TVtravelerInfos.Where(t => t.FOrderId == id).ToList();
            ViewBag.TVtravelerInfos = travelerInfos;
            ViewBag.formId = "Edit";
            ViewBag.title = "編輯訂單";
            return PartialView("_ModalPartial", vo);
        }

        //get travelerInfoPartial
        public IActionResult GetTravelerInfoPartial(int? id)
        {
            if (id == 0)
            {
                return PartialView("_TravelerInfoPartial", new TVtravelerInfo());
            }
            if (_context.TVtravelerInfos == null)
            {
                return NotFound();
            }
            var travelers = _context.TVtravelerInfos.Where(t => t.FOrderId == id);
            if (travelers == null)
            {
                return NotFound();
            }
            return PartialView("_TravelerInfoPartial", travelers);
        }





        //新增資料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VOrderViewModel vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TVorder tVorder = new TVorder
                    {
                        FId = vo.FId,
                        FProductId = vo.FProductId,
                        FCustomerId = vo.FCustomerId,
                        FPrice = vo.FPrice,
                        FQuantity = vo.FQuantity,
                        FDepartureDate = vo.FDepartureDate,
                        FForPickupOrDeliveryAddress = vo.FForPickupOrDeliveryAddress,
                        FInterviewReminder = vo.FInterviewReminder,
                        FEvaluate = vo.FEvaluate,
                        FMemo = vo.FMemo,
                        FStatusId = vo.FStatusId,
                        FCouponId = vo.FCouponId,
                        TVtravelerInfos = vo.TVtravelerInfos
                    };
                    _context.Add(tVorder);
                    await _context.SaveChangesAsync();

                    //List<TVtravelerInfo> travelers = new List<TVtravelerInfo>();
                    //travelers = vo.TVtravelerInfos.ToList();
                    //_context.Add(travelers);
                    //await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "新增資料成功" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = $"資料新增失敗：{e.Message}" });
                }
            }
            //驗證沒過            
            var errors = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
            );
            //var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return Json(new
            {
                success = false,
                message = "資料驗證失敗",
                errors
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VOrderViewModel vo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TVorder tVorder = new TVorder
                    {
                        FId = vo.FId,
                        FProductId = vo.FProductId,
                        FCustomerId = vo.FCustomerId,
                        FPrice = vo.FPrice,
                        FQuantity = vo.FQuantity,
                        FDepartureDate = vo.FDepartureDate,
                        FForPickupOrDeliveryAddress = vo.FForPickupOrDeliveryAddress,
                        FInterviewReminder = vo.FInterviewReminder,
                        FEvaluate = vo.FEvaluate,
                        FMemo = vo.FMemo,
                        FStatusId = vo.FStatusId,
                        FCouponId = vo.FCouponId,
                        TVtravelerInfos = vo.TVtravelerInfos
                    };
                    _context.Update(tVorder);
                    await _context.SaveChangesAsync();

                    //List<TVtravelerInfo> travelers = new List<TVtravelerInfo>();
                    //travelers = vo.TVtravelerInfos.ToList();
                    //_context.Add(travelers);
                    //await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "資料修改成功" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = $"資料修改失敗: {e.Message}"});
                }
            }

            //驗證沒過
            var errors = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
            );
            //var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return Json(new
            {
                success = false,
                message = "資料驗證失敗",
                errors
            });
        }
    }
}

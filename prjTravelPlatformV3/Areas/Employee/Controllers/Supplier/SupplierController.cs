using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prjTravelPlatformV3.Areas.Employee.ViewModels.Visa;
using prjTravelPlatformV3.Models;

namespace prjTravelPlatformV3.Areas.Employee.Controllers.Supplier
{
    [Area("Employee")]

    public class SupplierController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public SupplierController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        //view
        public IActionResult Index()
        {
            return View();
        }

        //api
        public JsonResult allCompanies()
        {
            var Companies = _context.TCcompanyInfos;
            return Json(Companies);
        }


        //get modal partial
        public async Task<IActionResult> GetPartial(int? id)
        {
            if (id == null || _context.TCcompanyInfos == null)
            {
                return NotFound();
            }
            var tCcompanyInfo = await _context.TCcompanyInfos
                .FirstOrDefaultAsync(m => m.FId == id);
            if (tCcompanyInfo == null)
            {
                return NotFound();
            }
            
            return PartialView("_ModalPartial", tCcompanyInfo);
        }


        //ischeck
        public async Task<IActionResult> isChecked(int id, string value)
        {
            var s = _context.TCcompanyInfos.Find(id);
            if (s == null)
            {
                return Json(new { success = false, message = $"更改失敗" });
            }
            try
            {
                s.FIsChecked = value;
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = $"更改成功" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = $"更改失敗: {e.Message}" });
            }
        }

        //isCoop
        public async Task<IActionResult> isCoop(int id, string value)
        {
            var s = _context.TCcompanyInfos.Find(id);
            if (s == null)
            {
                return Json(new { success = false, message = $"更改失敗" });
            }
            try
            {
                s.FIsInCooperation = value;
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = $"更改成功" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = $"更改失敗: {e.Message}" });
            }
        }
    }
}

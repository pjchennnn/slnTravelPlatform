using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjTravelPlatformV3.Areas.Employee.ViewModels.Hotel;
using prjTravelPlatformV3.Models;


namespace prjTravelPlatformV3.Areas.Employee.Controllers.Hotel
{
    [Route("/api/Hotels/{action}/{id?}")]
    public class HApiController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public HApiController(dbTravalPlatformContext context)
        {
            _context = context;
        }
        public IActionResult GetAll()
        {
            var hotels = from h in _context.THotels
                         select h;
            return Json(hotels);
        }
        public IActionResult GetById(int id)
        {
            var hotel = _context.THotels.FirstOrDefault(h => h.FHotelId == id);
            return Json(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    THotel tHotel = new THotel
                    {
                        FHotelId = hotel.HotelId,
                        FHotelName = hotel.HotelName,
                        FHotelEngName = hotel.HotelEngName,
                        FHotelAddress = hotel.HotelAddress,
                        FPhone = hotel.Phone,
                        FRegion = hotel.Region,
                        FTexId = hotel.TexId,
                    };
                    _context.Add(tHotel);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "資料新增成功" });
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
        public async Task<IActionResult> Edit(HotelViewModel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    THotel tHotel = new THotel
                    {
                        FHotelId = hotel.HotelId,
                        FHotelName = hotel.HotelName,
                        FHotelEngName = hotel.HotelEngName,
                        FHotelAddress = hotel.HotelAddress,
                        FPhone = hotel.Phone,
                        FRegion = hotel.Region,
                        FTexId = hotel.TexId,
                    };
                    _context.Update(tHotel);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "資料修改成功" });
                }
                catch (Exception e)
                {
                    return Json(new { success = false, message = $"資料修改失敗：{e.Message}" });
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

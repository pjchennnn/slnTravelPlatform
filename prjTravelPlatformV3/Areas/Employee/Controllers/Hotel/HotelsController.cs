using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prjTravelPlatformV3.Models;
using prjTravelPlatformV3.Areas.Employee.ViewModels.Hotel;

namespace prjTravelPlatformV3.Areas.Employee.Controllers.Hotel
{
    [Area("Employee")]
    public class HotelsController : Controller
    {
        private readonly dbTravalPlatformContext _context;

        public HotelsController(dbTravalPlatformContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
             return View();
        }
        // GET: Hotels/Create    
        public IActionResult Create()
        {
            return View();
        }

        //get modal partial
        public IActionResult GetPartial(int? id)
        {
            if (id == 0)
            {
                ViewBag.formId = "Create";
                ViewBag.title = "新增飯店資料";
                return PartialView("_ModalPartial", new HotelViewModel());
            }
            if (_context.THotels == null)
            {
                return NotFound();
            }
            var tHotel = _context.THotels.Find(id);
            if (tHotel == null)
            {
                return NotFound();
            }
            HotelViewModel h = new HotelViewModel
            {
                HotelId = tHotel.FHotelId,
                HotelName = tHotel.FHotelName,
                HotelEngName = tHotel.FHotelEngName,
                HotelAddress = tHotel.FHotelAddress,
                Phone = tHotel.FPhone,
                Region = tHotel.FRegion,
                TexId = tHotel.FTexId,
            };
            ViewBag.formId = "Edit";
            ViewBag.title = "編輯飯店資料";
            return PartialView("_ModalPartial", h);
        }

      
        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.THotels == null)
            {
                return Problem("Entity set 'dbTravalPlatformContext.THotels'  is null.");
            }
            var tHotel = await _context.THotels.FindAsync(id);
            if (tHotel != null)
            {
                _context.THotels.Remove(tHotel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool THotelExists(int id)
        {
            return (_context.THotels?.Any(e => e.FHotelId == id)).GetValueOrDefault();
        }


        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("FHotelId,FHotelName,FHotelEngName,FHotelAddress,FPhone,FRegion,FTexId")] THotel tHotel)
        //{
        //    if (id != tHotel.FHotelId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tHotel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!THotelExists(tHotel.FHotelId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tHotel);
        //}

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("HotelId,HotelName,HotelEngName,HotelAddress,Phone,Region,TexId")] HotelViewModel hotel)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        THotel tHotel = new THotel
        //        {
        //            FHotelId = hotel.HotelId,
        //            FHotelName = hotel.HotelName,
        //            FHotelEngName = hotel.HotelEngName,
        //            FHotelAddress = hotel.HotelAddress,
        //            FPhone = hotel.Phone,
        //            FRegion = hotel.Region,
        //            FTexId = hotel.TexId,
        //        };
        //        _context.Add(tHotel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return PartialView("_ModalPartial", hotel);
        //}
        //// GET: Hotels/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.THotels == null)
        //    {
        //        return NotFound();
        //    }

        //    var tHotel = await _context.THotels
        //        .FirstOrDefaultAsync(m => m.FHotelId == id);
        //    if (tHotel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tHotel);
        //}
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.THotels == null)
        //    {
        //        return NotFound();
        //    }

        //    var tHotel = await _context.THotels.FindAsync(id);
        //    if (tHotel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tHotel);
        //}
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.THotels == null)
        //    {
        //        return NotFound();
        //    }

        //    var tHotel = await _context.THotels
        //        .FirstOrDefaultAsync(m => m.FHotelId == id);
        //    if (tHotel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tHotel);
        //}


    }
}

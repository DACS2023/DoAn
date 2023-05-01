using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnCoSo.Areas.Identity.Data;
using DoAnCoSo.ViewModel;

namespace DoAnCoSo.Controllers
{
    public class GiaiDausController : Controller
    {
        private readonly QuanLyHoiThaoDBContext _context;

        public GiaiDausController(QuanLyHoiThaoDBContext context)
        {
            _context = context;
        }

        // GET: GiaiDaus
        public async Task<IActionResult> Index()
        {
            List<GiaiDauDetails> giaiDaudetailsList = new List<GiaiDauDetails>();
            
            GiaiDauDetails giaiDauDetails; 
            List<GiaiDau> giaiDauList = await _context.giaiDaus.ToListAsync();

            for(int i = 0; i < giaiDauList.Count;i++)
            {
                giaiDauDetails = new GiaiDauDetails();
                giaiDauDetails.giaiDau = new GiaiDau();
                giaiDauDetails.loaiGiaiDau = new LoaiGiaiDau();
                

                giaiDauDetails.giaiDau = await _context.giaiDaus.FirstOrDefaultAsync(m => m.IdgiaiDau == giaiDauList[i].IdgiaiDau);

                giaiDauDetails.loaiGiaiDau = await _context.loaiGiaiDaus.FirstOrDefaultAsync(m => m.IdloaiGiaiDau == giaiDauDetails.giaiDau.IdloaiGiaiDau);

                giaiDaudetailsList.Add(giaiDauDetails);
            }    
            
            return _context.giaiDaus != null ?
                          View(giaiDaudetailsList) :
                          Problem("Entity set 'QuanLyHoiThaoDBContext.giaiDaus'  is null.");

            //return _context.giaiDaus != null ?
            //             View(await _context.giaiDaus.ToListAsync()) :
            //             Problem("Entity set 'QuanLyHoiThaoDBContext.giaiDaus'  is null.");
        }

        // GET: GiaiDaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.giaiDaus == null)
            {
                return NotFound();
            }


            GiaiDauDetails giaiDauDetails = new GiaiDauDetails();

            giaiDauDetails.giaiDau = await _context.giaiDaus.FirstOrDefaultAsync(m => m.IdgiaiDau == id);

            giaiDauDetails.loaiGiaiDau = await _context.loaiGiaiDaus.FirstOrDefaultAsync(m => m.IdloaiGiaiDau == giaiDauDetails.giaiDau.IdloaiGiaiDau);

            //var giaiDau = await _context.giaiDaus
            //   .FirstOrDefaultAsync(m => m.IdgiaiDau == id);
            if (giaiDauDetails == null)
            {
                return NotFound();
            }


            return View(giaiDauDetails);
        }

        // GET: GiaiDaus/Create
        public IActionResult Create()
        {
            GiaiDauCreateModel giaiDauCreateModel = new GiaiDauCreateModel();
            giaiDauCreateModel.giaiDau = new GiaiDau();
            List<SelectListItem> loaiGiai = _context.loaiGiaiDaus
                .OrderBy(n => n.TenLoai)
                .Where(n=>n.TrangThai==true)
                .Select(n => new SelectListItem
                {
                    Value = n.IdloaiGiaiDau.ToString(),
                    Text = n.TenLoai
                }).ToList();
            giaiDauCreateModel.loaiGiaiDau = loaiGiai;
            return View(giaiDauCreateModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdgiaiDau,TenGiaiDau,IdloaiGiaiDau,NgayBatDau,NgayKetThuc,NoiDung,TrangThai")] GiaiDau giaiDau)
        {
            if (ModelState.IsValid)
            {
                giaiDau.TrangThai = true;
                _context.Add(giaiDau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaiDau);
        }

        // GET: GiaiDaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.giaiDaus == null)
            {
                return NotFound();
            }


            GiaiDauCreateModel giaiDauCreateModel = new GiaiDauCreateModel();

            giaiDauCreateModel.giaiDau = await _context.giaiDaus.FirstOrDefaultAsync(m => m.IdgiaiDau == id);

            //giaiDauCreateModel.loaiGiaiDau = (IEnumerable<SelectListItem>)await _context.loaiGiaiDaus.FirstOrDefaultAsync(m => m.IdloaiGiaiDau == giaiDauCreateModel.giaiDau.IdloaiGiaiDau); 
                

            List<SelectListItem> loaiGiai = _context.loaiGiaiDaus
                .OrderBy(n => n.TenLoai)
                .Where(n=>n.TrangThai==true)
                .Select(n => new SelectListItem
                {
                    Value = n.IdloaiGiaiDau.ToString(),
                    Text = n.TenLoai
                }).ToList();
            
            giaiDauCreateModel.loaiGiaiDau = loaiGiai;
            if (giaiDauCreateModel == null)
            {
                return NotFound();
            }


            return View(giaiDauCreateModel);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdgiaiDau,TenGiaiDau,IdloaiGiaiDau,NgayBatDau,NgayKetThuc,NoiDung,TrangThai")] GiaiDau giaiDau)
        {
            if (id != giaiDau.IdgiaiDau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaiDau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaiDauExists(giaiDau.IdgiaiDau))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(giaiDau);
        }

        // GET: GiaiDaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.giaiDaus == null)
            {
                return NotFound();
            }

            GiaiDauDetails giaiDauDetails = new GiaiDauDetails();

            giaiDauDetails.giaiDau = await _context.giaiDaus.FirstOrDefaultAsync(m => m.IdgiaiDau == id);

            giaiDauDetails.loaiGiaiDau = await _context.loaiGiaiDaus.FirstOrDefaultAsync(m => m.IdloaiGiaiDau == giaiDauDetails.giaiDau.IdloaiGiaiDau);

            if (giaiDauDetails == null)
            {
                return NotFound();
            }

            return View(giaiDauDetails);
        }

        // POST: GiaiDaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.giaiDaus == null)
            {
                return Problem("Entity set 'QuanLyHoiThaoDBContext.giaiDaus'  is null.");
            }
            var giaiDau = await _context.giaiDaus.FindAsync(id);
            if (giaiDau != null)
            {
                giaiDau.TrangThai = false;
                _context.Update(giaiDau);
                await _context.SaveChangesAsync();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaiDauExists(int id)
        {
            return (_context.giaiDaus?.Any(e => e.IdgiaiDau == id)).GetValueOrDefault();
        }
    }
}

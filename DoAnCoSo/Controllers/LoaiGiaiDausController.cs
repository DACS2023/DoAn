using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnCoSo.Areas.Identity.Data;

namespace DoAnCoSo.Controllers
{
    public class LoaiGiaiDausController : Controller
    {
        private readonly QuanLyHoiThaoDBContext _context;

        public LoaiGiaiDausController(QuanLyHoiThaoDBContext context)
        {
            _context = context;
        }

        // GET: LoaiGiaiDaus
        public async Task<IActionResult> Index()
        {
              return _context.loaiGiaiDaus != null ? 
                          View(await _context.loaiGiaiDaus.ToListAsync()) :
                          Problem("Entity set 'QuanLyHoiThaoDBContext.loaiGiaiDaus'  is null.");
        }

        // GET: LoaiGiaiDaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.loaiGiaiDaus == null)
            {
                return NotFound();
            }

            var loaiGiaiDau = await _context.loaiGiaiDaus
                .FirstOrDefaultAsync(m => m.IdloaiGiaiDau == id);
            if (loaiGiaiDau == null)
            {
                return NotFound();
            }

            return View(loaiGiaiDau);
        }

        // GET: LoaiGiaiDaus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiGiaiDaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdloaiGiaiDau,TenLoai,TrangThai")] LoaiGiaiDau loaiGiaiDau)
        {
            if (ModelState.IsValid)
            {
                loaiGiaiDau.TrangThai = true;
                _context.Add(loaiGiaiDau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiGiaiDau);
        }

        // GET: LoaiGiaiDaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.loaiGiaiDaus == null)
            {
                return NotFound();
            }

            var loaiGiaiDau = await _context.loaiGiaiDaus.FindAsync(id);
            if (loaiGiaiDau == null)
            {
                return NotFound();
            }
            return View(loaiGiaiDau);
        }

        // POST: LoaiGiaiDaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdloaiGiaiDau,TenLoai,TrangThai")] LoaiGiaiDau loaiGiaiDau)
        {
            if (id != loaiGiaiDau.IdloaiGiaiDau)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiGiaiDau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiGiaiDauExists(loaiGiaiDau.IdloaiGiaiDau))
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
            return View(loaiGiaiDau);
        }

        // GET: LoaiGiaiDaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.loaiGiaiDaus == null)
            {
                return NotFound();
            }

            var loaiGiaiDau = await _context.loaiGiaiDaus
                .FirstOrDefaultAsync(m => m.IdloaiGiaiDau == id);
            if (loaiGiaiDau == null)
            {
                return NotFound();
            }

            return View(loaiGiaiDau);
        }

        // POST: LoaiGiaiDaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.loaiGiaiDaus == null)
            {
                return Problem("Entity set 'QuanLyHoiThaoDBContext.loaiGiaiDaus'  is null.");
            }
            var loaiGiaiDau = await _context.loaiGiaiDaus.FindAsync(id);
            if (loaiGiaiDau != null)
            {
                loaiGiaiDau.TrangThai = false;
                _context.Update(loaiGiaiDau);
                await _context.SaveChangesAsync();
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiGiaiDauExists(int id)
        {
          return (_context.loaiGiaiDaus?.Any(e => e.IdloaiGiaiDau == id)).GetValueOrDefault();
        }
    }
}

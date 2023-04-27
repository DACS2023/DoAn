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
              return _context.giaiDaus != null ? 
                          View(await _context.giaiDaus.ToListAsync()) :
                          Problem("Entity set 'QuanLyHoiThaoDBContext.giaiDaus'  is null.");
        }

        // GET: GiaiDaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.giaiDaus == null)
            {
                return NotFound();
            }

            var giaiDau = await _context.giaiDaus
                .FirstOrDefaultAsync(m => m.IdgiaiDau == id);
            if (giaiDau == null)
            {
                return NotFound();
            }

            return View(giaiDau);
        }

        // GET: GiaiDaus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaiDaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdgiaiDau,TenGiaiDau,IdloaiGiaiDau,NgayBatDau,NgayKetThuc,NoiDung,TrangThai")] GiaiDau giaiDau)
        {
            if (ModelState.IsValid)
            {
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

            var giaiDau = await _context.giaiDaus.FindAsync(id);
            if (giaiDau == null)
            {
                return NotFound();
            }
            return View(giaiDau);
        }

        // POST: GiaiDaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            var giaiDau = await _context.giaiDaus
                .FirstOrDefaultAsync(m => m.IdgiaiDau == id);
            if (giaiDau == null)
            {
                return NotFound();
            }

            return View(giaiDau);
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
                _context.giaiDaus.Remove(giaiDau);
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

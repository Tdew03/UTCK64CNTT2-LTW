using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TranVanDiem_231230742_de02.Models;

namespace TranVanDiem_231230742_de02.Controllers
{
    public class TvdCatalogsController : Controller
    {
        private readonly NetCoreCRUDContext _context;

        public TvdCatalogsController(NetCoreCRUDContext context)
        {
            _context = context;
        }

        // GET: TvdCatalogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvdCatalogs.ToListAsync());
        }

        // GET: TvdCatalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvdCatalog = await _context.TvdCatalogs
                .FirstOrDefaultAsync(m => m.TvdId == id);
            if (tvdCatalog == null)
            {
                return NotFound();
            }

            return View(tvdCatalog);
        }

        // GET: TvdCatalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvdCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TvdId,TvdCateName,TvdCatePrice,TvdCateQty,TvdPicture,TvdCateActive")] TvdCatalog tvdCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvdCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvdCatalog);
        }

        // GET: TvdCatalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvdCatalog = await _context.TvdCatalogs.FindAsync(id);
            if (tvdCatalog == null)
            {
                return NotFound();
            }
            return View(tvdCatalog);
        }

        // POST: TvdCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TvdId,TvdCateName,TvdCatePrice,TvdCateQty,TvdPicture,TvdCateActive")] TvdCatalog tvdCatalog)
        {
            if (id != tvdCatalog.TvdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvdCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvdCatalogExists(tvdCatalog.TvdId))
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
            return View(tvdCatalog);
        }

        // GET: TvdCatalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvdCatalog = await _context.TvdCatalogs
                .FirstOrDefaultAsync(m => m.TvdId == id);
            if (tvdCatalog == null)
            {
                return NotFound();
            }

            return View(tvdCatalog);
        }

        // POST: TvdCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvdCatalog = await _context.TvdCatalogs.FindAsync(id);
            if (tvdCatalog != null)
            {
                _context.TvdCatalogs.Remove(tvdCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvdCatalogExists(int id)
        {
            return _context.TvdCatalogs.Any(e => e.TvdId == id);
        }
    }
}

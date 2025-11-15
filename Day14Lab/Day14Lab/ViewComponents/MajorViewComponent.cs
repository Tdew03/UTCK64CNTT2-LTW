using Microsoft.AspNetCore.Mvc;
using Day14Lab.Data;
using Day14Lab.Models;

namespace Day14Lab.ViewComponents
{
    public class MajorViewComponent:ViewComponent
    {
        SchoolContext db;
        List<Major> majors;
        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenederMajor", majors);
        }
    }
}

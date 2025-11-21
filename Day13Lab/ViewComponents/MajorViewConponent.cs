using Microsoft.AspNetCore.Mvc; 
using BaiTH1.Data;
using BaiTH1.Models;
namespace BaiTH1.ViewComponents
{
    public class MajorViewConponent: ViewComponent
    {
        SchoolContext db;
        List<Major> majors;
        public MajorViewConponent(SchoolContext context)
        {
            db = context;
            majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}

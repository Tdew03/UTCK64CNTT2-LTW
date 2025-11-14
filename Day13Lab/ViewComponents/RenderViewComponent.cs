using BaiTH1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BaiTH1.ViewComponents
{
    public class RenderViewComponent : ViewComponent  
    {
        private List<MenuItem> menu;

        public RenderViewComponent()
        {
            menu = new List<MenuItem>()
            {
                new MenuItem(){Id=1, Name="Branches", Link="/Branches/Index"},
                new MenuItem(){Id=2, Name="Students", Link="/Student/Index"},
                new MenuItem(){Id=3, Name="Subjects", Link="/Subjects/Index"},
                new MenuItem(){Id=4, Name="Courses", Link="/Courses/Index"}
            };
        }

        public IViewComponentResult Invoke()
        {
            return View("RenderLeftMenu", menu);
        }
    }
}

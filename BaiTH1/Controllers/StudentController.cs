using BaiTH1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaiTH1.Controllers
{
    [Route("Admin/Student")]// Tiền tố chung
    public class StudentController : Controller
    {
        
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {Id=101,Name = "Hải Nam ", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address = "A1-2018", Email="nam@g.com" },
                new Student()
                {Id=102,Name = "Minh Anh", Branch = Branch.BE, Gender = Gender.Female, IsRegular=false, Address = "B2-2019", Email="anh@g.com" },
                new Student()
                {Id=103,Name = "Hoàng Sơn", Branch = Branch.CE, Gender = Gender.Male, IsRegular=true, Address = "C3-2020", Email="son@g.com" },
                new Student()
                { Id=104,Name = "Phương Linh", Branch = Branch.EE, Gender = Gender.Female, IsRegular=false, Address = "D4-2021", Email="linh@g.com" }

            };
        }

        [Route("List", Name = " StudentList")]
        [Route("")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        [Route("Add", Name = " StudentAdd")]
        public IActionResult Create()
        {
            //Lấy danh sách các giá trị Gender để hiện thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            //Lấy danh sách các giá trị Branch để hiện thị select-option trên form
            //Để hiện thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="IT", Value = "1"},
                new SelectListItem(){ Text="BE", Value = "2"},
                new SelectListItem(){ Text="CE", Value = "3"},
                new SelectListItem(){ Text="EE", Value = "4"},
            };
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}

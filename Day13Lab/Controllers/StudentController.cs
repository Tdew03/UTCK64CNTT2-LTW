using BaiTH1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaiTH1.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudents;

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {Id=101,Name = "Hải Nam ", Branch = Branch.IT, Gender = Gender.Male, IsRegular=true, Address = "A1-2018", Email="nam@g.com", Score = 8.5 },
                new Student()
                {Id=102,Name = "Minh Anh", Branch = Branch.BE, Gender = Gender.Female, IsRegular=false, Address = "B2-2019", Email="anh@g.com", Score = 9.0},
                new Student()
                {Id=103,Name = "Hoàng Sơn", Branch = Branch.CE, Gender = Gender.Male, IsRegular=true, Address = "C3-2020", Email="son@g.com", Score = 7.3},
                new Student()
                {Id=104,Name = "Phương Linh", Branch = Branch.EE, Gender = Gender.Female, IsRegular=false, Address = "D4-2021", Email="linh@g.com", Score = 6.8}
            };
        }

        // ============================
        // LIST
        // ============================
        [Route("")]
        [Route("List", Name = "StudentList")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        // ============================
        // CREATE GET
        // ============================
        [HttpGet]
        [Route("Add", Name = "StudentAdd")]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        // ============================
        // CREATE POST
        // ============================
        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);
                return RedirectToAction("Index");
            }

            LoadDropdowns();
            return View(s);
        }

        // ============================
        // EDIT GET
        // ============================
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var st = listStudents.FirstOrDefault(x => x.Id == id);
            if (st == null) return NotFound();

            LoadDropdowns();

            return View(st);
        }

        // ============================
        // EDIT POST
        // ============================
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                var st = listStudents.FirstOrDefault(x => x.Id == s.Id);
                if (st == null) return NotFound();

                st.Name = s.Name;
                st.Email = s.Email;
                st.Password = s.Password;
                st.Branch = s.Branch;
                st.Gender = s.Gender;
                st.IsRegular = s.IsRegular;
                st.Address = s.Address;
                st.DateOfBirth = s.DateOfBirth;
                st.Score = s.Score;

                return RedirectToAction("Index");
            }

            LoadDropdowns();
            return View(s);
        }

        // ============================
        // HÀM DÙNG CHUNG
        // ============================
        private void LoadDropdowns()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="IT", Value="1"},
                new SelectListItem(){ Text="BE", Value="2"},
                new SelectListItem(){ Text="CE", Value="3"},
                new SelectListItem(){ Text="EE", Value="4"},
            };
        }
    }
}

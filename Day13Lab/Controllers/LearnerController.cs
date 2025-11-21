using BaiTH1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTH1.Models;

namespace MyWebApp.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // Action Index: Lấy danh sách sinh viên
        public IActionResult Index()
        {
            // Lấy danh sách Learner VÀ kèm theo thông tin Major (ngành học)
            var learners = db.Learners.Include(m => m.Major).ToList();

            return View(learners);
        }
        // GET: Learner/Create
        public IActionResult Create()
        {
            // Cách 1: Tạo thủ công danh sách SelectListItem
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });
            }
            ViewBag.MajorID = majors;

            // Cách 2: Dùng class SelectList (Nhanh gọn hơn)
            // Lưu ý: Dòng này sẽ ghi đè lên dòng ViewBag ở trên. Code này chỉ để demo 2 cách.
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");

            return View();
        }

        // POST: Learner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Nếu dữ liệu không hợp lệ (ví dụ chưa nhập tên), nạp lại danh sách Major để hiện lại form
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // 1. Action Edit (GET): Hiển thị form với dữ liệu cũ
        public IActionResult Edit(int? id) // Dùng int? để tránh lỗi nếu id bị null
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            // Tạo danh sách chọn Ngành học, chọn sẵn ngành hiện tại của sinh viên (learner.MajorID)
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // 2. Action Edit (POST): Cập nhật dữ liệu xuống DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Xử lý trường hợp tranh chấp dữ liệu (nhiều người sửa cùng lúc)
                    if (!LearnerExists(learner.LearnerID))
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

            // Nếu lỗi, load lại danh sách Major để hiện lại form
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // 3. Hàm phụ trợ kiểm tra sự tồn tại
        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }
        // GET: Learner/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            
            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }

            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
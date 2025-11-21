using BaiTH1.Data;
using BaiTH1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyWebApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                // Kiểm tra xem DB đã có chưa, nếu chưa thì tạo
                context.Database.EnsureCreated();

                // Kiểm tra xem đã có dữ liệu Major chưa
                if (context.Majors.Any())
                {
                    return; // DB đã được khởi tạo (đã có dữ liệu), không làm gì thêm
                }

                // 1. Tạo dữ liệu Ngành học (Major)
                var majors = new Major[] {
                    new Major{MajorName="IT"},
                    new Major{MajorName="Economics"},
                    new Major{MajorName="Mathematics"},
                };
                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                // 2. Tạo dữ liệu Sinh viên (Learner)
                var learners = new Learner[] {
                    new Learner { FirstMidName = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1},
                    new Learner { FirstMidName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };
                foreach (Learner l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                // 3. Tạo dữ liệu Khóa học (Course)
                var courses = new Course[]{
                    new Course{CourseID=1050,Title="Chemistry",Credits=3},
                    new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                    new Course{CourseID=4041,Title="Macroeconomics",Credits=3}
                };
                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                // 4. Tạo dữ liệu Đăng ký học (Enrollment)
                var enrollments = new Enrollment[]{
                    new Enrollment{LearnerID=1,CourseID=1050,Grade=5.5f},
                    new Enrollment{LearnerID=1,CourseID=4022,Grade=7.5f},
                    new Enrollment{LearnerID=2,CourseID=1050,Grade=3.5f},
                    new Enrollment{LearnerID=2,CourseID=4041,Grade=7f}
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

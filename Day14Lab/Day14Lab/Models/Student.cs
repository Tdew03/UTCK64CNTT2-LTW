using System.ComponentModel.DataAnnotations;

namespace Day14Lab.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên

        // HỌ TÊN: tối thiểu 4, tối đa 100 ký tự
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        // EMAIL: yêu cầu đuôi gmail.com
        [Required(ErrorMessage = "Email bắt buộc phải nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        // MẬT KHẨU: 8 ký tự, gồm hoa, thường, số, ký tự đặc biệt
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải nhập")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }

        // NGÀNH HỌC
        [Required(ErrorMessage = "Ngành học bắt buộc phải chọn")]
        public Branch? Branch { get; set; }

        // GIỚI TÍNH
        [Required(ErrorMessage = "Giới tính bắt buộc phải chọn")]
        public Gender? Gender { get; set; }

        // HỆ ĐÀO TẠO
        public bool IsRegular { get; set; }

        // ĐỊA CHỈ
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải nhập")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        // NGÀY SINH
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005",
            ErrorMessage = "Ngày sinh phải từ 1/1/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // ĐIỂM: kiểu số thực, giá trị từ 0.0 đến 10.0
        [Required(ErrorMessage = "Điểm bắt buộc phải nhập")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double Score { get; set; }
    }
}

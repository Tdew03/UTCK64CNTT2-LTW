namespace BaiTH1.Models
{
    public class Student
    {
        public int Id { get; set; }// Mã sinh viên
        public string? Name { get; set; }// Tên sinh viên
        public string? Email { get; set; }// Email sinh viên
        public string? Password { get; set; }// Mật khẩu 
        public Gender? Gender { get; set; }// Giới tính
        public Branch? Branch { get; set; }// Ngành học
        public bool IsRegular   { get; set; } //Hệ : true-chính quy, false- phi cq 
        public string? Address { get; set; }// Địa chỉ
        public DateTime DateOfBorth { get; set; }// Ngày sinh


    }
}

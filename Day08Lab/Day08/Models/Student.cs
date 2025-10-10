using System.ComponentModel.DataAnnotations;

namespace Day08.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        // Khóa ngoại đến Lớp học
        public int ClassId { get; set; }
        public virtual Class? Class { get; set; }

    }
}

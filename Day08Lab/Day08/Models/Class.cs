using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Day08.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

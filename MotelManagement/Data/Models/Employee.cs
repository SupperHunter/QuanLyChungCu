using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotelManagement.Data.Models
{
    public class Employee
    {
        [Key]
        public int MaNhanVien { get; set; }

        [Required]
        [MaxLength(100)]
        public string HoTen { get; set; }

        [Required]
        public Common.Gender GioiTinh { get; set; } // Sử dụng Enum cho giới tính

        [MaxLength(255)]
        public string DiaChi { get; set; }

        [MaxLength(15)]
        public string Sdt { get; set; }

        public DateTime? NgaySinh { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(20)]
        public string? UserName { get; set; }
        [StringLength(20)]
        public string? UserPassword { get; set; }
        [StringLength(20)]
        public string? UserRole { get; set; }
    }
}

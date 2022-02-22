using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
    public class AdminModel
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(20)]
        public string? AdminName { get; set; }
        [StringLength(20)]
        public string? AdminPassword { get; set; }
        [StringLength(1)]
        public string? AdminRole { get; set; }
    }
}

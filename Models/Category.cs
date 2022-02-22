using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "You need to insert category name")]
        //[StringLength(20, ErrorMessage = "Please don't insert more than 20 chars and min 4", MinimumLength = 4)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public bool Status { get; set; }

        public List<Food>? Foods { get; set; }
    }
}

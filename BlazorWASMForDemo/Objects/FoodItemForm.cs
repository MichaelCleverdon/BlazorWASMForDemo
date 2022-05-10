using System.ComponentModel.DataAnnotations;


namespace BlazorWASMForDemo.Objects
{
    public class FoodItemForm
    {
        [Display(AutoGenerateField = false)]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}

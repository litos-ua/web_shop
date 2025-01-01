
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InternetShopApp.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow; 

        [Required]
        public bool IsActive { get; set; } = true;

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>(); 
    }

}

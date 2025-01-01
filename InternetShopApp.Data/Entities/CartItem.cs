
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;


//namespace InternetShopApp.Data.Entities
//{
//    public class CartItem
//    {
//        public int Id { get; set; }

//        [Required]
//        public int CartId { get; set; } 

//        [Required]
//        public int ProductId { get; set; } 

//        [Required]
//        [Range(0, int.MaxValue)]
//        public int Quantity { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

//        [ForeignKey("CartId")]
//        public Cart? Cart { get; set; }

//        [ForeignKey("ProductId")]
//        public Product? Product { get; set; } 
//    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InternetShopApp.Data.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternetShopApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = decimal.Zero;

        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        // Требования к доставке: true или false, по умолчанию false
        public bool DeliveryRequirement { get; set; } = false;

        // Статус получения: true - получен, false - не получен, по умолчанию false
        public bool ReceivedStatus { get; set; } = false;

        // Тип оплаты("cash", "card") по умолчанию "card"
        [MaxLength(20)]
        public string TypeOfPayment { get; set; } = "card";

        // Статус оплаты ("not paid", "paid"), по умолчанию "not paid"
        [MaxLength(50)]
        public string PaymentStatus { get; set; } = "not paid";

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

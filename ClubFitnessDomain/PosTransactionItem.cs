using System.ComponentModel.DataAnnotations.Schema;

namespace ClubFitnessDomain
{
    public class PosTransactionItem
    {
        public long PosTransactionItemId { get; set; }
        public long PosTransactionId { get; set; }
        public int ProductId { get; set; }

        [NotMapped]
        public string ProductImage { get; set; }
        
        public int ItemQuantity { get; set; }

        [NotMapped]
        public decimal PriceIncTax { get; set; }
        [NotMapped]
        public decimal PriceExTax { get; set; }

        public decimal ItemTaxAmount { get; set; }
        public decimal ItemPriceExTax { get; set; }
        public decimal ItemPriceIncTax { get; set; }

        public decimal DiscountPercentage { get; set; }
        public decimal Discount { get; set; }
        public bool IsRefunded { get; set; }
        public long? PosTransactionRefItemId { get; set; }
        [NotMapped] 
        public string? ItemDescription { get; set; }
        public bool IsVoided { get; set; }

        // Navigation properties
        public virtual PosTransaction PosTransaction { get; set; }
        public virtual AccountProduct AccountProduct { get; set; }
    }
}
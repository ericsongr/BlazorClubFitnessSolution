using System.ComponentModel.DataAnnotations.Schema;
using ClubFitnessDomain.Enums;

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
        public decimal PriceIncTaxOriginalPriceBeforeDiscountedByPrice { get; set; }
        
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
        public string? ReasonForDiscount { get; set; }
        public bool IsVoided { get; set; }

        public int? DiscountByLookupItemId { get; set; }
        public string? CouponCode { get; set; }

        [NotMapped]
        public bool IsDiscountApplied { get; set; } 

        public virtual LookupTypeItem LookupTypeItem { get; set; }
        public virtual DiscountCoupon? DiscountCoupon { get; set; }

        // Navigation properties
        public virtual PosTransaction PosTransaction { get; set; }
        public virtual AccountProduct AccountProduct { get; set; }
    }
}
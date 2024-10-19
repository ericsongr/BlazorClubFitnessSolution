using System.ComponentModel.DataAnnotations.Schema;

namespace ClubFitnessDomain.Dtos
{
    public class PosTransactionItemDto
    {
        public int ProductId { get; set; }

        public string ProductImage { get; set; }
        
        public int ItemQuantity { get; set; }
        public decimal ItemTaxAmount { get; set; }
        public decimal ItemPriceExTax { get; set; }
        public decimal ItemPriceIncTax { get; set; }
        public decimal Discount { get; set; }
        public bool IsRefunded { get; set; }
        public string? ItemDescription { get; set; }
        public bool IsVoided { get; set; }

    }
}
namespace ClubFitnessDomain
{
    public class PosTransactionAudit
    {
        public long PosTransactionAuditId { get; set; }
        public long PosTransactionId { get; set; }
        public DateTime PosTransactionUtcDateTime { get; set; }
        public DateTime PosTransactionLocalDateTime { get; set; }
        public string? MemberNumber { get; set; }
        public decimal PosTransactionTotalIncTax { get; set; }
        public decimal PosTransactionTotalExTax { get; set; }
        public decimal PosTransactionTotalTax { get; set; }
        public int StaffMemberId { get; set; }
        public int? PrintFlag { get; set; }
        public int ProductId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTaxAmount { get; set; }
        public decimal ItemPriceExTax { get; set; }
        public decimal ItemPriceIncTax { get; set; }
        public string? PaymentType { get; set; }
        public string? CCNumber { get; set; }
        public decimal Discount { get; set; }
        public string? ReasonForDiscount { get; set; }
        public int ItemType { get; set; }
        public long PosTransactionItemId { get; set; }
        public int AuditPosType { get; set; }
        public int? SalesPersonStaffId { get; set; }

        // Navigation properties
        public PosTransaction PosTransaction { get; set; }
        public Staff Staff { get; set; }
    }
}
namespace ClubFitnessDomain
{
    public class PosTransactionGenericItem
    {
        public long PosTransactionGenericItemId { get; set; }
        public long PosTransactionId { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemAmount { get; set; }
        public int ItemQuantity { get; set; }
        public int? MembershipTypeId { get; set; }
        public string? MemberNumber { get; set; }
        public decimal Discount { get; set; }
        public short DiscountType { get; set; }

        // Navigation properties
        public PosTransaction PosTransaction { get; set; }
    }
}
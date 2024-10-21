namespace ClubFitnessDomain
{
    public class LookupTypeItem
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsShowOnline { get; set; }

        // Navigation property
        public LookupType LookupType { get; set; }
        public ICollection<PosTransactionItem> PosTransactionItems { get; set; }
        public ICollection<DiscountCoupon> DiscountCoupons { get; set; }
    }
}
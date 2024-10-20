namespace ClubFitnessDomain
{
    public class DiscountCoupon : IUserAction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CouponCode { get; set; }
        public decimal Discount { get; set; }
        public short DiscountType { get; set; }
        public decimal? MinimumAmount { get; set; }
        public bool IsActive { get; set; }
        
        public DateTime? ExpiryDate { get; set; }
        public int AccountId { get; set; }
        public string? ChargeType { get; set; }
        public short DiscountFor { get; set; }
        public bool IsCombineFees { get; set; }
        public string? AllocatedValueJson { get; set; }


        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }


        // Navigation properties
        public virtual Staff? CreatedByStaff { get; set; }
        public virtual Staff? UpdatedByStaff { get; set; }
        public virtual Staff? DeletedByStaff { get; set; }

        public ICollection<PosTransactionItem> PosTransactionItems { get; set; }
    }
}
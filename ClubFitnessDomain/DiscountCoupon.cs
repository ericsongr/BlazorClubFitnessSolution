namespace ClubFitnessDomain
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CouponCode { get; set; }
        public decimal Discount { get; set; }
        public short DiscountType { get; set; }
        public decimal? MinimumAmount { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedUtcDateTime { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int AccountId { get; set; }
        public string? ChargeType { get; set; }
        public bool IsDeleted { get; set; }
        public short DiscountFor { get; set; }
        public bool IsCombineFees { get; set; }
        public string? AllocatedValueJson { get; set; }

        // Navigation properties
        public virtual Staff? CreatedByStaff { get; set; }
        public virtual Staff? UpdatedByStaff { get; set; }
    }
}
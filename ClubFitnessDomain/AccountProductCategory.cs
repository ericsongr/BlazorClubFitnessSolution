namespace ClubFitnessDomain
{
    public class AccountProductCategory: IUserAction
    {
        public int AccountProductCategoryId { get; set; }
        public int AccountId { get; set; }
        public string ProductCategoryName { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public string? DisplayImagePath { get; set; }
        public bool IsPosCategory { get; set; } = true;

        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }

        public virtual Account Account { get; set; }
        public virtual Staff CreatedByStaffAccountProductCategory { get; set; }
        public virtual Staff UpdatedByStaffAccountProductCategory { get; set; }
        public virtual Staff DeletedByStaffAccountProductCategory { get; set; }

        public virtual ICollection<AccountProduct> AccountProducts { get; set; }
    }
}
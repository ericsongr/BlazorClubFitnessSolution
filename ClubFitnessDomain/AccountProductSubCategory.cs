namespace ClubFitnessDomain
{
    public class AccountProductSubCategory
    {
        public int AccountProductSubCategoryId { get; set; }
        public int? AccountId { get; set; }
        public int AccountProductCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public string? ShortDescription { get; set; }
        public DateTime CreatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public string CreatedUserName { get; set; }
        public DateTime UpdatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public string UpdatedUserName { get; set; }
        public bool IsActive { get; set; } = true;
        public string? DisplayImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }
        public string? GlCode { get; set; }

        // Navigation Properties
        public virtual AccountProductCategory AccountProductCategory { get; set; }
        public virtual Account? Account { get; set; }

        public virtual ICollection<AccountProduct> AccountProducts { get; set; }
    }
}
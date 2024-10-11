namespace ClubFitnessDomain
{
    public class AccountProductSubCategory : IUserAction
    {
        public int AccountProductSubCategoryId { get; set; }
        public int? AccountId { get; set; }
        public int AccountProductCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public string? ShortDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public string? DisplayImagePath { get; set; }
        
        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }
        
        public string? GlCode { get; set; }

        // Navigation Properties
        public virtual AccountProductCategory AccountProductCategory { get; set; }
        public virtual Account? Account { get; set; }
        
        public virtual Staff? CreatedByStaffSubCategory { get; set; }
        public virtual Staff? UpdatedByStaffSubCategory { get; set; }
        public virtual Staff? DeletedByStaffSubCategory { get; set; }



        public virtual ICollection<AccountProduct> AccountProducts { get; set; }
    }
}
namespace ClubFitnessDomain
{
    public class AccountProductCategory
    {
        public int AccountProductCategoryId { get; set; }
        public int AccountId { get; set; }
        public string ProductCategoryName { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public DateTime CreatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public string CreatedUserName { get; set; } = string.Empty;
        public DateTime UpdatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public string UpdatedUserName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string? DisplayImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsPosCategory { get; set; } = true;

        public virtual Account Account { get; set; }

        public virtual ICollection<AccountProduct> AccountProducts { get; set; }
    }
}
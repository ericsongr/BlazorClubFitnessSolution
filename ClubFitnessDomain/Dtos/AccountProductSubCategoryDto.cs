namespace ClubFitnessDomain.Dtos
{
    public class AccountProductSubCategoryDto
    {
        public int AccountProductSubCategoryId { get; set; }
        public int? AccountId { get; set; }
        public int AccountProductCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public string? ShortDescription { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string? DisplayImagePath { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public string? DeletedBy { get; set; }
        public string? GlCode { get; set; }
    }
}
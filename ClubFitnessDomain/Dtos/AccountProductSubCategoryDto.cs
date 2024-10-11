namespace ClubFitnessDomain.Dtos
{
    public class AccountProductSubCategoryDto
    {
        public int AccountProductSubCategoryId { get; set; }
        public int? AccountId { get; set; }
        public int AccountProductCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public string? ShortDescription { get; set; }
        public bool IsActive { get; set; }
        public string? DisplayImagePath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }
        public string? GlCode { get; set; }
    }
}
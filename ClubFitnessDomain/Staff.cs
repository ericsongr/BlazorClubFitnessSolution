namespace ClubFitnessDomain
{
    public class Staff 
    {
        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public string? Barcode { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
        public string? PhotoLocation { get; set; }
        public string? Email { get; set; }
        public Guid? ProviderUserKey { get; set; }
        public int? AccessControlUserId { get; set; }
        public string? Role { get; set; }
        public bool IsRegister { get; set; }
        public string? PosAccessPin { get; set; }
        public bool CanModify { get; set; }
        public bool IsSubscribeReminder { get; set; }
        public int? PreferredClub { get; set; }
        public bool EnablePreferredClubPrompt { get; set; }
        public decimal HourlyRate { get; set; }
        public bool RestrictAccessByIp { get; set; }
        public string? RestrictedIp { get; set; }
        public bool EnableMfa { get; set; }
        public int MfaProvider { get; set; }
        public bool IsSaleStaff { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }

        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation properties
        public virtual Account PreferredClubAccount { get; set; }

        public ICollection<DiscountCoupon> StaffDiscountCoupons { get; set; }
        public ICollection<DiscountCoupon> StaffUpdatedDiscountCoupons { get; set; }
        public ICollection<DiscountCoupon> StaffDeletedDiscountCoupons { get; set; }

        public ICollection<AccountProduct> CreatedByAccountProducts { get; set; }
        public ICollection<AccountProduct> UpdatedByAccountProducts { get; set; }
        public ICollection<AccountProduct> DeletedByAccountProducts { get; set; }

        public ICollection<AccountProductCategory> CreatedByAccountProductCategories { get; set; }
        public ICollection<AccountProductCategory> UpdatedByAccountProductCategories { get; set; }
        public ICollection<AccountProductCategory> DeletedByAccountProductCategories { get; set; }

        public ICollection<AccountProductSubCategory> CreatedByProductSubCategories { get; set; }
        public ICollection<AccountProductSubCategory> UpdatedByProductSubCategories { get; set; }
        public ICollection<AccountProductSubCategory> DeletedByProductSubCategories { get; set; }

        public ICollection<AccountSupplier> CreatedByAccountSuppliers { get; set; }
        public ICollection<AccountSupplier> UpdatedByAccountSuppliers { get; set; }
        public ICollection<AccountSupplier> DeletedByAccountSuppliers { get; set; }
        
        public ICollection<Account> CreatedByAccounts { get; set; }
        public ICollection<Account> UpdatedByAccounts { get; set; }
        public ICollection<Account> DeletedByAccounts { get; set; }
        
    }
}
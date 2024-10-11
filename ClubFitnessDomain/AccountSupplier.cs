using System;

namespace ClubFitnessDomain
{
    public class AccountSupplier
    {
        public int AccountSupplierId { get; set; }
        public int? AccountId { get; set; }
        public int SupplierNumber { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierReference { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactFax { get; set; }
        public string? BusinessNumber { get; set; }
        public string? AccountNumber { get; set; }
        public string? WebAccountURL { get; set; }
        public bool IsActive { get; set; } = true;
        public int? LeadTimeDays { get; set; }
        public string? ShippingReference { get; set; }
        public DateTime CreatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedUtcDateTime { get; set; } = DateTime.UtcNow;
        public string? DisplayImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation property
        public virtual Account Account { get; set; }

        public virtual ICollection<AccountProduct> AccountProducts { get; set; }
    }
}
using System;

namespace ClubFitnessDomain
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? Timezone { get; set; }
        public bool IsActive { get; set; }
        public string? Street { get; set; }
        public string? SubUrb { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string DialingCode { get; set; }
        public string? BusinessOwnerName { get; set; }
        public string? BusinessOwnerPhoneNumber { get; set; }
        public string? BusinessOwnerEmail { get; set; }
        public string? GeoCoordinates { get; set; }
        public int ClubfitFeeFailedPaymentCount { get; set; }
        public DateTime? PaymentIssueSuspensionDate { get; set; }
        public Guid AdvancedEmailEditorUid { get; set; }
        public string? CompanyLegalName { get; set; }

        public virtual ICollection<AccountSupplier> AccountSuppliers { get; set; }
    }
}
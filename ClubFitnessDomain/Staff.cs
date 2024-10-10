namespace ClubFitnessDomain
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public string? Barcode { get; set; }
        public DateTime LastModifiedUTCDateTime { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
        public string? PhotoLocation { get; set; }
        public string? Email { get; set; }
        public Guid? ProviderUserKey { get; set; }
        public int? AccessControlUserId { get; set; }
        public string? Role { get; set; }
        public bool IsRegister { get; set; }
        public int? CreatedBy { get; set; }
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

        // Navigation properties
        public virtual Account PreferredClubAccount { get; set; }
    }
}
namespace ClubFitnessDomain
{
    public class PosTransaction : IUserAction
    {
        public long PosTransactionId { get; set; }
        public DateTime PosTransactionUtcDateTime { get; set; }
        public DateTime PosTransactionLocalDateTime { get; set; }
        public string? MemberNumber { get; set; }
        public decimal PosTransactionTotalIncTax { get; set; }
        public decimal PosTransactionTotalExTax { get; set; }
        public decimal PosTransactionTotalTax { get; set; }
        public int StaffMemberId { get; set; }
        public int? PrintFlag { get; set; }
        public string? Till { get; set; }
        public long? PosTransactionRefId { get; set; }
        public string? TransactionType { get; set; }
        public string? RefundType { get; set; }
        public decimal OutstandingBalance { get; set; }
        public int? AccountId { get; set; }
        
        public DateTime CreatedDateTimeUtc { get; set; }
        public int CreatedBy { get; set; }
        
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }

        public virtual ICollection<PosTransactionItem> PosTransactionItems { get; set; }
        public virtual ICollection<PosTransactionPayment> PosTransactionPayments { get; set; }
        public virtual ICollection<PosTransactionGenericItem> PosTransactionGenericItems { get; set; }
        public virtual ICollection<PosTransactionAudit> PosTransactionAudits { get; set; }

        // Navigation properties
        public virtual Staff? CreatedByStaff { get; set; }
        public virtual Staff? UpdatedByStaff { get; set; }
        public virtual Staff? DeletedByStaff { get; set; }
        public virtual Account Account { get; set; }
    }
}
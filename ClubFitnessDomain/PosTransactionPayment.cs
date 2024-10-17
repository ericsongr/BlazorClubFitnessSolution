namespace ClubFitnessDomain
{
    public class PosTransactionPayment
    {
        public long PosTransactionPaymentId { get; set; }
        public long PosTransactionId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public string? CCNumber { get; set; }
        public DateTime? TransactionDateUtc { get; set; }

        // Navigation properties
        public PosTransaction PosTransaction { get; set; }
    }
}
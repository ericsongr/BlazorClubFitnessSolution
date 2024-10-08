namespace ClubFitnessDomain.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? Timezone { get; set; }
        public bool IsActive { get; set; }
       
    }
}

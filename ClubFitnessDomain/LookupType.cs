namespace ClubFitnessDomain
{
    public class LookupType
    {
        public int TypeId { get; set; }
        public string Type { get; set; }

        // Navigation properties
        public ICollection<LookupTypeItem> LookupTypeItems { get; set; }
    }
}
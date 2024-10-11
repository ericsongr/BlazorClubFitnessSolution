namespace ClubFitnessDomain;

public interface IUserAction
{
    //add
    public DateTime CreatedDateTimeUtc { get; set; }
    public int CreatedBy { get; set; }

    //edit
    public DateTime? UpdatedDateTimeUtc { get; set; }
    public int? UpdatedBy { get; set; }

    //delete
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDateTimeUtc { get; set; }
    public int? DeletedBy { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace ClubFitnessSolution.Models;

public class UserGroup
{
    [Required(ErrorMessage = "Please select role")]
    public string SelectedRole { get; set; }

    [Required(ErrorMessage = "Please Username")]
    public string Username { get; set; }
    public string Message { get; set; }

}
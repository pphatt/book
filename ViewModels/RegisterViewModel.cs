using System.ComponentModel.DataAnnotations;

namespace comic.ViewModels;

public class RegisterViewModel
{
    [Required]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$", 
        ErrorMessage = "Password must have more than 7 characters, 1 uppercase, 1 lowercase, 1 number, and 1 special character")]
    public string Password { get; set; }
}
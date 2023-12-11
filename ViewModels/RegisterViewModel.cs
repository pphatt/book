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
    public string Password { get; set; }
}
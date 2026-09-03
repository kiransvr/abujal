using System.ComponentModel.DataAnnotations;

namespace AbujalWebsite.Models;

public class ContactRequest
{
    [Required(ErrorMessage = "Please enter your name.")]
    [StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Please select a service of interest.")]
    public string ServiceInterest { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a message.")]
    [StringLength(2000)]
    public string Message { get; set; } = string.Empty;
}

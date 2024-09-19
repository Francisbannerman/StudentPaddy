using System.ComponentModel.DataAnnotations;

namespace GetEmployed.v2.Dtos;

public class ResetPasswordDto
{
    [Required]
    public string Token { get; set; }
    public string NewPassword { get; set; }
    public string? UserEmail { get; set; }
}
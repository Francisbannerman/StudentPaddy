using Dapper;
using GetEmployed.v2.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace GetEmployed.v2.Controllers;


[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public UserController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private NpgsqlConnection GetConnection()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(connectionString);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
    {
        using (var connection = GetConnection())
        {
            var existingUser = await connection.QueryFirstOrDefaultAsync<string>(
                "SELECT Email FROM Users WHERE Email = @Email", 
                new { Email = registrationDto.Email });

            if (existingUser != null)
            {
                return BadRequest("User with the given email already exists.");
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Email = registrationDto.Email,
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                TelephoneNumber = registrationDto.TelephoneNumber,
                Password = HashPassword(registrationDto.Password),
                IsUserOnAPlan = false,
                TotalJobsApplied = 0,
                TotalOffersReceived = 0,
                TotalUpcomingInterviews = 0,
                TotalNumberOfRejections = 0,
                IsUserAMentor = false
            };

            var sql = @"
                    INSERT INTO Users (UserId, Email, FirstName, LastName, TelephoneNumber, Password, 
                        IsUserOnAPlan, TotalJobsApplied, TotalOffersReceived, TotalUpcomingInterviews, 
                        TotalNumberOfRejections, IsUserAMentor)
                    VALUES (@UserId, @Email, @FirstName, @LastName, @TelephoneNumber, @Password, 
                        @IsUserOnAPlan, @TotalJobsApplied, @TotalOffersReceived, @TotalUpcomingInterviews, 
                        @TotalNumberOfRejections, @IsUserAMentor)";
                
            await connection.ExecuteAsync(sql, user);

            return Ok("User registered successfully");
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        using (var connection = GetConnection())
        {
            var user = await connection.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Email = @Email", 
                new { Email = loginDto.Email });

            if (user == null || HashPassword(loginDto.Password) != user.Password)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(new { message = "Login successful", UserId = user.UserId });
        }
    }
    
    private string HashPassword(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes); // You can use Base64 for storing the hash
        }
    }
    
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        using (var connection = GetConnection())
        {
            var user = await connection.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Users WHERE Email = @Email", 
                new { Email = forgotPasswordDto.Email });

            if (user == null)
            {
                return BadRequest("No user found with the given email.");
            }
            var resetToken = Guid.NewGuid().ToString();
            return Ok(resetToken);
        }
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
        using (var connection = GetConnection())
        {
            var sql = "UPDATE Users SET Password = @Password WHERE Email = @Email";

            await connection.ExecuteAsync(sql, new
            {
                Password = HashPassword(resetPasswordDto.NewPassword),
                Email = resetPasswordDto.UserEmail
            });
            return Ok("Password has been successfully reset.");
        }
    }

}
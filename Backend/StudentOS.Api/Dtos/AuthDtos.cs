namespace StudentOS.Api.Dtos;

public record RegisterDto(string FullName, string Email, string Password, string Role); // Admin | Teacher | Student
public record LoginDto(string Email, string Password);

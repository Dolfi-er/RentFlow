using Backend.DTOs;


namespace Backend.Services;

public interface IEmailService
{
    Task SendRecoveryCodeAsync(string email, string code);
    Task SendEmailAsync(SendEmailDTO sendEmailDTO);
}
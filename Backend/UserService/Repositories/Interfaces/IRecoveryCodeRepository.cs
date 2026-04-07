using Backend.Models;

namespace Backend.Repositories;

public interface IRecoveryCodeRepository
{
    Task<bool> SaveRecoveryCodeAsync(string email, RecoveryData data, TimeSpan expiry);
    Task<RecoveryData?> GetRecoveryCodeAsync(string email);
    Task<bool> UpdateRecoveryCodeAsync(string email, RecoveryData data, TimeSpan expiry);
    Task<bool> DeleteRecoveryCodeAsync(string email);
}
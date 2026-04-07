using System.Text.Json;
using Backend.Models;
using StackExchange.Redis;

namespace Backend.Repositories;

public class RecoveryCodeRepository : IRecoveryCodeRepository
{
    private readonly IDatabase _db;

    public RecoveryCodeRepository(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    private string GetKey(string email) => $"recovery:{email}";

    public async Task<bool> SaveRecoveryCodeAsync(string email, RecoveryData data, TimeSpan expiry)
    {
        var key = GetKey(email);
        var value = JsonSerializer.Serialize(data);
        return await _db.StringSetAsync(key, value, expiry);
    }

    public async Task<RecoveryData?> GetRecoveryCodeAsync(string email)
    {
        var key = GetKey(email);
        var value = await _db.StringGetAsync(key);

        if (value.IsNullOrEmpty)
            return null;

        return JsonSerializer.Deserialize<RecoveryData>(value!);
    }
    public async Task<bool> UpdateRecoveryCodeAsync(string email, RecoveryData data, TimeSpan expiry)
    {
        var key = GetKey(email);
        var value = JsonSerializer.Serialize(data);
        return await _db.StringSetAsync(key, value, expiry);
    }
    public async Task<bool> DeleteRecoveryCodeAsync(string email)
    {
        var key = GetKey(email);
        return await _db.KeyDeleteAsync(key);
    }
}
namespace Backend.Services;

public interface ITokenAccessor
{
    Guid? GetUserId();
}
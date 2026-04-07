namespace FacilityService.Services;

public interface ITokenAccessor
{
    Guid? GetUserId();
}
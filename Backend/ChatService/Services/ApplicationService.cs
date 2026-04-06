using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;

namespace Backend.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly string _baseFileURL;

    public ApplicationService(IApplicationRepository applicationRepository, IConfiguration configuration)
    {
        _applicationRepository = applicationRepository;
        _baseFileURL = configuration["FileEndpointBase"]!;
    }

    public async Task<Result<List<GetApplicationDTO>>> GetByMessageId(Guid messageId)
    {
        List<Application> entities = await _applicationRepository.GetByMessageId(messageId);
        List<GetApplicationDTO> dtos = new List<GetApplicationDTO>();
        foreach (var entity in entities)
        {
            dtos.Add(entity.ToDTO(_baseFileURL));
        }
        return Result<List<GetApplicationDTO>>.Success(dtos);
    }

    public async Task<Result<Guid>> CreateAsync(PostApplicationDTO postApplicationDTO)
    {
        Application application = postApplicationDTO.ToEntity();
        Guid id = await _applicationRepository.CreateAsync(application);
        return Result<Guid>.Success(id);
    }

    public async Task<Result<bool>> RemoveAsync(Guid id)
    {
        Application? application = await _applicationRepository.GetById(id);
        if(application is null) return Result<bool>.Error(ErrorCode.ApplicationNotFound);
        await _applicationRepository.RemoveAsync(application);
        return Result<bool>.Success(true);
    }
}
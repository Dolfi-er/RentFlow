using FacilityService.DTOs.FacilityDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Models.Entities;
using FacilityService.Repositories;
using MongoDB.Bson;

namespace FacilityService.Services;

public class MyFacilityService : IMyFacilityService
{
    private readonly IFacilityRepository _facilityRepository;
    private readonly IFileService _fileService;
    private readonly IContentTypeService _contentTypeService;
    private readonly string _baseFileURL;

    public MyFacilityService(IFacilityRepository facilityRepository, IFileService fileService, IContentTypeService contentTypeService, IConfiguration configuration)
    {
        _facilityRepository = facilityRepository;
        _fileService = fileService;
        _contentTypeService = contentTypeService;
        _baseFileURL = configuration["FileEndpointBase"]!;
    }

    public async Task<GetFacilityDTO?> GetByIdAsync(Guid facilityId)
    {
        FacilityEntity? facilityEntity = await _facilityRepository.GetByIdAsync(facilityId);
        if (facilityEntity is null) return null;
        return facilityEntity.ToDTO(_baseFileURL);
    }

    public async Task<List<GetFacilityDTO>> GetAllAsync()
    {
        return (await _facilityRepository.GetAllAsync()).Select(f => f.ToDTO(_baseFileURL)).ToList();
    }

    public async Task<List<GetFacilityDTO>> GetByOwnerAsync(Guid ownerId)
    {
        return (await _facilityRepository.GetAllAsync(ownerId)).Select(f => f.ToDTO(_baseFileURL)).ToList();
    }

    public async Task<Guid> CreateAsync(PostFacilityDTO postFacilityDTO, Guid ownerId)
    {
        Guid facilityId = Guid.NewGuid();
        FacilityEntity facilityEntity = postFacilityDTO.ToEntityFacility(ownerId);
        facilityEntity.Id = facilityId;

        AddressEntity addressEntity = postFacilityDTO.ToEntityAddress();
        addressEntity.Id = facilityId;
        facilityEntity.Address = addressEntity;

        List<ApplicationEntity> applicationEntities = await CreateApplications(facilityEntity.Id, postFacilityDTO.Files);
        facilityEntity.Applications.AddRange(applicationEntities);

        return await _facilityRepository.CreateAsync(facilityEntity);
    }

    public async Task<bool> UpdateAsync(Guid updateFacilityId, Guid ownerId, PutFacilityDTO putFacilityDTO)
    {
        FacilityEntity? facilityEntity = await _facilityRepository.GetByIdAsync(updateFacilityId);
        if (facilityEntity is null) return false;

        foreach (ApplicationEntity applicationEntity in facilityEntity.Applications)
        {
            await _fileService.Remove(applicationEntity.DocumentId.ToString());
        }

        await _facilityRepository.RemoveApplications(facilityEntity);

        facilityEntity.UpdateEntity(putFacilityDTO);

        List<ApplicationEntity> applicationEntities = await CreateApplications(facilityEntity.Id, putFacilityDTO.Files);
        facilityEntity.Applications.AddRange(applicationEntities);

        return await _facilityRepository.SaveChangesAsync();
    }

    private async Task<List<ApplicationEntity>> CreateApplications(Guid facilityId, List<IFormFile> files)
    {
        List<ApplicationEntity> applicationEntities = new List<ApplicationEntity>();

        foreach (IFormFile file in files)
        {
            using Stream stream = file.OpenReadStream();
            ObjectId documentId = await _fileService.Upload(stream, file.FileName);

            ApplicationEntity applicationEntity = new ApplicationEntity()
            {
                DocumentId = documentId,
                ContentType = _contentTypeService.GetContentType(file.FileName),
                FacilityId = facilityId,
            };

            applicationEntities.Add(applicationEntity);
        }

        return applicationEntities;
    }

    public async Task RemoveAsync(Guid facilityId)
    {
        FacilityEntity? facilityEntity = await _facilityRepository.GetByIdAsync(facilityId);
        if (facilityEntity is null) return;

        foreach (ApplicationEntity applicationEntity in facilityEntity.Applications)
        {
            await _fileService.Remove(applicationEntity.DocumentId.ToString());
        }

        await _facilityRepository.RemoveApplications(facilityEntity);
        await _facilityRepository.RemoveAsync(facilityId);
        await _facilityRepository.SaveChangesAsync();
    }
}
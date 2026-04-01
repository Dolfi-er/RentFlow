using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;

namespace Backend.Services;

public class Userservice : IUserService
{
    private readonly IUSerRepository _UserRepository;
    private readonly IUserInfoRepository _UserInfoRepository;
    public Userservice(IUSerRepository UserRepository, IUserInfoRepository UserInfoRepository)
    {
        _UserRepository = UserRepository;
        _UserInfoRepository = UserInfoRepository;
    }
    public async Task<Result<GetUser>> GetUser(Guid id)
    {
        User? user = await _UserRepository.GetUser(id);
        if(user is null) return Result<GetUser>.Error(ErrorCode.UserNotFound);
        return Result<GetUser>.Success(user.ToDTO());
    }

    public async Task<Result<bool>> UpdateUserInfo(PutUserInfo putUserInfo)
    {
       UserInfo? userInfo = await _UserInfoRepository.GetUserInfo(putUserInfo.Id);
       if(userInfo is null) return Result<bool>.Error(ErrorCode.UserInfoNotFound);
       userInfo.UpdateUserInfo(putUserInfo);
       await _UserInfoRepository.UpdateUserInfo(userInfo);
       return Result<bool>.Success(true);
    }
}
using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;
using FluentValidation;

namespace Backend.Services;

public class Userservice : IUserService
{
    private readonly IUSerRepository _UserRepository;
    private readonly IUserInfoRepository _UserInfoRepository;
    private readonly AbstractValidator<PutUserInfo> _validator;
    public Userservice(IUSerRepository UserRepository, IUserInfoRepository UserInfoRepository, AbstractValidator<PutUserInfo> validator)
    {
        _UserRepository = UserRepository;
        _UserInfoRepository = UserInfoRepository;
        _validator = validator;
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
        var result = await _validator.ValidateAsync(putUserInfo);
        if (!result.IsValid)
        {
            var firstError = result.Errors.First();
            var code = Enum.Parse<ErrorCode>(firstError.ErrorCode);
            return Result<bool>.Error(code);
        }
       userInfo.UpdateUserInfo(putUserInfo);
       await _UserInfoRepository.UpdateUserInfo(userInfo);
       return Result<bool>.Success(true);
    }
}
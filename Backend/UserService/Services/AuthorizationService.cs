using Backend.DTOs;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;
using BackEnd.Extensions;
using FluentValidation;

namespace Backend.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IUSerRepository _userRepository;
    private readonly IHashService _hashService;
    private readonly AbstractValidator<RegistrDTO> _validator;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ICookieService _cookieService;
    public AuthorizationService(IUSerRepository userRepository, IHashService hashService, AbstractValidator<RegistrDTO> validator, IJwtService jwtService, IRefreshTokenService refreshTokenService, ICookieService cookieService)
    {
        _userRepository = userRepository;
        _hashService = hashService;
        _validator = validator;
        _jwtService = jwtService;
        _refreshTokenService = refreshTokenService;
        _cookieService = cookieService;
    }
    public async Task<bool> ChangePassword(string login, string newPassword)
    {
        User? user = await _userRepository.GetUserByLogin(login);
        if (user == null) return false;
        newPassword = _hashService.Hash(newPassword);
        await _userRepository.UpdateUser(user, newPassword);
        return  true;
    }

    public async Task<Result<AnswerLoginDTO>> Login(LoginDTO loginDTO)
    {
        User? user = await _userRepository.GetUserByLogin(loginDTO.Login);
        if (user == null) return Result<AnswerLoginDTO>.Error(ErrorCode.UserNotFound);
        if (!_hashService.Verify(user!.HashPassword, loginDTO.Password)) return Result<AnswerLoginDTO>.Error(ErrorCode.WrongPassword);

        string token = _jwtService.GenerateToken(user);
        string coockieName = _jwtService.GetCookieName();
        int ExpireMinutes = _jwtService.GetExpireMinutes();

        string refreshToken = await _refreshTokenService.CreateToken(user);
        bool flag = _cookieService.SetCookie(coockieName, refreshToken, 10);
        if (!flag) return Result<AnswerLoginDTO>.Error(ErrorCode.CookieError);
        AnswerLoginDTO answer = new AnswerLoginDTO().With(x => x.UserId = user.Id).With(x => x.Token = token).With(x => x.CookieName = coockieName).With(x => x.ExpireMinutes = ExpireMinutes);
        return Result<AnswerLoginDTO>.Success(answer);
    }

    public async Task<Result<bool>> Logout(Guid id)
    {
        string coockiename = _jwtService.GetCookieName();
        string? token = _cookieService.GetCookie(coockiename);
        if (token == null) return Result<bool>.Error(ErrorCode.NotFoundToken);
        bool flag = await _refreshTokenService.DeleteToken(token, id);
        if (!flag) return Result<bool>.Error(ErrorCode.DeleteTokenError);
        _cookieService.DeleteCookie(coockiename);
        return Result<bool>.Success(true);
    }

    public async Task<Result<ChangeTokenDTO>> RefreshToken(Guid id)
    {
         string coockiename = _jwtService.GetCookieName();
        string? token = _cookieService.GetCookie(coockiename);
        if (token == null) return Result<ChangeTokenDTO>.Error(ErrorCode.NotFoundToken);
        bool flag = await _refreshTokenService.IsTokenValid(token, id);
        if (!flag) return Result<ChangeTokenDTO>.Error(ErrorCode.InvalidRefreshToken);
        User? userEntity = await _userRepository.GetUser(id);
        if (userEntity == null) return Result<ChangeTokenDTO>.Error(ErrorCode.UserNotFound);
        string newRefreshToken = await _refreshTokenService.CreateToken(userEntity);
        string newAccessToken = _jwtService.GenerateToken(userEntity);
        flag = _cookieService.SetCookie(coockiename, newRefreshToken, 10);
        if (!flag) return Result<ChangeTokenDTO>.Error(ErrorCode.CookieError);
        return Result<ChangeTokenDTO>.Success(new ChangeTokenDTO{AccessToken = newAccessToken});
    }

    public async Task<Result<Guid?>> RegistrUser(RegistrDTO registrDTO)
    {
        List<User> users = await  _userRepository.GetAllUsers();
        if (users.Where(u => u.Login == registrDTO.Login).Where(u => u.Email == registrDTO.Email).Count() == 0)
        {
            var result = await _validator.ValidateAsync(registrDTO);
            if (!result.IsValid)
            {
                var firstError = result.Errors.First();
                var code = Enum.Parse<ErrorCode>(firstError.ErrorCode);
                return Result<Guid?>.Error(code);
            }
            registrDTO.Password = _hashService.Hash(registrDTO.Password);
            User user = registrDTO.ToEntity();
            UserInfo userInfo = registrDTO.ToUserInfo(user.Id);
            Guid? id = await _userRepository.CreateUser(user, userInfo);
            if (id is null) return Result<Guid?>.Error(ErrorCode.UserCreationError);
            return Result<Guid?>.Success(id);
        }
        return Result<Guid?>.Error(ErrorCode.RepeatLogin);
    }
}
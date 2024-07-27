using Microsoft.EntityFrameworkCore;
using ShreeGanpati.API.Data;
using ShreeGanpati.API.Data.Entities;
using ShreeGanpati.Shared.Dtos;

namespace ShreeGanpati.API.Services;

public class AuthService(DataContext context, TokenService tokenService, PaswordService paswordService)
{
    private readonly DataContext _context = context;
    private readonly TokenService _tokenService = tokenService;
    private readonly PaswordService _paswordService = paswordService;

    public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
    {
        if (await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
        {
            return ResultWithDataDto<AuthResponseDto>.Failure("Email alredy exists");
        }
        var user = new User
        {
            Email = dto.Email,
            Address = dto.Address,
            Name = dto.Name,
        };

        (user.Salt, user.Hash) = _paswordService.GenerateSaltAndHash(dto.Password);
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, user.Address);
            var token = _tokenService.GenerateJwt(loggedInUser);
            var authResponse = new AuthResponseDto(loggedInUser, token);

            return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
        }
        catch (Exception ex)
        {
            return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
        }

    }
    //public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
    //{
    //    var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == dto.Email);

    //    if (dbUser is null)
    //        return ResultWithDataDto<AuthResponseDto>.Failure("User dose not exist");

    //}
}




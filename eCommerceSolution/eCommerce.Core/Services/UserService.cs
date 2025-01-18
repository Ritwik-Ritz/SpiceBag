using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<AuthResponse?> Login(Loginrequest loginrequest)
    {
        ApplicationUser? appUser = await _usersRepository.GetUserByEmailAndPass(loginrequest.Email, loginrequest.Password);

        if(appUser == null)
        {
            return null;
        }

        //return new AuthResponse(appUser.UserId, appUser.Email, appUser.PersonName, appUser.Gender, "token", true);
        //using automapper
        return _mapper.Map<AuthResponse>(appUser) with { Token = "token", Success = true};
    }

    public async Task<AuthResponse?> Register(RegisterRequest registerRequest)
    {

        //ApplicationUser newAppUser = new ApplicationUser() { 
        //Email = registerRequest.Email,
        //Password = registerRequest.Password,
        //PersonName = registerRequest.PersonName,
        //Gender  = registerRequest.Gender.ToString()};

        ApplicationUser newAppUser = _mapper.Map<ApplicationUser>(registerRequest);


        ApplicationUser? registeredUser = await _usersRepository.AddUser(newAppUser);

        if (registeredUser == null) { return null; }

        //return new AuthResponse(registeredUser.UserId, registeredUser.Email,registeredUser.PersonName, registeredUser.Gender, "Tojen", true);

        return _mapper.Map<AuthResponse>(registeredUser) with { Token = "tojen", Success = true };
    }
}

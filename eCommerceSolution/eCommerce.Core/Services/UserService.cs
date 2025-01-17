using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services;

internal class UserService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AuthResponse?> Login(Loginrequest loginrequest)
    {
        ApplicationUser? appUser = await _usersRepository.GetUserByEmailAndPass(loginrequest.Email, loginrequest.Password);

        if(appUser == null)
        {
            return null;
        }

        return new AuthResponse(appUser.UserId, appUser.Email, appUser.PersonName, appUser.Gender, "token", true);
    }

    public async Task<AuthResponse?> Register(RegisterRequest registerRequest)
    {

        ApplicationUser newAppUser = new ApplicationUser() { 
        Email = registerRequest.Email,
        Password = registerRequest.Password,
        PersonName = registerRequest.PersonName,
        Gender  = registerRequest.Gender.ToString()};


        ApplicationUser? registeredUser = await _usersRepository.AddUser(newAppUser);

        if (registeredUser == null) { return null; }

        return new AuthResponse(registeredUser.UserId, registeredUser.Email,registeredUser.PersonName, registeredUser.Gender, "Tojen", true);
    }
}

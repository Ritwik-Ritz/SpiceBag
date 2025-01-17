using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Services.Repository;

internal class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser User)
    {
        User.UserId = Guid.NewGuid();

        return User;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPass(string? email, string? password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "",
            Gender = Genderoptions.Male.ToString(),
        };
    }
}
 
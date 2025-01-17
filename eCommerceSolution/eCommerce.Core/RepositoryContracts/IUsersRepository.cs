using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser User);
    Task<ApplicationUser?> GetUserByEmailAndPass(string? email, string? password);
}

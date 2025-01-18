using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Services.DbContext;

namespace eCommerce.Services.Repository;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser User)
    {
        User.UserId = Guid.NewGuid();

        //sql query to add to postgre
        string query = "INSERT INTO public.\"Users\" (\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\" ) VALUES(@UserId, @Email, @PersonName, @Gender, @Password) ";

        int numOfRowsAffected = await _dbContext.DbConnection.ExecuteAsync(query, User);

        if (numOfRowsAffected > 0)
        {
            return User;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPass(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
        var parameters = new {Email =email , Password =password};

        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);

        return user;
    }
}
 
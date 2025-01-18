﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Services.DbContext;

public class DapperDbContext 
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("postgres");

        //create a new connection
        _connection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
}

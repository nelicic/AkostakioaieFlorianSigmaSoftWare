using API.Controllers;
using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace APIXunitTest;

public class UserControllerXunitTests
{
    private readonly DataContext _dbContext;
    public UserControllerXunitTests()
    {
        _dbContext = GetDatabaseContext();
    }

    [Theory]
    [InlineData(0, "Bob", "asj@gmail.co m")]
    [InlineData(0, "Bob", "sa@1345.13@")]
    [InlineData(0, "Bob", ".@ASDOI@")]
    [InlineData(0, "Bob", "IAS@@")]
    [InlineData(0, "Bob", "cz..8")]
    public async Task CreateUser_WithInvalidEmail_ExpectedBadRequest(int id, string name, string email)
    {
        var userController = new UsersController(_dbContext);
        User user = new User() { Id = id, Name = name, Email = email };

        var result = await userController.CreateUser(user);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Theory]
    [InlineData(0, "Bob", "sus@gmail.com")]
    [InlineData(0, "Bob", "okey@chnu.edu.ua")]
    [InlineData(0, "Bob", "name@example.com")]
    public async Task CreateUser_WithValidEmail_OkResult(int id, string name, string email)
    {
        var userController = new UsersController(_dbContext);
        User user = new User() { Id = id, Name = name, Email = email };

        var result = await userController.CreateUser(user);

        Assert.IsType<OkObjectResult>(result);
    }

    private DataContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new DataContext(options);
        databaseContext.Database.EnsureCreated();
        
        return databaseContext;
    }
}

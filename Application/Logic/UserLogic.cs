using Application.DaoInterface;
using Application.LogicInterfaces;
using Shared;
using Shared.DTO;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");
        
        //TODO add some more password logic

        ValidateData(dto);

        User toCreate = new User
        {
            userName = dto.UserName,
            password = dto.Password
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    private void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}
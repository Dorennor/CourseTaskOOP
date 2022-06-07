using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.PL.Interfaces;
using System.Threading.Tasks;

namespace CourseTaskOOP.PL.Services;

public class UserManagerService : IUserManager
{
    private readonly IUsersService<UserModel> _usersService;
    private UserModel? _loggedUser;

    public UserManagerService(IUsersService<UserModel> usersService)
    {
        _usersService = usersService;
        _loggedUser = _usersService.GetLoggedUserAsync().Result;
    }

    public UserModel? LoggedUser
    {
        get
        {
            return _loggedUser = _usersService.GetLoggedUserAsync().Result;
        }
    }

    public async Task LogoutAsync()
    {
        await _usersService.LogoutAsync();
    }

    public async Task LoginAsync(UserModel user)
    {
        await _usersService.LoginAsync(user);
    }

    public async Task RegisterAsync(UserModel user)
    {
        await _usersService.RegisterAsync(user);
    }
}
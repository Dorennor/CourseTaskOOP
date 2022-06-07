using CourseTaskOOP.BLL.Models;
using System.Threading.Tasks;

namespace CourseTaskOOP.PL.Interfaces;

public interface IUserManager
{
    UserModel LoggedUser { get; }

    Task LoginAsync(UserModel user);

    Task RegisterAsync(UserModel user);

    Task LogoutAsync();
}
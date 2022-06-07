using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class UsersService : IUsersService<UserModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public UsersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        var userModels = _mapper.Map<List<User>, List<UserModel>>(users);

        return userModels;
    }

    public async Task<UserModel> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        var userModel = _mapper.Map<User, UserModel>(user);

        return userModel;
    }

    public async Task<List<UserModel>> FindAsync(Func<UserModel, bool> predicate)
    {
        var userModels = _mapper.Map<List<User>, List<UserModel>>(await _unitOfWork.Users.GetAllAsync());
        return userModels.Where(predicate).ToList();
    }

    public async Task<UserModel> CreateAsync(UserModel item)
    {
        var user = _mapper.Map<UserModel, User>(item);
        await _unitOfWork.Users.CreateAsync(user);

        return item;
    }

    public async Task UpdateAsync(UserModel item)
    {
        var user = _mapper.Map<UserModel, User>(item);
        await _unitOfWork.Users.UpdateAsync(user);
    }

    public async Task DeleteAsync(UserModel item)
    {
        var user = _mapper.Map<UserModel, User>(item);
        await _unitOfWork.Users.DeleteAsync(user);
    }

    public async Task<bool> RegisterAsync(UserModel item)
    {
        var users = await _unitOfWork.Users.FindAsync(user => user.UserName == item.UserName);

        if (users.Count > 0) return false;

        var user = _mapper.Map<UserModel, User>(item);
        await _unitOfWork.Users.CreateAsync(user);

        return true;
    }

    public async Task<bool> LoginAsync(UserModel item)
    {
        var users = await _unitOfWork.Users.FindAsync(user => user.UserName == item.UserName);

        if (users.Count == 0) return false;

        var user = users.FirstOrDefault();

        if (user.PasswordHash != item.PasswordHash) return false;

        user.IsLogged = true;
        await _unitOfWork.Users.UpdateAsync(user);

        return true;
    }

    public async Task LogoutAsync()
    {
        var users = await _unitOfWork.Users.FindAsync(user => user.IsLogged == true);
        var user = users.FirstOrDefault();
        user.IsLogged = false;
        await _unitOfWork.Users.UpdateAsync(user);
    }

    public async Task<UserModel> GetLoggedUserAsync()
    {
        var users = await _unitOfWork.Users.FindAsync(user => user.IsLogged == true);

        if (users.Count <= 0) return null;

        var userModel = _mapper.Map<User, UserModel>(users.First());

        return userModel;
    }
}
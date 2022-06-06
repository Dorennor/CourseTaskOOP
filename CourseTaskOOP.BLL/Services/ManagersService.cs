using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class ManagersService : IUserService<ManagerModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public ManagersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<ManagerModel> GetAll()
    {
        var managers = _unitOfWork.Managers.GetAll();
        var managerModels = _mapper.Map<List<Manager>, List<ManagerModel>>(managers);

        return managerModels;
    }

    public ManagerModel GetById(int id)
    {
        var manager = _unitOfWork.Managers.GetById(id);
        var managerModel = _mapper.Map<Manager, ManagerModel>(manager);

        return managerModel;
    }

    public List<ManagerModel> Find(Func<ManagerModel, bool> predicate)
    {
        var managerModels = _mapper.Map<List<Manager>, List<ManagerModel>>(_unitOfWork.Managers.GetAll());
        return managerModels.Where(predicate).ToList();
    }

    public ManagerModel Create(ManagerModel item)
    {
        var manager = _mapper.Map<ManagerModel, Manager>(item);
        _unitOfWork.Managers.Create(manager);

        return item;
    }

    public void Update(ManagerModel item)
    {
        var manager = _mapper.Map<ManagerModel, Manager>(item);
        _unitOfWork.Managers.Update(manager);
    }

    public void Delete(ManagerModel item)
    {
        var manager = _mapper.Map<ManagerModel, Manager>(item);
        _unitOfWork.Managers.Delete(manager);
    }

    public bool Register(ManagerModel item)
    {
        var managers = _unitOfWork.Managers.Find(manager => manager.UserName == item.UserName);

        if (managers.Count > 0) return false;

        var manager = _mapper.Map<ManagerModel, Manager>(item);
        _unitOfWork.Managers.Create(manager);

        return true;
    }

    public bool Login(ManagerModel item)
    {
        var managers = _unitOfWork.Managers.Find(manager => manager.UserName == item.UserName);

        if (managers.Count == 0) return false;

        var manager = managers.FirstOrDefault();

        if (manager.PasswordHash != item.PasswordHash) return false;

        manager.IsLogged = true;
        _unitOfWork.Managers.Update(manager);

        return true;
    }

    public void Logout(ManagerModel item)
    {
        item.IsLogged = false;
        var manager = _mapper.Map<ManagerModel, Manager>(item);
        _unitOfWork.Managers.Update(manager);
    }

    public ManagerModel? GetLoggedUser()
    {
        var managers = _unitOfWork.Managers.Find(manager => manager.IsLogged == true);

        if (managers.Count <= 0) return null;

        var managerModel = _mapper.Map<Manager, ManagerModel>(managers.First());

        return managerModel;
    }
}
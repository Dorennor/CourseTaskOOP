using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class AdministratorsService : IUserService<AdministratorModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public AdministratorsService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Administrator, AdministratorModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<AdministratorModel> GetAll()
    {
        var administrators = _unitOfWork.Administrators.GetAll();
        var administratorModels = _mapper.Map<List<Administrator>, List<AdministratorModel>>(administrators);

        return administratorModels;
    }

    public AdministratorModel GetById(int id)
    {
        var administrator = _unitOfWork.Administrators.GetById(id);
        var administratorModel = _mapper.Map<Administrator, AdministratorModel>(administrator);

        return administratorModel;
    }

    public List<AdministratorModel> Find(Func<AdministratorModel, bool> predicate)
    {
        var administratorModels = _mapper.Map<List<Administrator>, List<AdministratorModel>>(_unitOfWork.Administrators.GetAll());
        return administratorModels.Where(predicate).ToList();
    }

    public AdministratorModel Create(AdministratorModel item)
    {
        var administrator = _mapper.Map<AdministratorModel, Administrator>(item);
        _unitOfWork.Administrators.Create(administrator);

        return item;
    }

    public void Update(AdministratorModel item)
    {
        var administrator = _mapper.Map<AdministratorModel, Administrator>(item);
        _unitOfWork.Administrators.Update(administrator);
    }

    public void Delete(AdministratorModel item)
    {
        var administrator = _mapper.Map<AdministratorModel, Administrator>(item);
        _unitOfWork.Administrators.Delete(administrator);
    }

    public bool Register(AdministratorModel item)
    {
        var administrators = _unitOfWork.Administrators.Find(administrator => administrator.UserName == item.UserName);

        if (administrators.Count > 0) return false;

        var administrator = _mapper.Map<AdministratorModel, Administrator>(item);
        _unitOfWork.Administrators.Create(administrator);

        return true;
    }

    public bool Login(AdministratorModel item)
    {
        var administrators = _unitOfWork.Administrators.Find(administrator => administrator.UserName == item.UserName);

        if (administrators.Count <= 0) return false;

        var administrator = administrators.FirstOrDefault();

        if (administrator.PasswordHash != item.PasswordHash) return false;

        administrator.IsLogged = true;
        _unitOfWork.Administrators.Update(administrator);

        return true;
    }

    public void Logout(AdministratorModel item)
    {
        item.IsLogged = false;
        var administrator = _mapper.Map<AdministratorModel, Administrator>(item);
        _unitOfWork.Administrators.Update(administrator);
    }

    public AdministratorModel? GetLoggedUser()
    {
        var administrators = _unitOfWork.Administrators.Find(administrator => administrator.IsLogged == true);

        if (administrators.Count <= 0) return null;

        var administratorModel = _mapper.Map<Administrator, AdministratorModel>(administrators.First());

        return administratorModel;
    }
}
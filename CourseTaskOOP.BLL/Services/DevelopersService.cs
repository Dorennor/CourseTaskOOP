using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class DevelopersService : IUserService<DeveloperModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public DevelopersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Developer, DeveloperModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<DeveloperModel> GetAll()
    {
        var developers = _unitOfWork.Developers.GetAll();
        var developerModels = _mapper.Map<List<Developer>, List<DeveloperModel>>(developers);

        return developerModels;
    }

    public DeveloperModel GetById(int id)
    {
        var developer = _unitOfWork.Developers.GetById(id);
        var developerModel = _mapper.Map<Developer, DeveloperModel>(developer);

        return developerModel;
    }

    public List<DeveloperModel> Find(Func<DeveloperModel, bool> predicate)
    {
        var developerModels = _mapper.Map<List<Developer>, List<DeveloperModel>>(_unitOfWork.Developers.GetAll());
        return developerModels.Where(predicate).ToList();
    }

    public DeveloperModel Create(DeveloperModel item)
    {
        var developer = _mapper.Map<DeveloperModel, Developer>(item);
        _unitOfWork.Developers.Create(developer);

        return item;
    }

    public void Update(DeveloperModel item)
    {
        var developer = _mapper.Map<DeveloperModel, Developer>(item);
        _unitOfWork.Developers.Update(developer);
    }

    public void Delete(DeveloperModel item)
    {
        var developer = _mapper.Map<DeveloperModel, Developer>(item);
        _unitOfWork.Developers.Delete(developer);
    }

    public bool Register(DeveloperModel item)
    {
        var developers = _unitOfWork.Developers.Find(developer => developer.UserName == item.UserName);

        if (developers.Count > 0) return false;

        var developer = _mapper.Map<DeveloperModel, Developer>(item);
        _unitOfWork.Developers.Create(developer);

        return true;
    }

    public bool Login(DeveloperModel item)
    {
        var developers = _unitOfWork.Developers.Find(developer => developer.UserName == item.UserName);

        if (developers.Count == 0) return false;

        var developer = developers.FirstOrDefault();

        if (developer.PasswordHash != item.PasswordHash) return false;

        developer.IsLogged = true;
        _unitOfWork.Developers.Update(developer);

        return true;
    }

    public void Logout(DeveloperModel item)
    {
        item.IsLogged = false;
        var developer = _mapper.Map<DeveloperModel, Developer>(item);
        _unitOfWork.Developers.Update(developer);
    }

    public DeveloperModel? GetLoggedUser()
    {
        var developers = _unitOfWork.Developers.Find(developer => developer.IsLogged == true);

        if (developers.Count <= 0) return null;

        var developerModel = _mapper.Map<Developer, DeveloperModel>(developers.First());

        return developerModel;
    }
}
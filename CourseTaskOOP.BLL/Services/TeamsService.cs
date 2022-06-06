using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class TeamsService : IService<TeamModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public TeamsService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Team, TeamModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<TeamModel> GetAll()
    {
        var teams = _unitOfWork.Teams.GetAll();
        var teamModels = _mapper.Map<List<Team>, List<TeamModel>>(teams);

        return teamModels;
    }

    public TeamModel GetById(int id)
    {
        var team = _unitOfWork.Teams.GetById(id);
        var teamModel = _mapper.Map<Team, TeamModel>(team);

        return teamModel;
    }

    public List<TeamModel> Find(Func<TeamModel, bool> predicate)
    {
        var teamModels = _mapper.Map<List<Team>, List<TeamModel>>(_unitOfWork.Teams.GetAll());
        return teamModels.Where(predicate).ToList();
    }

    public TeamModel Create(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        _unitOfWork.Teams.Create(team);

        return item;
    }

    public void Update(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        _unitOfWork.Teams.Update(team);
    }

    public void Delete(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        _unitOfWork.Teams.Delete(team);
    }
}
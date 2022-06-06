using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class TeamLeadersService : IUserService<TeamLeaderModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public TeamLeadersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<TeamLeader, TeamLeaderModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<TeamLeaderModel> GetAll()
    {
        var teamLeaders = _unitOfWork.TeamLeaders.GetAll();
        var teamLeaderModels = _mapper.Map<List<TeamLeader>, List<TeamLeaderModel>>(teamLeaders);

        return teamLeaderModels;
    }

    public TeamLeaderModel GetById(int id)
    {
        var teamLeader = _unitOfWork.TeamLeaders.GetById(id);
        var teamLeaderModel = _mapper.Map<TeamLeader, TeamLeaderModel>(teamLeader);

        return teamLeaderModel;
    }

    public List<TeamLeaderModel> Find(Func<TeamLeaderModel, bool> predicate)
    {
        var teamLeaderModels = _mapper.Map<List<TeamLeader>, List<TeamLeaderModel>>(_unitOfWork.TeamLeaders.GetAll());
        return teamLeaderModels.Where(predicate).ToList();
    }

    public TeamLeaderModel Create(TeamLeaderModel item)
    {
        var teamLeader = _mapper.Map<TeamLeaderModel, TeamLeader>(item);
        _unitOfWork.TeamLeaders.Create(teamLeader);

        return item;
    }

    public void Update(TeamLeaderModel item)
    {
        var teamLeader = _mapper.Map<TeamLeaderModel, TeamLeader>(item);
        _unitOfWork.TeamLeaders.Update(teamLeader);
    }

    public void Delete(TeamLeaderModel item)
    {
        var teamLeader = _mapper.Map<TeamLeaderModel, TeamLeader>(item);
        _unitOfWork.TeamLeaders.Delete(teamLeader);
    }

    public bool Register(TeamLeaderModel item)
    {
        var teamLeaders = _unitOfWork.TeamLeaders.Find(teamLeader => teamLeader.UserName == item.UserName);

        if (teamLeaders.Count > 0) return false;

        var teamLeader = _mapper.Map<TeamLeaderModel, TeamLeader>(item);
        _unitOfWork.TeamLeaders.Create(teamLeader);

        return true;
    }

    public bool Login(TeamLeaderModel item)
    {
        var teamLeaders = _unitOfWork.TeamLeaders.Find(teamLeader => teamLeader.UserName == item.UserName);

        if (teamLeaders.Count == 0) return false;

        var teamLeader = teamLeaders.FirstOrDefault();

        if (teamLeader.PasswordHash != item.PasswordHash) return false;

        teamLeader.IsLogged = true;
        _unitOfWork.TeamLeaders.Update(teamLeader);

        return true;
    }

    public void Logout(TeamLeaderModel item)
    {
        item.IsLogged = false;
        var teamLeader = _mapper.Map<TeamLeaderModel, TeamLeader>(item);
        _unitOfWork.TeamLeaders.Update(teamLeader);
    }

    public TeamLeaderModel? GetLoggedUser()
    {
        var teamLeaders = _unitOfWork.TeamLeaders.Find(teamLeader => teamLeader.IsLogged == true);

        if (teamLeaders.Count <= 0) return null;

        var teamLeaderModel = _mapper.Map<TeamLeader, TeamLeaderModel>(teamLeaders.First());

        return teamLeaderModel;
    }
}
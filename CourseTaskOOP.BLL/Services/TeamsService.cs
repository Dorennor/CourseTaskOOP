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

    public async Task<List<TeamModel>> GetAllAsync()
    {
        var teams = await _unitOfWork.Teams.GetAllAsync();
        var teamModels = _mapper.Map<List<Team>, List<TeamModel>>(teams);

        return teamModels;
    }

    public async Task<TeamModel> GetByIdAsync(int id)
    {
        var team = await _unitOfWork.Teams.GetByIdAsync(id);
        var teamModel = _mapper.Map<Team, TeamModel>(team);

        return teamModel;
    }

    public async Task<List<TeamModel>> FindAsync(Func<TeamModel, bool> predicate)
    {
        var teamModels = _mapper.Map<List<Team>, List<TeamModel>>(await _unitOfWork.Teams.GetAllAsync());
        return teamModels.Where(predicate).ToList();
    }

    public async Task<TeamModel> CreateAsync(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        await _unitOfWork.Teams.CreateAsync(team);

        return item;
    }

    public async Task UpdateAsync(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        await _unitOfWork.Teams.UpdateAsync(team);
    }

    public async Task DeleteAsync(TeamModel item)
    {
        var team = _mapper.Map<TeamModel, Team>(item);
        await _unitOfWork.Teams.DeleteAsync(team);
    }
}
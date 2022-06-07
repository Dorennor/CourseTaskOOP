using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class TeamMembersService : IService<TeamMemberModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public TeamMembersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<TeamMember, TeamMemberModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public async Task<List<TeamMemberModel>> GetAllAsync()
    {
        var teamMembers = await _unitOfWork.TeamMembers.GetAllAsync();
        var teamMemberModels = _mapper.Map<List<TeamMember>, List<TeamMemberModel>>(teamMembers);

        return teamMemberModels;
    }

    public async Task<TeamMemberModel> GetByIdAsync(int id)
    {
        var teamMember = await _unitOfWork.TeamMembers.GetByIdAsync(id);
        var teamMemberModel = _mapper.Map<TeamMember, TeamMemberModel>(teamMember);

        return teamMemberModel;
    }

    public async Task<List<TeamMemberModel>> FindAsync(Func<TeamMemberModel, bool> predicate)
    {
        var teamMemberModels = _mapper.Map<List<TeamMember>, List<TeamMemberModel>>(await _unitOfWork.TeamMembers.GetAllAsync());
        return teamMemberModels.Where(predicate).ToList();
    }

    public async Task<TeamMemberModel> CreateAsync(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        await _unitOfWork.TeamMembers.CreateAsync(teamMember);

        return item;
    }

    public async Task UpdateAsync(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        await _unitOfWork.TeamMembers.UpdateAsync(teamMember);
    }

    public async Task DeleteAsync(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        await _unitOfWork.TeamMembers.DeleteAsync(teamMember);
    }
}
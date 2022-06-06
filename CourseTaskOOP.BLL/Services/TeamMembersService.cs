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

    public List<TeamMemberModel> GetAll()
    {
        var teamMembers = _unitOfWork.TeamMembers.GetAll();
        var teamMemberModels = _mapper.Map<List<TeamMember>, List<TeamMemberModel>>(teamMembers);

        return teamMemberModels;
    }

    public TeamMemberModel GetById(int id)
    {
        var teamMember = _unitOfWork.TeamMembers.GetById(id);
        var teamMemberModel = _mapper.Map<TeamMember, TeamMemberModel>(teamMember);

        return teamMemberModel;
    }

    public List<TeamMemberModel> Find(Func<TeamMemberModel, bool> predicate)
    {
        var teamMemberModels = _mapper.Map<List<TeamMember>, List<TeamMemberModel>>(_unitOfWork.TeamMembers.GetAll());
        return teamMemberModels.Where(predicate).ToList();
    }

    public TeamMemberModel Create(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        _unitOfWork.TeamMembers.Create(teamMember);

        return item;
    }

    public void Update(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        _unitOfWork.TeamMembers.Update(teamMember);
    }

    public void Delete(TeamMemberModel item)
    {
        var teamMember = _mapper.Map<TeamMemberModel, TeamMember>(item);
        _unitOfWork.TeamMembers.Delete(teamMember);
    }
}
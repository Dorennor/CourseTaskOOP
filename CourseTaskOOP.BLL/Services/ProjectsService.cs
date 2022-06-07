using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class ProjectsService : IService<ProjectModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public ProjectsService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public async Task<List<ProjectModel>> GetAllAsync()
    {
        var projects = await _unitOfWork.Projects.GetAllAsync();
        var projectModels = _mapper.Map<List<Project>, List<ProjectModel>>(projects);

        return projectModels;
    }

    public async Task<ProjectModel> GetByIdAsync(int id)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(id);
        var projectModel = _mapper.Map<Project, ProjectModel>(project);

        return projectModel;
    }

    public async Task<List<ProjectModel>> FindAsync(Func<ProjectModel, bool> predicate)
    {
        var projectModels = _mapper.Map<List<Project>, List<ProjectModel>>(await _unitOfWork.Projects.GetAllAsync());
        return projectModels.Where(predicate).ToList();
    }

    public async Task<ProjectModel> CreateAsync(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        await _unitOfWork.Projects.CreateAsync(project);

        return item;
    }

    public async Task UpdateAsync(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        await _unitOfWork.Projects.UpdateAsync(project);
    }

    public async Task DeleteAsync(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        await _unitOfWork.Projects.DeleteAsync(project);
    }
}
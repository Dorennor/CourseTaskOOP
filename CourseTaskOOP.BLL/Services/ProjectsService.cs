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

    public List<ProjectModel> GetAll()
    {
        var projects = _unitOfWork.Projects.GetAll();
        var projectModels = _mapper.Map<List<Project>, List<ProjectModel>>(projects);

        return projectModels;
    }

    public ProjectModel GetById(int id)
    {
        var project = _unitOfWork.Projects.GetById(id);
        var projectModel = _mapper.Map<Project, ProjectModel>(project);

        return projectModel;
    }

    public List<ProjectModel> Find(Func<ProjectModel, bool> predicate)
    {
        var projectModels = _mapper.Map<List<Project>, List<ProjectModel>>(_unitOfWork.Projects.GetAll());
        return projectModels.Where(predicate).ToList();
    }

    public ProjectModel Create(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        _unitOfWork.Projects.Create(project);

        return item;
    }

    public void Update(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        _unitOfWork.Projects.Update(project);
    }

    public void Delete(ProjectModel item)
    {
        var project = _mapper.Map<ProjectModel, Project>(item);
        _unitOfWork.Projects.Delete(project);
    }
}
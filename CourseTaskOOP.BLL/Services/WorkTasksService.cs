using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class WorkTasksService : IService<WorkTaskModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public WorkTasksService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<WorkTask, WorkTaskModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<WorkTaskModel> GetAll()
    {
        var workTasks = _unitOfWork.WorkTasks.GetAll();
        var workTaskModels = _mapper.Map<List<WorkTask>, List<WorkTaskModel>>(workTasks);

        return workTaskModels;
    }

    public WorkTaskModel GetById(int id)
    {
        var workTask = _unitOfWork.WorkTasks.GetById(id);
        var workTaskModel = _mapper.Map<WorkTask, WorkTaskModel>(workTask);

        return workTaskModel;
    }

    public List<WorkTaskModel> Find(Func<WorkTaskModel, bool> predicate)
    {
        var workTaskModels = _mapper.Map<List<WorkTask>, List<WorkTaskModel>>(_unitOfWork.WorkTasks.GetAll());
        return workTaskModels.Where(predicate).ToList();
    }

    public WorkTaskModel Create(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        _unitOfWork.WorkTasks.Create(workTask);

        return item;
    }

    public void Update(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        _unitOfWork.WorkTasks.Update(workTask);
    }

    public void Delete(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        _unitOfWork.WorkTasks.Delete(workTask);
    }
}
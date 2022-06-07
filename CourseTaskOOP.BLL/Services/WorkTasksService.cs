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

    public async Task<List<WorkTaskModel>> GetAllAsync()
    {
        var workTasks = await _unitOfWork.WorkTasks.GetAllAsync();
        var workTaskModels = _mapper.Map<List<WorkTask>, List<WorkTaskModel>>(workTasks);

        return workTaskModels;
    }

    public async Task<WorkTaskModel> GetByIdAsync(int id)
    {
        var workTask = await _unitOfWork.WorkTasks.GetByIdAsync(id);
        var workTaskModel = _mapper.Map<WorkTask, WorkTaskModel>(workTask);

        return workTaskModel;
    }

    public async Task<List<WorkTaskModel>> FindAsync(Func<WorkTaskModel, bool> predicate)
    {
        var workTaskModels = _mapper.Map<List<WorkTask>, List<WorkTaskModel>>(await _unitOfWork.WorkTasks.GetAllAsync());
        return workTaskModels.Where(predicate).ToList();
    }

    public async Task<WorkTaskModel> CreateAsync(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        await _unitOfWork.WorkTasks.CreateAsync(workTask);

        return item;
    }

    public async Task UpdateAsync(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        await _unitOfWork.WorkTasks.UpdateAsync(workTask);
    }

    public async Task DeleteAsync(WorkTaskModel item)
    {
        var workTask = _mapper.Map<WorkTaskModel, WorkTask>(item);
        await _unitOfWork.WorkTasks.DeleteAsync(workTask);
    }
}
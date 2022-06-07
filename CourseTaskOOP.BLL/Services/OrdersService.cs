using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class OrdersService : IService<OrderModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public OrdersService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public async Task<List<OrderModel>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var orderModels = _mapper.Map<List<Order>, List<OrderModel>>(orders);

        return orderModels;
    }

    public async Task<OrderModel> GetByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        var orderModel = _mapper.Map<Order, OrderModel>(order);

        return orderModel;
    }

    public async Task<List<OrderModel>> FindAsync(Func<OrderModel, bool> predicate)
    {
        var orderModels = _mapper.Map<List<Order>, List<OrderModel>>(await _unitOfWork.Orders.GetAllAsync());
        return orderModels.Where(predicate).ToList();
    }

    public async Task<OrderModel> CreateAsync(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        await _unitOfWork.Orders.CreateAsync(order);

        return item;
    }

    public async Task UpdateAsync(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        await _unitOfWork.Orders.UpdateAsync(order);
    }

    public async Task DeleteAsync(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        await _unitOfWork.Orders.DeleteAsync(order);
    }
}
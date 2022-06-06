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

    public List<OrderModel> GetAll()
    {
        var orders = _unitOfWork.Orders.GetAll();
        var orderModels = _mapper.Map<List<Order>, List<OrderModel>>(orders);

        return orderModels;
    }

    public OrderModel GetById(int id)
    {
        var order = _unitOfWork.Orders.GetById(id);
        var orderModel = _mapper.Map<Order, OrderModel>(order);

        return orderModel;
    }

    public List<OrderModel> Find(Func<OrderModel, bool> predicate)
    {
        var orderModels = _mapper.Map<List<Order>, List<OrderModel>>(_unitOfWork.Orders.GetAll());
        return orderModels.Where(predicate).ToList();
    }

    public OrderModel Create(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        _unitOfWork.Orders.Create(order);

        return item;
    }

    public void Update(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        _unitOfWork.Orders.Update(order);
    }

    public void Delete(OrderModel item)
    {
        var order = _mapper.Map<OrderModel, Order>(item);
        _unitOfWork.Orders.Delete(order);
    }
}
using AutoMapper;
using CourseTaskOOP.BLL.Interfaces;
using CourseTaskOOP.BLL.Models;
using CourseTaskOOP.DAL.Interfaces;
using CourseTaskOOP.DAL.Models;
using CourseTaskOOP.DAL.Repositories;

namespace CourseTaskOOP.BLL.Services;

public class ClientsService : IUserService<ClientModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _mapper;

    public ClientsService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientModel>().ReverseMap());
        _mapper = new Mapper(config);
    }

    public List<ClientModel> GetAll()
    {
        var clients = _unitOfWork.Clients.GetAll();
        var clientModels = _mapper.Map<List<Client>, List<ClientModel>>(clients);

        return clientModels;
    }

    public ClientModel GetById(int id)
    {
        var client = _unitOfWork.Clients.GetById(id);
        var clientModel = _mapper.Map<Client, ClientModel>(client);

        return clientModel;
    }

    public List<ClientModel> Find(Func<ClientModel, bool> predicate)
    {
        var clientModels = _mapper.Map<List<Client>, List<ClientModel>>(_unitOfWork.Clients.GetAll());
        return clientModels.Where(predicate).ToList();
    }

    public ClientModel Create(ClientModel item)
    {
        var client = _mapper.Map<ClientModel, Client>(item);
        _unitOfWork.Clients.Create(client);

        return item;
    }

    public void Update(ClientModel item)
    {
        var client = _mapper.Map<ClientModel, Client>(item);
        _unitOfWork.Clients.Update(client);
    }

    public void Delete(ClientModel item)
    {
        var client = _mapper.Map<ClientModel, Client>(item);
        _unitOfWork.Clients.Delete(client);
    }

    public bool Register(ClientModel item)
    {
        var clients = _unitOfWork.Clients.Find(client => client.Email == item.Email);

        if (clients.Count > 0) return false;

        var client = _mapper.Map<ClientModel, Client>(item);
        _unitOfWork.Clients.Create(client);

        return true;
    }

    public bool Login(ClientModel item)
    {
        var clients = _unitOfWork.Clients.Find(client => client.Email == item.Email);

        if (clients.Count == 0) return false;

        var client = clients.FirstOrDefault();

        if (client.PasswordHash != item.PasswordHash) return false;

        client.IsLogged = true;
        _unitOfWork.Clients.Update(client);

        return true;
    }

    public void Logout(ClientModel item)
    {
        item.IsLogged = false;
        var client = _mapper.Map<ClientModel, Client>(item);
        _unitOfWork.Clients.Update(client);
    }

    public ClientModel? GetLoggedUser()
    {
        var clients = _unitOfWork.Clients.Find(client => client.IsLogged == true);

        if (clients.Count <= 0) return null;

        var clientModel = _mapper.Map<Client, ClientModel>(clients.First());

        return clientModel;
    }
}
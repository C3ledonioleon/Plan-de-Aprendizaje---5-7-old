using Proyecto.Models;
using Proyecto.Services.Contracts;
using Proyecto.Repositories.Contracts;

public class LocalService : ILocalService
{
    private readonly ILocalRepository _localRepository;

    public LocalService(ILocalRepository localRepository)
    {
        _localRepository = localRepository;
    }

    public List<Local> ObtenerTodo()
    {
        return _localRepository.GetAll();
    }

    public Local? ObtenerPorId(int id)
    {
        return _localRepository.GetById(id);
    }
    public int AgregarLocal(Local local)
    {
        return _localRepository.Add(local);
    }
    public bool ActualizarLocal(int id, Local local)
    {
        return _localRepository.Update(id, local);

    }

    public bool EliminarLocal(int id)
    {
        return _localRepository.Delete(id );;
    }

}
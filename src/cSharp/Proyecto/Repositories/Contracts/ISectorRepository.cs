using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface ISectorRepository
    {
        List<Sector> GetAll();
        Sector? GetById(int id);    
        int Add(Sector sector);
        bool  Update (int id,Sector sector);
        bool Delete (int sectorId);
    }
}

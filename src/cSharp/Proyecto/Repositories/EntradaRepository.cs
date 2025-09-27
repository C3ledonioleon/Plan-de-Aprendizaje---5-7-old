using Proyecto.Models;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Proyecto.Repositories.Contracts;

namespace Proyecto.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly IConfiguration _configuration;

        public EntradaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public List<Entrada> GetAll()
        {
            using var db = Connection;
            return db.Query<Entrada>("SELECT * FROM Entrada").ToList();
        }

        public Entrada? GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Entrada>("SELECT * FROM Entrada WHERE IdEntrada = @IdEntrada", new { IdEntrada = id });
        }

        public bool Anular(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Entrada SET Estado = 'Anulada' WHERE IdEntrada = @IdEntrada";
            int rows = db.Execute(sql, new { IdEntrada = id });
            return rows > 0;
        }
    }
}

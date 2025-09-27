using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using System.Data;

namespace Proyecto.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly string _connectionString;

        public TarifaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public int Add(Tarifa tarifa)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Tarifa (FuncionId, Precio, Stock, Estado)
                VALUES (@FuncionId, @Precio, @Stock, @Estado);
                SELECT LAST_INSERT_ID();";
            return db.ExecuteScalar<int>(sql, tarifa);
        }

        public IEnumerable<Tarifa> GetByFuncionId(int funcionId)
        {
            using var db = Connection;
            return db.Query<Tarifa>(
                "SELECT * FROM Tarifa WHERE FuncionId = @FuncionId",
                new { FuncionId = funcionId }
            );
        }

        public Tarifa GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Tarifa>(
                "SELECT * FROM Tarifa WHERE IdTarifa = @IdTarifa",
                new { IdTarifa = id }
            );
        }

        public bool Update(Tarifa tarifa)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Tarifa
                SET Precio = @Precio, Stock = @Stock, Estado = @Estado
                WHERE IdTarifa = @IdTarifa";
            int rows = db.Execute(sql, tarifa);
            return rows > 0;
        }
    }
}

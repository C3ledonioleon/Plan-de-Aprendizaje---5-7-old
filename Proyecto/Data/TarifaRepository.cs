using Proyecto.Models;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Data
{
    public class TarifaRepository
    {
        private readonly IConfiguration _configuration;

        public TarifaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        // POST /tarifas
        public int Add(Tarifa tarifa)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Tarifa (MedioPago, Stock, IdSector, IdFuncion)
                VALUES (@MedioPago, @Stock, @IdSector, @IdFuncion);
                SELECT LAST_INSERT_ID();";
            int newId = db.ExecuteScalar<int>(sql, tarifa);
            tarifa.IdTarifa = newId;
            return newId;
        }

        // GET /funciones/{funcionId}/tarifas
        public List<Tarifa> GetByFuncion(int funcionId)
        {
            using var db = Connection;
            return db.Query<Tarifa>("SELECT * FROM Tarifa WHERE IdFuncion = @IdFuncion", new { IdFuncion = funcionId }).ToList();
        }

        // GET /tarifas/{tarifaId}
        public Tarifa? GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Tarifa>("SELECT * FROM Tarifa WHERE IdTarifa = @IdTarifa", new { IdTarifa = id });
        }

        // PUT /tarifas/{tarifaId}
        public bool Update(int id, Tarifa tarifa)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Tarifa 
                SET MedioPago = @MedioPago, Stock = @Stock, IdSector = @IdSector, IdFuncion = @IdFuncion
                WHERE IdTarifa = @IdTarifa";
            int rows = db.Execute(sql, new { tarifa.MedioPago, tarifa.Stock, tarifa.IdSector, tarifa.IdFuncion, IdTarifa = id });
            return rows > 0;
        }
    }
}

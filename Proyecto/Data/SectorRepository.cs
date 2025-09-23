using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Collections.Generic;

namespace Proyecto.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly string _connectionString;

        public SectorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private MySqlConnection GetConnection() => new(_connectionString);

        public int CrearSector(Sector sector)
        {
            using var connection = GetConnection();
            string sql = @"
                INSERT INTO Sector (Nombre, Capacidad, IdLocal) 
                VALUES (@Nombre, @Capacidad, @IdLocal);
                SELECT LAST_INSERT_ID();";
            return connection.ExecuteScalar<int>(sql, sector);
        }

        public IEnumerable<Sector> ObtenerSectoresPorLocal(int localId)
        {
            using var connection = GetConnection();
            string sql = "SELECT * FROM Sector WHERE IdLocal = @LocalId";
            return connection.Query<Sector>(sql, new { LocalId = localId });
        }

        public bool ActualizarSector(Sector sector)
        {
            using var connection = GetConnection();
            string sql = @"
                UPDATE Sector 
                SET Nombre = @Nombre, Capacidad = @Capacidad 
                WHERE IdSector = @IdSector";
            int filas = connection.Execute(sql, sector);
            return filas > 0;
        }

        public bool EliminarSector(int sectorId)
        {
            using var connection = GetConnection();

            // Validación: verificar que no tenga tarifas asociadas
            string checkSql = "SELECT COUNT(*) FROM Tarifa WHERE IdSector = @SectorId";
            int countTarifas = connection.ExecuteScalar<int>(checkSql, new { SectorId = sectorId });

            if (countTarifas > 0) return false;

            string sql = "DELETE FROM Sector WHERE IdSector = @SectorId";
            int filas = connection.Execute(sql, new { SectorId = sectorId });
            return filas > 0;
        }
    }
}

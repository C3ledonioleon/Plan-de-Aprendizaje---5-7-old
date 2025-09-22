using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using System.Data;
using System.Collections.Generic;

namespace Proyecto.Data
{
    public class LocalRepository
    {
        private readonly string _connectionString;

        public LocalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public int Add(Local local)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Local (Nombre, Direccion, CapacidadTotal)
                VALUES (@Nombre, @Direccion, @CapacidadTotal);
                SELECT LAST_INSERT_ID();";
            return db.ExecuteScalar<int>(sql, local);
        }

        public IEnumerable<Local> GetAll()
        {
            using var db = Connection;
            return db.Query<Local>("SELECT * FROM Local");
        }

        public Local GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Local>("SELECT * FROM Local WHERE IdLocal = @IdLocal", new { IdLocal = id });
        }

        public bool Update(Local local)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Local
                SET Nombre = @Nombre, Direccion = @Direccion, CapacidadTotal = @CapacidadTotal
                WHERE IdLocal = @IdLocal";
            int rows = db.Execute(sql, local);
            return rows > 0;
        }

        public bool Delete(int id)
        {
            using var db = Connection;
            // Verificar si tiene funciones vigentes
            string checkSql = "SELECT COUNT(*) FROM Funcion WHERE IdLocal = @IdLocal AND Fecha >= CURDATE()";
            int count = db.ExecuteScalar<int>(checkSql, new { IdLocal = id });
            if (count > 0) return false;

            string deleteSql = "DELETE FROM Local WHERE IdLocal = @IdLocal";
            int rows = db.Execute(deleteSql, new { IdLocal = id });
            return rows > 0;
        }
    }
}

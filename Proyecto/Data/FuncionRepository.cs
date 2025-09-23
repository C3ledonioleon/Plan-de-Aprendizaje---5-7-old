using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Data;
using System.Collections.Generic;

namespace Proyecto.Data
{
    public class FuncionRepository : IFuncionRepository
    {
        private readonly string _connectionString;

        public FuncionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public int Add(Funcion funcion)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Funcion (Fecha, IdEvento, IdLocal, Cancelada)
                VALUES (@Fecha, @IdEvento, @IdLocal, @Cancelada);
                SELECT LAST_INSERT_ID();";
            return db.ExecuteScalar<int>(sql, funcion);
        }

        public IEnumerable<Funcion> GetAll()
        {
            using var db = Connection;
            string sql = "SELECT * FROM Funcion";
            return db.Query<Funcion>(sql);
        }

        public Funcion? GetById(int id)
        {
            using var db = Connection;
            string sql = "SELECT * FROM Funcion WHERE IdFuncion = @Id";
            return db.QueryFirstOrDefault<Funcion>(sql, new { Id = id });
        }

        public bool Update(Funcion funcion)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Funcion
                SET Fecha = @Fecha, IdEvento = @IdEvento, IdLocal = @IdLocal
                WHERE IdFuncion = @IdFuncion";
            int rows = db.Execute(sql, funcion);
            return rows > 0;
        }

        public bool Cancelar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Funcion SET Cancelada = 1 WHERE IdFuncion = @Id";
            int rows = db.Execute(sql, new { Id = id });
            return rows > 0;
        }
    }
}

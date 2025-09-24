using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using Proyecto.Interfaces;
using System.Data;
using System.Collections.Generic;

namespace Proyecto.Repositories.Contracts
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly string _connectionString;

        public OrdenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public int Add(Orden orden)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Orden (FechaOrden, IdCliente)
                VALUES (@FechaOrden, @IdCliente);
                SELECT LAST_INSERT_ID();";
            return db.ExecuteScalar<int>(sql, orden);
        }

        public List<Orden> GetAll()
        {
            using var db = Connection;
            string sql = "SELECT * FROM Orden";
            return db.Query<Orden>(sql).AsList();
        }

        public Orden? GetById(int id)
        {
            using var db = Connection;
            string sql = "SELECT * FROM Orden WHERE IdOrden = @Id";
            return db.QueryFirstOrDefault<Orden>(sql, new { Id = id });
        }

        public void Pagar(int id, List<Entrada> entradas)
        {
            using var db = Connection;
            using var tran = db.BeginTransaction();

            try
            {
                // Marcar orden como pagada
                string sqlOrden = "UPDATE Orden SET Pagada = 1 WHERE IdOrden = @Id";
                db.Execute(sqlOrden, new { Id = id }, tran);

                // Insertar entradas asociadas
                foreach (var entrada in entradas)
                {
                    entrada.IdOrden = id;
                    string sqlEntrada = @"
                        INSERT INTO Entrada (Precio, IdOrden, IdTarifa)
                        VALUES (@Precio, @IdOrden, @IdTarifa)";
                    db.Execute(sqlEntrada, entrada, tran);
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public bool Cancelar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Orden SET Cancelada = 1 WHERE IdOrden = @Id";
            int rows = db.Execute(sql, new { Id = id });
            return rows > 0;
        }
    }
}

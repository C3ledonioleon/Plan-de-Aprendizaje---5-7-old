using Proyecto.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Data
{
    public class OrdenRepository
    {
        private readonly IConfiguration _configuration;

        public OrdenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        // Obtener todas las órdenes
        public List<Orden> GetAll()
        {
            using var db = Connection;
            return db.Query<Orden>("SELECT * FROM Orden").ToList();
        }

        // Obtener orden por Id
        public Orden? GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Orden>("SELECT * FROM Orden WHERE IdOrden = @IdOrden", new { IdOrden = id });
        }

        // Crear orden
        public int Add(Orden orden)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Orden (FechaOrden, IdCliente)
                VALUES (@FechaOrden, @IdCliente);
                SELECT LAST_INSERT_ID();";
            int newId = db.ExecuteScalar<int>(sql, orden);
            orden.IdOrden = newId;
            return newId;
        }

        // Marcar orden como pagada y generar entradas
        public void Pagar(int ordenId, List<Entrada> entradas)
        {
            using var db = Connection;
            using var transaction = db.BeginTransaction();

            try
            {
                // Aquí podrías actualizar un campo "Estado" de la orden si existiera
                // db.Execute("UPDATE Orden SET Estado = 'Pagada' WHERE IdOrden = @IdOrden", new { IdOrden = ordenId }, transaction);

                foreach (var entrada in entradas)
                {
                    entrada.IdOrden = ordenId;
                    string sql = @"
                        INSERT INTO Entrada (Precio, IdOrden, IdTarifa)
                        VALUES (@Precio, @IdOrden, @IdTarifa);";
                    db.Execute(sql, entrada, transaction);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // Cancelar orden
        public bool Cancelar(int ordenId)
        {
            using var db = Connection;
            // Opcional: validar que la orden no esté pagada
            string sql = "DELETE FROM Orden WHERE IdOrden = @IdOrden";
            int rows = db.Execute(sql, new { IdOrden = ordenId });
            return rows > 0;
        }
    }
}

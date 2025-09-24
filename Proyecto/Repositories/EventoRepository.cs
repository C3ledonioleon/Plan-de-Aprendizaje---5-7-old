using Proyecto.Models;
using Proyecto.Interfaces;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto.Repositories.Contracts
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IConfiguration _configuration;

        public EventoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new MySqlConnection(
            _configuration.GetConnectionString("DefaultConnection")
        );

        public int Add(Evento evento)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Evento (Nombre, Genero, FechaInicio, FechaFin)
                VALUES (@Nombre, @Genero, @FechaInicio, @FechaFin);
                SELECT LAST_INSERT_ID();";

            int newId = db.ExecuteScalar<int>(sql, evento);
            evento.IdEvento = newId;
            return newId;
        }

        public List<Evento> GetAll()
        {
            using var db = Connection;
            return db.Query<Evento>("SELECT * FROM Evento").ToList();
        }

        public Evento? GetById(int id)
        {
            using var db = Connection;
            return db.QueryFirstOrDefault<Evento>(
                "SELECT * FROM Evento WHERE IdEvento = @IdEvento",
                new { IdEvento = id }
            );
        }

        public bool Update(Evento evento)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Evento
                SET Nombre = @Nombre,
                    Genero = @Genero,
                    FechaInicio = @FechaInicio,
                    FechaFin = @FechaFin
                WHERE IdEvento = @IdEvento";

            int rows = db.Execute(sql, evento);
            return rows > 0;
        }

        public bool Publicar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Evento SET Estado = 'Publicado' WHERE IdEvento = @IdEvento";
            int rows = db.Execute(sql, new { IdEvento = id });
            return rows > 0;
        }

        public bool Cancelar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Evento SET Estado = 'Cancelado' WHERE IdEvento = @IdEvento";
            int rows = db.Execute(sql, new { IdEvento = id });
            return rows > 0;
        }
    }
}

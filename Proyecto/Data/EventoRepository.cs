using Dapper;
using MySql.Data.MySqlClient;
using Proyecto.Models;
using System.Data;
using System.Collections.Generic;

namespace Proyecto.Data
{
    public class EventoRepository
    {
        private readonly string _connectionString;

        public EventoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Conexión a la base de datos
        private IDbConnection Connection => new MySqlConnection(_connectionString);

        // Agregar un nuevo evento
        public int Add(Evento evento)
        {
            using var db = Connection;
            string sql = @"
                INSERT INTO Evento (Nombre, Genero, FechaInicio, FechaFin, Publicado, Cancelado)
                VALUES (@Nombre, @Genero, @FechaInicio, @FechaFin, @Publicado, @Cancelado);
                SELECT LAST_INSERT_ID();";
            return db.ExecuteScalar<int>(sql, evento);
        }

        // Listar todos los eventos
        public IEnumerable<Evento> GetAll()
        {
            using var db = Connection;
            string sql = "SELECT * FROM Evento";
            return db.Query<Evento>(sql);
        }

        // Obtener evento por ID
        public Evento? GetById(int id)
        {
            using var db = Connection;
            string sql = "SELECT * FROM Evento WHERE IdEvento = @Id";
            return db.QueryFirstOrDefault<Evento>(sql, new { Id = id });
        }

        // Actualizar evento
        public bool Update(Evento evento)
        {
            using var db = Connection;
            string sql = @"
                UPDATE Evento
                SET Nombre = @Nombre, Genero = @Genero, FechaInicio = @FechaInicio, FechaFin = @FechaFin
                WHERE IdEvento = @IdEvento";
            int rows = db.Execute(sql, evento);
            return rows > 0;
        }

        // Publicar evento
        public bool Publicar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Evento SET Publicado = 1 WHERE IdEvento = @Id";
            int rows = db.Execute(sql, new { Id = id });
            return rows > 0;
        }

        // Cancelar evento
        public bool Cancelar(int id)
        {
            using var db = Connection;
            string sql = "UPDATE Evento SET Cancelado = 1 WHERE IdEvento = @Id";
            int rows = db.Execute(sql, new { Id = id });
            return rows > 0;
        }
    }
}

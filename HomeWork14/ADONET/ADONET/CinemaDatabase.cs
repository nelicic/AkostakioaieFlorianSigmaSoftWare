using Microsoft.Data.SqlClient;

namespace ADONET
{
    public class CinemaDatabase
    {
        private readonly string _connectionString;
        public CinemaDatabase(string connectionString)
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public async Task ReadAsync()
        {
            string sqlExpression = "SELECT * FROM Showtimes";

            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"{reader["Id"]} {reader["MovieId"]} {reader["CinemaHallId"]} {reader["Date"]} {reader["Duration"]}");
                }
            }
        }

        public async Task CreateAsync(int movieId, int cinemaHallId, string dateTime, int duration)
        {
            string sqlExpression = $"INSERT INTO Showtimes(MovieId, CinemaHallId, Date, Duration) VALUES('{movieId}', '{cinemaHallId}', '{dateTime}', '{duration}')";
            await ExecuteQuery(sqlExpression);
        }

        public async Task UpdateAsync(int showtimeId, int newMovieId)
        {
            string sqlExpression = $"UPDATE Showtimes SET MovieId = '{newMovieId}' WHERE Id = {showtimeId}";
            await ExecuteQuery(sqlExpression);
        }

        public async Task DeleteAsync(int showTimeid)
        {
            string sqlExpression = $"DELETE FROM Showtimes WHERE Id = '{showTimeid}'";
            await ExecuteQuery(sqlExpression);
        }

        private async Task ExecuteQuery(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.OpenAsync();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}


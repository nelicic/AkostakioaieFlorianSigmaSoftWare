using ADONET;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
CinemaDatabase cinemaDatabase = new CinemaDatabase(connectionString);

await cinemaDatabase.DeleteAsync(1003);
await cinemaDatabase.ReadAsync();
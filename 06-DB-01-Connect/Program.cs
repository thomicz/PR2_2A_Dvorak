using Microsoft.Data.SqlClient;

namespace _06_DB_01_Connect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PR2A;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command;
            SqlDataReader reader;
            DumpDB(connection, out command, out reader);
        }

        private static void InsertCar(int id, string regPlate, string brand, string model, DateTime purchased)
        {

        }
        private static void DumpDB(SqlConnection connection, out SqlCommand command, out SqlDataReader reader)
        {
            connection.Open();

            string query = "SELECT * FROM Cars";
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string regPlate = (string)reader["RegPlate"];
                string brand = (string)reader["Brand"];
                string model = (string)reader["Model"];
                DateTime purchared = reader.GetDateTime(4);

                Console.WriteLine($"ID: {id}, reg. plate: {regPlate}, type: {brand} {model}, purschared {purchared}");

            }
        }
    }
}

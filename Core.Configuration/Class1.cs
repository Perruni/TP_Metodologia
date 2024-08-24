using MySql.Data.MySqlClient;
using System;

namespace Core.Configuration
{
    public class Class1
    {
        public void TestConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=prueba1;User ID=Alexis;Password=admin;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abrir conexión
                    connection.Open();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                }
                catch (MySqlException ex)
                {
                    // Capturar y mostrar errores
                    Console.WriteLine("Error al intentar conectar a la base de datos: " + ex.Message);
                }
                finally
                {
                    // Cerrar conexión
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("Conexión cerrada.");
                    }
                }
            }
        }
    }
}
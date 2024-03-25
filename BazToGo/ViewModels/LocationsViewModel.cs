using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using BazToGo.Models;

public class LocationViewModel
{
    private MySqlConnection _connection;

    public LocationViewModel()
    {
        string connectionString = "Server=localhost;Database=BazDB;Uid=root;Pwd=PassDB;";
        _connection = new MySqlConnection(connectionString);
    }

    public List<Locations> GetLocationsFromDatabase()
    {
        List<Locations> locations = new List<Locations>();

        try
        {
            _connection.Open();

            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM locations";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Locations location = new Locations
                {
                    IDLocation = Convert.ToInt32(reader["IDLocation"]),
                    LocationName = reader["LocationName"].ToString(),
                    DropPoint = reader["DropPoint"].ToString(),
                    CardinalDirection = reader["CardinalDirection"].ToString()
                };
                locations.Add(location);
            }

            _connection.Close();

            Console.WriteLine("Data retrieval successful."); // Print success message to console
        }
        catch (Exception ex)
        {
            // Handle exception, log or display error message
            Console.WriteLine("Error: " + ex.Message);
        }

        return locations;
    }
}

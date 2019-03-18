using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace VehicleApi.Models
{
    public class DatabaseConnection
    {
        string connString = "Server=localhost;Database=douglas_car_rental_server;Uid=root;Pwd=";

        public DatabaseConnection()
        {
            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from vehicle";
            MySqlDataReader reader = command.ExecuteReader();

            List<VehicleData> vehicleData = new List<VehicleData>();
            while (reader.Read())
            {
               
                String make  = reader["Make" ].ToString();
                String model = reader["Model"].ToString();
                String year  = reader["Year" ].ToString();
                String type  = reader["Type" ].ToString();
                vehicleData.Add(new VehicleData { Make = make, Model = model, Type = type, Year = year });
            }
        }


    }
}
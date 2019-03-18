using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleApi.Models;
using MySql.Data.MySqlClient;

namespace VehicleApi.Controllers
{
    public class ValuesController : ApiController
    {
        List<VehicleData> vehicleData = new List<VehicleData>();

        public ValuesController()
        {
            /*
            vehicleData.Add(new VehicleData { Make = "1", Model = "2", Type = "3", Year = "5" });
            vehicleData.Add(new VehicleData { Make = "1", Model = "2", Type = "3", Year = "5" });
            vehicleData.Add(new VehicleData { Make = "1", Model = "2", Type = "3", Year = "5" });
            vehicleData.Add(new VehicleData { Make = "1", Model = "2", Type = "3", Year = "5" });
            */
            
            string connString = "Server=localhost;Database=douglas_car_rental_server;Uid=root;Pwd=";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from vehicle";
            MySqlDataReader reader = command.ExecuteReader();

            
            while (reader.Read())
            {

                String make = reader["Make"].ToString();
                String model = reader["Model"].ToString();
                String year = reader["Year"].ToString();
                String type = reader["Type"].ToString();
                vehicleData.Add(new VehicleData { Make = make, Model = model, Type = type, Year = year });
            }


            
        }

        // GET api/values
        [Route("api/Vehicle")]
        public List<VehicleData> Get()
        {
            return vehicleData;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

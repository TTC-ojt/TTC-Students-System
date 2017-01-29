using MySql.Data.MySqlClient;
using MySql.Connection;
using System;

namespace GN.TTC.Students.Models
{
    internal class Provider
    {

        internal Provider()
        {
            ID = 0;
            Region = "";
            Province = "";
            District = "";
            City = "";
            Name = "";
            Address = "";
            Type = "";
            Classification = "";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal string Region { get; set; }
        internal string Province { get; set; }
        internal string District { get; set; }
        internal string City { get; set; }
        internal string Name { get; set; }
        internal string Address { get; set; }
        internal string Type { get; set; }
        internal string Classification { get; set; }

        /// <summary>
        /// Get Default provider
        /// </summary>
        /// <returns>Provider</returns>
        internal static Provider GetDefault()
        {
            Provider provider = new Provider();
            try
            {
                string query = "SELECT * FROM providers WHERE id=1";
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            provider.ID = rdr.GetInt32(0);
                            provider.Region = rdr.GetString(1);
                            provider.Province = rdr.GetString(2);
                            provider.District = rdr.GetString(3);
                            provider.City = rdr.GetString(4);
                            provider.Name = rdr.GetString(5);
                            provider.Address = rdr.GetString(6);
                            provider.Type = rdr.GetString(7);
                            provider.Classification = rdr.GetString(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return provider;
        }

        /// <summary>
        /// Saves to DB
        /// </summary>
        internal void Save()
        {
            try
            {
               using(MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
               {
                   MySqlCommand cmd = new MySqlCommand();
                   cmd.Connection = con;
                       cmd.CommandText = "UPDATE providers SET region = @region, province = @province, district = @district, city = @city, name = @name, address = @address, type = @type, classification = @classification WHERE id = 1";
                       cmd.Parameters.AddWithValue("region", Region);
                       cmd.Parameters.AddWithValue("province", Province);
                       cmd.Parameters.AddWithValue("district", District);
                       cmd.Parameters.AddWithValue("city", City);
                       cmd.Parameters.AddWithValue("name", Name);
                       cmd.Parameters.AddWithValue("address", Address);
                       cmd.Parameters.AddWithValue("type", Type);
                       cmd.Parameters.AddWithValue("classification", Classification);
                   con.Open();
                   cmd.ExecuteNonQuery();
               }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
        }

    }
}

using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Contact
    {
        internal Contact()
        {
            ID = 0;
            StudentID = 0;
            Phone = "";
            Email = "";
            Street = "";
            Barangay = "";
            City = "";
            District = "";
            Province = "";
            Region = "";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Phone { get; set; }
        internal string Email { get; set; }
        internal string Street { get; set; }
        internal string Barangay { get; set; }
        internal string City { get; set; }
        internal string District { get; set; }
        internal string Province { get; set; }
        internal string Region { get; set; }

        /// <summary>
        /// Gets Contact by Student
        /// </summary>
        /// <param name="StudentID">Student ID</param>
        /// <returns>Contact</returns>
        internal static Contact getContactByStudent(int StudentID)
        {
            Contact contact = new Contact();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM contacts WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            contact.ID = rdr.GetInt32(0);
                            contact.StudentID = rdr.GetInt32(1);
                            contact.Phone = rdr.GetString(2);
                            contact.Email = rdr.GetString(3);
                            contact.Street = rdr.GetString(4);
                            contact.Barangay = rdr.GetString(5);
                            contact.City = rdr.GetString(6);
                            contact.District = rdr.GetString(7);
                            contact.Province = rdr.GetString(8);
                            contact.Region = rdr.GetString(9);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return contact;
        }

        /// <summary>
        /// Saves Contact to DB
        /// </summary>
        internal void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ID > 0)
                    {
                        cmd.CommandText = "UPDATE contacts SET phone = @phone, email = @email, street = @street, barangay = @barangay, city = @city, district = @district, province = @province, region = @region WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO contacts (student_id, phone, email, street, barangay, city, district, province, region) VALUES (@student_id, @phone, @email, @street, @barangay, @city, @district, @province, @region)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("phone", Phone);
                    cmd.Parameters.AddWithValue("email", Email);
                    cmd.Parameters.AddWithValue("street", Street);
                    cmd.Parameters.AddWithValue("barangay", Barangay);
                    cmd.Parameters.AddWithValue("city", City);
                    cmd.Parameters.AddWithValue("district", District);
                    cmd.Parameters.AddWithValue("province", Province);
                    cmd.Parameters.AddWithValue("region", Region);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (ID == 0) ID = Convert.ToInt32(cmd.LastInsertedId);
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
        }
    }
}

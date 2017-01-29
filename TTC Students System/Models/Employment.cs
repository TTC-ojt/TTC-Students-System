using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{

    class Employment
    {
        internal Employment()
        {
            ID = 0;
            StudentID = 0;
            Type = "";
            DateEmployed = new DateTime(2000,01,01);
            Occupation = "";
            Employer = "";
            Address = "";
            Classification = "";
            Income = 0m;
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Type { get; set; }
        internal DateTime DateEmployed { get; set; }
        internal string Occupation { get; set; }
        internal string Employer { get; set; }
        internal string Address { get; set; }
        internal string Classification { get; set; }
        internal decimal Income { get; set; }

        /// <summary>
        /// Get Employment By Student
        /// </summary>
        /// <param name="StudentID">Student ID</param>
        /// <returns>Employment</returns>
        internal static Employment getEmploymentByStudent(int StudentID, string Type)
        {
            Employment employment = new Employment();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM employments WHERE student_id = @student_id AND type = @type";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    cmd.Parameters.AddWithValue("@type", Type);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            employment.ID = rdr.GetInt32(0);
                            employment.StudentID = rdr.GetInt32(1);
                            employment.Type = rdr.GetString(2);
                            employment.DateEmployed = rdr.GetDateTime(3);
                            employment.Occupation = rdr.GetString(4);
                            employment.Employer = rdr.GetString(5);
                            employment.Address = rdr.GetString(6);
                            employment.Classification = rdr.GetString(7);
                            employment.Income = rdr.GetDecimal(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return employment;
        }

        /// <summary>
        /// Saves Employment to DB
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
                        cmd.CommandText = "UPDATE employments SET date_employed = @date_employed, occupation = @occupation, employer = @employer, address = @address, classification = @classification, income = @income WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO employments (student_id, type, date_employed, occupation, employer, address, classification, income ) VALUES (@student_id, @type, @date_employed, @occupation, @employer, @address, @classification, @income)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                        cmd.Parameters.AddWithValue("type", Type);
                    }
                    cmd.Parameters.AddWithValue("date_employed", DateEmployed);
                    cmd.Parameters.AddWithValue("occupation", Occupation);
                    cmd.Parameters.AddWithValue("employer", Employer);
                    cmd.Parameters.AddWithValue("address", Address);
                    cmd.Parameters.AddWithValue("classification", Classification);
                    cmd.Parameters.AddWithValue("income", Income);
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

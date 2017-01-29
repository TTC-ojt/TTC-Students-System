using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Graduate
    {
        internal Graduate()
        {
            ID = 0;
            StudentID = 0;
            SpecialOrder = "";
            DateIssued = new DateTime(2000, 1, 1);
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string SpecialOrder { get; set; }
        internal DateTime DateIssued { get; set; }

        //Get Assessment by student
        internal static Graduate getByStudent(int StudentID)
        {
            Graduate graduate = new Graduate();
            try
            {
                using(MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM graduates WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using(MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            graduate.ID = rdr.GetInt32(0);
                            graduate.StudentID = rdr.GetInt32(1);
                            graduate.SpecialOrder = rdr.GetString(2);
                            graduate.DateIssued = rdr.GetDateTime(3);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return graduate;
        }

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
                        cmd.CommandText = "UPDATE graduates SET special_order = @special_order, date_issued = @date_issued WHERE student_id = @student_id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO graduates (student_id, special_order, date_issued) VALUES (@student_id, @special_order, @date_issued)";
                    }
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("special_order", SpecialOrder);
                    cmd.Parameters.AddWithValue("date_issued", DateIssued);
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

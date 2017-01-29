using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Drop
    {
        internal Drop()
        {
            ID = 0;
            StudentID = 0;
            Reason = "";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Reason { get; set; }

        //Get Assessment by student
        internal static Drop getByStudent(int StudentID)
        {
            Drop stop = new Drop();
            try
            {
                using(MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM drops WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using(MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            stop.ID = rdr.GetInt32(0);
                            stop.StudentID = rdr.GetInt32(1);
                            stop.Reason = rdr.GetString(2);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return stop;
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
                        cmd.CommandText = "UPDATE drops SET reason = @reason WHERE student_id = @student_id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO drops (student_id, reason) VALUES (@student_id, @reason)";
                    }
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("reason", Reason);
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

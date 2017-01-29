using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Assessment
    {
        internal Assessment()
        {
            ID = 0;
            StudentID = 0;
            Date = DateTime.Today;
            Result = "";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal DateTime Date { get; set; }
        internal string Result { get; set; }

        //Get Assessment by student
        internal static Assessment getByStudent(int StudentID)
        {
            Assessment assessment = new Assessment();
            try
            {
                using(MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM assessments WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using(MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            assessment.ID = rdr.GetInt32(0);
                            assessment.StudentID = rdr.GetInt32(1);
                            assessment.Date = rdr.GetDateTime(2);
                            assessment.Result = rdr.GetString(3);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return assessment;
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
                        cmd.CommandText = "UPDATE assessments SET date = @date, result = @result WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO assessments (student_id, date, result) VALUES (@student_id, @date, @result)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("date", Date);
                    cmd.Parameters.AddWithValue("result", Result);
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

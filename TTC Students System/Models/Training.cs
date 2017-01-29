using MySql.Connection;
using MySql.Data.MySqlClient;
using System;

namespace GN.TTC.Students.Models
{
    class Training
    {
        internal Training()
        {
            ID = 0;
            StudentID = 0;
            Status = "ENROLLED";
            Scholarship = "";
            Voucher = "";
            DateStarted = new DateTime(2000, 01, 01);
            DateFinished = new DateTime(2000, 01, 01);
            Result = "";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Status { get; set; }
        internal string Scholarship { get; set; }
        internal string Voucher { get; set; }
        internal DateTime DateStarted { get; set; }
        internal DateTime DateFinished { get; set; }
        internal string Result { get; set; }

        internal static Training getTrainingByStudent(int StudentID)
        {
            Training training = new Training();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM trainings WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            training.ID = rdr.GetInt32(0);
                            training.StudentID = rdr.GetInt32(1);
                            training.Status = rdr.GetString(2);
                            training.Scholarship = rdr.GetString(3);
                            training.Voucher = rdr.GetString(4);
                            training.DateStarted = rdr.GetDateTime(5);
                            training.DateFinished = rdr.GetDateTime(6);
                            training.Result = rdr.GetString(7);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return training;
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
                        cmd.CommandText = "UPDATE trainings SET status = @status, scholarship = @scholarship, voucher = @voucher, date_started = @date_started, date_finished = @date_finished, result = @result WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO trainings (student_id, status, scholarship, voucher, date_started, date_finished, result) VALUES (@student_id, @status, @scholarship, @voucher, @date_started, @date_finished, @result)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("status", Status);
                    cmd.Parameters.AddWithValue("scholarship", Scholarship);
                    cmd.Parameters.AddWithValue("voucher", Voucher);
                    cmd.Parameters.AddWithValue("date_started", DateStarted);
                    cmd.Parameters.AddWithValue("date_finished", DateFinished);
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

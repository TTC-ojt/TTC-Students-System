using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GN.TTC.Students.Models
{
    class Grade
    {

        internal Grade()
        {
            ID = 0;
            SubjectID = 0;
            StudentID = 0;
            Score = "";
            Remarks = "";
        }

        internal int ID { get; set; }
        internal int SubjectID { get; set; }
        internal int StudentID { get; set; }
        internal string Score { get; set; }
        internal string Remarks { get; set; }
        
        internal static Grade getBySubjectAndStudent(int SubjectID, int StudentID)
        {
            Grade grade = new Grade();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM grades WHERE subject_id = @subject_id AND student_id = @student_id";
                    cmd.Parameters.AddWithValue("subject_id", SubjectID);
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            grade.ID = rdr.GetInt32(0);
                            grade.SubjectID = rdr.GetInt32(1);
                            grade.StudentID = rdr.GetInt32(2);
                            grade.Score = rdr.GetString(3);
                            grade.Remarks = rdr.GetString(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return grade;
        }

        internal void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ID > 0) cmd.CommandText = "UPDATE grades SET grade = @grade, remarks = @remarks WHERE subject_id = @subject_id AND student_id = @student_id";
                    else cmd.CommandText = "INSERT INTO grades (subject_id, student_id, grade, remarks) VALUES (@subject_id, @student_id, @grade, @remarks)";
                    cmd.Parameters.AddWithValue("subject_id", SubjectID);
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("grade", Score);
                    cmd.Parameters.AddWithValue("remarks", Remarks);
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

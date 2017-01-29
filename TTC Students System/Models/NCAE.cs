using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Models
{
    class NCAE
    {

        internal NCAE()
        {
            ID = 0;
            StudentID = 0;
            General = "";
            Technical = "";
            NonVerbal = "";
            FirstField = "";
            SecondField = "";
        }

        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string General { get; set; }
        internal string Technical { get; set; }
        internal string NonVerbal { get; set; }
        internal string FirstField { get; set; }
        internal string SecondField { get; set; }

        internal static NCAE getByStudent(int StudentID)
        {
            NCAE ncae = new NCAE();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM ncae WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ncae.ID = rdr.GetInt32(0);
                            ncae.StudentID = rdr.GetInt32(1);
                            ncae.General = rdr.GetString(2);
                            ncae.Technical = rdr.GetString(3);
                            ncae.NonVerbal = rdr.GetString(4);
                            ncae.FirstField = rdr.GetString(5);
                            ncae.SecondField = rdr.GetString(6);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return ncae;
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
                        cmd.CommandText = "UPDATE ncae SET general = @general, technical = @technical, nonverbal = @nonverbal, 1stfield = @1stfield, 2ndfield = @2ndfield WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO ncae (student_id, general, technical, nonverbal, 1stfield, 2ndfield) VALUES (@student_id, @general, @technical, @nonverbal, @1stfield, @2ndfield)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("general", General);
                    cmd.Parameters.AddWithValue("technical", Technical);
                    cmd.Parameters.AddWithValue("nonverbal", NonVerbal);
                    cmd.Parameters.AddWithValue("1stfield", FirstField);
                    cmd.Parameters.AddWithValue("2ndfield", SecondField);
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

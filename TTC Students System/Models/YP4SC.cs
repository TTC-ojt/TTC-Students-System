using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Models
{
    class YP4SC
    {

        internal YP4SC()
        {
            ID = 0;
            StudentID = 0;
            Enterprising = "";
            Investigative = "";
            Social = "";
            Realistic = "";
            Conventional = "";
            Artistic = "";
            FirstLevel = "";
            SecondLevel = "";
            ThirdLevel = "";
        }

        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Enterprising { get; set; }
        internal string Investigative { get; set; }
        internal string Social { get; set; }
        internal string Realistic { get; set; }
        internal string Conventional { get; set; }
        internal string Artistic { get; set; }
        internal string FirstLevel { get; set; }
        internal string SecondLevel { get; set; }
        internal string ThirdLevel { get; set; }

        internal static YP4SC getByStudent(int StudentID)
        {
            YP4SC yp4sc = new YP4SC();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM yp4sc WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            yp4sc.ID = rdr.GetInt32(0);
                            yp4sc.StudentID = rdr.GetInt32(1);
                            yp4sc.Enterprising = rdr.GetString(2);
                            yp4sc.Investigative = rdr.GetString(3);
                            yp4sc.Social = rdr.GetString(4);
                            yp4sc.Realistic = rdr.GetString(5);
                            yp4sc.Conventional = rdr.GetString(6);
                            yp4sc.Artistic = rdr.GetString(7);
                            yp4sc.FirstLevel = rdr.GetString(8);
                            yp4sc.SecondLevel = rdr.GetString(9);
                            yp4sc.ThirdLevel = rdr.GetString(10);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return yp4sc;
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
                        cmd.CommandText = "UPDATE yp4sc SET enterprising = @enterprising, investigative = @investigative, social = @social, realistic = @realistic, conventional = @conventional, 1stlevel = @1stlevel, 2ndlevel = @2ndlevel, 3rdlevel = @3rdlevel WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO yp4sc (student_id, enterprising, investigative, social, realistic, conventional, 1stlevel, 2ndlevel, 3rdlevel) VALUES (@student_id, @enterprising, @investigative, @social, @realistic, @conventional, @1stlevel, @2ndlevel, @3rdlevel)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("enterprising", Enterprising);
                    cmd.Parameters.AddWithValue("investigative", Investigative);
                    cmd.Parameters.AddWithValue("social", Social);
                    cmd.Parameters.AddWithValue("realistic", Realistic);
                    cmd.Parameters.AddWithValue("conventional", Conventional);
                    cmd.Parameters.AddWithValue("1stlevel", FirstLevel);
                    cmd.Parameters.AddWithValue("2ndlevel", SecondLevel);
                    cmd.Parameters.AddWithValue("3rdlevel", ThirdLevel);
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

using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Models
{
    class MATB
    {

        internal MATB()
        {
            ID = 0;
            StudentID = 0;
            Reading = "";
            eReading = "";
            Mechanical = "";
            eMechanical = "";
            Math = "";
            eMath = "";
        }

        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Reading { get; set; }
        internal string eReading { get; set; }
        internal string Mechanical { get; set; }
        internal string eMechanical { get; set; }
        internal string Math { get; set; }
        internal string eMath { get; set; }

        internal static MATB getByStudent(int StudentID)
        {
            MATB matb = new MATB();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM matb WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            matb.ID = rdr.GetInt32(0);
                            matb.StudentID = rdr.GetInt32(1);
                            matb.Reading = rdr.GetString(2);
                            matb.eReading = rdr.GetString(3);
                            matb.Mechanical = rdr.GetString(4);
                            matb.eMechanical = rdr.GetString(5);
                            matb.Math = rdr.GetString(6);
                            matb.eMath = rdr.GetString(7);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return matb;
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
                        cmd.CommandText = "UPDATE matb SET reading = @reading, e_reading = @e_reading, mechanical = @mechanical, e_mechanical = @e_mechanical, math = @math, e_math = @e_math WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO matb (student_id, reading, e_reading, mechanical, e_mechanical, math, e_math) VALUES (@student_id, @reading, @e_reading, @mechanical, @e_mechanical, @math, @e_math)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("reading", Reading);
                    cmd.Parameters.AddWithValue("e_reading", eReading);
                    cmd.Parameters.AddWithValue("mechanical", Mechanical);
                    cmd.Parameters.AddWithValue("e_mechanical", eMechanical);
                    cmd.Parameters.AddWithValue("math", Math);
                    cmd.Parameters.AddWithValue("e_math", eMath);
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

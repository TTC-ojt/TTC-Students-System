using System;
using MySql.Data.MySqlClient;
using MySql.Connection;
using System.Collections.Generic;

namespace GN.TTC.Students.Models
{
    class Insurance
    {
        internal Insurance()
        {
            ID = 0;
            StudentID = 0;
            Beneficiary = "";
            Relationship = "";
            Amount = 0m;
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Company { get; set; }
        internal string Beneficiary { get; set; }
        internal string Relationship { get; set; }
        internal decimal Amount { get; set; }

        internal static Insurance getByStudent(int StudentID)
        {
            Insurance insurance = new Insurance();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM insurances WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            insurance.ID = rdr.GetInt32(0);
                            insurance.StudentID = rdr.GetInt32(1);
                            insurance.Company = rdr.GetString(2);
                            insurance.Beneficiary = rdr.GetString(3);
                            insurance.Relationship = rdr.GetString(4);
                            insurance.Amount = rdr.GetDecimal(5);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return insurance;
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
                        cmd.CommandText = "UPDATE insurances SET company = @company, beneficiary = @beneficiary, relationship = @relationship, amount = @amount WHERE student_id = @student_id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO insurances (student_id, company, beneficiary, relationship, amount) VALUES (@student_id, @company, @beneficiary, @relationship, @amount)";
                    }
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("company", Company);
                    cmd.Parameters.AddWithValue("beneficiary", Beneficiary);
                    cmd.Parameters.AddWithValue("relationship", Relationship);
                    cmd.Parameters.AddWithValue("amount", Amount);
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

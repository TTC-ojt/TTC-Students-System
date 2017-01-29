using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Models
{
    class InPlant
    {

        internal InPlant()
        {
            ID = 0;
            CompanyID = 0;
            StudentID = 0;
            StartDate = new DateTime(2000, 1, 1);
            EndDate = new DateTime(2000, 1, 1);
        }

        internal int ID { get; set; }
        internal int CompanyID { get; set; }
        internal DateTime StartDate { get; set; }
        internal DateTime EndDate { get; set; }
        internal int StudentID { get; set; }

        internal static MySqlDataAdapter GetDataAdapter()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select companies.name, inplants.start_date, inplants.end_date, concat_ws(' ', students.firstname, students.middlename, students.lastname, students.extname) as 'Student', batches.number from companies join inplants on companies.id=inplants.company_id join students on students.id=inplants.student_id join batches on batches.id=students.batch_id";
                    adapter = new MySqlDataAdapter(cmd);
                    MySqlCommandBuilder cmdBuilder = new MySqlCommandBuilder(adapter);
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return adapter;
        }

        internal static InPlant getByStudent(int StudentID)
        {
            InPlant inplant = new InPlant();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM inplants WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            inplant.ID = rdr.GetInt32(0);
                            inplant.CompanyID = rdr.GetInt32(1);
                            inplant.StudentID = rdr.GetInt32(2);
                            inplant.StartDate = rdr.GetDateTime(3);
                            inplant.EndDate = rdr.GetDateTime(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return inplant;
        }

        internal static List<InPlant> getAllByCompanyAndDate(int CompanyID, DateTime StartDate, DateTime EndDate)
        {
            List<InPlant> inplants = new List<InPlant>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM inplants WHERE company_id = @company_id AND start_date <= DATE(@startdate) AND end_date >= DATE(@enddate)";
                    cmd.Parameters.AddWithValue("company_id", CompanyID);
                    cmd.Parameters.AddWithValue("startdate", StartDate);
                    cmd.Parameters.AddWithValue("enddate", EndDate);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            InPlant inplant = new InPlant();
                            inplant.ID = rdr.GetInt32(0);
                            inplant.CompanyID = rdr.GetInt32(1);
                            inplant.StudentID = rdr.GetInt32(2);
                            inplant.StartDate = rdr.GetDateTime(3);
                            inplant.EndDate = rdr.GetDateTime(4);
                            inplants.Add(inplant);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return inplants;
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
                        cmd.CommandText = "UPDATE inplants SET start_date=@start_date,end_date=@end_date WHERE company_id=@company_id AND student_id=@student_id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO inplants (company_id,student_id,start_date,end_date) VALUES (@company_id,@student_id,@start_date,@end_date)";                        
                    }
                    cmd.Parameters.AddWithValue("company_id", CompanyID);
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("start_date", StartDate);
                    cmd.Parameters.AddWithValue("end_date", EndDate);
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

        internal void Delete()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "DELETE FROM inplants WHERE id= @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
        }

    }
}

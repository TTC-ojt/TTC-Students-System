using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Subject
    {

        internal Subject()
        {
            ID = 0;
            ProgramID = 0;
            Type = "";
            Code = "";
            Title = "";
            Description = "";
            Hours = 0;
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int ProgramID { get; set; }
        internal string Type { get; set; }
        internal string Code { get; set; }
        internal string Title { get; set; }
        internal string Description { get; set; }
        internal short Hours { get; set; }

        /// <summary>
        /// Gets all subjects by program
        /// </summary>
        /// <param name="ProgramID">Program ID</param>
        /// <returns>Subjects List</returns>
        internal static List<Subject> getAllByProgram(int ProgramID)
        {
            List<Subject> subjects = new List<Subject>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM subjects WHERE program_id = @program_id";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Subject subject = new Subject();
                            subject.ID = rdr.GetInt32(0);
                            subject.ProgramID = rdr.GetInt32(1);
                            subject.Type = rdr.GetString(2);
                            subject.Code = rdr.GetString(3);
                            subject.Title = rdr.GetString(4);
                            subject.Description = rdr.GetString(5);
                            subject.Hours = rdr.GetInt16(6);
                            subjects.Add(subject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return subjects;
        }

        /// <summary>
        /// Saves subject to DB
        /// </summary>
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
                        cmd.CommandText = "UPDATE subjects SET type = @type, code = @code,title = @title, description = @description, hours = @hours WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO subjects (program_id, type, code, title, description, hours ) VALUES (@program_id, @type, @code, @title, @description ,@hours)";
                        cmd.Parameters.AddWithValue("program_id", ProgramID);
                    }
                    cmd.Parameters.AddWithValue("type", Type);
                    cmd.Parameters.AddWithValue("code", Code);
                    cmd.Parameters.AddWithValue("title", Title);
                    cmd.Parameters.AddWithValue("description", Description);
                    cmd.Parameters.AddWithValue("hours", Hours);
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

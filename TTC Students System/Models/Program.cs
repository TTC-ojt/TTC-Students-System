﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Program
    {
        
        internal Program()
        {
            ID = 0;
            Industry = "";
            Status = "";
            Title = "";
            Copr = "";
            Calendar = "";
            Delivery = "";
            OneYear = false;
            ShortCourse = false;
            Tuition = 0m;
            Hours = 0;
            ShortName = "";
        }

        internal int ID;
        internal string Industry;
        internal string Status;
        internal string Title;
        internal string Copr;
        internal string Calendar;
        internal string Delivery;
        internal bool OneYear;
        internal bool ShortCourse;
        internal decimal Tuition;
        internal short Hours;
        internal string ShortName;

        /// <summary>
        /// Gets all programs
        /// </summary>
        /// <returns>Program List</returns>
        internal static List<Program> getAll()
        {
            List<Program> programs = new List<Program>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM programs";
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Program program = new Program();
                            program.ID = rdr.GetInt32(0);
                            program.Industry = rdr.GetString(1);
                            program.Status = rdr.GetString(2);
                            program.Title = rdr.GetString(3);
                            program.Copr = rdr.GetString(4);
                            program.Calendar = rdr.GetString(5);
                            program.Delivery = rdr.GetString(6);
                            program.OneYear = rdr.GetBoolean(7);
                            program.ShortCourse = rdr.GetBoolean(8);
                            program.Tuition = rdr.GetDecimal(9);
                            program.Hours = rdr.GetInt16(10);
                            program.ShortName = rdr.GetString(11);
                            programs.Add(program);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return programs;
        }

        /// <summary>
        /// Gets Program by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Program</returns>
        internal static Program getByID(int id)
        {
            Program program = new Program();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM programs WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            program.ID = rdr.GetInt32(0);
                            program.Industry = rdr.GetString(1);
                            program.Status = rdr.GetString(2);
                            program.Title = rdr.GetString(3);
                            program.Copr = rdr.GetString(4);
                            program.Calendar = rdr.GetString(5);
                            program.Delivery = rdr.GetString(6);
                            program.OneYear = rdr.GetBoolean(7);
                            program.ShortCourse = rdr.GetBoolean(8);
                            program.Tuition = rdr.GetDecimal(9);
                            program.Hours = rdr.GetInt16(10);
                            program.ShortName = rdr.GetString(11);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return program;
        }

        /// <summary>
        /// Sums up all tuition under this Program
        /// </summary>
        /// <returns>Full Tuition</returns>
        internal decimal GetFullTuition()
        {
            decimal full_tuition = Tuition;
            try
            {
                string query = "SELECT assessment, id_card, insurance, tshirt, special FROM fees WHERE program_id=@program_id";
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("program_id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            full_tuition += rdr.GetDecimal(0);
                            full_tuition += rdr.GetDecimal(1);
                            full_tuition += rdr.GetDecimal(2);
                            full_tuition += rdr.GetDecimal(3);
                            full_tuition += rdr.GetDecimal(4);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return full_tuition;
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
                        cmd.CommandText = "UPDATE programs SET industry = @industry, status = @status, title = @title, copr = @copr, calendar = @calendar, delivery = @delivery, one_year = @one_year, short_course = @short_course, tuition = @tuition, hours = @hours, short_name = @short_name WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO programs (industry, status, title, copr, calendar, delivery, one_year, short_course, tuition, hours, short_name) VALUES (@industry, @status, @title, @copr, @calendar, @delivery, @one_year, @short_course, @tuition, @hours, @short_name)";
                    }
                    cmd.Parameters.AddWithValue("industry", Industry);
                    cmd.Parameters.AddWithValue("status", Status);
                    cmd.Parameters.AddWithValue("title", Title);
                    cmd.Parameters.AddWithValue("copr", Copr);
                    cmd.Parameters.AddWithValue("calendar", Calendar);
                    cmd.Parameters.AddWithValue("delivery", Delivery);
                    cmd.Parameters.AddWithValue("one_year", OneYear);
                    cmd.Parameters.AddWithValue("short_course", ShortCourse);
                    cmd.Parameters.AddWithValue("tuition", Tuition);
                    cmd.Parameters.AddWithValue("hours", Hours);
                    cmd.Parameters.AddWithValue("short_name", ShortName);
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
using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Connection;
using System.IO;
using System.Windows.Forms;

namespace GN.TTC.Students.Models
{
    class Student
    {
        internal Student()
        {
            ID = 0;
            BatchID = 0;
            Number = "";
            LastName = "";
            FirstName = "";
            MiddleName = "";
            ExtName = "";
            Tuition = 0m;
            Status = "IN-SCHOOL";
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int BatchID { get; set; }
        internal string Number { get; set; }
        internal string LastName { get; set; }
        internal string FirstName { get; set; }
        internal string MiddleName { get; set; }
        internal string ExtName { get; set; }
        internal decimal Tuition { get; set; }
        internal string Status { get; set; }

        internal static MySqlDataAdapter GetDataAdapter(int BatchID)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT " + 
                        "`providers`.`region`, `providers`.`province`, `providers`.`district`, `providers`.`city`, `providers`.`name`, `providers`.`address`, `providers`.`type`, `providers`.`classification`," +
                        "`programs`.`industry`, `programs`.`status`, `programs`.`title`, `programs`.`copr`, `programs`.`calendar`, `programs`.`delivery`," +
                        "`students`.`lastname`, `students`.`firstname`, `students`.`middlename`, `students`.`extname`," + 
                        "`contacts`.`phone`, `contacts`.`email`, `contacts`.`street`, `contacts`.`barangay`, `contacts`.`city`," + 
                        "`profiles`.`gender`, `profiles`.`birthdate`, `profiles`.`birthplace`, `profiles`.`civil_status`, `profiles`.`education`, `profiles`.`nationality`, `profiles`.`classification`," +
                        "`trainings`.`status`, `trainings`.`scholarship`, `trainings`.`voucher`, `trainings`.`date_started`, `trainings`.`date_finished`, `trainings`.`result`," + 
                        "`assessments`.`date`, `assessments`.`result`," + 
                        "`employments`.`date_employed`, `employments`.`occupation`, `employments`.`employer`, `employments`.`address`, `employments`.`classification`, `employments`.`income` " + 
                        " FROM providers, students " + 
                        " JOIN contacts ON students.id = contacts.student_id " + 
                        " JOIN profiles ON students.id = profiles.student_id " + 
                        " JOIN batches ON students.batch_id = batches.id " + 
                        " JOIN programs ON programs.id = batches.program_id " + 
                        " JOIN trainings ON students.id = trainings.student_id " + 
                        " JOIN assessments ON students.id = assessments.student_id " + 
                        " JOIN employments ON students.id = employments.student_id " + 
                        " WHERE batches.id = @batch_id AND employments.type = 'After'";
                    cmd.Parameters.AddWithValue("@batch_id", BatchID);
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

        /// <summary>
        /// Get all students by Batch
        /// </summary>
        /// <param name="BatchID">Batch ID</param>
        /// <returns>Student List</returns>
        internal static List<Student> getByBatch(int BatchID)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE batch_id = @batch_id ORDER BY lastname, firstname, middlename";
                    cmd.Parameters.AddWithValue("batch_id", BatchID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Student student = new Student();
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return students;
        }

        /// <summary>
        /// Get Student by Number
        /// </summary>
        /// <param name="number">Student Number</param>
        /// <returns>Student</returns>
        internal static Student getStudentByNumber(string number)
        {
            Student student = new Student();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE number = @number";
                    cmd.Parameters.AddWithValue("number", number);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return student;
        }

        internal static Student getByID(int ID)
        {
            Student student = new Student();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM students WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return student;
        }

        /// <summary>
        /// Find students by Name //TODO
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal static List<Student> Find(string query, int ProgramID, int BatchID)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ProgramID > 0 && BatchID > 0)
                    {
                        cmd.CommandText = "SELECT students.id, students.batch_id, students.number, students.lastname, students.firstname, students.middlename, students.extname, students.tuition, students.status FROM students JOIN batches ON students.batch_id=batches.id JOIN programs ON batches.program_id=programs.id WHERE CONCAT_WS(' ', students.number, students.firstname, students.middlename, students.lastname) LIKE '%" + query + "%' AND programs.id=@program_id AND batches.id=@batch_id ORDER BY lastname, firstname, middlename";
                        cmd.Parameters.AddWithValue("program_id", ProgramID);
                        cmd.Parameters.AddWithValue("batch_id", BatchID);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM students WHERE CONCAT_WS(' ', number, firstname, middlename, lastname) LIKE '%" + query + "%' ORDER BY lastname, firstname, middlename";
                    }
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Student student = new Student();
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return students;
        }

        internal static List<Student> FindWithStatus(string query, int ProgramID, int BatchID, string Status)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ProgramID > 0 && BatchID > 0)
                    {
                        cmd.CommandText = "SELECT students.id, students.batch_id, students.number, students.lastname, students.firstname, students.middlename, students.extname, students.tuition, students.status FROM students JOIN batches ON students.batch_id=batches.id JOIN programs ON batches.program_id=programs.id WHERE CONCAT_WS(' ', students.number, students.firstname, students.middlename, students.lastname) LIKE '%" + query + "%' AND programs.id=@program_id AND batches.id=@batch_id AND students.status = @status ORDER BY lastname, firstname, middlename";
                        cmd.Parameters.AddWithValue("program_id", ProgramID);
                        cmd.Parameters.AddWithValue("batch_id", BatchID);
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM students WHERE CONCAT_WS(' ', number, firstname, middlename, lastname) LIKE '%" + query + "%' AND status = @status ORDER BY lastname, firstname, middlename";
                    }
                    cmd.Parameters.AddWithValue("@status", Status);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Student student = new Student();
                            student.ID = rdr.GetInt32(0);
                            student.BatchID = rdr.GetInt32(1);
                            student.Number = rdr.GetString(2);
                            student.LastName = rdr.GetString(3);
                            student.FirstName = rdr.GetString(4);
                            student.MiddleName = rdr.GetString(5);
                            student.ExtName = rdr.GetString(6);
                            student.Tuition = rdr.GetDecimal(7);
                            student.Status = rdr.GetString(8);
                            students.Add(student);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return students;
        }

        /// <summary>
        /// Gets the Next Sequence for Student Number
        /// </summary>
        /// <returns>Student Number</returns>
        internal static string GetNextNumber()
        {
            int number = 1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT number FROM students ORDER BY id DESC LIMIT 1";
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string last = rdr.GetString(0);
                            number = Convert.ToInt32(last.Split('-').Last()) + 1;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return number.ToString("D4");
        }

        internal string GetFullName()
        {
            string fullname = LastName;
            if (!string.IsNullOrWhiteSpace(ExtName)) fullname += " " + ExtName;
            fullname += ", " + FirstName + " ";
            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                var mis = MiddleName.Split(' ');
                foreach (var mi in mis)
                {
                    if (mi.Length > 0) fullname += mi.Substring(0, 1) + ". ";
                }
            }
            return fullname;
        }

        /// <summary>
        /// Saves student to DB
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
                        cmd.CommandText = "UPDATE students SET lastname = @lastname, firstname = @firstname, middlename = @middlename, extname = @extname, tuition = @tuition, status = @status WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO students (batch_id, number, lastname, firstname, middlename, extname, tuition, status) VALUES (@batch_id, @number, @lastname, @firstname, @middlename, @extname, @tuition, @status)";
                        cmd.Parameters.AddWithValue("batch_id", BatchID);
                        cmd.Parameters.AddWithValue("number", Number);
                    }
                    cmd.Parameters.AddWithValue("lastname", LastName);
                    cmd.Parameters.AddWithValue("firstname", FirstName);
                    cmd.Parameters.AddWithValue("middlename", MiddleName);
                    cmd.Parameters.AddWithValue("extname", ExtName);
                    cmd.Parameters.AddWithValue("tuition", Tuition);
                    cmd.Parameters.AddWithValue("status", Status);
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
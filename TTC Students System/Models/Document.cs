using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GN.TTC.Students.Models
{
    class Document
    {

        internal Document()
        {
            ID = 0;
            StudentID = 0;
            C137 = false;
            C138 = false;
            GoodMoral = false;
            BirthCert = false;
            Pictures = false;
            Diploma = false;
            BrgyClearance = false;
            Envelope = false;
            Remarks = "";
        }

        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal bool C137 { get; set; }
        internal bool C138 { get; set; }
        internal bool GoodMoral { get; set; }
        internal bool BirthCert { get; set; }
        internal bool Pictures { get; set; }
        internal bool Diploma { get; set; }
        internal bool BrgyClearance { get; set; }
        internal bool Envelope { get; set; }
        internal string Remarks { get; set; }

        internal static Document getByStudent(int StudentID)
        {
            Document document = new Document();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM documents WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            document.ID = rdr.GetInt32(0);
                            document.StudentID = rdr.GetInt32(1);
                            document.C137 = rdr.GetBoolean(2);
                            document.C138 = rdr.GetBoolean(3);
                            document.GoodMoral = rdr.GetBoolean(4);
                            document.BirthCert = rdr.GetBoolean(5);
                            document.Pictures = rdr.GetBoolean(6);
                            document.Diploma = rdr.GetBoolean(7);
                            document.BrgyClearance = rdr.GetBoolean(8);
                            document.Envelope = rdr.GetBoolean(9);
                            document.Remarks = rdr.GetString(10);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return document;
        }

        internal static List<Document> getByBatch(int BatchID)
        {
            List<Document> documents = new List<Document>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT documents.id, documents.student_id,`documents`.`c137`, `documents`.`c138`, `documents`.`good_moral`, `documents`.`birth_cert`, `documents`.`pictures`, `documents`.`diploma`, `documents`.`brgy_clearance`, `documents`.`envelope`, `documents`.`remarks` FROM documents JOIN students ON documents.student_id = students.id WHERE students.batch_id = @batch_id";
                    cmd.Parameters.AddWithValue("@batch_id", BatchID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Document document = new Document();
                            document.ID = rdr.GetInt32(0);
                            document.StudentID = rdr.GetInt32(1);
                            document.C137 = rdr.GetBoolean(2);
                            document.C138 = rdr.GetBoolean(3);
                            document.GoodMoral = rdr.GetBoolean(4);
                            document.BirthCert = rdr.GetBoolean(5);
                            document.Pictures = rdr.GetBoolean(6);
                            document.Diploma = rdr.GetBoolean(7);
                            document.BrgyClearance = rdr.GetBoolean(8);
                            document.Envelope = rdr.GetBoolean(9);
                            document.Remarks = rdr.GetString(10);
                            documents.Add(document);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return documents;
        }

        internal bool IsComplete()
        {
            return C137 && C138 && GoodMoral && BirthCert && Pictures && Diploma && BrgyClearance && Envelope;
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
                        cmd.CommandText = "UPDATE documents SET `c137` = @c137, `c138` = @c138, good_moral = @good_moral, birth_cert = @birth_cert, pictures = @pictures, diploma = @diploma, `brgy_clearance` = @brgy_clearance, envelope = @envelope, remarks = @remarks WHERE student_id = @student_id";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO documents (student_id, `c137`, `c138`, good_moral, birth_cert, pictures, diploma, `brgy_clearance`, envelope, remarks) VALUES (@student_id, @c137, @c138, @good_moral, @birth_cert, @pictures, @diploma, @brgy_clearance, @envelope, @remarks)";
                        
                    }
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("c137", C137);
                    cmd.Parameters.AddWithValue("c138", C138);
                    cmd.Parameters.AddWithValue("good_moral", GoodMoral);
                    cmd.Parameters.AddWithValue("birth_cert", BirthCert);
                    cmd.Parameters.AddWithValue("pictures", Pictures);
                    cmd.Parameters.AddWithValue("diploma", Diploma);
                    cmd.Parameters.AddWithValue("brgy_clearance", BrgyClearance);
                    cmd.Parameters.AddWithValue("envelope", Envelope);
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

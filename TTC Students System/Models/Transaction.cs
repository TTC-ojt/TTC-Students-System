using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GN.TTC.Students.Models
{
    class Transaction
    {

        internal Transaction()
        {
            ID = 0;
            StudentID = 0;
            Code = "";
            DateTime = new DateTime(2000, 1, 1);
            Amount = 0m;
        }

        internal int ID { get; set; }
        internal int StudentID { get; set; }
        internal string Code { get; set; }
        internal DateTime DateTime { get; set; }
        internal decimal Amount { get; set; }

        internal static decimal GetBalance(int StudentID)
        {
            decimal balance = 0m;
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT students.tuition - IFNULL(SUM(transactions.amount), 0) FROM transactions JOIN students ON transactions.student_id = students.id WHERE students.id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            balance = rdr.GetDecimal(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return balance;
        }

        internal static List<Transaction> getTransactionsByStudent(int StudentID)
        {
            List<Transaction> transactions = new List<Transaction>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM transactions WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Transaction transaction = new Transaction();
                            transaction.ID = rdr.GetInt32(0);
                            transaction.StudentID = rdr.GetInt32(1);
                            transaction.Code = rdr.GetString(2);
                            transaction.DateTime = rdr.GetDateTime(3);
                            transaction.Amount = rdr.GetDecimal(4);
                            transactions.Add(transaction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return transactions;
        }

        internal static Transaction getByID(int ID)
        {
            Transaction transaction = new Transaction();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM transactions WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            transaction.ID = rdr.GetInt32(0);
                            transaction.StudentID = rdr.GetInt32(1);
                            transaction.Code = rdr.GetString(2);
                            transaction.DateTime = rdr.GetDateTime(3);
                            transaction.Amount = rdr.GetDecimal(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return transaction;
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
                        cmd.CommandText = "UPDATE transactions SET code = @code, amount = @amount WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO transactions (student_id, code, amount) VALUES (@student_id, @code, @amount)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("code", Code);
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

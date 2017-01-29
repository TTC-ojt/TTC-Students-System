using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Fee
    {

        internal Fee()
        {
            ID = 0;
            ProgramID = 0;
            Assessment = 0m;
            ID_Card = 0m;
            Insurance = 0m;
            TShirt = 0m;
            Special = 0m;
        }

        //PROPERTIES
        internal int ID { get; set; }
        internal int ProgramID { get; set; }
        internal decimal Assessment {get; set; }
        internal decimal ID_Card { get; set; }
        internal decimal Insurance { get; set; }
        internal decimal TShirt { get; set; }
        internal decimal Special { get; set; }

        /// <summary>
        /// Get Fees by Program
        /// </summary>
        /// <param name="ProgramID">Program ID</param>
        /// <returns>Fee List</returns>
        internal static Fee getByProgram(int ProgramID)
        {
            Fee fee = new Fee();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM fees WHERE program_id = @program_id";
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            fee.ID = rdr.GetInt32(0);
                            fee.ProgramID = rdr.GetInt32(1);
                            fee.Assessment = rdr.GetDecimal(2);
                            fee.ID_Card = rdr.GetDecimal(3);
                            fee.Insurance = rdr.GetDecimal(4);
                            fee.TShirt = rdr.GetDecimal(5);
                            fee.Special = rdr.GetDecimal(6);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return fee;
        }

        /// <summary>
        /// Saves Fee to DB
        /// </summary>
        public void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    if (ID > 0)
                    {
                        cmd.CommandText = "UPDATE fees SET program_id = @program_id, assessment = @assessment, id_card = @id_card, insurance = @insurance, tshirt = @tshirt, special = @special WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO fees (program_id, assessment, id_card, insurance, tshirt, special) VALUES (@program_id, @assessment, @id_card, @insurance, @tshirt, @special)";
                    }
                    cmd.Parameters.AddWithValue("program_id", ProgramID);
                    cmd.Parameters.AddWithValue("assessment", Assessment);
                    cmd.Parameters.AddWithValue("id_card", ID_Card);
                    cmd.Parameters.AddWithValue("insurance", Insurance);
                    cmd.Parameters.AddWithValue("tshirt", TShirt);
                    cmd.Parameters.AddWithValue("special", Special);
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

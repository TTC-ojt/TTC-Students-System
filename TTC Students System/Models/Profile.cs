using System;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Profile
    {
        internal Profile()
        {
            ID = 0;
            StudentID = 0;
            Gender = "Male";
            Birthdate = new DateTime(2000, 1, 1);
            Birthplace = "";
            CivilStatus = "Single";
            Education = "";
            Nationality = "Filipino";
            Classification = "Regular";
            Guardian = "";
        }

        internal int ID;
        internal int StudentID;
        internal string Gender;
        internal DateTime Birthdate;
        internal string Birthplace;
        internal string CivilStatus;
        internal string Education;
        internal string Nationality;
        internal string Classification;
        internal string Guardian;

        internal static Profile getByStudent(int StudentID)
        {
            Profile profile = new Profile();
            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM profiles WHERE student_id = @student_id";
                    cmd.Parameters.AddWithValue("@student_id", StudentID);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            profile.ID = rdr.GetInt32(0);
                            profile.StudentID = rdr.GetInt32(1);
                            profile.Gender = rdr.GetString(2);
                            profile.Birthdate = rdr.GetDateTime(3);
                            profile.Birthplace = rdr.GetString(4);
                            profile.CivilStatus = rdr.GetString(5);
                            profile.Education = rdr.GetString(6);
                            profile.Nationality = rdr.GetString(7);
                            profile.Classification = rdr.GetString(8);
                            profile.Guardian = rdr.GetString(9);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return profile;
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
                        cmd.CommandText = "UPDATE profiles SET gender = @gender, birthdate = @birthdate, birthplace = @birthplace, civil_status = @civil_status, education = @education, nationality = @nationality, classification = @classification, guardian = @guardian WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO profiles (student_id, gender, birthdate, birthplace, civil_status, education, nationality, classification, guardian) VALUES (@student_id, @gender,  @birthdate, @birthplace, @civil_status, @education, @nationality, @classification, @guardian)";
                        cmd.Parameters.AddWithValue("student_id", StudentID);
                    }
                    cmd.Parameters.AddWithValue("gender", Gender);
                    cmd.Parameters.AddWithValue("birthdate", Birthdate);
                    cmd.Parameters.AddWithValue("birthplace", Birthplace);
                    cmd.Parameters.AddWithValue("civil_status", CivilStatus);
                    cmd.Parameters.AddWithValue("education", Education);
                    cmd.Parameters.AddWithValue("nationality", Nationality);
                    cmd.Parameters.AddWithValue("classification", Classification);
                    cmd.Parameters.AddWithValue("guardian", Guardian);
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
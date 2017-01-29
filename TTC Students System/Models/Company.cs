using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Connection;

namespace GN.TTC.Students.Models
{
    class Company
    {

        internal Company()
        {
            ID = 0;
            Name = "";
            Address = "";
            RegularHour = 0m;
            RegularDay = 0m;
            HolidayHour = 0m;
            HolidayHour = 0m;
            LegalHolidayHour = 0m;
            LegalHolidayDay = 0m;
            GuaranteeHour = 0;
            GuaranteeDay = 0;
            ExtendedTime = 0m;
            NightPremiumHour = 0m;
            NightPremiumDay = 0m;
            TransportationAllowance = 0m;
            SaturdayHour = 0m;
            SaturdayDay = 0m;
        }

        internal int ID { get; set; }
        internal string Name { get; set; }
        internal string Address { get; set; }
        internal decimal RegularHour { get; set; }
        internal decimal RegularDay { get; set; }
        internal decimal HolidayHour { get; set; }
        internal decimal HolidayDay { get; set; }
        internal decimal LegalHolidayHour { get; set; }
        internal decimal LegalHolidayDay { get; set; }
        internal decimal GuaranteeHour { get; set; }
        internal decimal GuaranteeDay { get; set; }
        internal decimal ExtendedTime { get; set; }
        internal decimal NightPremiumHour { get; set; }
        internal decimal NightPremiumDay { get; set; }
        internal decimal TransportationAllowance { get; set; }
        internal decimal SaturdayHour { get; set; }
        internal decimal SaturdayDay { get; set; }

        internal static List<Company> getAll()
        {
            List<Company> companies = new List<Company>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM companies";
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Company company = new Company();
                            company.ID = rdr.GetInt32(0);
                            company.Name = rdr.GetString(1);
                            company.Address = rdr.GetString(2);
                            company.RegularHour = rdr.GetDecimal(3);
                            company.RegularDay = rdr.GetDecimal(4);
                            company.HolidayHour = rdr.GetDecimal(5);
                            company.HolidayDay = rdr.GetDecimal(6);
                            company.LegalHolidayHour = rdr.GetDecimal(7);
                            company.LegalHolidayDay = rdr.GetDecimal(8);
                            company.GuaranteeHour = rdr.GetDecimal(9);
                            company.GuaranteeDay = rdr.GetDecimal(10);
                            company.ExtendedTime = rdr.GetDecimal(11);
                            company.NightPremiumHour = rdr.GetDecimal(12);
                            company.NightPremiumDay = rdr.GetDecimal(13);
                            company.TransportationAllowance = rdr.GetDecimal(14);
                            company.SaturdayHour = rdr.GetDecimal(15);
                            company.SaturdayDay = rdr.GetDecimal(16);
                            companies.Add(company);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return companies;
        }

        internal static Company getbyCompanyId(int id)
        {
            Company company = new Company();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM companies WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            company.ID = rdr.GetInt32(0);
                            company.Name = rdr.GetString(1);
                            company.Address = rdr.GetString(2);
                            company.RegularHour = rdr.GetDecimal(3);
                            company.RegularDay = rdr.GetDecimal(4);
                            company.HolidayHour = rdr.GetDecimal(5);
                            company.HolidayDay = rdr.GetDecimal(6);
                            company.LegalHolidayHour = rdr.GetDecimal(7);
                            company.LegalHolidayDay = rdr.GetDecimal(8);
                            company.GuaranteeHour = rdr.GetDecimal(9);
                            company.GuaranteeDay = rdr.GetDecimal(10);
                            company.ExtendedTime = rdr.GetDecimal(11);
                            company.NightPremiumHour = rdr.GetDecimal(12);
                            company.NightPremiumDay = rdr.GetDecimal(13);
                            company.TransportationAllowance = rdr.GetDecimal(14);
                            company.SaturdayHour = rdr.GetDecimal(15);
                            company.SaturdayDay = rdr.GetDecimal(16);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return company;
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
                        cmd.CommandText = "UPDATE companies SET name=@name,address=@address,regular_hour=@regular_hour,regular_day=@regular_day,holiday_hour=@holiday_hour,holiday_day=@holiday_day,legal_holiday_hour=@legal_holiday_hour,legal_holiday_day=@legal_holiday_day,guarantee_hour=@guarantee_hour,guarantee_day=@guarantee_day,extended_time=@extended_time,night_premium_hour=@night_premium_hour,night_premium_day=@night_premium_day,transportation_allowance=@transportation_allowance, saturday_hour = @saturday_hour, saturday_day=@saturday_day WHERE id = @id";
                        cmd.Parameters.AddWithValue("id", ID);
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO companies (name,address,regular_hour,regular_day,holiday_hour,holiday_day,legal_holiday_hour,legal_holiday_day,guarantee_hour,guarantee_day,extended_time,night_premium_hour,night_premium_day,transportation_allowance, saturday_hour, saturday_day) VALUES (@name,@address,@regular_hour,@regular_day,@holiday_hour,@holiday_day,@legal_holiday_hour,@legal_holiday_day,@guarantee_hour,@guarantee_day,@extended_time,@night_premium_hour,@night_premium_day,@transportation_allowance, @saturday_hour, @saturday_day)";
                    }
                    cmd.Parameters.AddWithValue("name", Name);
                    cmd.Parameters.AddWithValue("address", Address);
                    cmd.Parameters.AddWithValue("regular_hour", RegularHour);
                    cmd.Parameters.AddWithValue("regular_day", RegularDay);
                    cmd.Parameters.AddWithValue("holiday_hour", HolidayHour);
                    cmd.Parameters.AddWithValue("holiday_day", HolidayDay);
                    cmd.Parameters.AddWithValue("legal_holiday_hour", LegalHolidayHour);
                    cmd.Parameters.AddWithValue("legal_holiday_day", LegalHolidayDay);
                    cmd.Parameters.AddWithValue("guarantee_hour", GuaranteeHour);
                    cmd.Parameters.AddWithValue("guarantee_day", GuaranteeDay);
                    cmd.Parameters.AddWithValue("extended_time", ExtendedTime);
                    cmd.Parameters.AddWithValue("night_premium_hour", NightPremiumHour);
                    cmd.Parameters.AddWithValue("night_premium_day", NightPremiumDay);
                    cmd.Parameters.AddWithValue("transportation_allowance", TransportationAllowance);
                    cmd.Parameters.AddWithValue("saturday_hour", SaturdayHour);
                    cmd.Parameters.AddWithValue("saturday_day", SaturdayDay);
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

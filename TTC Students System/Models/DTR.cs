using MySql.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Models
{
    class DTR
    {

        internal DTR()
        {
            ID = 0;
            CompanyID = 0;
            StudentID = 0;
            Date = new DateTime(2000, 1, 1);
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
        internal int CompanyID { get; set; }
        internal DateTime Date { get; set; }
        internal int StudentID { get; set; }
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

        internal static List<DTR> getAllByCompanyAndDate(int CompanyID, DateTime StartDate, DateTime EndDate)
        {
            List<DTR> dtrs = new List<DTR>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT `dtr`.`id`,`dtr`.`company_id`,`dtr`.`date`,`dtr`.`student_id`,`dtr`.`regular_hour`,`dtr`.`regular_day`,`dtr`.`holiday_hour`,`dtr`.`holiday_day`,`dtr`.`legal_holiday_hour`,`dtr`.`legal_holiday_day`,`dtr`.`guarantee_hour`,`dtr`.`guarantee_day`,`dtr`.`extended_time`,`dtr`.`night_premium_hour`,`dtr`.`night_premium_day`,`dtr`.`transportation_allowance`,`dtr`.`saturday_hour`,`dtr`.`saturday_day` FROM dtr WHERE company_id = @company_id AND date >= DATE(@startdate) AND date <= DATE(@enddate) GROUP BY student_id";
                    cmd.Parameters.AddWithValue("company_id", CompanyID);
                    cmd.Parameters.AddWithValue("startdate", StartDate);
                    cmd.Parameters.AddWithValue("enddate", EndDate);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DTR dtr = new DTR();
                            dtr.ID = rdr.GetInt32(0);
                            dtr.CompanyID = rdr.GetInt32(1);
                            dtr.Date = rdr.GetDateTime(2);
                            dtr.StudentID = rdr.GetInt32(3);
                            dtr.RegularHour = rdr.GetDecimal(4);
                            dtr.RegularDay = rdr.GetDecimal(5);
                            dtr.HolidayHour = rdr.GetDecimal(6);
                            dtr.HolidayDay = rdr.GetDecimal(7);
                            dtr.LegalHolidayHour = rdr.GetDecimal(8);
                            dtr.LegalHolidayDay = rdr.GetDecimal(9);
                            dtr.GuaranteeHour = rdr.GetDecimal(10);
                            dtr.GuaranteeDay = rdr.GetDecimal(11);
                            dtr.ExtendedTime = rdr.GetDecimal(12);
                            dtr.NightPremiumHour = rdr.GetDecimal(13);
                            dtr.NightPremiumDay = rdr.GetDecimal(14);
                            dtr.TransportationAllowance = rdr.GetDecimal(15);
                            dtr.SaturdayHour = rdr.GetDecimal(16);
                            dtr.SaturdayDay = rdr.GetDecimal(17);
                            dtrs.Add(dtr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return dtrs;
        }

        internal static List<DTR> getAllByCompanyAndDateForSummary(int CompanyID, DateTime StartDate, DateTime EndDate)
        {
            List<DTR> dtrs = new List<DTR>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(Builder.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT dtr.id,`dtr`.`company_id`,`dtr`.`date`,`dtr`.`student_id`,SUM(`dtr`.`regular_hour`),SUM(`dtr`.`regular_day`),SUM(`dtr`.`holiday_hour`),SUM(`dtr`.`holiday_day`),SUM(`dtr`.`legal_holiday_hour`),SUM(`dtr`.`legal_holiday_day`),SUM(`dtr`.`guarantee_hour`),SUM(`dtr`.`guarantee_day`),SUM(`dtr`.`extended_time`),SUM(`dtr`.`night_premium_hour`),SUM(`dtr`.`night_premium_day`),SUM(`dtr`.`transportation_allowance`),SUM(`dtr`.`saturday_hour`),SUM(`dtr`.`saturday_day`) FROM dtr WHERE company_id = @company_id AND date >= DATE(@startdate) AND date <= DATE(@enddate) GROUP BY student_id";
                    cmd.Parameters.AddWithValue("company_id", CompanyID);
                    cmd.Parameters.AddWithValue("startdate", StartDate);
                    cmd.Parameters.AddWithValue("enddate", EndDate);
                    con.Open();
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DTR dtr = new DTR();
                            dtr.ID = rdr.GetInt32(0);
                            dtr.CompanyID = rdr.GetInt32(1);
                            dtr.Date = rdr.GetDateTime(2);
                            dtr.StudentID = rdr.GetInt32(3);
                            dtr.RegularHour = rdr.GetDecimal(4);
                            dtr.RegularDay = rdr.GetDecimal(5);
                            dtr.HolidayHour = rdr.GetDecimal(6);
                            dtr.HolidayDay = rdr.GetDecimal(7);
                            dtr.LegalHolidayHour = rdr.GetDecimal(8);
                            dtr.LegalHolidayDay = rdr.GetDecimal(9);
                            dtr.GuaranteeHour = rdr.GetDecimal(10);
                            dtr.GuaranteeDay = rdr.GetDecimal(11);
                            dtr.ExtendedTime = rdr.GetDecimal(12);
                            dtr.NightPremiumHour = rdr.GetDecimal(13);
                            dtr.NightPremiumDay = rdr.GetDecimal(14);
                            dtr.TransportationAllowance = rdr.GetDecimal(15);
                            dtr.SaturdayHour = rdr.GetDecimal(16);
                            dtr.SaturdayDay = rdr.GetDecimal(17);
                            dtrs.Add(dtr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorTrapper.Log(ex, LogOptions.PromptTheUser);
            }
            return dtrs;
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
                        cmd.CommandText = "UPDATE dtr SET regular_hour=@regular_hour,regular_day=@regular_day,holiday_hour=@holiday_hour,holiday_day=@holiday_day,legal_holiday_hour=@legal_holiday_hour,legal_holiday_day=@legal_holiday_day,guarantee_hour=@guarantee_hour,guarantee_day=@guarantee_day,extended_time=@extended_time,night_premium_hour=@night_premium_hour,night_premium_day=@night_premium_day,transportation_allowance=@transportation_allowance, saturday_hour = @saturday_hour, saturday_day=@saturday_day WHERE company_id = @company_id AND student_id=@student_id AND date = @date";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO dtr (company_id,student_id,date,regular_hour,regular_day,holiday_hour,holiday_day,legal_holiday_hour,legal_holiday_day,guarantee_hour,guarantee_day,extended_time,night_premium_hour,night_premium_day,transportation_allowance,saturday_hour, saturday_day) VALUES (@company_id,@student_id,@date,@regular_hour,@regular_day,@holiday_hour,@holiday_day,@legal_holiday_hour,@legal_holiday_day,@guarantee_hour,@guarantee_day,@extended_time,@night_premium_hour,@night_premium_day,@transportation_allowance, @saturday_hour, @saturday_day)";
                    }
                    cmd.Parameters.AddWithValue("company_id", CompanyID);
                    cmd.Parameters.AddWithValue("student_id", StudentID);
                    cmd.Parameters.AddWithValue("date", Date);
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

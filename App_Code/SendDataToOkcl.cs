using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using DAL;
using System.Xml;
using System.IO;

/// <summary>
/// Summary description for SendDataToOkcl
/// </summary>
/// 

public class SendDataToOkcl
{
    public SendDataToOkcl()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection("server=evidyalaya.net.in;Initial Catalog=DBeVidyalaya;Persist Security Info=True;User ID=come2myct;Password=myct2013");
    CommonCode cc = new CommonCode();

    public string returnCurDate()
    {
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        string dt = indianTime.ToString("yyyy-MM-dd");
        return dt;
    }

    public int InsertDataToOkclTable(string mobileNumber, string code)
    {
        try
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            int dateValue = indianTime.Day;//System.DateTime.Now.Day;
            string codeValue = code.Substring(2, 2);
            string returnVal = string.Empty;

            CommonData commonData = new CommonData();
            string sqlQuery1 = "SELECT * FROM [OKCLDB].[dbo].[Users] WHERE [UserName] = '" + mobileNumber + "' AND [Status] = '1'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery1;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OkclConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string sqlQuery2 = "SELECT [UserName] FROM [OKCLDB].[dbo].[Users] WHERE [Id] = '" + ds.Tables[0].Rows[0]["SeniorId"].ToString() + "'";
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = sqlQuery2;
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OkclConnectionString"].ConnectionString);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (code.Length > 6)
                    {
                        code = code.Trim();
                    }

                    if (code.Length == 6)
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = "uspInsertDataToOkcl";
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OkclConnectionString"].ConnectionString);

                        sqlCommand.Parameters.Add("@userName", SqlDbType.NVarChar, 15).Value = mobileNumber;
                        sqlCommand.Parameters.Add("@code", SqlDbType.NVarChar, 10).Value = code;
                        sqlCommand.Parameters.Add("@returnVal", SqlDbType.Int).Direction = ParameterDirection.Output;

                        SqlParameter returnValue = sqlCommand.CreateParameter();
                        returnValue.SqlDbType = SqlDbType.Int;
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        sqlCommand.Parameters.Add(returnValue);

                        sqlCommand.Connection.Open();
                        sqlCommand.ExecuteNonQuery();
                        returnVal = sqlCommand.Parameters["@returnVal"].Value.ToString();
                        returnVal = Convert.ToString(returnValue.Value);
                        sqlCommand.Connection.Close();

                        if (dateValue.ToString() == codeValue)
                        {
                            if (returnVal == "1")
                            {
                                string messSC = "Dear School Coordinator, You have successfully registered your attendance today";
                                commonData.SendSMS(mobileNumber, messSC);

                                string HMNo = ds2.Tables[0].Rows[0]["UserName"].ToString();
                                string messgHM = "Dear Sir/Madam,The School Coordinator deployed at school is Present";
                                commonData.SendSMS(HMNo, messgHM);
                            }
                        }
                    }
                }
            }
            else
            {
                string messSC = "Dear School Coordinator, your attendance not register. Please Send Attendance SMS through valid register mobileNo";
                commonData.SendSMS(mobileNumber, messSC);
            }
            return 1;
        }
        catch
        {
            return 0;
        }
    }


    #region METHOD TO INSERT EVIDYALAYA LOGIN TABLE
    public int InsertDataToEvidyalaya(string UserMobileNo, string RefmobileNo, string password, string strDevId, string strSimSerialNo, string firstName, string lastName, string address, string eMailId, int Role_Id, string pincode, string latitude, string longitude, int state, int district, int Taluka, string getUserID)
    {
        try
        {
            cmd.CommandText = "uspInsertRegDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@mobileNumber", UserMobileNo);
            cmd.Parameters.AddWithValue("@emailId", eMailId);
            cmd.Parameters.AddWithValue("@usrPassword", cc.DESDecrypt(password.Trim()));
            cmd.Parameters.AddWithValue("@roleId", Role_Id);
            cmd.Parameters.AddWithValue("@refMobileNumber", RefmobileNo);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@stateId", state);
            cmd.Parameters.AddWithValue("@districtId", district);
            cmd.Parameters.AddWithValue("@talukaId", Taluka);
            cmd.Parameters.AddWithValue("@imeiNumber", strDevId);
            cmd.Parameters.AddWithValue("@simSerialNumber", strSimSerialNo);
            cmd.Parameters.AddWithValue("@longitude", longitude);
            cmd.Parameters.AddWithValue("@lattitude", latitude);
            cmd.Parameters.AddWithValue("@myctUserId", getUserID);
            cmd.Parameters.AddWithValue("@insertBy", UserMobileNo);
            if (cmd.Connection.State == ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    #endregion


}
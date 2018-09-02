using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SendRegDataToEzeeOrder
/// </summary>
/// 

public class SendRegDataToEzeeOrder
{
	public SendRegDataToEzeeOrder()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ezeeOrderConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    public int Registration(string userid, string pwd, string firmName, string firmType, string fname, string lname, string mobNo, string refMobNo, string emailId, string address, string landlineNo, string pincode, string state, string district, string taluka, string area, string passcode, string longitude, string latitude, string imei, string simserial, string typeofUser)
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspRegToEzeeOrderApp";

            cmd.Parameters.AddWithValue("@userId", userid);
            cmd.Parameters.AddWithValue("@usrpassword", pwd);
            cmd.Parameters.AddWithValue("@firmName", firmName);
            cmd.Parameters.AddWithValue("@firmType", firmType);
            cmd.Parameters.AddWithValue("@firstName", fname);
            cmd.Parameters.AddWithValue("@lastName", lname);
            cmd.Parameters.AddWithValue("@mobileNumber", mobNo);
            cmd.Parameters.AddWithValue("@refMobileNo", refMobNo);
            cmd.Parameters.AddWithValue("@emailId", emailId);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@landline", landlineNo);
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@stateId", state);
            cmd.Parameters.AddWithValue("@districtId", district);
            cmd.Parameters.AddWithValue("@talukaId", taluka);
            cmd.Parameters.AddWithValue("@area", area);
            cmd.Parameters.AddWithValue("@passcode", passcode);
            cmd.Parameters.AddWithValue("@longitude", longitude);
            cmd.Parameters.AddWithValue("@latitude", latitude);
            cmd.Parameters.AddWithValue("@imeiNo", imei);
            cmd.Parameters.AddWithValue("@simSerial", simserial);
            cmd.Parameters.AddWithValue("@typeOfUser", typeofUser);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return 1;
        }
        catch(Exception ex)
        {
            return 0;
        }
    }
}
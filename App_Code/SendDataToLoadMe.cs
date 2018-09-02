using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SendDataToLoadMe
/// </summary>
/// 

public class SendDataToLoadMe
{
	public SendDataToLoadMe()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection con = new SqlConnection("server=103.16.143.251; Initial Catalog=DBeZeeTransport; User ID=onlineexamDB; Password=onlineDB@098; pooling='true'; Min Pool Size=0; Max Pool Size=200;");  //onlineexam#%2015
    SqlCommand cmd = new SqlCommand();
    CommonCode cc = new CommonCode();

    public void InsertRegDetails(string firstName, string lastName, string mobileNumber, string emailId, string password, int roleId, string refMobileNumber, string myctUserId, string pincode, int stateId, int districtId, int talukaId, string villageName, string imeiNumber, string simSerialNumber, string longitude, string latitude)
    {
        try
        {
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uspInsertRegFromApp";

            cmd.Parameters.AddWithValue("@firstName", firstName.Trim());
            cmd.Parameters.AddWithValue("@lastName", lastName.Trim());
            cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber.Trim());
            cmd.Parameters.AddWithValue("@emailId", emailId.Trim());
            cmd.Parameters.AddWithValue("@password", cc.DESDecrypt(password.Trim()));
            cmd.Parameters.AddWithValue("@roleId", roleId);
            cmd.Parameters.AddWithValue("@refMobNumber", refMobileNumber.Trim());
            cmd.Parameters.AddWithValue("@myctUserId", myctUserId.Trim());
            cmd.Parameters.AddWithValue("@pincode", pincode);
            cmd.Parameters.AddWithValue("@stateId", stateId);
            cmd.Parameters.AddWithValue("@districtId", districtId);
            cmd.Parameters.AddWithValue("@talukaId", talukaId);
            cmd.Parameters.AddWithValue("@villageName", villageName);
            cmd.Parameters.AddWithValue("@imeiNumber", imeiNumber.Trim());
            cmd.Parameters.AddWithValue("@simSerialNumber", simSerialNumber.Trim());
            cmd.Parameters.AddWithValue("@longitude", longitude);
            cmd.Parameters.AddWithValue("@latitude", latitude);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        catch (Exception ex)
        {
 
        }
    }


}
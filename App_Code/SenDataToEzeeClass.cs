using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SenDataToEzeeClass
/// </summary>
public class SenDataToEzeeClass
{
	public SenDataToEzeeClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //SqlConnection con = new SqlConnection("server=truevoters.in; Initial Catalog=DBeZeeOnlineExam; User ID=truevoter; Password=myabhinavit@123; pooling='true'; Min Pool Size=0; Max Pool Size=200;");  //onlineexam#%2015
SqlConnection con = new SqlConnection("server=truevoters.in; Initial Catalog=DBeZeeOnlineExam; User ID=sa; Password=K17jyjo8/T+6z2v; pooling='true'; Min Pool Size=0; Max Pool Size=200;");  //onlineexam#%2015

    public void InsertClassAppDetailsToeZeeTest(string firstName, string lastName, string firmName, string mobileNo, string Password, string address, string emailID, string userType, string instituteHeadMoblieNo, string strDevID)
    {
        try
        {

            if (mobileNo != "9422324927" && instituteHeadMoblieNo != "9422324927" && mobileNo != "9999999999" && instituteHeadMoblieNo != "9999999999" && mobileNo != "9292929292" && instituteHeadMoblieNo != "9292929292" && mobileNo != "9393939393" && instituteHeadMoblieNo != "9393939393")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspInsertClassAppRegistration";
                cmd.Connection = con;

                SqlParameter[] parameter = new SqlParameter[] 
        {
            new SqlParameter("@firstName",firstName),
            new SqlParameter("@lastName",lastName),
            new SqlParameter("@firmName",firmName),
            new SqlParameter("@mobileNo",mobileNo),
            new SqlParameter("@usrPassword",Password),
            new SqlParameter("@usraddress",address),
            new SqlParameter("@emailID",emailID),
            new SqlParameter("@userType",userType),
            new SqlParameter("@instituteHeadMoblieNo",instituteHeadMoblieNo),
            new SqlParameter("@strDevID",strDevID)
                      
        };
                cmd.Parameters.AddRange(parameter);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        catch
        {

        }
        finally
        {

        }

    }
}
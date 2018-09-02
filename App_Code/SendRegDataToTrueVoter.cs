using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;


/// <summary>
/// Summary description for SendRegDataToTrueVoter
/// </summary>
/// 

public class SendRegDataToTrueVoter
{
    public SendRegDataToTrueVoter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TrueVoterConnectionString"].ConnectionString);
    private SqlCommand sqlCommand = null;
    private SqlDataAdapter sqlDataAdapter = null;
    private DataSet data = null;
    private int Error = CommonCode.OK1;
    public int isError { get { return this.Error; } }
    public DataSet userData { get { return this.data; } }
    private string registerNewUserQuery = "[TrueVoterDB].[dbo].[uspRegisterUser]";

    public string newRegistration(string name, string mobileNo, string userName, string password, String otp, string MName, string LName, string latitute, string langitute, string email, string userType, string imeiNumber, string refMobileNo)
    {
        try
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = registerNewUserQuery;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = name;
            sqlCommand.Parameters.Add("@mobileNo", SqlDbType.NVarChar, 12).Value = mobileNo;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 10).Value = userName;
            sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
            sqlCommand.Parameters.Add("@mName", SqlDbType.NVarChar, 20).Value = MName;
            sqlCommand.Parameters.Add("@lName", SqlDbType.NVarChar, 20).Value = LName;
            sqlCommand.Parameters.Add("@otp", SqlDbType.NVarChar, 8).Value = otp;
            sqlCommand.Parameters.Add("@lat", SqlDbType.NVarChar, 8).Value = latitute;
            sqlCommand.Parameters.Add("@lag", SqlDbType.NVarChar, 8).Value = langitute;
            
            sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
            sqlCommand.Parameters.Add("@usrType", SqlDbType.NVarChar, 50).Value = userType;
            sqlCommand.Parameters.Add("@imei", SqlDbType.NVarChar, 50).Value = imeiNumber;
            sqlCommand.Parameters.Add("@refMobileNo", SqlDbType.NVarChar, 50).Value = refMobileNo;
            sqlCommand.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            
            SqlParameter returnValue = sqlCommand.CreateParameter();
            returnValue.SqlDbType = SqlDbType.Int;
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlCommand.Parameters.Add(returnValue);

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();

            sqlCommand.ExecuteNonQuery();

            if (Convert.ToString(returnValue.Value) == "1")
            { return CommonCode.OK1.ToString() + "*" + sqlCommand.Parameters["@rid"].Value.ToString(); }
            else if (Convert.ToString(returnValue.Value) == "2")
                return CommonCode.USER_NAME_ALREADY_USED.ToString();
            else
                return returnValue.Value.ToString();
        }
        catch (SqlException sqlException)
        {
            return CommonCode.SQL_ERROR.ToString();
        }
        catch (Exception excepiton)
        {
            return CommonCode.ERROR.ToString();
        }
        finally { sqlCommand.Connection.Close(); sqlCommand.Dispose(); }
    }
}
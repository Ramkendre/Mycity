using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for SendRegDataToEzeeSchool
/// </summary>
public class SendRegDataToEzeeSchool
{
    public SendRegDataToEzeeSchool()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SchoolAppRegistrationDetails(string ImeiNo, string SimNo, string Name, string FirmName, string MobileNo, string userid, string roleid)
    {
        string schoolcode = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            string s1 = "SELECT [Schoolcode] FROM [udise_teachermaster] WHERE [junior_id]='" + Convert.ToString(userid) + "'";
            schoolcode = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.Text, s1));
        }
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ezeeSchoolConnectionString"].ConnectionString))
        {
            conn.Open();
            SqlParameter[] par = new SqlParameter[9];
            par[0] = new SqlParameter("@MobileNo", MobileNo);
            par[1] = new SqlParameter("@ImeiNo", ImeiNo);
            par[2] = new SqlParameter("@SimNo", SimNo);
            par[3] = new SqlParameter("@Name", Name);
            par[4] = new SqlParameter("@FirmName", FirmName);
            par[5] = new SqlParameter("@UserId", userid);
            par[6] = new SqlParameter("@Schoolcode", schoolcode);
            par[7] = new SqlParameter("@roleid1", roleid);
            par[8] = new SqlParameter("@output", 1);
            par[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(conn, CommandType.StoredProcedure, "SchoolAppRegister", par);
        }
    }
}
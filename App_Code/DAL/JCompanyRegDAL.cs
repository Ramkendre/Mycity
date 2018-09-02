using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for JCompanyRegDAL
/// </summary>
public class JCompanyRegDAL
{
    CommonCode cc = new CommonCode();
	public JCompanyRegDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int AddRecord(JCompanyRegBLL JCRB)
    {
        //SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
        //cmd.Connection = con;
        SqlParameter[] par = new SqlParameter[]
        {
            new SqlParameter("@NameOfComp",JCRB.NameOfComp1),new SqlParameter("@TypeOfUnit",JCRB.TypeOfUnit1),
            new SqlParameter("@DirectName",JCRB.DirectName1),new SqlParameter("@MobileNo",JCRB.MobileNo1),
            new SqlParameter("@EmailId",JCRB.EmailId1),new SqlParameter("@FAddress",JCRB.FAddress1),
            new SqlParameter("@State",JCRB.State1),new SqlParameter("@District",JCRB.District1),
            new SqlParameter("@Taluka",JCRB.Taluka1),new SqlParameter("@City",JCRB.City1),
            new SqlParameter("@Sectors",JCRB.Sectors1),new SqlParameter("@UserId",JCRB.UserId1),
            new SqlParameter("@EntryDate",JCRB.EntryDate1)
        };
         SqlCommand cmd = new SqlCommand("uspJCompReg", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

       
    }
}

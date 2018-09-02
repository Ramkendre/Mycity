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
/// Summary description for JDemandJobDAL
/// </summary>
public class JDemandJobDAL
{
	public JDemandJobDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int AddRecord(JDemandJobBLL JCRB)
    {
        //SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
        //cmd.Connection = con;
        SqlParameter[] par = new SqlParameter[]
        {
             new SqlParameter("@Sector",JCRB.Sector1),
            new SqlParameter("@JRole",JCRB.JRole1),new SqlParameter("@Experience",JCRB.Experience1),
            new SqlParameter("@Salary",JCRB.Salary1),new SqlParameter("@State",JCRB.State1),
            new SqlParameter("@District",JCRB.District1),
            new SqlParameter("@Taluka",JCRB.Taluka1),new SqlParameter("@Date",JCRB.Date1),
            new SqlParameter("@IntrestedFor",JCRB.IntrestedFor1),new SqlParameter("@EntryDate",JCRB.EntryDate1),
            new SqlParameter("@UserId",JCRB.UserId1)
        };
        SqlCommand cmd = new SqlCommand("uspInsertJDemandJobMyct", con);
        cmd.Parameters.AddRange(par);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        con.Open();
        int result = cmd.ExecuteNonQuery();
        return result;


    }
    
}

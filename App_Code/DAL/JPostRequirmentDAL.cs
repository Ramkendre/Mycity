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
/// Summary description for JPostRequirmentDAL
/// </summary>
public class JPostRequirmentDAL
{
	public JPostRequirmentDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public int AddRecord(JPostRequirmentBLL JCRB)
    {
        //SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
        //cmd.Connection = con;
        SqlParameter[] par = new SqlParameter[]
        {
             new SqlParameter("@CName",JCRB.CName1),
            new SqlParameter("@InSector",JCRB.InSector1),new SqlParameter("@JRole",JCRB.JRole1),
            new SqlParameter("@Qualification",JCRB.Qualification1),new SqlParameter("@Skill",JCRB.Skill1),
            new SqlParameter("@JRequirment",JCRB.JRequirment1),new SqlParameter("@VaccancyTill",JCRB.VaccancyTill1),
            new SqlParameter("@SalaryOffered",JCRB.SalaryOffered1),new SqlParameter("@FreExp",JCRB.FreExp1),
            new SqlParameter("@TrainingOffered",JCRB.TrainingOffered1),new SqlParameter("@EntryDate",JCRB.EntryDate1),
            new SqlParameter("@UserId",JCRB.UserId1)
        };
            SqlCommand cmd = new SqlCommand("uspInsertJPostReqMyct", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

       
    }
    
}

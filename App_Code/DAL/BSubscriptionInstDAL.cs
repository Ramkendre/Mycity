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
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for BSubscriptionInstDAL
/// </summary>
public class BSubscriptionInstDAL
{
	public BSubscriptionInstDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet LoadGrid(BSubscriptionInstBLL BSIB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", BSIB.UserId1);
            SqlCommand cmd = new SqlCommand("uspBLoadSubInstalment", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int AddRecord(BSubscriptionInstBLL BSIB)
    { 
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@MID",BSIB.MID1),
                 new SqlParameter("@SubAmt",BSIB.SubAmt1), new SqlParameter("@LInstalment",BSIB.LInstalment1),
                  new SqlParameter("@LIMonth",BSIB.LIMonth1), new SqlParameter("@Date",BSIB.Date1),
                   new SqlParameter("@UserId",BSIB.UserId1),new SqlParameter("@EnteryDate",BSIB.EnteryDate1),
            };
            SqlCommand cmd = new SqlCommand("uspSubInstInsertMyct", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    public int UpdateRecord(BSubscriptionInstBLL BSIB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BSIB.ID1),
                new SqlParameter("@MID",BSIB.MID1),
                 new SqlParameter("@SubAmt",BSIB.SubAmt1), new SqlParameter("@LInstalment",BSIB.LInstalment1),
                  new SqlParameter("@LIMonth",BSIB.LIMonth1), new SqlParameter("@Date",BSIB.Date1),
                   new SqlParameter("@UserId",BSIB.UserId1),new SqlParameter("@EnteryDate",BSIB.EnteryDate1),
            };
            SqlCommand cmd = new SqlCommand("uspUBSubInstalment", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            con.Open();
            int re = cmd.ExecuteNonQuery();
            return re;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
    public void SelectRecord(BSubscriptionInstBLL BSIB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlDataReader dr;
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BSIB.ID1),
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspSubInstSelectMyct",par);
            if (dr.HasRows)
            {
                dr.Read();
                BSIB.LIMonth1 = Convert.ToString(dr["LIMonth"]);
                BSIB.LInstalment1 = Convert.ToString(dr["LInstalment"]);
                BSIB.SubAmt1 = Convert.ToString(dr["SubAmt"]);
                BSIB.MID1 = Convert.ToString(dr["MID"]);

            }
        }
        catch(Exception ex)
        {
        
        }
    }
}

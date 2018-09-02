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
/// Summary description for BMemRegDAL
/// </summary>
public class BMemRegDAL
{
	public BMemRegDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet LoadGrid(BMemRegBLL MRBLL)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", MRBLL.UserId1);

            SqlCommand cmd = new SqlCommand("uspBLoadMemRegistration", conn);
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
    //public DataSet LoadGrid(BMemRegBLL MRBLL)
    //{
    //    try
    //    {
    //        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //        DataSet ds = new DataSet();
    //        SqlParameter[] par = new SqlParameter[1];
    //        par[0] = new SqlParameter("@UserId", MRBLL.UserId1);
    //        SqlCommand cmd = new SqlCommand("uspBLoadMemRegistration", con);
    //        cmd.Parameters.AddRange(par);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        da.Fill(ds);

    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {

    //    }
        
    //}
    public int AddRecord(BMemRegBLL MRBLL)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        string str=DateTime.Now.Date.ToString("yyyy-MM-dd");
        try
        {
            SqlParameter[] par = new SqlParameter[]
        {
            new SqlParameter("@GID",MRBLL.GID1),
        new SqlParameter("@FName",MRBLL.FName1),
        new SqlParameter("@LName",MRBLL.LName1),
        new SqlParameter("@MobileNo",MRBLL.MobileNo1),
        new SqlParameter("@Post",MRBLL.Post1),
        new SqlParameter("@DOJ",MRBLL.DOJ1),
        new SqlParameter("@Subscription",MRBLL.Subscription1),
        new SqlParameter("@Deposite",MRBLL.Deposite1),
        new SqlParameter("@Loan",MRBLL.Loan1),
        new SqlParameter("@UserId",MRBLL.UserId1),
        new SqlParameter("@EntryDate",str)
        };
            SqlCommand cmd = new SqlCommand("uspBMRegiInsertMyct", con);
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
        finally
        {
            con.Close();
        }
    }
    public int UpdateRecord(BMemRegBLL MRBLL)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
            new SqlParameter("@MID",MRBLL.MID1),
            new SqlParameter("@GID",MRBLL.GID1),
            new SqlParameter("@FName",MRBLL.FName1),
            new SqlParameter("@LName",MRBLL.LName1),
            new SqlParameter("@MobileNo",MRBLL.MobileNo1),
            new SqlParameter("@Post",MRBLL.Post1),
            new SqlParameter("@DOJ",MRBLL.DOJ1),
            new SqlParameter("@Subscription",MRBLL.Subscription1),
            new SqlParameter("@Deposite",MRBLL.Deposite1),
            new SqlParameter("@Loan",MRBLL.Loan1),
            new SqlParameter("@UserId",MRBLL.UserId1),
            new SqlParameter("@EntryDate",str),
            };
            SqlCommand cmd = new SqlCommand("uspUBMReg", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public void SelectRecord(BMemRegBLL MRBLL)
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@MID",MRBLL.MID1),
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspSelectMReg", par);
            if(dr.HasRows)
            {
                dr.Read();
                MRBLL.GID1 = Convert.ToString(dr["GID"]);
                MRBLL.FName1 = Convert.ToString(dr["FName"]);
                MRBLL.LName1 = Convert.ToString(dr["LName"]);
                MRBLL.MobileNo1 = Convert.ToString(dr["MobileNo"]);
                MRBLL.Post1 = Convert.ToString(dr["Post"]);
                MRBLL.DOJ1 = Convert.ToString(dr["DOJ"]);
                MRBLL.Subscription1 = Convert.ToString(dr["Subscription"]);
                MRBLL.Deposite1 = Convert.ToString(dr["Deposite"]);
                MRBLL.Loan1 = Convert.ToString(dr["Loan"]);

            }
        }
        catch(Exception ex)
        {
        
        }
        finally
        {
            con.Close();
        }
    }
}

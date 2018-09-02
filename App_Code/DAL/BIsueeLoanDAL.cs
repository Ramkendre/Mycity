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
/// Summary description for BIsueeLoanDAL
/// </summary>
public class BIsueeLoanDAL
{
	public BIsueeLoanDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet LoadGrid(BIsueeLoanBLL BILB)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", BILB.UserId1);

            SqlCommand cmd = new SqlCommand("uspBLoadIssueLoan", conn);
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

    public int AddRecord(BIsueeLoanBLL BILB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
        {
        new SqlParameter("@MID",BILB.MID1),
       
        new SqlParameter("@LoanAmt",BILB.LoanAmt1),
        new SqlParameter("@DateOfIssue",BILB.DateOfIssue1),
        new SqlParameter("@MInstalment",BILB.MInstalment1), new SqlParameter("@DueDate",BILB.DueDate1),
        new SqlParameter("@UserId",BILB.UserId1),
        };
            SqlCommand cmd = new SqlCommand("uspBIssueLoanInsertMyct", con);
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

    public int UpdateRecord(BIsueeLoanBLL BILB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
       
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
        {
         new SqlParameter("@ID",BILB.ID1) ,  
        new SqlParameter("@MID",BILB.MID1),
        new SqlParameter("@LoanAmt",BILB.LoanAmt1),
        new SqlParameter("@DateOfIssue",BILB.DateOfIssue1),
        new SqlParameter("@MInstalment",BILB.MInstalment1), new SqlParameter("@DueDate",BILB.DueDate1),
        new SqlParameter("@UserId",BILB.UserId1),
        new SqlParameter("@EntryDate",BILB.EntryDate1),
        };
            SqlCommand cmd = new SqlCommand("uspUBIsueeLoan", con);
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
    public void Select(BIsueeLoanBLL BILB)
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BILB.ID1)
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspBSelectIssueLoan", par);
            if (dr.HasRows)
            {
                dr.Read();
                BILB.MID1 = Convert.ToString(dr["MID"]);
                BILB.MInstalment1 = Convert.ToString(dr["MInstalment"]);
                BILB.LoanAmt1 = Convert.ToString(dr["LoanAmt"]);
                BILB.DateOfIssue1 = Convert.ToString(dr["DateOfIssue"]);
                BILB.DueDate1 = Convert.ToString(dr["DueDate"]);
            }
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
    }



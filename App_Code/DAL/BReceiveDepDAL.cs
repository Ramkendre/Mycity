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
/// Summary description for BReceiveDepDAL
/// </summary>
public class BReceiveDepDAL
{
	public BReceiveDepDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet LoadGrid(BReceiveDepBLL BRDB)
    { 
         SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId",BRDB.UserId1);
            SqlCommand cmd = new SqlCommand("uspBLoadReceiveDeposite", con);
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
    public int AddRecord(BReceiveDepBLL BRDB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
              new SqlParameter("@MID",BRDB.MID1),  
              
              new SqlParameter("@DepositeAmt",BRDB.DepositeAmt1), 
              new SqlParameter("@PaymentType",BRDB.PaymentType1), new SqlParameter("@Date",BRDB.Date1), 
              new SqlParameter("@DepositPeriod",BRDB.DepositPeriod1),
              new SqlParameter("@UserId",BRDB.UserId1),
              new SqlParameter("@EntryDate",BRDB.EntryDate1)
            };
            SqlCommand cmd = new SqlCommand("uspBReceiveDepositeInsertMyct", con);
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
    public int UpdateRecord(BReceiveDepBLL BRDB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BRDB.ID1),
           new SqlParameter("@MID",BRDB.MID1),  
              
              new SqlParameter("@DepositeAmt",BRDB.DepositeAmt1), 
              new SqlParameter("@PaymentType",BRDB.PaymentType1), new SqlParameter("@Date",BRDB.Date1), 
              new SqlParameter("@DepositPeriod",BRDB.DepositPeriod1),
              
              new SqlParameter("@EntryDate",BRDB.EntryDate1)
            };
            SqlCommand cmd = new SqlCommand("uspUpdateBReceiveDep", con);
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
    public void SelectRecord(BReceiveDepBLL BRDB)
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BRDB.ID1),
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspBSelectReceiveDep", par);
            if (dr.HasRows)
            {
                dr.Read();
                //BRDB.ID1 = Convert.ToString(dr["ID"]);
                BRDB.MID1 = Convert.ToString(dr["MID"]);
                BRDB.DepositeAmt1 = Convert.ToString(dr["DepositeAmt"]);
                BRDB.PaymentType1 = Convert.ToString(dr["PaymentType"]);
                BRDB.DepositPeriod1 = Convert.ToString(dr["DepositPeriod"]);
                BRDB.Date1 = Convert.ToString(dr["Date"]);
               

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
}

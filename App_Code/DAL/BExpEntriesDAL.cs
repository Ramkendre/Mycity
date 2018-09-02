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
/// Summary description for BExpEntriesDAL
/// </summary>
public class BExpEntriesDAL
{
	public BExpEntriesDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet LoadGrid(BExpEntriesBLL BEEB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0]=new SqlParameter("@UserId",BEEB.UserId1);
            SqlCommand cmd = new SqlCommand("uspBLoadExpenditureE", con);
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

    public int AddRecord(BExpEntriesBLL BEEB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
              new SqlParameter("@Date",BEEB.Date1),  
              new SqlParameter("@VoucharNo",BEEB.VoucharNo1),
              new SqlParameter("@TypeOfExp",BEEB.TypeOfExp1), 
              new SqlParameter("@Amount",BEEB.Amount1), new SqlParameter("@Description",BEEB.Description1), 
              new SqlParameter("@Mode",BEEB.Mode1), new SqlParameter("@UserId",BEEB.UserId1),
              new SqlParameter("@EntryDate",BEEB.EntryDate1)
            };
            SqlCommand cmd = new SqlCommand("uspBExpEInsertMyct", con);
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
    public int UpdateRecord(BExpEntriesBLL BEEB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BEEB.ID1),
              new SqlParameter("@Date",BEEB.Date1),  
              new SqlParameter("@VoucharNo",BEEB.VoucharNo1),
              new SqlParameter("@TypeOfExp",BEEB.TypeOfExp1), 
              new SqlParameter("@Amount",BEEB.Amount1), new SqlParameter("@Description",BEEB.Description1), 
              new SqlParameter("@Mode",BEEB.Mode1),
              new SqlParameter("@EntryDate",BEEB.EntryDate1)
            };
            SqlCommand cmd = new SqlCommand("uspUpdateBExpenditureE", con);
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
    public void SelectRecord(BExpEntriesBLL BEEB)
    { 
         SqlDataReader dr;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con.Open();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",BEEB.ID1),
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspBSelectExpenditureE", par);
            if(dr.HasRows)
            {
                dr.Read();
                BEEB.Date1 = Convert.ToString(dr["Date"]);
                BEEB.VoucharNo1 = Convert.ToString(dr["VoucharNo"]);
                BEEB.TypeOfExp1 = Convert.ToString(dr["TypeOfExp"]);
                BEEB.Amount1 = Convert.ToString(dr["Amount"]);
                BEEB.Description1 = Convert.ToString(dr["Description"]);
                BEEB.Mode1 = Convert.ToString(dr["Mode"]);
              

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

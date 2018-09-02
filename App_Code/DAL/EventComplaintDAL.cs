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
/// Summary description for EventComplaintDAL
/// </summary>
public class EventComplaintDAL
{
	public EventComplaintDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    CommonCode cc = new CommonCode();
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    public DataSet LoadGrid(EventComplaintBLL SPCB)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", SPCB.UserId1);
            //par[1] = new SqlParameter("@UsrMobileNo", SPCB.UsrMobileNo1);
            //string str = "SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address] as a,[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='"++"' and keyword='EZEEPLANNER'";

            SqlCommand cmd = new SqlCommand("EventCompLoadgrid", con);
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
    public DataSet LoadGrid1(EventComplaintBLL SPCB)
    {
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            SqlParameter[] par = new SqlParameter[1];
           
            par[0] = new SqlParameter("@UsrMobileNo", SPCB.UsrMobileNo1);
            //string str = "SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address] as a,[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='"++"' and keyword='EZEEPLANNER'";

            SqlCommand cmd = new SqlCommand("EventCompLoadgridForAll", con);
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
    public int AddRecord(EventComplaintBLL SPCB)
    {
        int row;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            SqlParameter[] par = new SqlParameter[]
           {
                new SqlParameter("@CompType",SPCB.CompType1),
                new SqlParameter("@Date",SPCB.Date1),
                new SqlParameter("@CompDetails",SPCB.CompDetails1),
                new SqlParameter("@CompName",SPCB.CompName1),
                new SqlParameter("@CompSub",SPCB.CompSub1),
                new SqlParameter("@CompFDept",SPCB.CompFDept1),
                new SqlParameter("@MobileNo",SPCB.MobileNo1),
                new SqlParameter("@Address",SPCB.Address1),
                new SqlParameter("@CurrentDate",str),
                new SqlParameter("@UserId",SPCB.UserId1),
           };
            SqlCommand cmd = new SqlCommand("EventComplaintInsert", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            row = cmd.ExecuteNonQuery();
            return row;
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
    public void SelectRecord(EventComplaintBLL SPCB)
    {
        conn.Open();
        SqlDataReader dr;
        try
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@CID",SPCB.CID1),
                };
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EventCompSelect", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    SPCB.CompName1 = Convert.ToString(dr["CompName"]);
                    SPCB.CompType1 = Convert.ToString(dr["CompType"]);
                    SPCB.CompSub1 = Convert.ToString(dr["CompSub"]);
                    SPCB.CompFDept1 = Convert.ToString(dr["CompFDept"]);
                    SPCB.CompDetails1 = Convert.ToString(dr["CompDetails"]);
                    SPCB.Date1 = Convert.ToString(dr["Date"]);
                    SPCB.MobileNo1 = Convert.ToString(dr["MobileNo"]);
                    SPCB.Address1 = Convert.ToString(dr["Address"]);


                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
    public int UpdateRecord(EventComplaintBLL SPCB)
    {
        int row;
       try{
           string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@CID",SPCB.CID1),
               new SqlParameter("@CompType",SPCB.CompType1),
                new SqlParameter("@Date",SPCB.Date1),
                new SqlParameter("@CompDetails",SPCB.CompDetails1),
                new SqlParameter("@CompName",SPCB.CompName1),
                new SqlParameter("@CompSub",SPCB.CompSub1),
                new SqlParameter("@CompFDept",SPCB.CompFDept1),
                new SqlParameter("@MobileNo",SPCB.MobileNo1),
                new SqlParameter("@Address",SPCB.Address1),
                new SqlParameter("@CurrentDate",str),
                new SqlParameter("@UserId",SPCB.UserId1),
                 //new SqlParameter("@Status1",EBLL.Status3),
                 //new SqlParameter("@Status2",EBLL.Status4),
                 
                };
                // par[13] = new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1);
                //par[13] = new SqlParameter("@SendMgs", EBLL.SendMgs1);

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UECompMyCt", par);
            }
            return row;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
}

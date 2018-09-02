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
/// Summary description for EventDeathDAL
/// </summary>
public class EventDeathDAL
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
	public EventDeathDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    CommonCode cc = new CommonCode();
    public DataSet loadgrid(EventDeathBLL SPBL)
    {
     
        DataSet ds = new DataSet();
        try
        {
            conn.Open();
           using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@UserId", SPBL.UserId1);
                par[1] = new SqlParameter("@Status", 1);
                par[1].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "EventLoadGridDeath", par);

            }
            //SqlCommand cmd = new SqlCommand("EventLoadGridDeath", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlParameter[] par = new SqlParameter[10];
            //par[0] = new SqlParameter("@UserId", SPBL.UserId1);
            //par[1] = new SqlParameter("@Status", 1);
            //par[1].Direction = ParameterDirection.Output;
            ////cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
            ////cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            return ds;
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
    public int AddRecord(EventDeathBLL SPBL)
    {
        int row;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@NameOfAccused", SPBL.NameOfAccused1),
                    new SqlParameter("@Date", SPBL.Date1),
                    new SqlParameter("@Time", SPBL.Time1),
                    new SqlParameter("@Location", SPBL.Location1),
                    new SqlParameter("@SDescp", SPBL.SDescp1),
                    new SqlParameter("@Relative", SPBL.Relative1),
                    new SqlParameter("@Relation", SPBL.Relation1),
                    new SqlParameter("@PVisit", SPBL.PVisit1),
                    new SqlParameter("@MDescp", SPBL.MDescp1),
                    new SqlParameter("@UserId", SPBL.UserId1),
                    new SqlParameter("@Status1",SPBL.Status3),
                    new SqlParameter("@Status2",SPBL.Status4),
                   
                    new SqlParameter("@CurrentDate",str),
            };
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "EventDeathInsert", par);

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
    public void SelectRecord(EventDeathBLL SPBL)
    {
        SqlDataReader dr;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
              {
                  new SqlParameter("DID",SPBL.DID1),
              };
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EDeathSelect", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    SPBL.NameOfAccused1 = Convert.ToString(dr["NameOfAccused"]);
                    SPBL.Date1 = Convert.ToString(dr["Date"]);
                    SPBL.Time1 = Convert.ToString(dr["Time"]);
                    SPBL.Location1 = Convert.ToString(dr["Location"]);
                    SPBL.SDescp1 = Convert.ToString(dr["SDescp"]);
                    SPBL.Relative1 = Convert.ToString(dr["Relative"]);
                    SPBL.Relation1 = Convert.ToString(dr["Relation"]);
                    SPBL.PVisit1 = Convert.ToString(dr["PVisit"]);
                    SPBL.MDescp1 = Convert.ToString(dr["MDescp"]);
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

    public int UpdateRecord(EventDeathBLL SPBL)
    {
        int row;
        try
        {
            conn.Open();
            using(SqlConnection con=new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                  new SqlParameter("@DID",SPBL.DID1),
                   new SqlParameter("@NameOfAccused",SPBL.NameOfAccused1),
                 new SqlParameter("@Date",SPBL.Date1),
                 new SqlParameter("@Time",SPBL.Time1),
                 new SqlParameter("@Location",SPBL.Location1),
                 new SqlParameter("@SDescp",SPBL.SDescp1),
                 new SqlParameter("@Relative",SPBL.Relative1),
                 new SqlParameter("@Relation",SPBL.Relation1),
                 new SqlParameter("@PVisit",SPBL.PVisit1),new SqlParameter("@MDescp",SPBL.MDescp1),
                 new SqlParameter("@UserId",SPBL.UserId1),
                 new SqlParameter("@CurrentDate",cc.DateFormatStatus()),
 
                };
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UEDeathct", par);
                return row;
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
}

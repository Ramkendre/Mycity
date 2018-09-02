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
/// Summary description for EventMeetingDAL
/// </summary>
public class EventMeetingDAL
{

    public EventMeetingDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    CommonCode cc = new CommonCode();
    public DataSet LoadGrid(EventMeetingBLL SPMB)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", SPMB.UserId1);

            SqlCommand cmd = new SqlCommand("EventLoadGridMeeting", conn);
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
    public int AddRecord(EventMeetingBLL SPMB)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int result;
        DataSet ds = new DataSet();
        try
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            SqlParameter[] par = new SqlParameter[]
            {
             new SqlParameter("@ETitle ", SPMB.ETitle1),
             new SqlParameter("@MeetingType", SPMB.MeetingType1),
             new SqlParameter("@Location", SPMB.Location1),
             new SqlParameter("@FrmDate", SPMB.FrmDate1),
             new SqlParameter("@UptoDate", SPMB.UptoDate1),
             new SqlParameter("@FrmTime", SPMB.FrmTime1),
             new SqlParameter("@UpToTime", SPMB.UptoTime1),
             new SqlParameter("@Descp", SPMB.Descp1),
             new SqlParameter("@RemDate ", SPMB.RemDate1),
             new SqlParameter("@RemTime", SPMB.RemTime1),
             new SqlParameter("@RepRemainder", SPMB.RepRemainder1),
             new SqlParameter("@UserId", SPMB.UserId1),
             new SqlParameter("@CurrentDate",str)

            };
            SqlCommand cmd1 = new SqlCommand("EventMeetingInsert", conn);
            cmd1.Parameters.AddRange(par);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            conn.Open();
            result = cmd1.ExecuteNonQuery();
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        { conn.Close(); }
    }
    public void SelectRecord(EventMeetingBLL SPMB)
    {
        SqlDataReader dr;
        try
        {
            using(SqlConnection con=new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[] 
                { 
                    new SqlParameter("ID",SPMB.ID1),
                };
                con.Open();
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "sp_EmeetingSelect", par);
                if(dr.HasRows)
                {
                    dr.Read();
                    SPMB.ETitle1 = Convert.ToString(dr["ETitle"]);
                    SPMB.MeetingType1 = Convert.ToString(dr["MeetingType"]);
                    SPMB.Location1 = Convert.ToString(dr["Location"]);
                    SPMB.FrmDate1 = Convert.ToString(dr["FrmDate"]);
                    SPMB.UptoDate1 = Convert.ToString(dr["UptoDate"]);
                    SPMB.FrmTime1 = Convert.ToString(dr["FrmTime"]);
                    SPMB.UptoTime1 = Convert.ToString(dr["UptoTime"]);
                    SPMB.Descp1 = Convert.ToString(dr["Descp"]);
                    SPMB.RemDate1 = Convert.ToString(dr["RemDate"]);
                    SPMB.RemTime1 = Convert.ToString(dr["RemTime"]);
                    SPMB.RepRemainder1 = Convert.ToString(dr["RepRemainder"]);
                    
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int UpdateRecord(EventMeetingBLL SPMB)
    {
        int row;
        try
        {
            conn.Open();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",SPMB.ID1),
                new SqlParameter("@ETitle",SPMB.ETitle1),
                new SqlParameter("@MeetingType",SPMB.MeetingType1),
                new SqlParameter("@Location",SPMB.Location1),
                new SqlParameter("@UptoTime",SPMB.UptoTime1),
                new SqlParameter("@UptoDate",SPMB.UptoDate1),
                new SqlParameter("@FrmDate",SPMB.FrmDate1),
                new SqlParameter("@FrmTime",SPMB.FrmTime1),
                new SqlParameter("@Descp",SPMB.Descp1),
                new SqlParameter("@RemDate",SPMB.RemDate1),
                new SqlParameter("@RemTime",SPMB.RemTime1),
                new SqlParameter("@RepRemainder",SPMB.RepRemainder1),
                new SqlParameter("@UserId",SPMB.UserId1),
                new SqlParameter("@CurrentDate",cc.DateFormatStatus()),
                };
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UEMeetingCt", par);
                return row;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        { conn.Close(); }
    }

}

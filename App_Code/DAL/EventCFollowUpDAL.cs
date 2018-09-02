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
/// Summary description for EventCFollowUpDAL
/// </summary>
public class EventCFollowUpDAL
{
	public EventCFollowUpDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    CommonCode cc = new CommonCode();
    public DataSet LoadGrid(EventCFollowUpBLL objCFBLL)
    {
        try
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", objCFBLL.UserId1);
            SqlCommand cmd = new SqlCommand("EventCFollowUpLoadgrid", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int AddRecord(EventCFollowUpBLL objCFBLL)
    {
        int row;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@CID",objCFBLL.CID1),new SqlParameter("@Date",objCFBLL.Date1),
                new SqlParameter("@Remark",objCFBLL.Remark1),new SqlParameter("@Status",objCFBLL.Status1),
                new SqlParameter("@CurrentDate",cc.DateFormatStatus()),
                new SqlParameter("@UserId",objCFBLL.UserId1),
            };
            SqlCommand cmd = new SqlCommand("EventCFollowUpInsert", con);
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
}

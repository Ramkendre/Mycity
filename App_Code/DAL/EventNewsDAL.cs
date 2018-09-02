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
/// Summary description for EventNewsDAL
/// </summary>
public class EventNewsDAL
{
    public EventNewsDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    CommonCode cc = new CommonCode();
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    public DataSet LoadGrid(EventNewsBLL SPNB)
    {
        try
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", SPNB.UserId1);
            SqlCommand cmd = new SqlCommand("EventLoadGridNews", con);
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
    public int AddRecord(EventNewsBLL SPNB)
    {
        int row;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");

        try
        {
            //string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            SqlParameter[] par = new SqlParameter[]
            {
             new SqlParameter("@NewsHead ",SPNB.NewsHead1),
             new SqlParameter("@NewsDetails",SPNB.NewsDetails1),
             new SqlParameter("@NPaper",SPNB.NPaper1),
             new SqlParameter("@Role",SPNB.Role1),
             new SqlParameter("@Date",SPNB.Date1),
             new SqlParameter("@Time",SPNB.Time1),
             new SqlParameter("@TypeOfNews",SPNB.TypeOfNews1),
             new SqlParameter("@Location",SPNB.Location1),
             new SqlParameter("@Feedback",SPNB.Feedback1),
             new SqlParameter("@UserId",SPNB.UserId1),
             //new SqlParameter("@Status1",SPNB.Status3),
             //new SqlParameter("@Status2",SPNB.Status4),
            new SqlParameter("@CurrentDate",str),
             
            };
            SqlCommand cmd1 = new SqlCommand("EventNewsInsert", con);
            cmd1.Parameters.AddRange(par);
            cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            con.Open();
            row = cmd1.ExecuteNonQuery();

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
    public void SelectRecord(EventNewsBLL SPNB)
    {
        SqlDataReader dr;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@NID",SPNB.NID1)
                };

                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EventSelectNews", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    SPNB.NewsHead1 = Convert.ToString(dr["NewsHead"]);
                    SPNB.NewsDetails1 = Convert.ToString(dr["NewsDetails"]);
                    SPNB.NPaper1 = Convert.ToString(dr["NPaper"]);
                    SPNB.Role1 = Convert.ToString(dr["Role"]);
                    SPNB.Date1 = Convert.ToString(dr["Date"]);
                    SPNB.Time1 = Convert.ToString(dr["Time"]);
                    SPNB.TypeOfNews1 = Convert.ToString(dr["TypeOfNews"]);
                    SPNB.Location1 = Convert.ToString(dr["Location"]);
                    SPNB.Feedback1 = Convert.ToString(dr["Feedback"]);

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
    public int UpdateRecord(EventNewsBLL SPNB)
    {
        int row;
        try
        {
            conn.Open();
            using(SqlConnection con=new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@NID",SPNB.NID1),
                    new SqlParameter("@NewsHead",SPNB.NewsHead1),
                    new SqlParameter("@NewsDetails",SPNB.NewsDetails1),
                    new SqlParameter("@NPaper",SPNB.NPaper1),
                    new SqlParameter("@Role",SPNB.Role1),
                    new SqlParameter("@Date",SPNB.Date1),
                    new SqlParameter("@Time",SPNB.Time1),
                    new SqlParameter("@TypeOfNews",SPNB.TypeOfNews1),
                    new SqlParameter("@Location",SPNB.Location1),
                    new SqlParameter("@Feedback",SPNB.Feedback1),
                   new SqlParameter("@UserId",SPNB.UserId1),
                };

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UENewsMyCt", par);
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

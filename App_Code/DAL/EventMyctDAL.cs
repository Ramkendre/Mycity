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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for EventMyctDAL
/// </summary>
public class EventMyctDAL
{
	public EventMyctDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    CommonCode cc = new CommonCode();
    public int Addrecord(EventMyctBLL EBLL)
    { 
        int row;
        try
        {
            conn.Open();
            using(SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
                SqlParameter[] par = new SqlParameter[]
                {
                 new SqlParameter("@BrideName", EBLL.BrideName1),
                 new SqlParameter("@GroomName", EBLL.GroomName1),
                 new SqlParameter("@InvitionFrom", EBLL.InvitionFrom1),
                 new SqlParameter("@Date", EBLL.Date1),
                 new SqlParameter("@Time", EBLL.Time1),
                 new SqlParameter("@RemDate",EBLL.RemDate1),
                 new SqlParameter("@RemTime",EBLL.RemTime1),
                 new SqlParameter("@Location", EBLL.Location1),
                 new SqlParameter("@PersonName", EBLL.PersonName1),
                 new SqlParameter("@MobileNumber",EBLL.MobileNumber1),
                 new SqlParameter("@PVisit",EBLL.PVisit1),
                 new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1),
                 new SqlParameter("@MDescp", EBLL.MDescp1),
                 new SqlParameter("@CurrentDate",str),
                 new SqlParameter("@Status1",EBLL.Status3),
                 new SqlParameter("@Status2",EBLL.Status4),
                 
                
                };
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "EventMyCtInsert", par);
            
            }
            return row;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }

    public int Updaterecord(EventMyctBLL EBLL)
    {
        int row;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@Id", EBLL.Id1),
               new SqlParameter("@BrideName",EBLL.BrideName1),
               new SqlParameter("@GroomName",EBLL.GroomName1),
               new SqlParameter("@InvitionFrom", EBLL.InvitionFrom1),
                new SqlParameter("@Date", EBLL.Date1),
                 new SqlParameter("@Time", EBLL.Time1),
                 new SqlParameter("@RemDate",EBLL.RemDate1),
                 new SqlParameter("@RemTime",EBLL.RemTime1),
                 new SqlParameter("@Location", EBLL.Location1),
                 new SqlParameter("@PersonName", EBLL.PersonName1),
                 new SqlParameter("@MobileNumber",EBLL.MobileNumber1),
                 new SqlParameter("@PVisit",EBLL.PVisit1),
                 new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1),
                 new SqlParameter("@MDescp", EBLL.MDescp1),
                 new SqlParameter("@CurrentDate",cc.DateFormatStatus()),
                 //new SqlParameter("@Status1",EBLL.Status3),
                 //new SqlParameter("@Status2",EBLL.Status4),
                 
                };
                // par[13] = new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1);
                //par[13] = new SqlParameter("@SendMgs", EBLL.SendMgs1);

                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UEMyCt", par);
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

    //public int Deleterecord(EventMyctBLL EBLL)
    //{
    //    int row;
    //    try
    //    {
    //        conn.Open();
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //        {
    //            SqlParameter[] par = new SqlParameter[20];
    //            par[0] = new SqlParameter("@Id", EBLL.Id1);
    //            par[1] = new SqlParameter("@BrideName", EBLL.BrideName1);
    //            par[2] = new SqlParameter("@GroomName", EBLL.GroomName1);
    //            par[3] = new SqlParameter("@InvitionFrom", EBLL.InvitionFrom1);
    //            par[4] = new SqlParameter("@DateOfMgs", EBLL.DateOfMgs1);
    //            par[5] = new SqlParameter("@TimeOfMgs", EBLL.TimeOfMgs1);
    //            par[6] = new SqlParameter("@Location", EBLL.Location1);
    //            par[7] = new SqlParameter("@SpecialDescription", EBLL.SpecialDescription1);
    //            par[8] = new SqlParameter("@FristName", EBLL.FristName1);
    //            par[9] = new SqlParameter("@LastName", EBLL.LastName1);
    //            par[10] = new SqlParameter("@MobileNo", EBLL.MobileNo1);
    //            par[11] = new SqlParameter("@Address", EBLL.Address1);
    //            par[12] = new SqlParameter("@Priority", EBLL.Priority1);
    //            // par[13] = new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1);
    //            par[13] = new SqlParameter("@status", 11);
    //            par[13].Direction = ParameterDirection.Output;
    //            row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "EventDeleteMyCT", par);
    //        }
    //        return row;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //}
    public DataSet loadgrid(EventMyctBLL EBLL)
    {
        DataSet ds = new DataSet();

        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@MyCt_UserId", EBLL.MyCt_UserId1);
                //par[1] = new SqlParameter("@status", 11);
                //par[1].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "EventGridLoad", par);
            }
            return ds;

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }

    public void SelectRecord(EventMyctBLL EBLL)
    {
        SqlDataReader dr;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[]
                {
                 new SqlParameter("@Id", EBLL.Id1),
                 //new SqlParameter("@BrideName",EBLL.BrideName1),
                 //new SqlParameter("@GroomName",EBLL.GroomName1),
                 //new SqlParameter("@Date",EBLL.Date1),
                };
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EventMyCtSelect", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    EBLL.BrideName1 = Convert.ToString(dr["BrideName"]);
                    EBLL.GroomName1 = Convert.ToString(dr["GroomName"]);
                    EBLL.InvitionFrom1 = Convert.ToString(dr["InvitionFrom"]);
                    EBLL.Date1 = Convert.ToString(dr["Date"]);
                    EBLL.Time1 = Convert.ToString(dr["Time"]);
                    EBLL.Location1 = Convert.ToString(dr["Location"]);
                    EBLL.RemDate1 = Convert.ToString(dr["RemDate"]);
                    EBLL.RemTime1 = Convert.ToString(dr["RemTime"]);
                    EBLL.MobileNumber1 = Convert.ToString(dr["MobileNumber"]);
                    EBLL.PersonName1 = Convert.ToString(dr["PersonName"]);
                    EBLL.PVisit1 = Convert.ToString(dr["PVisit"]);
            //EBLL.MyCt_UserId1 = Convert.ToString(dr[Session["User"].ToString()]);
            EBLL.MDescp1 = Convert.ToString(dr["MDescp"]);
                }
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }


    ////-------------------------------------Select Record Usermaster------------------------------------------------------
    public void SelectUserMaster(EventMyctBLL EBLL)
    {
        SqlDataReader dr;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@usrUserId", EBLL.UsrUserId);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EventFaithfully", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    EBLL.UsrFirstName = Convert.ToString(dr["usrFirstName"]);
                    EBLL.UsrLastName = Convert.ToString(dr["usrLastName"]);
                }
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }

}

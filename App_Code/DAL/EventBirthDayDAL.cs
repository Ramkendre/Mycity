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
/// Summary description for EventBirthDayDAL
/// </summary>
/// 
public class EventBirthDayDAL
{
    CommonCode cc = new CommonCode();
    int row = 0;
    public EventBirthDayDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    //-------------------------------------------------------Add Record BirthdayEvent----------------------------------------------------------------
    public DataSet loadGrid(EventBirthDayBLL objEBDB)
    {
        DataSet ds = new DataSet();
        try
        {
           
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[10];
                par[0] = new SqlParameter("@UserId", objEBDB.UserId1);
                par[1] = new SqlParameter("@Status", 1);
                par[1].Direction = ParameterDirection.Output;
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "EventLoadGridBDay", par);
            }
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
      
        
    }
    public int AddRecord(EventBirthDayBLL objEBDB)
    {
        int row;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[12];
                //par[0] = new SqlParameter("@BID",objEBDB.BId1);
                par[0] = new SqlParameter("@NameOfPerson", objEBDB.NameOfPerson1);
                par[1] = new SqlParameter("@MobileNo", objEBDB.MobileNo1);
                par[2] = new SqlParameter("@BirthDate", objEBDB.Birthdate1);
                
                par[5] = new SqlParameter("@Gender", objEBDB.Gender1);
                par[6] = new SqlParameter("@SMsg", objEBDB.SMsg1);
                par[7] = new SqlParameter("@MDescp", objEBDB.MDescp1);
                par[3] = new SqlParameter("@RemDate", objEBDB.RemDate1);
                par[4] = new SqlParameter("@Time", objEBDB.Time1);
                par[8] = new SqlParameter("@UserId",objEBDB.UserId1);
                par[9] = new SqlParameter("@Status1", objEBDB.Status);
                par[10] = new SqlParameter("@Status2", objEBDB.Status4);
                
                //par[10] = new SqlParameter("@Status3", objEBDB.Status5);

                string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
                //string srt = DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd");
                //par[11] = new SqlParameter("@CurrentDate", cc.DateFormatStatus());
                par[11] = new SqlParameter("@CurrentDate",srt);
                
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "EventBirthDayInsert", par);
                ///string str = "Update tbl_EBirthDay set Status1='1' where UserId='" + objEBDB.UserId1 + "'";
                //int i = cc.ExecuteNonQuery(str);
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
    public DataSet catchBDay(EventBirthDayBLL objEBDB)
    {
        
        try
        {
            DataSet ds = new DataSet();
         
            conn.Open();
            SqlCommand cmd = new SqlCommand("EventCatchBday",conn);
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
    public void SelectRecord(EventBirthDayBLL objEBDB)
    {
        SqlDataReader dr;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[] 
                { 
                    new SqlParameter("BID",objEBDB.BID1),
                };
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "EBdaySelect", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    objEBDB.NameOfPerson1 = Convert.ToString(dr["NameOfPerson"]);
                    objEBDB.Birthdate1 = Convert.ToString(dr["Birthdate"]);
                    objEBDB.RemDate1 = Convert.ToString(dr["RemDate"]);
                    objEBDB.MobileNo1 = Convert.ToString(dr["MobileNo"]);
                    objEBDB.Time1 = Convert.ToString(dr["Time"]);
                    objEBDB.Gender1 = Convert.ToString(dr["Gender"]);
                    objEBDB.SMsg1 = Convert.ToString(dr["SMsg"]);
                    objEBDB.MDescp1 = Convert.ToString(dr["MDescp"]);

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

    //-------------------------------------------------------Update Record BirthdayEvent----------------------------------------------------------------
    public int UpdateRecord(EventBirthDayBLL objEBDB)
    {
        int row;
        try
        {
            conn.Open();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                SqlParameter[] par = new SqlParameter[] 
                { 
                    new SqlParameter("@BID",objEBDB.BID1),
                    new SqlParameter("@NameOfPerson",objEBDB.NameOfPerson1),
                    new SqlParameter("@Birthdate",objEBDB.Birthdate1),
                    new SqlParameter("@RemDate",objEBDB.RemDate1),
                    new SqlParameter("@MobileNo",objEBDB.MobileNo1),
                    new SqlParameter("@Time",objEBDB.Time1),
                    new SqlParameter("@SMsg",objEBDB.SMsg1),
                    new SqlParameter("@MDescp",objEBDB.MDescp1),
                    new SqlParameter("@Gender",objEBDB.Gender1),
                    new SqlParameter("@CurrentDate",cc.DateFormatStatus()),
                    new SqlParameter("UserId",objEBDB.UserId1),
                    
                    

                };
                row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "sp_UEBDay", par);
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
    //public int UpdateRecord(EventBirthDayBLL objEBDB)
    //{
    //    try
    //    {
    //        conn.Open();
    //        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //        {

    //            SqlParameter[] par = new SqlParameter[10];
    //            par[0] = new SqlParameter("@BId", objEBDB.BId1);
    //            par[1] = new SqlParameter("@NameOfPerson", objEBDB.NameOfPerson1);
    //            par[2] = new SqlParameter("@UserId", objEBDB.UserId1);
    //            par[3] = new SqlParameter("@Birthdate", objEBDB.Birthdate1);
    //            par[4] = new SqlParameter("@Time", objEBDB.Time1);
    //            par[5] = new SqlParameter("@addr", objEBDB.Addr);
    //           // par[6] = new SqlParameter("@BirthUserId", objEBDB.BirthUserId1);
    //            par[6] = new SqlParameter("@mobileno", objEBDB.MobileNo1);
    //            par[7] = new SqlParameter("@status", 11);
    //            // par[0] = new SqlParameter("", objEBDB);
    //            par[7].Direction = ParameterDirection.InputOutput;
    //            row = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "EnevtBirthDateInsertOrUpdate", par);

    //        }

    //    }
    //    catch (Exception ex)
    //    { }
    //    finally
    //    {
    //        conn.Close();
    //    }
    //    return row;
    //}


}

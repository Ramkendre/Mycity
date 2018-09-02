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
/// Summary description for DALMiscalRegistration
/// </summary>
public class DALMiscalRegistration
{
   
    int status;
    CommonCode cc = new CommonCode();
	public DALMiscalRegistration()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int DALInsertMiscalRegistration(BALMiscalRegistration obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "insert into MiscalFriends(userid,friendid,Groupno,FriendName)values('" + obj.Userid + "','" + obj.Friendid + "','" + obj.Groupno + "','" + obj.FriendName + "') ";
                status = cc.ExecuteNonQuery(sql);
                
            }
            catch (Exception ex)
            {
            }
            return status;
        }


    }

    public int DALUpdateMiscalRegistration(BALMiscalRegistration obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "update MiscalFriends set Groupno='" + obj.Groupno + "' where userid='" + obj.Userid + "' and friendid='" + obj.Friendid + "'";
                status = cc.ExecuteNonQuery(sql);

            }
            catch (Exception ex)
            {
            }
            return status;
        }


    }

    public int DALFriendIsExist(BALMiscalRegistration obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select Id from MiscalFriends where friendid='"+obj.Friendid+"' and userid='"+obj.Userid+"'";
                string id = cc.ExecuteScalar(sql);
                if (id == "")
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                

            }
            catch (Exception ex)
            {
            }
            return status;
        }


    }
    public DataSet DALGetAllMiscalReport(BALMiscalRegistration obj)
    {
        DataSet ds=new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select cid,mobileNumber,recordDate from Connection1 where p1='" + obj.Simno + "' and MIMENumber='" + obj.IMEINO + "' order by cid desc";
                 ds = cc.ExecuteDataset(sql);
            }
            catch (Exception ex)
            { }
        }
        return ds;


    }
    public DataSet DALGetAllMessageReport(BALMiscalRegistration obj)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                string sql = "select MiscalResponseCounter.id as id,MiscalResponse.ResponseMsg,MiscalResponseCounter.MobileNumber,MiscalResponseCounter.date from MiscalResponseCounter inner join MiscalResponse on MiscalResponseCounter.Message_id=MiscalResponse.id where MiscalResponse.userid='"+obj.Userid+"' order by MiscalResponseCounter.id desc";
                ds = cc.ExecuteDataset(sql);
            }
            catch (Exception ex)
            { }
        }
        return ds;


    }


}

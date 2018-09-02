using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Html_TodayReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    //TodayBLL objTodayBLL = new TodayBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillMeeting();
            fillNews();
            fillComp();
            FillFollowup();
        }
    }
    public void fillMeeting()
    {
        string str = "select Name as id from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='2'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddltxt.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddltxt.DataValueField = "id";
        }
        ddltxt.DataBind();

        ddltxt.Items.Add("Select");


    }
    public void fillNews()
    {
        string srt = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='1'";
        SqlDataAdapter da = new SqlDataAdapter(srt, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlnews.DataSource = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlnews.DataValueField = "Id";
        }
        ddlnews.DataBind();
        ddlnews.Items.Add("Select");

    }
    public void fillComp()
    {
        string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_Id='3'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlCtype.DataSource = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCtype.DataValueField = "Id";
        }
        ddlCtype.DataBind();
        ddlCtype.Items.Add("Select");
    }
    public void FillFollowup()
    {
        string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_Id='5'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DDLStatus.DataSource = ds;

        if (ds.Tables[0].Rows.Count > 0)
        {
            DDLStatus.DataValueField = "Id";
        }
        DDLStatus.DataBind();
        DDLStatus.Items.Add("Select");
    }

    public void LoadGrid()
    {
        //objTodayBLL.UserId1 = Convert.ToString(Session["User"]);
        //objTodayBLL.MeetingType1 = Convert.ToString(objTodayBLL.MeetingType1);
        //DataSet ds = objTodayBLL.LoadgridBLL(objTodayBLL);
        //DataSet ds = new DataSet();
        //string str = "select ID  FROM [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='"+ddltxt.Text+"' ";
        //ds = cc.ExecuteDataset(str);
        //string st =Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
        //string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
        //string str1 = "select * from tbl_EventMeeting where MeetingType='" + st + "' and UserId='" + Convert.ToString(Session["User"]) + "' and FrmDate='" + srt + "'";
        //ds = cc.ExecuteDataset(str1);
        //if(ds.Tables[0].Rows.Count!=0)
        //{
        //    gvItem.DataSource = ds;
        //    gvItem.DataBind();
        //}
        DataSet ds = new DataSet();
        string str = "select ID  FROM [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + ddltxt.Text + "' ";
        ds = cc.ExecuteDataset(str);

        string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string str1 = "select * from tbl_EventMeeting where MeetingType='" + ds.Tables[0].Rows[i]["ID"] + "' and UserId='" + Convert.ToString(Session["User"]) + "' and FrmDate='" + srt + "'";
            ds = cc.ExecuteDataset(str1);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItem.DataSource = ds;
                gvItem.DataBind();
            }
        }
    }
    public void LoadGridNews()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + ddlnews.Text + "' ";
            ds = cc.ExecuteDataset(str);

            string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string str2 = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where NPaper='" + ds.Tables[0].Rows[i]["ID"] + "' and UserId='" + Convert.ToString(Session["User"]) + "' and Date='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gvItemNews.DataSource = ds;
                    gvItemNews.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGridComp()
    {
        try
        {
            DataSet ds = new DataSet();
            string str = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + ddlCtype.Text + "'";
            ds = cc.ExecuteDataset(str);

            string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string str2 = "select  * from [Come2myCityDB].[dbo].[tbl_EventComplaint]  where CompType='" + ds.Tables[0].Rows[i]["ID"] + "' and UserId='" + Convert.ToString(Session["User"]) + "' and Date='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gvItemComp.DataSource = ds;
                    gvItemComp.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGridFollowup()
    {
        try
        {
            string str = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + DDLStatus.Text + "'";
            DataSet ds = cc.ExecuteDataset(str);

            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string str1 = "select * from [Come2myCityDB].[dbo].[tbl_ECFollowUp] where Status='" + ds.Tables[0].Rows[i]["ID"] + "' and UserId='" + Convert.ToString(Session["User"]) + "' and Date='" + srt + "'";
                ds = cc.ExecuteDataset(str1);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    gvItemFollowuo.DataSource = ds;
                    gvItemFollowuo.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void lnkComboReport_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 0;
    //}
    protected void ddlnews_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGridNews();
    }
    protected void ddlCtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGridComp();
    }
    protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGridFollowup();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(view2);
        LoadgridBDay();
        LoadgridDeath();
        LoadgridNew1();
        LoadgridMeeting1();
        LoadGridMarriage();
        LoadGridComp1();
        LoadGridFollow();
        
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = -1;
    }
    public void LoadgridBDay()
    {
        try
        {
            //string srt = cc.DateFormatStatus();
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "Select * from [Come2myCityDB].[dbo].[tbl_EBirthDay] where UserId='" + Session["User"] + "' and [CurrentDate]='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItemTB.DataSource = ds;
                gvItemTB.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void LoadgridDeath()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventDeath] where UserId='" + Session["User"] + "' and Date='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItemDeath.DataSource = ds;
                gvItemDeath.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }

    }
    public void LoadgridNew1()
    {
        try
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string srt = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='"+Session["User"]+"' and Date='"+str+"'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(srt,con);
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                gvItemNew1.DataSource = ds;
                gvItemNew1.DataBind();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadgridMeeting1()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + Session["User"] + "' and FrmDate='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                gvItemMeet.DataSource = ds;
                gvItemMeet.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGridMarriage()
    {
        try 
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str2 = "select * from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + Session["User"] + "' and Date='" + str + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str2,con);
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                gvItemMarry.DataSource = ds;
                gvItemMarry.DataBind();
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGridComp1()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='"+Session["user"]+"' and Date='"+srt+"'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str,con);
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count!=0)
            {
                gvItemComp1.DataSource = ds;
                gvItemComp1.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
    }
    public void LoadGridFollow()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_ECFollowUp] where UserId='" + Session["user"] + "' and Date='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str,con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItemfollow.DataSource = ds;
                gvItemfollow.DataBind();
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }


}

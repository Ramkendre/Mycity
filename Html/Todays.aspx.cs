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
using System.IO;

public partial class Html_Todays : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    //TodayBLL objTodayBLL = new TodayBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }
        //txtBirthdate.Text = DateTime.Now.Date.ToString();
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = -1;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
    //    //MultiView1.ActiveViewIndex = 1;
        LoadgridBDay();
        LoadgridDeath();
        LoadgridNew1();
        LoadgridMeeting1();
        LoadGridMarriage();
        LoadGridComp1();
    }
//------------------------------------------Todays----------------------------------------------------------
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
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventDeath] where UserId='" + Session["User"] + "' and [CurrentDate]='" + srt + "'";
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
            string srt = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='" + Session["User"] + "' and [CurrentDate]='" + str + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(srt, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + Session["User"] + "' and [CurrentDate]='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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
            string str2 = "select * from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + Session["User"] + "' and [CurrentDate]='" + str + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str2, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItemMarry.DataSource = ds;
                gvItemMarry.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGridComp1()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + Session["user"] + "' and [CurrentDate]='" + srt + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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
//---------------------------------DateWise------------------------------------------------------------------
    protected void txtBirthdate_TextChanged(object sender, EventArgs e)
    {
        LoadgridBDayDate();
       
    }
    public void LoadgridBDayDate()
    {
        try
        {
            //string srt = cc.DateFormatStatus();
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "Select * from [Come2myCityDB].[dbo].[tbl_EBirthDay] where UserId='" + Session["User"] + "' and [CurrentDate]='" +txtBirthdate.Text + "'";
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
    protected void txtDeath_TextChanged(object sender, EventArgs e)
    {
        LoadgridDeathDate();
    }
    public void LoadgridDeathDate()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventDeath] where UserId='" + Session["User"] + "' and [CurrentDate]='" + txtDeath.Text + "'";
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

    protected void txtNews_TextChanged(object sender, EventArgs e)
    {
        LoadgridNew1Date();
    }

    public void LoadgridNew1Date()
    {
        try
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string srt = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='" + Session["User"] + "' and [CurrentDate]='" + txtNews.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(srt, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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
    protected void txtMeet_TextChanged(object sender, EventArgs e)
    {
        LoadgridMeeting1Date();
    }
    public void LoadgridMeeting1Date()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + Session["User"] + "' and [CurrentDate]='" + txtMeet.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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
    protected void txtMarry_TextChanged(object sender, EventArgs e)
    {
        LoadGridMarriageDate();
    }
    public void LoadGridMarriageDate()
    {
        try
        {
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str2 = "select * from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + Session["User"] + "' and [CurrentDate]='" + txtMarry.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str2, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                gvItemMarry.DataSource = ds;
                gvItemMarry.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void txtComp_TextChanged(object sender, EventArgs e)
    {
        LoadGridComp1Date();
    }
    public void LoadGridComp1Date()
    {
        try
        {
            string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + Session["user"] + "' and [CurrentDate]='" + txtComp.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
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

   
//-------------------------Child---------------------------------------------------------------------
    protected void lnkShowBday_Click(object sender, EventArgs e)
    {
        ShowChildBday();

    }
    public void ShowChildBday()
    {
        string str =
                   " with Event as( " +
                   " select *from( " +
                   " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                   " inner join " +
                   " [Come2myCityDB].[dbo].[tbl_EBirthDay] as table2 " +

                   " on " +
                   " table1.uid=table2.[UserId] " +
                   " ) " +
                   " ) ";
        str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,CurrentDate,UserId from Event where Status2='0'";
        //ds = cc.ExecuteDataset(str);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemBC.DataSource = ds;
        gvItemBC.DataBind();

    }
    protected void lnkShowDeath_Click(object sender, EventArgs e)
    {
        ShowChildDeath();

    }
    public void ShowChildDeath()
    {
        string str =
                  " with Event as( " +
                  " select *from( " +
                  " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                  " inner join " +
                  " [Come2myCityDB].[dbo].[tbl_EventDeath] as table2 " +

                  " on " +
                  " table1.uid=table2.[UserId] " +
                  " ) " +
                  " ) ";
        str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],DID,NameOfAccused,Date,Time,Location,SDescp,Relative,Relation,PVisit,MDescp,CurrentDate,UserId from Event where Status2='0' ";
        //ds = cc.ExecuteDataset(str);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemDC.DataSource = ds;
        gvItemDC.DataBind();


    }
    protected void lnkShowNews_Click(object sender, EventArgs e)
    {
        ShowChildNews();

    }
    public void ShowChildNews()
    {
        string str =
                  " with Event as( " +
                  " select *from( " +
                  " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                  " inner join " +
                  " [Come2myCityDB].[dbo].[tbl_EventNews] as table2 " +
                  " on " +
                  " table1.uid=table2.[UserId] " +
                  " ) " +
                  " ) ";
        str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],NID,NewsHead,NewsDetails,NPaper,Role,Date,Time,TypeOfNews,Location,Feedback,CurrentDate,UserId from Event where Status2='0'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemNewC.DataSource = ds;
        gvItemNewC.DataBind();
    }
    protected void lnkShowMeet_Click(object sender, EventArgs e)
    {
        ShowChildMeet();

    }
    public void ShowChildMeet()
    {

        string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventMeeting] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
        str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],ID,ETitle,MeetingType,Location,FrmDate,FrmTime,UptoDate,UptoTime,Descp,RemDate,RemTime,RepRemainder,CurrentDate,UserId from Event where Status2='0'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemMeetC.DataSource = ds;
        gvItemMeetC.DataBind();

    }
    protected void lnkShowMarryC_Click(object sender, EventArgs e)
    {
        ShowChildMarry();

    }
    public void ShowChildMarry()
    {
        string str =
                       " with Event as( " +
                       " select *from( " +
                       " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                       " inner join " +
                       " [Come2myCityDB].[dbo].[tbl_EventMyCt] as table2 " +
                       " on " +
                       " table1.uid=table2.[MyCt_UserId] " +
                       " ) " +
                       " ) ";
        str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],Id,BrideName,GroomName,InvitionFrom,Date,Time,Location,PersonName,MobileNumber,PVisit,MDescp,RemDate,RemTime,CurrentDate,MyCt_UserId from Event where Status2='0' ";
        //ds = cc.ExecuteDataset(str);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemMarryC.DataSource = ds;
        gvItemMarryC.DataBind();
    }
    protected void lnkShowCompC_Click(object sender, EventArgs e)
    {
        ShowChildComp();

    }
    public void ShowChildComp()
    {
        string str =
                   " with Event as( " +
                   " select *from( " +
                   " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address] as a,[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                   " inner join " +
                   " [Come2myCityDB].[dbo].[tbl_EventComplaint] as table2 " +
                   " on " +
                   " table1.uid=table2.[UserId] " +
                   " ) " +
                   " ) ";
        str += "select [firstName],[lastName],m,[usertype],[RefMobileNo],a,[eMailId],CID,CompType,Date,CompSub,CompDetails,CompFDept,CompName,MobileNo,Address,CurrentDate,UserId from Event where Status2='0'";
        //ds = cc.ExecuteDataset(str);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemCompC.DataSource = ds;
        gvItemCompC.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
  //-----------------------Bday---------------------------------------------------------
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        
            
            gvItemTB.RenderControl(htmlWrite);
            gvItemBC.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnExportToExcelD_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);


            gvItemDeath.RenderControl(htmlWrite);
            //gvItemBC.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
}

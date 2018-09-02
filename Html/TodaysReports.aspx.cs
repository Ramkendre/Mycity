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

public partial class Html_TodaysReports : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    //TodayBLL objTodayBLL = new TodayBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    PostBackTrigger trigger = new PostBackTrigger();
    //    trigger.ControlID = btnExportToExcel.ID;
    //    UpdatePanel1.Triggers.Add(trigger);
    //}  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadGrid();
           
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //MultiView1.ActiveViewIndex = 1;
        LoadgridBDay();
        LoadgridDeath();
    }
    protected void lnkComboReport_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        //MultiView1.ActiveViewIndex = 0;
        //LoadgridBDay();
        //LoadgridDeath();
        //LoadgridNew1();
        //LoadgridMeeting1();
        //LoadGridMarriage();
        //LoadGridComp1();
        //LoadGridFollow();

    }
    protected void lnkShowBday_Click(object sender, EventArgs e)
    {
        ShowChildBday();

    }
    protected void lnkShowDeath_Click(object sender, EventArgs e)
    {
        ShowChildDeath();

    }
    protected void lnkShowNews_Click(object sender, EventArgs e)
    {
        ShowChildNews();

    }
    protected void lnkShowMeet_Click(object sender, EventArgs e)
    {
        ShowChildMeet();

    }
    protected void lnkShowMarryC_Click(object sender, EventArgs e)
    {
        ShowChildMarry();

    }
    protected void lnkShowCompC_Click(object sender, EventArgs e)
    {
        ShowChildComp();

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
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemB.DataSource = ds;
        gvItemB.DataBind();

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
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemNewC.DataSource = ds;
        gvItemNewC.DataBind();
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
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemMeetC.DataSource = ds;
        gvItemMeetC.DataBind();

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
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemMarryC.DataSource = ds;
        gvItemMarryC.DataBind();
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
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemCompC.DataSource = ds;
        gvItemCompC.DataBind();
    }
    protected void lnkToday_Click(object sender, EventArgs e)
    {
       
    }
    protected void lnkSDate_Click(object sender, EventArgs e)
    {
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
    protected void lnkBR_Click(object sender, EventArgs e)
    {
        //LoadGrid1();
        LoadgridBDay();
        //MultiView1.Visible = true;
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
            string srt = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='" + Session["User"] + "' and Date='" + str + "'";
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
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + Session["User"] + "' and FrmDate='" + srt + "'";
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
            string str2 = "select * from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + Session["User"] + "' and Date='" + str + "'";
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
            string str = "select * from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + Session["user"] + "' and Date='" + srt + "'";
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
    //public void LoadGridFollow()
    //{
    //    try
    //    {
    //        string srt = DateTime.Now.Date.ToString("yyyy-MM-dd");
    //        string str = "select * from [Come2myCityDB].[dbo].[tbl_ECFollowUp] where UserId='" + Session["user"] + "' and Date='" + srt + "'";
    //        DataSet ds = new DataSet();
    //        SqlDataAdapter da = new SqlDataAdapter(str, con);
    //        da.Fill(ds);
    //        if (ds.Tables[0].Rows.Count != 0)
    //        {
    //            gvItemfollow.DataSource = ds;
    //            gvItemfollow.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlEvent.SelectedItem.ToString() == "Birthday")
        {
            LoadDLLBday();
            ShowChildDLLBday();
        }
        else if(ddlEvent.SelectedItem.ToString()=="Death")
        {
            LoadDLLDeath();
            ShowChildDLLDeath();
            
        }
        else if(ddlEvent.SelectedItem.ToString()=="Meeting")
        {
            LoadDLLMeeting();
        }
        else if(ddlEvent.SelectedItem.ToString()=="Marriage")
        {
            LoadDLLMarriage();
        }
        else if(ddlEvent.SelectedItem.ToString()=="News")
        {
            LoadDLLNews();
        }
        else if (ddlEvent.SelectedItem.ToString() == "Complaint")
        {
            LoadDLLComplaint();
        }
        
    }

    public void LoadDLLBday()
    {
        string str = "select * from [Come2myCityDB].[dbo].[tbl_EBirthDay] where UserId='" + Session["User"] + "' and CurrentDate='"+txtBirthdate.Text+"'";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemD.DataSource = ds;
        gvItemD.DataBind();
    
    }
    public void LoadDLLDeath()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_EventDeath] where UserId='" + Session["User"] + "' and CurrentDate='" + txtBirthdate.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemDe.DataSource = ds;
        gvItemDe.DataBind();
    }
    public void LoadDLLMeeting()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + Session["User"] + "' and CurrentDate='" + txtBirthdate.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemDeath.DataSource = ds;
        gvItemDeath.DataBind();
    }
    public void LoadDLLMarriage()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_EventMyCt] where UserId='" + Session["User"] + "' and CurrentDate='" + txtBirthdate.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemMa.DataSource = ds;
        gvItemMa.DataBind();
    }
    public void LoadDLLNews()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='" + Session["User"] + "' and CurrentDate='" + txtBirthdate.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemN.DataSource = ds;
        gvItemN.DataBind();
    }
    public void LoadDLLComplaint()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + Session["User"] + "' and CurrentDate='" + txtBirthdate.Text + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        gvItemC.DataSource = ds;
        gvItemC.DataBind();
    }
   
    public void ShowChildDLLBday()
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
        
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemBC.DataSource = ds;
        gvItemBC.DataBind();
    }
   
    public void ShowChildDLLDeath()
    {
        string str =
                  " with Event as( " +
                  " select *from( " +
                  " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + Session["MobileNo"].ToString() + "' and keyword='EZEEPLANNER')as table1 " +
                  " inner join " +
                  "  [Come2myCityDB].[dbo].[tbl_EventDeath] as table2 " +

                  " on " +
                  " table1.uid=table2.[UserId] " +
                  " ) " +
                  " ) ";
        str += "select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],DID,NameOfAccused,Date,Time,Location,SDescp,Relative,Relation,PVisit,MDescp,CurrentDate,UserId from Event where Status2='0'";
        
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemDeC.DataSource = ds;
        gvItemDeC.DataBind();
    }
    public void ShowChildDLLNews()
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
        ds = cc.ExecuteDataset(str);
        //ds = cc.ExecuteDataset(str);
        //DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemNC.DataSource = ds;
        gvItemNC.DataBind();
    }
    public void ShowChildDLLMeeting()
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
        //ds = cc.ExecuteDataset(str);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItemMc.DataSource = ds;
        gvItemMc.DataBind();
    }
    public void ShowChildDLLMarriage()
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
        GvItemMaC.DataSource = ds;
        GvItemMaC.DataBind();
    }
    public void ShowChildDLLComplaint()
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
        gvItemCC.DataSource = ds;
        gvItemCC.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItemB.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            //Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    //protected void btnExportToExcelDate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Response.Clear();
    //        Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
    //        Response.ContentType = "application/vnd.xls";
    //        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    //        gvItemB.RenderControl(htmlWrite);
    //        Response.Write(stringWrite.ToString());
    //        //Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


}

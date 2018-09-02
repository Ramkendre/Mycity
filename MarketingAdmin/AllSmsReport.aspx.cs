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

public partial class MarketingAdmin_AllSmsReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "", DateFormattxt = "";
    string DateDateForm = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        if (!IsPostBack)
        {
            AllSMSLoadGrid();
            CountTotal();
            Longcode();
            //Panel1.Visible = true;
            //Panel2.Visible = false;
        }
    }
    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
        DateFormattxt = SystemDate.ToString("dd'-'MM'-'yyyy''");
    }

    //public void ChooseDdl()
    //{
    //    string Sendfrom = "";
    //    int Sentto = 0, total = 0;

    //    string DateSelect = Convert.ToString(txtDate.Text);
    //    string[] Datesplit = DateSelect.Split('-');
    //    DateDateForm = Datesplit[2] + "-" + Datesplit[1] + "-" + Datesplit[0];


    //    string Sql = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
    //                 "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%'  and sendfrom='"+ddlCatagory.SelectedItem.Text+"'";
    //    DataSet ds = cc.ExecuteDataset(Sql);
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        //Sendfrom = Convert.ToString(dr["SendFrom"]);
    //        string MobileNo = Convert.ToString(dr["sendto"]);
    //        string Sql2 = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
    //                     "where  sendto='" + MobileNo + "'  and  CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%' and sendfrom='" + ddlCatagory.SelectedItem.Text + "'";
    //        string TotalSMS = Convert.ToString(cc.ExecuteScalar(Sql2));
    //        string[] All = TotalSMS.Split(',');
    //        Sentto = Convert.ToInt16(All.Length);
    //        total = total + Sentto;
    //    }
    //    lblLongCode.Text = Convert.ToString(total);
    //}

    public void AllSMSLoadGrid()
    {//" + DateFormat + "
        try
        {
            string Sql = "SELECT  distinct[SendFrom] , count([SendFrom])as Total_Sent FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                         "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateFormat + "%' GROUP BY [SendFrom]";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }

    public void CountTotal()
    {
        try
        {
            string Sql = "SELECT count([SendFrom]) FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateFormat + "%' ";
            lblTotal.Text = Convert.ToString(cc.ExecuteScalar(Sql));
        }
        catch (Exception ex)
        { }
    }

    public void Longcode()
    {
        string Sendfrom = "";
        int Sentto = 0, total = 0;
        string Sql = "SELECT  sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                     "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateFormat + "%' ";
        DataSet ds = cc.ExecuteDataset(Sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            //Sendfrom = Convert.ToString(dr["SendFrom"]);
            string MobileNo = Convert.ToString(dr["sendto"]);
            string Sql2 = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                         "where  sendto='" + MobileNo + "'  and  CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateFormat + "%'";
            string TotalSMS = Convert.ToString(cc.ExecuteScalar(Sql2));
            string[] All = TotalSMS.Split(',');
            Sentto = Convert.ToInt16(All.Length);
            total = total + Sentto;
        }
        lblLongCode.Text = Convert.ToString(total);
    }
    public void ChkDateWise()
    {
        try
        {
            string DateSelect = Convert.ToString(txtDate.Text);
            string[] Datesplit = DateSelect.Split('-');
            string DateDateForm = Datesplit[2] + "-" + Datesplit[1] + "-" + Datesplit[0];

            string Sql = "SELECT [SendFrom] , count([SendFrom])as Total_Sent FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                         "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%' GROUP BY [SendFrom]";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();

            string SqlCount = "SELECT count([SendFrom]) FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%' ";
            lblTotal.Text = Convert.ToString(cc.ExecuteScalar(SqlCount));

            LongcodeChk();
        }
        catch (Exception ex)
        { }
       

    }
    public void LongcodeChk()
    {
        string Sendfrom = "";
        int Sentto = 0, total = 0;
        string Sql = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                     "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%' ";
        DataSet ds = cc.ExecuteDataset(Sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            //Sendfrom = Convert.ToString(dr["SendFrom"]);
            string MobileNo = Convert.ToString(dr["sendto"]);
            string Sql2 = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                         "where  sendto='" + MobileNo + "'  and  CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%'";
            string TotalSMS = Convert.ToString(cc.ExecuteScalar(Sql2));
            string[] All = TotalSMS.Split(',');
            Sentto = Convert.ToInt16(All.Length);
            total = total + Sentto;
        }
        lblLongCode.Text = Convert.ToString(total);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ChkDateWise();
    }
    //protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)

    //{
    //    ChooseDdl();
    //}
    //protected void rblChk_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rblChk.SelectedValue == "2")
    //    {
    //        Panel1.Visible = false;
    //        Panel2.Visible = true;
    //        AllSMSLoadGridShow();
    //    }
    //    else
    //    {
    //        Panel1.Visible = true;
    //        Panel2.Visible = false;
    //        AllSMSLoadGrid();
    //    }
    //}

    //public void AllSMSLoadGridShow()
    //{//" + DateFormat + "
    //    try
    //    {
    //        string Sql = "SELECT ID, [SendFrom] , count([SendFrom])as Total_Sent FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
    //                     "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '2013-09-04%' GROUP BY [SendFrom],ID";
    //        DataSet ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            gvShowId.DataSource = ds.Tables[0];
    //            gvShowId.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    { }
    //}

    //protected void gvShowId_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvShowId.PageIndex = e.NewPageIndex;
    //    AllSMSLoadGridShow();

    //}
    //protected void gvShowId_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Show")
    //    {
    //        string Sendfrom = "";
    //        string Cmd = Convert.ToString(e.CommandArgument);

    //        int Sentto = 0, total = 0;
    //        string Sql = "SELECT sendfrom,sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
    //                     "where CONVERT(NVARCHAR(25), sendDateTime, 126) like '2013-09-05%' and ID=" + Cmd + " ";
    //        DataSet ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {

    //            lblcatagory.Text = Convert.ToString(ds.Tables[0].Rows[0]["sendfrom"]);
    //           string  MobileNo = Convert.ToString(ds.Tables[0].Rows[0]["sendfrom"]);

    //            foreach (DataRow dr in ds.Tables[0].Rows)
    //            {
    //                //Sendfrom = Convert.ToString(dr["SendFrom"]);
    //                string MobileNo = Convert.ToString(dr["sendto"]);
    //                string Sql2 = "SELECT sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
    //                             "where  sendto='" + MobileNo + "'  and  CONVERT(NVARCHAR(25), sendDateTime, 126) like '" + DateDateForm + "%' and sendto='" + MobileNo + "'";
    //                string TotalSMS = Convert.ToString(cc.ExecuteScalar(Sql2));
    //                string[] All = TotalSMS.Split(',');
    //                Sentto = Convert.ToInt16(All.Length);
    //                total = total + Sentto;
    //            }
    //        }
    //        lblShowTotal.Text = Convert.ToString(total);
    //    }
    //}
}

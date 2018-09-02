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

public partial class MarketingAdmin_SmsAccount : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        if (!IsPostBack)
        {
            // LodGrid();
            LoadtodayReport();
            Panel1.Visible = false;
            Panel2.Visible = false;
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
    }
    public void LodGrid()
    {
        try
        {
            string Sql = "Select top(300) ID,SendFrom,SendTo,sentMessage,Flag,EntryDate,sendercode,smslength from sendSMSstatus order by ID desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[2].Text.ToString();
                if (Data.Contains(','))
                {
                    row.Cells[2].Text = "List Upload";
                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Details")
            {
                string ID = Convert.ToString(e.CommandArgument);
                string Sql = "Select ID,SendFrom,SendTo,sentMessage,Flag,EntryDate,sendercode,smslength from sendSMSstatus where ID=" + ID + "";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["sentMessage"]);
                    lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["EntryDate"]);
                    lblSendFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["SendFrom"]);
                    txtSendto.Text = Convert.ToString(ds.Tables[0].Rows[0]["SendTo"]);
                    string Sendto = Convert.ToString(txtSendto.Text);
                    string[] Toatal = Sendto.Split(',');
                    lblTotal.Text = Convert.ToString(Toatal.Length);
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    rblChk.SelectedValue = "2";
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void rblChk_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblChk.SelectedValue == "2")
        {

            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            gvItem.Visible = true;
            LodGrid();
        }
        else if (rblChk.SelectedValue == "3")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            gvItem.Visible = true;
            LodGrid();

        }
        else
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
            LoadtodayReport();
            gvItem.Visible = false;
        }
    }

    public void LoadtodayReport()
    {
        try
        {//" + DateFormat + "
            string Sql = "SELECT [SendFrom] , count([SendFrom])as Total_Sent FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                         "where CONVERT(NVARCHAR(25), EntryDate, 126) like '" + DateFormat + "%' GROUP BY [SendFrom]";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvToday.DataSource = ds.Tables[0];
                gvToday.DataBind();
            }
            TodayCounter();
        }
        catch (Exception ex)
        { }
    }
    public void TodayCounter()
    {
        Int32 total = 0, Sentto = 0;
        string Sql = "SELECT Sendto FROM [Come2MyCityDB].[come2mycity].[sendSMSstatus] " +
                       "where CONVERT(NVARCHAR(25), EntryDate, 126) like '" + DateFormat + "%'";
        DataSet ds = cc.ExecuteDataset(Sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string MobileNo = Convert.ToString(dr["sendto"]);
            string[] All = MobileNo.Split(',');
            Sentto = Convert.ToInt16(All.Length);
            total = total + Sentto;
        }
        lblCounter.Text = Convert.ToString(total);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string[] Date = txtDateForm.Text.Split('-');
            string Datetxt = Date[2] + "-" + Date[1] + "-" + Date[0];

            string Sql = "Select ID,SendFrom,SendTo,sentMessage,Flag,EntryDate,sendercode,smslength from sendSMSstatus where SendFrom='" + Convert.ToString(txtMobileNo.Text) + "' and  CONVERT(NVARCHAR(25), EntryDate, 126) like '" + Datetxt + "%' ";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[2].Text.ToString();
                    if (Data.Contains(','))
                    {
                        row.Cells[2].Text = "List Upload";
                    }

                }
            }
            else
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LodGrid();
    }

}

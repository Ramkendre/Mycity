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

public partial class MarketingAdmin_SmsReportUdise : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        try
        {
            int SMSbal = 0, totalCountBal = 0, smsLen = 0;

            string Sql = "Select SendFrom ,count(*) as TotalSMSSend,sentMessage,smslength,EntryDate " +
                         "FROM UDISE_SendSMSReport " +
                         "where SendFrom='" + Convert.ToString(Session["MobileNumber"]) + "' group by smslength,EntryDate,SendFrom,sentMessage";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvToday.DataSource = ds.Tables[0];
            gvToday.DataBind();


            for (int i = 0; i < gvToday.Rows.Count; i++)
            {
                int countSms = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalSMSSend"]);
                Label lblCountSms = (Label)gvToday.Rows[i].Cells[0].FindControl("lblCountSms");
                Label lblTotalSMS = (Label)gvToday.Rows[i].Cells[0].FindControl("lblTotalSMS");
                string sendMessage1 = Convert.ToString(gvToday.Rows[i].Cells[1].Text);

                smsLen = sendMessage1.Length;
                if (smsLen >= 0 && smsLen <= 160)
                {
                    totalCountBal = 1;
                }
                else if (smsLen >= 161 && smsLen <= 306)
                {
                    totalCountBal = 2;
                }
                else if (smsLen >= 307 && smsLen <= 459)
                {
                    totalCountBal = 3;

                }
                else if (smsLen >= 460 && smsLen <= 612)
                {
                    totalCountBal = 4;

                }
                else if (smsLen >= 613 && smsLen <= 765)
                {
                    totalCountBal = 5;
                }
                else if (smsLen >= 766 && smsLen <= 918)
                {
                    totalCountBal = 6;

                }
                else if (smsLen >= 919 && smsLen <= 1071)
                {
                    totalCountBal = 7;

                }
                else if (smsLen >= 1072 && smsLen <= 1224)
                {
                    totalCountBal = 8;
                }
                else if (smsLen >= 1225 && smsLen <= 1377)
                {
                    totalCountBal = 9;

                }
                else if (smsLen >= 1378 && smsLen <= 1530)
                {
                    totalCountBal = 10;
                }
                else { }
                if (totalCountBal != 0)
                {
                    lblCountSms.Text = Convert.ToString(totalCountBal);
                    lblTotalSMS.Text = (Convert.ToString((totalCountBal * countSms) + 1));
                }
                else
                {
                    lblCountSms.Text = "0";
                }
            }
            foreach (GridViewRow row in gvToday.Rows)
            {
                string Data = row.Cells[4].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[4].Text = Data;
            }
            lblError.Text = "";

        }
        catch (Exception ex)
        { }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int SMSbal = 0, totalCountBal = 0, smsLen = 0;



            string Sql = "Select SendFrom ,count(*) as TotalSMSSend,sentMessage,smslength,EntryDate " +
                         "From UDISE_SendSMSReport where SendFrom='" + Convert.ToString(Session["MobileNumber"]) + "'";
            if (ddlMonth.SelectedValue != "0")
            {
                Sql = Sql + " and datePart(month,UDISE_SendSMSReport.EntryDate)=" + ddlMonth.SelectedValue + "";
            }
            if (ddlYear.SelectedValue != "0")
            {
                Sql = Sql + " and datePart(year,UDISE_SendSMSReport.EntryDate)=" + ddlYear.SelectedItem.Text + "";
            }
            if (txtDate.Text != "")
            {
                Sql = Sql + " and CONVERT(NVARCHAR(25), EntryDate, 126) like '" + txtDate.Text + "%'";
            }
            Sql = Sql + " group by smslength,EntryDate,SendFrom,sentMessage";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvToday.DataSource = ds.Tables[0];
            gvToday.DataBind();


            for (int i = 0; i < gvToday.Rows.Count; i++)
            {
                int countSms = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalSMSSend"]);
                Label lblCountSms = (Label)gvToday.Rows[i].Cells[0].FindControl("lblCountSms");
                Label lblTotalSMS = (Label)gvToday.Rows[i].Cells[0].FindControl("lblTotalSMS");
                string sendMessage1 = Convert.ToString(gvToday.Rows[i].Cells[1].Text);

                smsLen = sendMessage1.Length;
                if (smsLen >= 0 && smsLen <= 160)
                {
                    totalCountBal = 1;
                }
                else if (smsLen >= 161 && smsLen <= 306)
                {
                    totalCountBal = 2;
                }
                else if (smsLen >= 307 && smsLen <= 459)
                {
                    totalCountBal = 3;

                }
                else if (smsLen >= 460 && smsLen <= 612)
                {
                    totalCountBal = 4;

                }
                else if (smsLen >= 613 && smsLen <= 765)
                {
                    totalCountBal = 5;
                }
                else if (smsLen >= 766 && smsLen <= 918)
                {
                    totalCountBal = 6;

                }
                else if (smsLen >= 919 && smsLen <= 1071)
                {
                    totalCountBal = 7;

                }
                else if (smsLen >= 1072 && smsLen <= 1224)
                {
                    totalCountBal = 8;
                }
                else if (smsLen >= 1225 && smsLen <= 1377)
                {
                    totalCountBal = 9;

                }
                else if (smsLen >= 1378 && smsLen <= 1530)
                {
                    totalCountBal = 10;
                }
                else { }
                if (totalCountBal != 0)
                {
                    lblCountSms.Text = Convert.ToString(totalCountBal);
                    lblTotalSMS.Text = (Convert.ToString((totalCountBal * countSms) + 1));
                }
                else
                {
                    lblCountSms.Text = "0";
                }
            }


            //BillReport();

            foreach (GridViewRow row in gvToday.Rows)
            {
                string Data = row.Cells[4].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[4].Text = Data;
            }
            lblError.Text = "";
        }
        catch (Exception ex)
        { }
    }


    //------------------------------

    public string DateSplit(string data)
    {
        string[] dt = data.Split(' ');
        string[] Dts = dt[0].Split('/');
        data = Dts[1] + "-" + Dts[0] + "-" + Dts[2];
        return data;
    }


    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvToday.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnBill_Click(object sender, EventArgs e)
    {
        if (ddlMonth.SelectedIndex == 0)
        {
            lblError.Text = "Please select month......'";
        }
        else if (ddlYear.SelectedIndex == 0)
        {
            lblError.Text = "Please select year..!";
        }
        else
        {
            lblMonth.Text = Convert.ToString("Month Wise Total SMS sent: " + ddlMonth.SelectedItem.Text);
            BillReport();
        }
    }

    public void BillReport()
    {
        try
        {
            string Sql = "Select count(*) from UDISE_SendSMSReport where datePart(month,UDISE_SendSMSReport.EntryDate)=" + ddlMonth.SelectedValue + " and datePart(year,UDISE_SendSMSReport.EntryDate)=" + ddlYear.SelectedItem.Text + " and SendFrom='" + Convert.ToString(Session["MobileNumber"]) + "'";
            string BillDetails = Convert.ToString(cc.ExecuteScalar(Sql));
            if (BillDetails == "" || BillDetails == null)
            {
                lblBill.Text = "0";
            }
            else
            {
                lblBill.Text = Convert.ToString(BillDetails);
                lblError.Text = "";

            }
        }
        catch (Exception ex)
        { }
    }
    protected void gvToday_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvToday.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        lblError.Text = "";
        lblMonth.Text = "";
        lblBill.Text = "";
        ddlYear.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
    }
}

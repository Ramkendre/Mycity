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

public partial class MarketingAdmin_SMSReport : System.Web.UI.Page
{
    LongCodeBLL objSMS = new LongCodeBLL();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string TodaysDate = System.DateTime.Now.ToShortDateString();
            txtfrmdate.Text = TodaysDate;
            txttodate.Text = TodaysDate;
            Bindresource();


        }
    }
    private void BindReport(string frmdate, string todate)
    {
        DataSet ds;
        int count = 0;
        string counter = "";
        try
        {

            if (ddlcode.SelectedIndex == 0)
            {
                ds = objSMS.BLLSMSReport(objSMS);
                counter = objSMS.BLLSMSReportcount(objSMS);
            }
            else
            {
                objSMS.Sendercode = Convert.ToInt32(ddlcode.SelectedItem.Value);
                ds = objSMS.BLLgetsmsbyid(objSMS);
                counter = objSMS.BLLgetsmsbyidcount(objSMS);
            }

            gvReport.DataSource = ds.Tables[0];
            gvReport.DataBind();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                int sqlcount = Convert.ToInt32(dr["smslength"]);
                if (sqlcount < 160)
                {
                    count = count + 1;

                }
                else if (sqlcount > 160)
                {
                    count = count + 2;
                }
                else if (sqlcount > 320)
                {
                    count = count + 3;

                }
                else if (sqlcount > 480)
                {
                    count = count + 4;
                }

            }

            lblttlsms.Visible = true;
            lbltotalsms.Visible = true;
            lblsms.Visible = true;
            lbltotal.Visible = true;
            lbltotal.Text = count.ToString();
            lbltotalsms.Text = counter.ToString();



        }
        catch (Exception ex)
        {
        }
    }

    private void Bindresource()
    {
        try
        {
            DataSet ds = objSMS.BLLSMSCode(objSMS);

            ddlcode.DataTextField = "ProjectName";
            ddlcode.DataValueField = "id";

            ddlcode.DataSource = ds;
            ddlcode.DataBind();
            ddlcode.Items.Insert(0, "--Select--");



        }
        catch (Exception ex)
        {
        }
    }
    protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReport.PageIndex = e.NewPageIndex;
        GetSmsRecord();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetSmsRecord();

    }

    private void GetSmsRecord()
    {
        try
        {
            if ((txtfrmdate.Text == "") && (txttodate.Text == ""))
            {
                string date = System.DateTime.Now.ToShortDateString();
                date = cc.ChangeDate2(date);
                objSMS.Frmdate = date;
                objSMS.Todate = date;
                BindReport(objSMS.Frmdate, objSMS.Todate);
            }
            else
            {

                string fromdate = txtfrmdate.Text;
                fromdate = cc.ChangeDate2(fromdate);
                objSMS.Frmdate = fromdate;
                string todate = txttodate.Text;
                todate = cc.ChangeDate2(todate);
                objSMS.Todate = todate;
                BindReport(objSMS.Frmdate, objSMS.Todate);


            }





        }
        catch (Exception ex)
        {
        }

    }
   
    protected void imgFrom_Click(object sender, ImageClickEventArgs e)
    {
       
    }
}

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

public partial class html_SentSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    LongCodeBLL objSMS = new LongCodeBLL();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserIdSession = Convert.ToString(Session["User"]);
            if (UserIdSession == "")
            {
                Response.Redirect("../default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    GetSmsRecord();
                }
            }
        }
        catch(Exception ex)
        {}
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            GetSmsRecord();

        }
        catch (Exception ex)
        { }

    }
    private void GetSmsRecord()
    {
        try
        {
            if ((txtfrmdate.Text == "") && (txttodate1.Text == "") && (txtSearchMobile.Text == ""))
            {
                string date = System.DateTime.Now.ToShortDateString();
                date = cc.ChangeDate2(date);
                objSMS.Frmdate = date;
                objSMS.Todate = date;
                showsentsms();
            }
            else if (txtSearchMobile.Text == "")
            {

                string fromdate = txtfrmdate.Text;
                fromdate = cc.ChangeDate2(fromdate);
                objSMS.Frmdate = fromdate;
                string todate = txttodate1.Text;
                todate = cc.ChangeDate2(todate);
                objSMS.Todate = todate;
                BindReport(objSMS.Frmdate, objSMS.Todate);


            }
            else
            {
                string fromdate = txtfrmdate.Text;
                fromdate = cc.ChangeDate2(fromdate);
                objSMS.Frmdate = fromdate;
                string todate = txttodate1.Text;
                todate = cc.ChangeDate2(todate);
                objSMS.Todate = todate;
                BindReport(objSMS.Frmdate, objSMS.Todate);

            }

        }
        catch (Exception ex)
        {
        }

    }
    public string ChangeDate2(string dt)
    {
        string[] tmpdt;

        string dt1 = "0";
        try
        {
            tmpdt = dt.Split('/');
            if (tmpdt[0].Length == 1)
                tmpdt[0] = "0" + tmpdt[0];
            if (tmpdt[1].Length == 1)
                tmpdt[1] = "0" + tmpdt[1];

            dt1 = tmpdt[2] + "-" + tmpdt[0] + "-" + tmpdt[1];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }
    public void showsentsms()
    {
        try
        {

            string sql = "select ID,SendFrom,SendTo,sentMessage,SendDateTime from sendSMSstatus where SendFrom='" + Session["Mobile"].ToString() + "' and sendercode in(1,2,3,4) order by id desc";
            DataSet ds = cc.ExecuteDataset(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DateTime date = Convert.ToDateTime(dr["sendDateTime"]);
                date = date.AddHours(11);
                date = date.AddMinutes(90);
                dr["sendDateTime"] = date;
            }
            grdsntmsg.DataSource = ds;
            grdsntmsg.DataBind();

            foreach (GridViewRow row in grdsntmsg.Rows)
            {
                string Data = row.Cells[2].Text.ToString();
                Data = "List Of Mobile No";
                row.Cells[2].Text = Data;
            }
        }
        catch (Exception er)
        { throw er; }
    }
    private void BindReport(string frmdate, string todate)
    {
        DataSet ds;
        //int count = 0;
        //string counter = "";
        try
        {
            if (txtSearchMobile.Text == "")
            {
                objSMS.Mobileno = Convert.ToString(Session["Mobile"]);
                ds = objSMS.BLLSMSReport(objSMS);
                grdsntmsg.DataSource = ds.Tables[0];
                grdsntmsg.DataBind();
            }
            else
            {
                objSMS.Mobileno = txtSearchMobile.Text;
                ds = objSMS.BLLSMSReportByMobile(objSMS);
                grdsntmsg.DataSource = ds.Tables[0];
                grdsntmsg.DataBind();

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdsntmsg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdsntmsg.PageIndex = e.NewPageIndex;
        GetSmsRecord();


    }

}

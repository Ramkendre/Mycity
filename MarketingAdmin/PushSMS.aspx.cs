using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class MarketingAdmin_PushSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    VerifySMSBLL objVerifyBLL = new VerifySMSBLL();
    DataSet ds = new DataSet();
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            panel1.Visible = false;
            txtCurrDate.Text = Convert.ToString(System.DateTime.Now);
            txtFromDate.Text = Convert.ToString(System.DateTime.Now);
            txtToDate.Text = Convert.ToString(System.DateTime.Now);
            loadGvLongCodeSMSReceve();
        }
    }
    

    public void loadGvLongCodeSMSReceve()
    {
        try
        {
            string sql = "select top(50)* from uvajagar order by id desc";
            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvLongCodeSMS.DataSource = ds.Tables[0];
                gvLongCodeSMS.DataBind();
            }
        }
        catch (Exception ex)
        {

        }

    }
    
    protected void chkSelectDate_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectDate.Checked == true)
        {
            panel1.Visible = true;
        }
        else
        {
            panel1.Visible = false;            
        }
    }
    protected void btnRecords_Click(object sender, EventArgs e)
    {

        show();

    }

    private void show()
    {

        string datefrom = ChangeDate(txtFromDate.Text);
        string dateto = ChangeDate(txtToDate.Text);

        if (panel1.Visible == true)
        {
            string sql = "select top(50) pk,mobile,message,shortcode,flagstatus, Senddate from come2mycity.test where ((Senddate between '" + datefrom + "' and '" + dateto + "')) order by PK desc";
            DataSet ds = cc.ExecuteDataset(sql);
            gvLongCodeSMS.DataSource = ds.Tables[0];
            gvLongCodeSMS.DataBind();
           
        }
        else
        {
            loadGvLongCodeSMSReceve();
        }
    }
    public string ChangeDate(string dt)
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

            dt1 = tmpdt[2] + "/" + tmpdt[0] + "/" + tmpdt[1];

        }
        catch (Exception ex)
        {
            string msg = ex.Message;


        }
        return dt1;
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
       // Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void gvLongCodeSMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLongCodeSMS.PageIndex = e.NewPageIndex;
        loadGvLongCodeSMSReceve();

    }
    
    protected void gvLongCodeSMS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CommonCode cc = new CommonCode();
        TextBox txtNewMsgUpdate = (TextBox)gvLongCodeSMS.Rows[e.RowIndex].FindControl("txtMsg");
        Label lblIdText = (Label)gvLongCodeSMS.Rows[e.RowIndex].FindControl("lblID");
        Label lblMobile = (Label)gvLongCodeSMS.Rows[e.RowIndex].FindControl("lblMobile");
        DateTime today = DateTime.Now.Date;
        string id = "";
        string msm = "";
        string mobileNo = "";
        id = lblIdText.Text;
        msm = txtNewMsgUpdate.Text;
        mobileNo = lblMobile.Text;
        string sqlPush = "update come2mycity.test set FlagStatus = 0 where PK = " + id.ToString() + "";
        int d = cc.ExecuteNonQuery(sqlPush);
        loadGvLongCodeSMSReceve();
        string URL = "http://www.com/sendMsg.aspx?message=" + msm.ToString() + "&mobilenumber=" + mobileNo.ToString() + "&receivedon=" + Convert.ToString(today) + "";
        Response.Redirect(URL);
       //Response.Redirect("../MarketingAdmin/EditSMS.aspx");
        

    }
    protected void gvLongCodeSMS_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvLongCodeSMS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLongCodeSMS.EditIndex = e.NewEditIndex;
        loadGvLongCodeSMSReceve();
    }


    protected void gvLongCodeSMS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("../MarketingAdmin/PushSMS.aspx");
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
}


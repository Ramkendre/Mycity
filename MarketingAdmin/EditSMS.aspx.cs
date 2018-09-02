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


public partial class MarketingAdmin_EditSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    VerifySMSBLL objVerifyBLL = new VerifySMSBLL();
    DataSet ds = new DataSet();
    int status;
    string Datelast;
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

        string sql = "select top(1000)* from come2mycity.test order by PK desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvLongCodeSMS.DataSource = ds.Tables[0];
        gvLongCodeSMS.DataBind();

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
            string sql = "select pk,mobile,message,shortcode,flagstatus,Senddate, from come2mycity.test where  ((Senddate between '" + datefrom + "' and '" + dateto + "'))  order by Senddate desc";
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
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void gvLongCodeSMS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLongCodeSMS.PageIndex = e.NewPageIndex;
        loadGvLongCodeSMSReceve();

    }
    string Date;
    string GetDate;

    protected void gvLongCodeSMS_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CommonCode cc = new CommonCode();
        TextBox txtNewMsgUpdate = (TextBox)gvLongCodeSMS.Rows[e.RowIndex].FindControl("txtMsg");
        Label lblIdText = (Label)gvLongCodeSMS.Rows[e.RowIndex].FindControl("lblID");
        Label lblMobile = (Label)gvLongCodeSMS.Rows[e.RowIndex].FindControl("lblMobile");
        Label DateProper = (Label)gvLongCodeSMS.Rows[e.RowIndex].FindControl("lblDate");
        Datelast = Convert.ToString(DateProper.Text);

       
        DateTime today = DateTime.Now.Date;
        string id = "";
        string msm = "";
        string mobileNo = "";
        id = lblIdText.Text;
        msm = txtNewMsgUpdate.Text;
        mobileNo = "91"+lblMobile.Text;

        string sqlPush = "update come2mycity.test set FlagStatus = 0 where PK = " + id.ToString() + "";
        int F = cc.ExecuteNonQuery(sqlPush);
        loadGvLongCodeSMSReceve();
        string URL = "http://www.come2mycity.com/sendMsg.aspx?message=" + Convert.ToString(msm) + "&mobilenumber=" + Convert.ToString(mobileNo) + "&receivedon=" + Convert.ToString(Datelast) + "";
        Response.Redirect(URL);
    }

    protected void gvLongCodeSMS_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvLongCodeSMS_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvLongCodeSMS.EditIndex = e.NewEditIndex;
        loadGvLongCodeSMSReceve();
    }
    protected void btnDataTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            string chkContact = "chkSelectMessage";
            ArrayList selecteItem = GetCheckedItems(chkContact, gvLongCodeSMS);
            if (selecteItem.Count > 0)
            {
                foreach (string id in selecteItem)
                {
                    string sql = "select * from come2mycity.test where pk='" + id + "'";
                    DataSet ds = cc.ExecuteDataset(sql);
                    string message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    string mobile = Convert.ToString(ds.Tables[0].Rows[0]["mobile"]);
                    string shortcode = Convert.ToString(ds.Tables[0].Rows[0]["shortcode"]);
                    string FlagStatus = Convert.ToString(ds.Tables[0].Rows[0]["smsStatus"]);
                    string PK = Convert.ToString(ds.Tables[0].Rows[0]["PK"]);
                    string SendDate = Convert.ToString(ds.Tables[0].Rows[0]["SendDate"]);
                    sql = "insert into uvajagar(PK,Message,Mobile,smsStatus,SendDate)" +
                        "values('" + PK + "','" + message + "','" + mobile + "','" + FlagStatus + "','" + SendDate + "')";
                    int a = cc.ExecuteNonQuery(sql);
                }
            }
            else
            {
                Response.Write("<script>(alert)('Plz select atleast one')</script>");
                loadGvLongCodeSMSReceve();
            }
        }
        catch (Exception ex)
        {
        }
    }
    private ArrayList GetCheckedItems(string crtl, GridView grdView)
    {
        ArrayList checkedItems = new ArrayList();
        CheckBox chk;
        string chkBoxIndex = string.Empty;
        try
        {
            foreach (GridViewRow row in grdView.Rows)
            {
                chkBoxIndex = (string)grdView.DataKeys[row.RowIndex].Value.ToString();
                chk = (CheckBox)row.FindControl("chkSelectMessage");

                if (chk.Checked)
                {
                    if (!(checkedItems.Contains(chkBoxIndex)))
                    {
                        checkedItems.Add(chkBoxIndex);

                    }
                    else
                    {
                        checkedItems.Remove(chkBoxIndex);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        return checkedItems;
    }
    protected void gvLongCodeSMS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("../MarketingAdmin/EditSMS.aspx");
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MarketingAdmin_SMSresaler : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urBLL = new UserRegistrationBLL();
    int status;
    CommonSqlQueryCode ccr = new CommonSqlQueryCode();
    string name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvbalanceshow();
        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        InsertBalanceTransfer();


    }

    private void InsertBalanceTransfer()
    {
        string senderId = "myctin";
        try
        {
            urBLL.Frmmobileno = "9422325020";

            urBLL.Customermobileno = Convert.ToString(txtmobileno.Text);
            urBLL.Transbal = Convert.ToString(txttransaction.Text);
            urBLL.Prombal = Convert.ToString(txtPromotional.Text);
            urBLL.Validfrom = Convert.ToString(txtvalidfrom.Text);
            urBLL.Validupto = Convert.ToString(txtvalidupto.Text);
            status = urBLL.BLLInsertBalanceTransfer(urBLL);
            if (status == 1)
            {
                int Transactional = Convert.ToInt32(urBLL.Transbal);
                int Promtional = Convert.ToInt32(urBLL.Prombal);
                string mobileto = urBLL.Customermobileno;
                string query = "select * from usermaster where usrMobileNo='" + mobileto + "'";
                DataSet dss = cc.ExecuteDataset(query);
                int SMSBal1 = Convert.ToInt32(dss.Tables[0].Rows[0]["SMSbal"]);
                int PaidCount1 = Convert.ToInt32(dss.Tables[0].Rows[0]["paidCount"]);
                SMSBal1 = SMSBal1 + Transactional;
                PaidCount1 = PaidCount1 + Promtional;
                string sql12 = "update usermaster set SMSbal='" + SMSBal1 + "' ,paidCount='" + PaidCount1 + "' where usrMobileNo='" + mobileto + "'  ";
                int aaa = cc.ExecuteNonQuery(sql12);
                string messageto = "Dear user Your Transactional Bal is " + urBLL.Transbal + " & Promotional Bal is " + urBLL.Prombal + " updated successfully in ur a/c Thanks Via www.myct.in ";
                cc.SendMessageTra(senderId, mobileto, messageto);
                string sendto = "9422325020";
                string sql = "select * from usermaster where usrMobileNo='" + sendto + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                int SMSBal = Convert.ToInt32(ds.Tables[0].Rows[0]["SMSbal"]);
                int PaidCount = Convert.ToInt32(ds.Tables[0].Rows[0]["paidCount"]);
                SMSBal = SMSBal - Transactional;
                PaidCount = PaidCount - Promtional;
                string sql1 = "update usermaster set SMSbal='" + SMSBal + "' ,paidCount='" + PaidCount + "' where usrMobileNo='" + sendto + "'  ";
                int a = cc.ExecuteNonQuery(sql1);
                string message = "Dear user Trans Bal= " + urBLL.Transbal + " & Promo Bal=" + urBLL.Prombal + " is transfer to " + urBLL.Customermobileno + "";
                string sms = message + " Your Trans Bal is " + SMSBal + " & Promo Bal is" + PaidCount + " Thanks Via www.myct.in";
                cc.SendMessageTra(senderId, sendto, sms);
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Balance Transfer successfully')", true);
                Response.Write("<script>alert('Balance Transfer successfully')</script>");

                gvbalanceshow();
                clearall();
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz fill all information')", true);
                Response.Write("<script>alert('Plz fill all information')</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void clearall()
    {
        // txtcustomername.Text = "";
        txtmobileno.Text = "";
        txttransaction.Text = "";
        txtPromotional.Text = "";
        txtvalidfrom.Text = "";
        txtvalidupto.Text = "";
        txtname.Text = "";

    }

    private void gvbalanceshow()
    {
        try
        {
            string sql = " select * from transferbalance order by id desc ";
            DataSet dd = cc.ExecuteDataset(sql);
            gvBalance.DataSource = dd.Tables[0];
            gvBalance.DataBind();
        }
        catch { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtmobileno.Text == "" || txtmobileno.Text == null)
            {
                Response.Write("<script>alert('Plz Enter MobileNo. !!')</script>");

            }
            else
            {
                searchRecord();
            }
        }
        catch (Exception ex)
        {
        }


    }
    private void searchRecord()
    {
        urBLL.Customermobileno = txtmobileno.Text;
        status = urBLL.BLLSearchUserExist(urBLL);
        if (status == 1)
        {
            string sql = "select usrFirstName+' '+usrLastName as FullName from usermaster where usrMobileNo='" + txtmobileno.Text + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            txtname.Text = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
            name = txtname.Text;
            txttransaction.Enabled = true;
            txtPromotional.Enabled = true;
            txtvalidfrom.Enabled = true;
            txtvalidupto.Enabled = true;
            btnsubmit.Enabled = true;
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This MobileNo. is not registered to myct.in')", true);
            Response.Write("<script>alert('This MobileNo. is not registered to myct.in')</script>");

        }
    }
    protected void gvBalance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBalance.PageIndex = e.NewPageIndex;
        gvbalanceshow();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/SMSresaler.aspx");
    }
}

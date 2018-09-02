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

public partial class Html_SpacialSMS : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Val", typeof(string));
        dt.Rows.Add(1, "Mahesh");
        dt.Rows.Add(2, "Siddhu");
        dt.Rows.Add(3, "Sourabh");
        dt.Rows.Add(4, "Mahesh1");
        dt.Rows.Add(5, "Mahesh2");
        dt.Rows.Add(6, "Mahesh3");
        ddlUserGr.DataSource = dt;
        ddlUserGr.DataTextField = "Val";
        ddlUserGr.DataValueField = "ID";
        ddlUserGr.DataBind();
        ddlUserGr.Items.Add("--Select--");
        ddlUserGr.SelectedIndex = ddlUserGr.Items.Count - 1;
        ddlUserGr.Items[ddlUserGr.Items.Count - 1].Value = "";


        LoadPaidBal();
       
    }
    public void LoadPaidBal()
    {
        string usrIdSn = Convert.ToString(Session["User"]);
        string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
        int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
        lblPaidBal.Text = Convert.ToString(bal);
    }
    public void btnSendSms_Click(object sender, EventArgs e)
    {
        
    
    }
    protected void btnStudent_Click(object sender, EventArgs e)
    {
        
    }

    protected void ddlUserGr_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dd = new DataTable();
        dd.Columns.Add("a", typeof(int));
        dd.Columns.Add("b", typeof(string));
        dd.Columns.Add("c", typeof(string));
        dd.Columns.Add("d", typeof(string));
        dd.Columns.Add("e", typeof(string));
        dd.Rows.Add(1001, "Murlidhar", "9422325020", "6789", "Abhinav");
        dd.Rows.Add(1002, "Mahesh", "9881991453", "9876", "XYZ");
        dd.Rows.Add(1002, "Mahesh", "9881991453", "9876", "XYZ");
        dd.Rows.Add(1002, "Mahesh", "9881991453", "9876", "XYZ");
        dd.Rows.Add(1002, "Mahesh", "9881991453", "9876", "XYZ");
        gvStuGr.DataSource = dd;
        gvStuGr.DataBind();

    }
}

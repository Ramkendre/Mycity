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

public partial class MarketingAdmin_SMSstatus : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string mobileno = "";
    UserRegistrationBLL usrBLL = new UserRegistrationBLL();
    int status;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridshow();
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtmobileno.Text == "" || txtmobileno.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz Enter MobileNo..!!')", true);
        }
        else
        {
            insertrecord();
            txtmobileno.Text = "";
        }
     
    }

    public void insertrecord()
    {
        usrBLL.usrMobileNo = txtmobileno.Text;
        string sqlfetch = "select usrUserid from usermaster where usrMobileNo='" + usrBLL.usrMobileNo + "'";
        string userid = cc.ExecuteScalar(sqlfetch);
       status = usrBLL.BLLIsExistUserRegistrationInitial(usrBLL);
       if (status == 0)
       {
           string sqlcheck = "select id from SMSstatus where Userid='" + userid + "' ";
           string id = cc.ExecuteScalar(sqlcheck);
           if (id == null || id=="")
           {
               DateTime datetime = DateTime.Now;
               string smsstatus = "Deactive";

               string sql = "insert into SMSstatus(Userid,SMS_status,sms_date)values('" + userid + "','" + smsstatus + "','" + datetime + "')";
               string insertvalue = cc.ExecuteScalar(sql);

               ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS menu is deactivated successfully')", true);
           }
           //else
           //{
           //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS menu is already deactivated to your account ')", true);

           //}
       }
       else
       {
           ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This number is not registered to www.myct.in')", true);

       }
       gridshow();
        
    }

    public void gridshow()
    {
        mobileno = txtmobileno.Text;
        string sql = "select id, usrFirstName+' '+usrLastName as FullName,usrMobileNo,SMS_status,sms_date from usermaster inner join SMSstatus " +
            "on usermaster.usrUserid=SMSstatus.Userid order by id desc ";
        DataSet ds = cc.ExecuteDataset(sql);
        GridSMSstatus.DataSource = ds.Tables[0];
        GridSMSstatus.DataBind();
    }
    protected void GridSMSstatus_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblid.Text = Id;
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                string sql = "delete from SMSstatus where id='" + lblid.Text + "'";
                int a = cc.ExecuteNonQuery(sql);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record is deleted successfully, SMS menu is activated')", true);

            }
        }
        catch (Exception ex)
        {
        }
        gridshow();

    }
    protected void GridSMSstatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtmobileno.Text = "";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void GridSMSstatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridSMSstatus.PageIndex = e.NewPageIndex;
        gridshow();
    }
}

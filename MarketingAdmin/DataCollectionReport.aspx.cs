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
using System.Text;
using System.IO;

public partial class MarketingAdmin_DataCollectionReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    Location li = new Location();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            GetRecord();
            AddTable();

        }
        //GridView1.HeaderRow.Visible = false;

    }
    private void GetRecord()
    {
        try
        {
            string sql = "select usrFirstName+''+usrLastName as fullname,p5,p7,p9,p11,p13,send_date from DataCollection1" +
" inner join UserMaster on DataCollection1.sender_mobileno = UserMaster.usrUserId" +
" where main_ref='9c4cf910-25bc-4e87-948d-23a29a3402d0' or ref_id='9c4cf910-25bc-4e87-948d-23a29a3402d0'" +
" and send_date='04/17/2013'";
            DataSet ds = cc.ExecuteDataset(sql);
            gvdisplay.DataSource = ds.Tables[0];
            gvdisplay.DataBind();
        }
        catch (Exception ex)
        { }
    }

    private void AddTable()
        {
        string sql5 = "select SUM(CAST(p5  AS INT))as p5,SUM(CAST(p7  AS INT))as p7,SUM(CAST(p9  AS INT))as p9,SUM(CAST(p11  AS INT))as p11,SUM(CAST(p13  AS INT))as p13 from DataCollection1 " +
            " inner join UserMaster on DataCollection1.sender_mobileno = UserMaster.usrUserId where main_ref='9c4cf910-25bc-4e87-948d-23a29a3402d0' or ref_id='9c4cf910-25bc-4e87-948d-23a29a3402d0'and send_date='04/17/2013'" +
            " and ISNUMERIC(p5) = 1 and ISNUMERIC(p7) = 1 and ISNUMERIC(p9) = 1 and ISNUMERIC(p11) = 1and ISNUMERIC(p13) = 1 ";
       
                DataSet ds1 = cc.ExecuteDataset(sql5);
        GridView1.DataSource = ds1.Tables[0];
   
        GridView1.DataBind();
        
       
    }

    protected void btnSendmail_Click(object sender, EventArgs e)
    {
        string sendTo = "smsofmyct@gmail.com";
        string subject = "Report of date "+System.DateTime.Now;
       string MailBody = GetGridviewData(gvdisplay);
        li.sendEmail(sendTo, subject, MailBody);

        

    }
    public string GetGridviewData(GridView gv)
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gv.RenderControl(htw);
        return strBuilder.ToString();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}

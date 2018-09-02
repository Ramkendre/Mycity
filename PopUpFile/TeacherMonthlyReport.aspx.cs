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

public partial class PopUpFile_TeacherMonthlyReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGird();
        }
    }
    public void LoadGird()
    {
        string MobileNo = Convert.ToString(Request.QueryString["Mobileno"]);
        try
        {
            if (MobileNo == "" || MobileNo == null)
            {
                Response.Redirect("~/udise/Home.aspx");
            }
            else
            {

                string Sql = "Select Top(60) usrFirstName,usrLastName,pk, Message,mobile,shortcode,data,SendDate,FlagStatus from Come2mycity.test inner join UserMaster on "+
                    "Come2mycity.test.mobile= UserMaster.usrMobileNo" +
               " where mobile='" + MobileNo + "' order by pk  desc";
                DataSet ds = cc.ExecuteDataset(Sql);
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();

                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[6].Text.ToString();
                    if (Data == "0")
                    {
                        row.Cells[6].Text = "Correct";
                    }
                    else if (Data == "1")
                    {
                        row.Cells[6].Text = "Incorrect";
                    }
                    else if (Data == "2")
                    {
                        row.Cells[6].Text = "Updated";
                    }
                    else if (Data == "3")
                    {
                        row.Cells[6].Text = "Pending";
                    }
                }
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[5].Text.ToString();
                    Data = cc.DTGet_LocalEvent(Data);
                    row.Cells[5].Text = Data;
                }
            }
        }
        catch (Exception ex)
        {

        }

    }
}

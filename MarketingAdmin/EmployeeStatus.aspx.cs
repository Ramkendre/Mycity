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
using System.IO;
using System.Data.SqlClient;

public partial class MarketingAdmin_EmployeeStatus : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string Userid = Convert.ToString(Session["MarketingUser"]);
        if (Userid == null || Userid == "")
        {
            Response.Redirect("~/MarketingAdmin/Login1.aspx");            
        }
        if (!IsPostBack)
        {
            bindprjnames();
        }        
    }

    public void bindprjnames()
    {
        DataSet ds = new DataSet();
        string sql = "select [prj_Id],[prj_Name] FROM [Come2myCityDB].[come2mycity].[tblProjectList]";
        ds = cc.ExecuteDataset(sql);

        ddlNameofProject.DataSource = ds;
        ddlNameofProject.DataTextField = "prj_Name";
        ddlNameofProject.DataValueField = "prj_Id";
        ddlNameofProject.DataBind();        
        ddlNameofProject.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlNameofProject.SelectedIndex = 0;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sql,user,fname,lname;
        string folderPath;
        string ab = FileUpload1.FileName;
        folderPath = Server.MapPath("NewsFiles\\" + FileUpload1.FileName);
        if (FileUpload1.HasFile)
        {
            string path = "";
            path = Server.MapPath("NewsFiles");
            path = path + "\\" + FileUpload1.FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
                FileUpload1.SaveAs(path);
            }
            else
            {
                FileUpload1.SaveAs(path);
            }
            Response.Write("<script>alert('File Uploaded successfully')</script>");
        }
        else
        {
            Response.Write("<script>alert('File format not recognised')</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File format not recognised')", true);
        }
        string str = Convert.ToString(Session["MobileNumber"]);
        sql = "select usrUserId, usrFirstName, usrLastName from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + str + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            user = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
            fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
            sql = "insert into [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]([usrUserId],[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrSubject],[usrContents],[usrTimeReq],[usrEndDate],[usrSpecificwork],[usrAttachment],[usrWorkStatus],[usrCurrentDate]) values" +
               "('" + user + "','" + fname + "','" + lname + "','" + ddlNameofProject.SelectedItem.Text + "','" + ddlEntrytype.SelectedItem.Text + "','" + txtSubject.Text + "','" + txtContent.Text + "','" + txttime.Text + "','" + txtDate.Text + "','" + ddlworkdate.SelectedItem.Text + "','" + folderPath + "','" + ddlworkstatus.SelectedItem.Text + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')";
            int status = cc.ExecuteNonQuery(sql);
            if (status == 1)
            {
                Response.Write("<script>alert('Inserted Record successfully')</script>");
            }
            clear();
        }
    }
    public void clear()
    {
        ddlNameofProject.SelectedIndex = 0;
        ddlEntrytype.SelectedIndex = 0;
        txtSubject.Text = "";
        txtContent.Text = "";
        txttime.Text = "";
        txtDate.Text = "";
        ddlworkdate.SelectedIndex = 0;
        ddlworkstatus.SelectedIndex = 0;

    }
    
}

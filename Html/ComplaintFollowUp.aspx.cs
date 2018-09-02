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
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

public partial class Html_ComplaintFollowUp : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventCFollowUpBLL objCFBLL = new EventCFollowUpBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
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
                Loadgrid();
                fill();
            }
        }
    }
    public void Loadgrid()
    {
        objCFBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        //objCFBLL.UsrMobileNo1 = Convert.ToString(Session["MobileNo"].ToString());
        //string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
        //string sql = cc.ExecuteScalar(str);
        //objCFBLL.ID1 = Convert.ToString(sql);
        DataSet ds = objCFBLL.LoadgridBLL(objCFBLL);
       gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
        //foreach (GridViewRow row in gvItem.Rows)
        //{
        //    string data = row.Cells[5].Text;
        //    row.Cells[5].Text = data;
        //}
    }
    public void Addrecord()
    {
        try
        {
            string str, str1, sql;
            if(txtStatus.Text!="")
            {
                str = txtStatus.Text;
                 str1 = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str + "'";
                 sql = cc.ExecuteScalar(str1);
            }
            else
            {
                
                str = DDLStatus.SelectedItem.Text;
                str = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str + "'";
                sql = cc.ExecuteScalar(str);
            }
            objCFBLL.UserId1 = Convert.ToString(Session["User"].ToString());
            objCFBLL.CID1 = Convert.ToString(txtCID.Text);
            objCFBLL.Date1 = Convert.ToString(txtDate.Text);
            objCFBLL.Remark1 = Convert.ToString(txtRemark.Text);
            objCFBLL.Status1 = Convert.ToString(sql);
            
            int Status = objCFBLL.AddrecordBLL(objCFBLL);
            if (Status == 1)
            {
                Loadgrid();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event not added Successfully')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CFID = Convert.ToString(lblid.Text);
        if (CFID == "" || CFID == null)
        {
            Addrecord();
        }

    }
    public void fill()
    {
        string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where UserId='" + Session["User"].ToString() + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        DDLStatus.DataSource = ds;
        if(ds.Tables[0].Rows.Count>0)
        {
            DDLStatus.DataValueField = "Id";
        }
        DDLStatus.DataBind();
        DDLStatus.Items.Add("Add New");
        DDLStatus.Items.Add("Select");

        DDLStatus.Items.Insert(0,new ListItem("select","0"));
        DDLStatus.SelectedIndex = 0;

    }
    public void txtchange(DropDownList ddl,TextBox tb)
    {
        string str1 = "select Name,ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where UserId='" + Session["User"].ToString() + "' and Sub_ID='5'";
        DataSet ds = cc.ExecuteDataset(str1);
        //string str = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (Convert.ToString(txtStatus.Text) == Convert.ToString(ds.Tables[0].Rows[i]["Name"]))
            {
                //string abc = txtStatus.Text;
                ViewState["abc"]=txtStatus.Text;
               
            }
        }
        if (Convert.ToString(txtStatus.Text)==Convert.ToString(ViewState["abc"]))
        {
            ScriptManager.RegisterStartupScript(this,typeof(Page),"msg","alert('this type of Status Already Present')",true);
            DDLStatus.Visible = true;
            txtStatus.Visible = false;
            ViewState["abc"] = null;
        }
    
        else
        {
            string st = txtStatus.Text.ToUpper();
            string str3 = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId)values('5','" + st + "','" + Session["User"].ToString() + "')";
            int row = cc.ExecuteNonQuery(str3);

            string str2 = "select Name,ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where UserId='" + Session["User"].ToString() + "'";
            DataSet ds1 = cc.ExecuteDataset(str2);

            DDLStatus.DataSource = ds;
            DDLStatus.DataTextField = "Name";
            DDLStatus.DataValueField = "ID";
            DDLStatus.DataBind();

            DDLStatus.Items.Insert(0, new ListItem("select", "0"));
            DDLStatus.SelectedIndex = 0;

            ddl.Visible = true;
            tb.Visible = false;
        }
    }
    public void cmb(DropDownList ddl,TextBox tb)
    { 
        if(DDLStatus.SelectedItem.Text=="Add New")
        {
            txtStatus.Visible = true;
            tb.Focus();
            tb.Text = "";
            ddl.Visible = false;
        }
    }
    protected void DDLStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb(DDLStatus,txtStatus);
    }
    protected void txtStatus_TextChanged(object sender, EventArgs e)
    {
        txtchange(DDLStatus,txtStatus);
    }
}


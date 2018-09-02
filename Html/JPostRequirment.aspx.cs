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
using System.Data.SqlClient;

public partial class Html_JPostRequirment : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    JPostRequirmentBLL objJPostReqBLL = new JPostRequirmentBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            fillddlSector();
            fillCName();
           
        }
    }
    public void fillCName()
    {
        DataSet ds = new DataSet();
        
        string w = "select [CID],[NameOfComp] FROM [Come2myCityDB].[come2mycity].[tbl_JCompReg]";
        SqlDataAdapter da = new SqlDataAdapter(w,con);
        da.Fill(ds);
        ddlCName.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlCName.DataValueField = "CID";
            ddlCName.DataTextField = "NameOfComp";
        }
        ddlCName.DataBind();
        ddlCName.Items.Add("---Select---");
        ddlCName.SelectedIndex = ddlCName.Items.Count - 1;
        ddlCName.Items[ddlCName.Items.Count - 1].Value = "";
    }
    public void fillddlSector()
    {
        DataSet ds = new DataSet();
        string str = "SELECT [ID],[DivisionName] FROM [Come2myCityDB].[come2mycity].[tbl_JDivision]";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        ddlSISector.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlSISector.DataValueField = "ID";
            ddlSISector.DataTextField = "DivisionName";
        }
        ddlSISector.DataBind();
        ddlSISector.Items.Add("---Select---");
        ddlSISector.SelectedIndex = ddlSISector.Items.Count - 1;
        ddlSISector.Items[ddlSISector.Items.Count - 1].Value = "";

        
    }
    public void fillddlRole()
    {
        DataSet ds = new DataSet();
        
        string s = "select [SID],[NameOfQP] FROM [Come2myCityDB].[come2mycity].[tbl_JSubDivision] where DID=" + ddlSISector.SelectedValue + "";
      
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        da.Fill(ds);
        ddlJRole.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJRole.DataValueField = "SID";
            ddlJRole.DataTextField = "NameOfQP";
        }
        ddlJRole.DataBind();
        ddlJRole.Items.Add("--Select--");
        ddlJRole.SelectedIndex = ddlJRole.Items.Count - 1;
        ddlJRole.Items[ddlJRole.Items.Count - 1].Value = "";
    }
    public void AddRecord()
    {
        string str = "select NameOfComp from [Come2myCityDB].[come2mycity].[tbl_JCompReg] where CID='" + ddlCName.SelectedValue + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        string s = Convert.ToString(ds.Tables[0].Rows[0]["NameOfComp"]);
        objJPostReqBLL.CName1 = Convert.ToString(s);
        objJPostReqBLL.InSector1 = Convert.ToString(ddlSISector.Text);
        objJPostReqBLL.JRole1 = Convert.ToString(ddlJRole.Text);
        objJPostReqBLL.Qualification1 = Convert.ToString(txtQuli.Text);
        objJPostReqBLL.Skill1 = Convert.ToString(txtSkill.Text);
        objJPostReqBLL.JRequirment1 = Convert.ToString(txtreq.Text);
        objJPostReqBLL.VaccancyTill1 = Convert.ToString(txtvacancy.Text);
        objJPostReqBLL.SalaryOffered1 = Convert.ToString(txtSal.Text);
        objJPostReqBLL.FreExp1 = Convert.ToString(txtFreshExp.Text);
        objJPostReqBLL.TrainingOffered1 = Convert.ToString(rbtTrainO.Text);
        objJPostReqBLL.UserId1 = Convert.ToString(Session["User"]);
        string d = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objJPostReqBLL.EntryDate1 = Convert.ToString(d);
        int Status = objJPostReqBLL.AddRecordBLL(objJPostReqBLL);
        if(Status==1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddRecord();
    }
    protected void ddlSISector_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlRole();
    }
}

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
using System.Collections.Generic;

public partial class Html_JCompanyRegistration : System.Web.UI.Page
{

    JCompanyRegBLL objJCompanyRegBLL=new JCompanyRegBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillList();
            fillddl();
            fillddlState();
            fillddlDist();
        }
    }
    public void fillList()
    {
        DataSet ds = new DataSet();
        string str = "select ID,[DivisionName] FROM [Come2myCityDB].[come2mycity].[tbl_JDivision]";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        lbSector.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            lbSector.DataValueField = "ID";
            lbSector.DataTextField = "DivisionName";
        }
        lbSector.DataBind();
        //lbSector.Items.Add = "Select";
        //lbSector.SelectedIndex = lbSector.Items.Count - 1;
        //lbSector.Items[lbSector.Items.Count - 1].Value = "";
       
    }
    public void fillddlState()
    {
        DataSet ds = new DataSet();
        string a = "select [stateId],[stateName] FROM [Come2myCityDB].[dbo].[StateMaster]";
        SqlDataAdapter da = new SqlDataAdapter(a,con);
        da.Fill(ds);
        ddlState.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlState.DataValueField = "stateId";
            ddlState.DataTextField = "stateName";
        }
        ddlState.DataBind();
        ddlState.Items.Add("--Select---");
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        ddlState.Items[ddlState.Items.Count - 1].Value = "";
    }
    public void fillddlDist()
    {
        DataSet ds = new DataSet();
        string str = "select [distId],[distName] FROM [Come2myCityDB].[dbo].[DistrictMaster]";
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        ddlDistrict.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlDistrict.DataValueField = "distId";
            ddlDistrict.DataTextField = "distName";
        }
        ddlDistrict.DataBind();
        ddlDistrict.Items.Add("---Select----");
        ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
        ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = "";
    }
    public void fillddl()
    {
        DataSet ds = new DataSet();
        string s = "select ID,[UnitName] FROM [Come2myCityDB].[come2mycity].[tbl_JUnitName]";
        SqlDataAdapter da = new SqlDataAdapter(s,con);
        da.Fill(ds);
        ddlUnit.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlUnit.DataValueField = "ID";
            ddlUnit.DataTextField = "UnitName";
        }
        ddlUnit.DataBind();
        ddlUnit.Items.Add("Select");
        ddlUnit.SelectedIndex = ddlUnit.Items.Count - 1;
        ddlUnit.Items[ddlUnit.Items.Count-1].Value="";
        
    }
    public void AddRecord()
    {
        try
        {
            objJCompanyRegBLL.NameOfComp1 = Convert.ToString(txtCName.Text);
            objJCompanyRegBLL.TypeOfUnit1 = Convert.ToString(ddlUnit.Text);
            objJCompanyRegBLL.DirectName1 = Convert.ToString(txtDName.Text);
            objJCompanyRegBLL.MobileNo1 = Convert.ToString(txtMobileNo.Text);
            objJCompanyRegBLL.EmailId1 = Convert.ToString(txtEmail.Text);
            objJCompanyRegBLL.FAddress1 = Convert.ToString(txtFAdd.Text);
            objJCompanyRegBLL.State1 = Convert.ToString(ddlState.Text);
            objJCompanyRegBLL.District1 = Convert.ToString(ddlDistrict.Text);
            objJCompanyRegBLL.Taluka1 = Convert.ToString(txtTaluka.Text);
            objJCompanyRegBLL.City1 = Convert.ToString(txtCity.Text);
           //IList<string> selectedItems = new List<string>();
           //try
           //{
           //    foreach (ListItem item in lbSector.Items)
           //    {
           //        if (item.Selected == true)
           //        {
           //            selectedItems.Add(item.Value + ", ");

           //        }
           //    }
           //}
   //----------------------Code For Multiple Dropdown value fetching-------------------------------
            string selectedItems = "";
            try
            {
                foreach (ListItem item in lbSector.Items)
                {
                    if (item.Selected == true)
                    {
                        selectedItems = selectedItems + item.Value + ", ";

                    }
                }
            }
            catch (Exception ex)
            {

            }
            objJCompanyRegBLL.Sectors1 = Convert.ToString(selectedItems.ToString());
            objJCompanyRegBLL.UserId1 = Convert.ToString(Session["User"]);
            string c = DateTime.Now.Date.ToString("yyyy-MM-dd");
            objJCompanyRegBLL.EntryDate1 = Convert.ToString(c);




            int Status = objJCompanyRegBLL.AddRecordBLL(objJCompanyRegBLL);
            if (Status == 1)
            {
                //LoadGrid();
                //Clear();
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
        AddRecord();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string message = "";
        foreach (ListItem item in lbSector.Items)
        {
            if (item.Selected)
            {
                message += item.Text + " " + item.Value + "\\n";
            }
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MarketingAdmin_ALL_Report : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    CommonCode cc = new CommonCode();
    string sql = string.Empty;
    string mobileNo = "8087371027";
    string TID;
    string mob = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLBindName();
            DDLBindProject();
            loginSession();
        }       
    }

    
    public void DDLBindName()
    {
        cmd.CommandText = "select [EmpMobNo],[FirstName],[LastName] from [EzeeMarketing_AddEmpPermission]";
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (con.State == ConnectionState.Closed)
        {
            con.Close();
        }
        da.SelectCommand = cmd;
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpName.DataSource = ds.Tables[0];
            drpName.DataTextField = "FirstName";
            drpName.DataValueField = "EmpMobNo";
            drpName.DataBind();
            drpName.Items.Add("--Select--");
            drpName.SelectedIndex = drpName.Items.Count - 1;
        }
    }

    public void DDLBindProject()
    {
        DataSet ds52 = new DataSet();
        cmd.CommandText = "select [ItemId],[ItemName],[AdminMobNo] from [Come2myCityDB].[dbo].[EzeeMarketingAddItem] where [AdminMobNo]='8087371027' and [GroupID]=4";//"select [ItemId],[ItemName],[GroupID] from [Come2myCityDB].[dbo].[EzeeMarketingAddItem] where [AdminMobNo]='" + mobileNo .ToString()+ "' and [GroupID]=4";// "select [EmpMobNo],[FirstName],[LastName] from [EzeeMarketing_AddEmpPermission]";
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (con.State == ConnectionState.Closed)
        {
            con.Close();
        }
        da.SelectCommand = cmd;
        da.Fill(ds52);
        if (ds52.Tables[0].Rows.Count > 0)
        {
            ddprojectWise.DataSource = ds52.Tables[0];
            ddprojectWise.DataTextField = "ItemName";
            ddprojectWise.DataValueField = "ItemId";
            ddprojectWise.DataBind();
            ddprojectWise.Items.Add("--Select--");
            ddprojectWise.SelectedIndex = ddprojectWise.Items.Count - 1;
        }
    }

    public string loginSession()
    {
        if (Session["Mobile"] != null)
        {
            mob = Session["Mobile"].ToString();
        }
        else
        {
            Response.Redirect("~/default.aspx");
        }
        return mob;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //if (drpName.SelectedItem.ToString() != "--Select--" && ddprojectWise.SelectedItem.ToString().Equals("--Select--") && txtDate.Text.Equals("") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='"+drpName.SelectedItem.ToString()+"'";
            //}
            //if (drpName.SelectedItem.ToString() != "" && ddprojectWise.SelectedItem.ToString() != "--Select--" && txtDate.Text.Equals("") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='"+drpName.SelectedItem.ToString()+"' AND EMW.[ProjectId]='"+ddprojectWise.SelectedValue.ToString()+"'";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && ddprojectWise.SelectedItem.ToString() != "--Select--" && txtDate.Text != string.Empty && ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='"+txtDate.Text+"'";
            //}

            //if (txtDate.Text != "" && ddprojectWise.SelectedItem.ToString().Equals("") && drpName.SelectedItem.ToString().Equals("") && ddlStatuswise.SelectedItem.ToString().Equals(""))
            //{ 

            //}       
            //if (ddlStatuswise.SelectedItem.ToString() != "" && ddprojectWise.SelectedItem.ToString().Equals("") && txtDate.Text != "")
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[ProjectWork]='"+ddlStatuswise.SelectedItem.ToString()+"'";
            //}

            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString() != "" && drpName.SelectedItem.ToString().Equals("--Select--"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";    
            //}
            ////
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Pending"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Continued"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Partial"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("complete"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Proposed"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Dismissed"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}
            //if (ddprojectWise.SelectedItem.ToString() != "" && txtDate.Text != "" && ddlStatuswise.SelectedItem.ToString().Equals("Cancled"))
            //{
            //    cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW INNER JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] where EMW.[EmployeeName]='" + drpName.SelectedItem.ToString() + "' AND EMW.[ProjectId]='" + ddprojectWise.SelectedValue.ToString() + "' AND EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "' OR EMW.[ProjectDetails]='" + ddlWorktypewise.SelectedItem.ToString() + "' ";
            //}

            StringBuilder strobj = new StringBuilder();

            string namewisesrch = " EMW.[EmployeeName]= '" + Convert.ToString(drpName.SelectedItem) + "' AND ";
            string projectwisesrch = "EMW.[ProjectId]='" + Convert.ToString(ddprojectWise.SelectedValue) + "' AND ";
            string datesrch = "EMW.[ProjectDate]='" + txtDate.Text + "' AND ";
            string wrktypesrch = "EMW.[ProjectDetails]='" + Convert.ToString(ddlWorktypewise.SelectedItem) + "' AND ";
            string statuswisesrch = "EMW.[ProjectWork]='" + Convert.ToString(ddlStatuswise.SelectedItem) + "' AND ";
            strobj.Append(" Where ");
            if (Convert.ToString(drpName.SelectedItem) != "")
            {
                if (drpName.SelectedItem.Text != "--Select--")
                {
                    if (ddprojectWise.SelectedItem.ToString().Equals("--Select--") && txtDate.Text == string.Empty && ddlStatuswise.SelectedItem.ToString().Equals("--Select--"))//if (projectwisesrch == "--Select--" && datesrch == "" && wrktypesrch == null && statuswisesrch== "--Select--")
                    {//&& ddlWorktypewise.SelectedValue == null
                        strobj.Append(namewisesrch.Remove(namewisesrch.Length - 4));
                    }
                    else
                    {
                        strobj.Append(namewisesrch);
                    }
                }
                else
                {
                    strobj.Append("");
                }
            }
            if (Convert.ToString(ddprojectWise.SelectedItem) != "")
            {
                if (ddprojectWise.SelectedItem.Text != "--Select--")
                {
                    if (txtDate.Text == string.Empty && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString() != "--Select--")//if (datesrch == "" && wrktypesrch == null && statuswisesrch == "--Select--" && namewisesrch == "--Select--")
                    {//&& ddlWorktypewise.SelectedValue == null
                        strobj.Append(projectwisesrch.Remove(projectwisesrch.Length - 4));
                    }
                    else if (txtDate.Text == string.Empty && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--"))
                    {
                        strobj.Append(projectwisesrch.Remove(projectwisesrch.Length - 4));
                    }
                    else
                    {
                        strobj.Append(projectwisesrch);
                    }
                }
                else
                {
                    strobj.Append("");
                }
            }
            if (Convert.ToString(txtDate.Text) != "")
            {
                if (ddprojectWise.SelectedItem.Text != "--Select--")
                {
                    if (ddlWorktypewise.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString().Equals("--Select--"))// if (wrktypesrch == null && statuswisesrch == "--Select--" && namewisesrch == "--Select--" && projectwisesrch == "--Select--")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else if (ddlWorktypewise.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString() != "--Select--" && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString() != ("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else if (txtDate.Text != string.Empty && ddlStatuswise.SelectedItem.ToString() != "--Select--" && drpName.SelectedItem.ToString() != "" && ddprojectWise.SelectedItem.ToString() != "")
                    {
                        strobj.Append(datesrch.Remove(datesrch.Length - 4));
                    }
                    else
                    {
                        strobj.Append(datesrch);
                    }
                }
                else if (drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString().Equals("--Select--") && txtDate.Text != string.Empty && ddlStatuswise.SelectedItem.ToString().Equals("--Select--"))
                {
                    strobj.Append(datesrch.Remove(datesrch.Length - 4));
                }
                else
                {
                    strobj.Append("");
                }
            }

            if (Convert.ToString(ddlWorktypewise.SelectedItem) != "")
            {
                if (ddlWorktypewise.SelectedItem.Text != "--Select--")
                {
                    if (datesrch == "" && namewisesrch == "--Select--" && statuswisesrch == "--Select--" && projectwisesrch == "--Select--")
                    {
                        strobj.Append(wrktypesrch.Remove(wrktypesrch.Length - 4));
                    }
                    else
                    {
                        strobj.Append(wrktypesrch);
                    }
                }
                else
                {
                    strobj.Append("");
                }
            }
            if (Convert.ToString(ddlStatuswise.SelectedItem) != "")
            {
                if (ddlStatuswise.SelectedItem.Text != "--Select--")
                {
                    if (txtDate.Text == string.Empty && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString().Equals("--Select--"))//if (datesrch == "" && wrktypesrch == null && namewisesrch == "--Select--" && projectwisesrch == "--Select--")
                    {
                        strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    }
                    else if (drpName.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.Text != "--Select--" && txtDate.Text == string.Empty && ddprojectWise.SelectedItem.ToString() != "--Select--" && ddlWorktypewise.SelectedItem.ToString().Equals("--Select--"))
                    {
                        strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    }
                    //if (ddlWorktypewise.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString().Equals("--Select--"))// if (wrktypesrch == null && statuswisesrch == "--Select--" && namewisesrch == "--Select--" && projectwisesrch == "--Select--")
                    //{
                    //    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    //}
                    //else if (ddlWorktypewise.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    //{
                    //    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    //}
                    //else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString() != "--Select--" && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    //{
                    //    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    //}
                    //else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString().Equals("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    //{
                    //    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    //}
                    ////else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString() != ("--Select--") && drpName.SelectedItem.ToString().Equals("--Select--") && ddprojectWise.SelectedItem.ToString() != "--Select--")
                    ////{
                    ////    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    ////}
                    //else if (ddlWorktypewise.SelectedItem.ToString().Equals("--Select--") && ddlStatuswise.SelectedItem.ToString()!=("--Select--") && drpName.SelectedItem.ToString()!=("--Select--") && ddprojectWise.SelectedItem.ToString()!=("--Select--") && txtDate.Text!=string.Empty)
                    //{
                    //    strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    //}
                    else if (drpName.SelectedItem.ToString() != "--Select--" && ddlStatuswise.SelectedItem.Text != "--Select--" && txtDate.Text == string.Empty && ddprojectWise.SelectedItem.ToString() != "--Select--" && ddlWorktypewise.SelectedItem.ToString() != ("--Select--"))
                    {
                        strobj.Append(statuswisesrch.Remove(statuswisesrch.Length - 4));
                    }
                    else if (txtDate.Text != string.Empty && ddlStatuswise.SelectedItem.ToString() != "--Select--" && drpName.SelectedItem.ToString() != "" && ddprojectWise.SelectedItem.ToString() != "")
                    {
                        string data2 = string.Empty;
                        data2 = "EMW.[ProjectDate]='" + txtDate.Text + "' AND EMW.[ProjectWork]='" + ddlStatuswise.SelectedItem.ToString() + "'";
                        strobj.Append(data2);
                    }
                    else
                    {
                        strobj.Append(statuswisesrch);
                    }
                }
                else
                {
                    strobj.Append("");
                }
            }


            cmd.CommandText = "SELECT  EMW.[ReportId],EMW.[ProjectId],EMW.[UserMobNo],EMW.[ProjectDetails],EMW.[ProjectContents],EMW.[ProjectTime],EMW.[ProjectDate],EMW.[ProjectQuantity],EMW.[ProjectWork],EMW.[ParentId],EMW.[Imei],EMW.[EmployeeName] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] AS EMW LEFT JOIN [Come2myCityDB].[dbo].[EzeeMarketingAddItem] AS EMAI ON  EMW.[ReportId]=EMAI.[ItemId] " + strobj + "";

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvReport.DataSource = ds.Tables[0];
                gvReport.DataBind();
            }
            else
            {
                gvReport.EmptyDataText = "No Data Found !!!";
                gvReport.DataBind();
            }
        }
        catch
        {
            gvReport.EmptyDataText = "No Data Found !!!";
            gvReport.DataBind();
        }
    }

    protected void ddprojectWise_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + mobileNo.ToString() + "' and [GroupID]=5";
            ds = cc.ExecuteDataset(sql);
            ddlWorktypewise.DataSource = ds.Tables[0];
            ddlWorktypewise.DataTextField = "ItemName";
            ddlWorktypewise.DataValueField = "ItemId";
            ddlWorktypewise.DataBind();
            ddlWorktypewise.Items.Add("--Select--");
            ddlWorktypewise.SelectedIndex = ddlWorktypewise.Items.Count - 1;
        }
        catch { }
    }
    protected void gvReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddprojectWise.DataValueField= gvReport.SelectedRow.Cells[2].Text;
        TID = ddprojectWise.DataValueField.ToString();
        //Application["TID"] = TID;
        lblMsg.Visible = true;
        lblMsg.Text = "Trail For Record No='" + TID + "'";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Trail For Record No=" + TID + "')", true);
        Response.Redirect("WorkReport.aspx?TID="+TID);
    }
    protected void LinkRemark_Click(object sender, EventArgs e)
    {
        string RemarkID = string.Empty;
        string ReportId = string.Empty;
        string ParentId = string.Empty;
        LinkButton lnkRemove = (LinkButton)sender;
        RemarkID = lnkRemove.CommandArgument;

        string id = RemarkID;
        string[] ary = id.Split(',');
        ReportId = Convert.ToString(ary[0].Trim());
        ParentId = Convert.ToString(ary[1].Trim());
        lblMsg.Visible = true;
        lblMsg.Text = "Trail For Record No='" + ReportId + "'";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Trail For Record No=" + ReportId + "')", true);
        Response.Redirect("WorkReport.aspx?ReportId=" + ReportId);
    }
}
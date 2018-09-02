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

public partial class MarketingAdmin_Rpt_EmpforAdmin : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }
    protected void gvEmpWorkStatus_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvEmpWorkStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpWorkStatus.PageIndex = e.NewPageIndex;
        load();
        //bindgridofwork();
    }
    protected void ddlRoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql,usrid = string.Empty;
        sql = "select Uid1 from [Come2myCityDB].[come2mycity].[MartketingSubuser] where UseRole='"+ddlRoleList.SelectedItem.Text+"'";
        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            usrid += "'" + ds.Tables[0].Rows[0][0].ToString() + "'";
            for (int i = 1; ds.Tables[0].Rows.Count > i; i++)
                usrid += ",'" + ds.Tables[0].Rows[i][0].ToString() + "'";
            sql = "select [usrAutoId],[usrUserId],[usrFirstName]+' '+[usrLastName] as fullname FROM [Come2myCityDB].[dbo].[UserMaster] where usrUserId in (" + usrid + ")";
            ds = cc.ExecuteDataset(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlEmpList.DataSource = ds;
                ddlEmpList.DataTextField = "fullname";
                ddlEmpList.DataValueField = "usrAutoId";
                ddlEmpList.DataBind();
                ddlEmpList.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            Response.Write("<script>alert('User not Found...!!!')</script>");
        }
    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {       
        //string dt = txtDate.Text;

        load();
    }
    public void load()
    {
        string sqlqry, fn = string.Empty, ln = string.Empty;
        string sql, usrid = string.Empty;
        sql = "select Uid1 from [Come2myCityDB].[come2mycity].[MartketingSubuser] where UseRole='" + ddlRoleList.SelectedItem.Text + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            
            usrid += "'" + ds.Tables[0].Rows[0][0].ToString() + "'";
            for (int i = 1; ds.Tables[0].Rows.Count > i; i++)
                usrid += ",'" + ds.Tables[0].Rows[i][0].ToString() + "'";
            if (rdo_sortbtn.SelectedValue == "1" || rdo_sortbtn.SelectedValue == "2" || rdo_sortbtn.SelectedValue == "4")
            {
                sqlqry = "select EmpId,[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrContents],[usrTimeReq],[usrEndDate],[usrAttachment],[usrWorkStatus] FROM [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]" +
                    "where usrUserId in (" + usrid + ") and (([usrCurrentDate]='" + txtdayDate.Text + "')or([usrCurrentDate]>='" + txtmnthfromDate.Text + "' and [usrCurrentDate]<='" + txtmnthtoDate.Text + "')or([usrPrjName]='" + ddlprjwise.SelectedItem.Text + "'))";
                ds = cc.ExecuteDataset(sqlqry);
                gvEmpWorkStatus.DataSource = ds;
                gvEmpWorkStatus.DataBind();
            }
            else if (rdo_sortbtn.SelectedValue == "3")
            {
                //bindgridofwork();
                
                string dt = txtempDate.Text;
                string fullname = ddlEmpList.SelectedItem.Text;
                string[] fullnames = fullname.Split(' ');

                fn = fullnames[0];
                ln = fullnames[1];
                sqlqry = "select EmpId,[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrContents],[usrTimeReq],[usrEndDate],[usrAttachment],[usrWorkStatus] FROM [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]" +
                   "where  ([usrFName]='" + fn + "' and [usrLName]='" + ln + "' and ([usrCurrentDate]='" + txtempDate.Text + "'))";
                ds = cc.ExecuteDataset(sqlqry);
                gvEmpWorkStatus.DataSource = ds;
                gvEmpWorkStatus.DataBind();
            }

        }
        else
        {
            gvEmpWorkStatus.DataSource = null;
            gvEmpWorkStatus.DataBind();
            Response.Write("<script>alert('This date of record not found...!!!')</script>");
        }

        //bindgridofwork();
    }
    
    public void bindgridofwork()
    {
        try
        {
            string sqlqry, fn= string.Empty, ln = string.Empty;
            string dt = txtempDate.Text;
            string fullname = ddlEmpList.SelectedItem.Text;
            string[] fullnames = fullname.Split(' ');
                          
                fn = fullnames[0];
                ln = fullnames[1];

            sqlqry = "select [usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrContents],[usrTimeReq],[usrEndDate],[usrAttachment],[usrWorkStatus] FROM [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt] where ([usrFName]='" + fn + "' and [usrLName]='" + ln + "') or ([usrFName]='" + fn + "' and [usrLName]='" + ln + "' and [usrCurrentDate]='" + dt + "') ";
            DataSet ds = cc.ExecuteDataset(sqlqry);

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvEmpWorkStatus.DataSource = ds;
                gvEmpWorkStatus.DataBind();
            }
            else
            {
                gvEmpWorkStatus.DataSource = null;
                gvEmpWorkStatus.DataBind();
                Response.Write("<script>alert('This date of record not found...!!!')</script>");
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void rdo_sortbtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtdayDate.Text = "";
        txtempDate.Text = "";
        txtmnthfromDate.Text = "";
        txtmnthtoDate.Text = "";
        ddlprjwise.SelectedValue = "0";
        ddlEmpList.SelectedValue = "0";
        if (rdo_sortbtn.SelectedValue == "1")
        {
            pnldaywise.Visible = true;
            pnlempwise.Visible = false;
            pnlmonthwise.Visible = false;
            pnlprojectwise.Visible = false;
        }
        else if (rdo_sortbtn.SelectedValue == "2")
        {
            pnldaywise.Visible = false;
            pnlempwise.Visible = false;
            pnlmonthwise.Visible = true;
            pnlprojectwise.Visible = false;
        }
        else if (rdo_sortbtn.SelectedValue == "3")
        {
            pnldaywise.Visible = false;
            pnlempwise.Visible = true;
            pnlmonthwise.Visible = false;
            pnlprojectwise.Visible = false;
        }
        else if (rdo_sortbtn.SelectedValue == "4")
        {
            pnldaywise.Visible = false;
            pnlempwise.Visible = false;
            pnlmonthwise.Visible = false;
            pnlprojectwise.Visible = true;
        }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        //string Path = "";
        //Path = Server.MapPath("NewsFiles");
        //path = path + "\\" + FileUpload1.FileName;
        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
}

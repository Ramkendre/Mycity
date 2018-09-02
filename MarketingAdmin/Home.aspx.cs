using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

public partial class MarketingAdmin_MarketingHome : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            loadItem();
        }
        if (Convert.ToString(Session["MarketingUser"]) == "")
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnsave_Click1(object sender, EventArgs e)
    {
        try
        {
            // string sql = "update AdminSubMarketingSubUser set mainrole=0 where  friendid='" + Convert.ToString(Session["MarketingUser"]) + "' ";
            // sql =  sql + "update AdminSubMarketingSubUser set mainrole=1 where  friendid='" + Convert.ToString(Session["MarketingUser"]) + "' and roleid='" + Convert.ToString(Session["RoleId"])+"'";
            // int i = cc.ExecuteNonQuery(sql);
            //if(i>=1)               
            //{
            lblError.Text = "Role Updated Succesfully........";
            //    lblError.Visible = true;
                Session["RoleId"] = ddlrole.SelectedValue;
               
                lblError.Text = "Role Updated Succesfully........";
                lblError.Visible = true;
            //}

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public void loadItem()
    {

        try
        {
            string vSQl = "select distinct asm.roleid,SubMenuPermission.roleid as id, SubMenuPermission.RoleName from  [Come2myCityDB].[come2mycity].[AdminSubMarketingSubUser]  asm " +
                             " inner join [Come2myCityDB].[come2mycity].[SubMenuPermission] on [Come2myCityDB].[come2mycity].[SubMenuPermission].Roleid=asm.roleid " +
                             " where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";

            DataSet ds = cc.ExecuteDataset(vSQl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlrole.DataSource = ds.Tables[0];
                ddlrole.DataTextField = "RoleName";
                ddlrole.DataValueField = "id";
                ddlrole.DataBind();
                ddlrole.Items.Add("---Select---");
                ddlrole.SelectedIndex = ddlrole.Items.Count - 1;
                ddlrole.Items[ddlrole.Items.Count - 1].Value = "";

            }
        }
        catch (Exception ex)
        {

        }
    }
}

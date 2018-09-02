using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Role : System.Web.UI.Page
{

    Role role = new Role();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getinfo();
            getRole();
        }
      
    }

   


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = Convert.ToString(lblId.Text.ToString());

        if (Id == "" || Id == null)
        {
            AddNew();
        }
        else
        {
            Update(Id);
            btnSubmit.Text = "Submit";
            lblError.Text = "";
           
        }
    }
    private void AddNew()
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtRoleName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the Role Name";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Role Name')", true);
            }
            else
            {
                string Sql = "Select Roleid from [Come2myCityDB].[come2mycity].submenuPermission where RoleName='" + txtRoleName.Text.ToString() + "'";
                string Id = Convert.ToString(cc.ExecuteScalar(Sql));
                if (!(Id == null || Id == ""))
                {
                    lblError.Visible = true;
                    lblError.Text = "This Name is already exist";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                    lblError.Text = "";
           
                }
                else
                {

                    string sql11 = "select roleid,referencerole from [Come2myCityDB].[come2mycity].submenuPermission where rolename='" + ddlRole.SelectedItem.Text + "' ";
                    DataSet ds = cc.ExecuteDataset(sql11);
                    string refrole = Convert.ToString(ds.Tables[0].Rows[0]["referencerole"]);
                    if (refrole == "")
                    {
                        string roleid = Convert.ToString(ds.Tables[0].Rows[0]["roleid"]);
                        refrole = roleid;
                    }
                    if (ddlRole.SelectedValue == "0")
                    {
                        refrole = "";
                    }

                    Sql = "Insert into [Come2myCityDB].[come2mycity].submenuPermission(RoleName,RoleDescription,PageAccessPerm,UnderRole,referencerole) Values ('" + txtRoleName.Text.ToString() + "','" + txtRoleName.Text.ToString() + "','','" + ddlRole.SelectedValue + "','" + refrole.ToString() + "') ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtRoleName.Text = "";
                    txtRoleDescription.Text = "";

                    lblError.Visible = true;
                    getinfo();
                    lblError.Text = "Role Added Successfully";
                    lblError.Visible = false;
           
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role added successfully')", true);
                    getRole();
                    getinfo();
                    

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role not added')", true);
        }
    }


    public void getinfo()
    {
        try
        {
            DataSet ds = role.GetAllRole();
            gvRole.DataSource = ds.Tables[0];
            gvRole.DataBind();
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void getRole()
    {
        try
        {
            string sql = "select Roleid,RoleName,RoleDescription from [Come2myCityDB].[come2mycity].submenuPermission";
            DataSet ds = cc.ExecuteDataset(sql);
            ddlRole.DataSource = ds.Tables[0];
            
            ddlRole.DataTextField = "RoleName";
            ddlRole.DataValueField = "Roleid";
            ddlRole.DataBind();
            ddlRole.Items.Add("--Select--");
            ddlRole.SelectedIndex = ddlRole.Items.Count - 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void Update(string Id)
    {
        CommonCode cc = new CommonCode();
        try
        {
            if (txtRoleName.Text == "")
            {
                lblError.Visible = true;
                lblError.Text = "Please Enter the role name";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Role Name')", true);
            }
            else
            {
                string Sql = "Select RoleId from [Come2myCityDB].[come2mycity].submenuPermission where RoleName='" + txtRoleName.Text.ToString() + "' and RoleId=" + Id + "";
                string Id1 = Convert.ToString(cc.ExecuteScalar(Sql));
                //if (!(Id1 == null || Id1 == ""))
                //{
                //    lblError.Visible = true;
                //    lblError.Text = "This Name is already exist";
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                //}
                //else
                //{
                Sql = "Update [Come2myCityDB].[come2mycity].submenuPermission set RoleName='" + txtRoleName.Text.ToString() + "',UnderRole='" + ddlRole.SelectedValue + "',RoleDescription='" + txtRoleDescription.Text + "' where RoleId=" + Id + "  ";
                    int flag = cc.ExecuteNonQuery(Sql);
                    txtRoleName.Text = "";
                    txtRoleDescription.Text = "";
                    getinfo();
                    lblError.Visible = true;
                    lblError.Text = "Role updated Successfully";
                    getinfo();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role updated successfully')", true);

                    
                    lblId.Text = "";
                    lblError.Visible = false;
           
                //}
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Role not Updated')", true);
        }
    }
    protected void gvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRole.PageIndex = e.NewPageIndex;
        getinfo();
    }
    protected void gvRole_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                btnSubmit.Text = "Update";
                string Id = Convert.ToString(e.CommandArgument);
                lblId.Text = Id;
                string Sql = "Select RoleId, RoleName,RoleDescription,UnderRole from [Come2myCityDB].[come2mycity].subMenuPermission where RoleId=" + Id + "";
                try
                {
                    DataSet ds = cc.ExecuteDataset(Sql);
                    txtRoleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                    txtRoleDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoleDescription"]);
                    ddlRole.SelectedValue  = Convert.ToString(ds.Tables[0].Rows[0]["UnderRole"]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (Convert.ToString(e.CommandName) == "Assign")
            {
                string Id = Convert.ToString(e.CommandArgument);
                Response.Redirect("AssignMenu.aspx?Id=" + Id + "");
            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtRoleName.Text = "";
            lblId.Text = "";
            btnSubmit.Text = "Submit";
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }
    protected void gvRole_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_AssignMenu : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            string RoleId = Convert.ToString(Request.QueryString["id"]);
            this.getInitialData(RoleId);
            
            
        }
       
    }
   

    private void getInitialData(string RoleId)
    {
        //For Loading parent Menu
        //string Sql = "Select MenuId, MenuName from Menu";
        //try
        //{
        //    DataSet ds = cc.ExecuteDataset(Sql);
        //    lstMainMenu.DataSource = ds.Tables[0];
        //    lstMainMenu.DataValueField = "MenuId";
        //    lstMainMenu.DataTextField = "MenuName";
        //    lstMainMenu.DataBind();
          
        //}
        string Sql = "Select pageid,pagename from [Come2myCityDB].[come2mycity].PageMenuMaster";
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            lstMainMenu.DataSource = ds.Tables[0];
            lstMainMenu.DataValueField = "pageid";
            lstMainMenu.DataTextField = "pagename";
            lstMainMenu.DataBind();

        }
        catch(Exception ex){}

        //For Loading the initial menu
        Sql = "Select RoleId, RoleName,PageAccessPerm from [Come2myCityDB].[come2mycity].submenuPermission where RoleId=" + RoleId + "";
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            txtRoleName.Text= Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            string MenuId = Convert.ToString(ds.Tables[0].Rows[0]["PageAccessPerm"]);

            MenuId = MenuId.Replace(",", "','");
            Sql = "Select pageid, pagename from [Come2myCityDB].[come2mycity].PageMenuMaster where pageid in('" + MenuId + "') ";
            ds = cc.ExecuteDataset(Sql);
            lstAssignedMenu.DataSource = ds.Tables[0];
            lstAssignedMenu.DataTextField = "pagename";
            lstAssignedMenu.DataValueField = "pageid";
            lstAssignedMenu.DataBind();

        }
        catch (Exception ex) { }
    }


    
   
    
    protected void btnRight_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (ListItem lst in lstMainMenu.Items)
            {
                if (lst.Selected)
                {
                    int flag = 0;
                    foreach (ListItem lst1 in lstAssignedMenu.Items)
                    {
                        if (lst.Value == lst1.Value)
                        {
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        lstAssignedMenu.Items.Add(lst);
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnLeft_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (ListItem lst in lstAssignedMenu.Items)
            {
                if (lst.Selected)
                {
                    lstAssignedMenu.Items.Remove(lst);
                }
            }
        }
        catch (Exception ex)
        { }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
        if (lstAssignedMenu.Items.Count==0)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select atleast one Menu')", true);
            lblError.Visible = true;
            lblError.Text = "Please Select atleast one menu";
        }
        else
        {
            try
            {
                string MenuId = "";
                foreach (ListItem lst in lstAssignedMenu.Items)
                {
                    MenuId = MenuId + "," + lst.Value.ToString();
                }
                if (MenuId.Length > 1)
                {
                    MenuId = MenuId.Substring(1);
                }
                    string RoleId = Convert.ToString(Request.QueryString["Id"]);

                    string Sql = "Update [Come2myCityDB].[come2mycity].submenuPermission set PageAccessPerm='" + MenuId + "' where RoleId=" + RoleId + "";
                int count = cc.ExecuteNonQuery(Sql);
                if (count == 1)
                {
                   lblError.Visible = true;
                    lblError.Text = "Menu Assigned Succesfully .";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Menu Assigned Succesfully')", true);
                    lblError.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Menu Assigned Succesfully')", true);
                lblError.Visible = false;
                lblError.Text = "Menu Assigned Succesfully.";
                lstAssignedMenu.Text = "";
            }
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Role.aspx");
    }
}

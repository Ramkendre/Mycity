using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_UserList : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            LoadValue();
            count();
            LoadValueDeactive();
            countdeactive();
        }

    }

    private void count()
    {

        try
        {

            string mono = Convert.ToString(Session["Mobile"]);

            string s = "select count(*) from MartketingSubuser where MUMono='" + mono + "' and Active='1'";
            string a = cc.ExecuteScalar(s);
            lblActiveCount.Text = "" + a.ToString();


        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void countdeactive()
    {

        try
        {

            string mono = Convert.ToString(Session["Mobile"]);

            string s = "select count(*) from MartketingSubuser ms inner join UserMaster um on ms.Uid1=um.usrUserId  where ms.MUMono='" + mono + "' and Active='0'";
            string a = cc.ExecuteScalar(s);
            lblDeactiveCount.Text = "" + a.ToString();


        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    private void LoadValue()
    {
        try
        {
            string mono = Convert.ToString(Session["Mobile"]);
            int a = 1;
            string s = "select MID,RoleName,usrFirstName,usrMobileNo,city,District from MartketingSubuser inner join usermaster" +
                        " on MartketingSubuser.Uid1=usermaster.usrUserid inner join submenuPermission" +
                        " on MartketingSubuser.RoeId=submenuPermission.RoleId" +
                        " where MartketingSubuser.MUMono='"+mono+"' and Active=1 order by MID desc";
            DataSet ds = cc.ExecuteDataset(s);
            gvUser.DataSource = ds.Tables[0];
            gvUser.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    private void LoadValueDeactive()
    {
        try
        {
            string mono = Convert.ToString(Session["Mobile"]);

            //string s = " select ms.MID,um.usrFirstName,ms.city,ms.UseRole,um.usrMobileNo from MartketingSubuser ms inner join UserMaster um on ms.Uid1=um.usrUserId  where ms.MUMono='" + mono + "' and Active='0' order by ms.MID desc";
            string s = "select MID,RoleName,usrFirstName,usrMobileNo,city,District from MartketingSubuser inner join usermaster" +
                        " on MartketingSubuser.Uid1=usermaster.usrUserid inner join submenuPermission" +
                        " on MartketingSubuser.RoeId=submenuPermission.RoleId" +
                        " where MartketingSubuser.MUMono='" + mono + "' and Active=0 order by MID desc";
            DataSet ds = cc.ExecuteDataset(s);
            gvDeactive.DataSource = ds.Tables[0];
            gvDeactive.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        LoadValue();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../MarketingAdmin/AddNewUser.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                Response.Redirect("../MarketingAdmin/AddNewUser.aspx?id=" + Id);


            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    protected void gvDeactive_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId1.Text = Id;
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                Response.Redirect("../MarketingAdmin/AddNewUser.aspx?id=" + Id);


            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    protected void gvDeactive_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}


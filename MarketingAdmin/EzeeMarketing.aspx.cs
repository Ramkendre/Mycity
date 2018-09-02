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

public partial class MarketingAdmin_EzeeMarketing : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (txtusrMobileNo.Text != "" || txtusrMobileNo.Text != null)
            {
                if (ddlusr.SelectedItem.Text == "User")
                {
                    string sql = "SELECT [Usr_mobile],[Cust_mobile],[F_name],[L_name],[Firm_name],[C_Type],[email],[Adm_mobile] FROM [Come2myCityDB].[dbo].[EzeeMarketingCustdetails] where Usr_mobile = '" + Convert.ToString(txtusrMobileNo.Text) + "'";
                    ds = cc.ExecuteDataset(sql);

                    if (ds != null)
                    {
                        gvUse.DataSource = ds;
                        gvUse.DataBind();
                    }
                }
                else if (ddlusr.SelectedItem.Text == "Admin")
                {
                    string sql = "SELECT [Usr_mobile],[Cust_mobile],[F_name],[L_name],[Firm_name],[C_Type],[email],[Adm_mobile] FROM [Come2myCityDB].[dbo].[EzeeMarketingCustdetails] where Adm_mobile = '" + Convert.ToString(txtusrMobileNo.Text) + "'";
                    ds = cc.ExecuteDataset(sql);

                    if (ds != null)
                    {
                        gvUse.DataSource = ds;
                        gvUse.DataBind();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Select The User Type')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Please enter the Mobile number')</script>");
            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void btnFeedback_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds1 = new DataSet();
            if (txtusrMobileNo.Text != "" || txtusrMobileNo.Text != null)
            {
                if (ddlusr.SelectedItem.Text == "User")
                {
                    string sql = "SELECT [FId],[FeedBack_Desc],[Points],[ReminderDare],[Admin_Num],[Usr_mobile],[Cust_mobile]FROM [Come2myCityDB].[dbo].[EzeeMarketing_FeedBack] where Usr_mobile = '" + txtusrMobileNo.Text + "'";
                    ds1 = cc.ExecuteDataset(sql);

                    if (ds1 != null)
                    {
                        gvUse.DataSource = ds1;
                        gvUse.DataBind();
                    }
                }
                else if (ddlusr.SelectedItem.Text == "Admin")
                {
                    string sql = "SELECT [FId],[FeedBack_Desc],[Points],[ReminderDare],[Admin_Num],[Usr_mobile],[Cust_mobile]FROM [Come2myCityDB].[dbo].[EzeeMarketing_FeedBack] where Admin_Num = '" + txtusrMobileNo.Text + "'";
                    ds1 = cc.ExecuteDataset(sql);

                    if (ds1 != null)
                    {
                        gvUse.DataSource = ds1;
                        gvUse.DataBind();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please Select The User Type')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Please enter the Mobile number')</script>");
            }
        }
        catch (Exception ex)
        {

        }
        
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds2 = new DataSet();
            if (txtusrMobileNo.Text != "" || txtusrMobileNo.Text != null)
            {
                if (ddlusr.SelectedItem.Text == "User")
                {
                    string sql2 = "SELECT [OrderId],[Usr_mobile],[Cust_mobile],[Items],[Adm_Mobile]FROM [Come2myCityDB].[dbo].[EzeeMarketing_addorder] where Usr_mobile = '" + txtusrMobileNo.Text + "' ";
                    ds2 = cc.ExecuteDataset(sql2);

                    if (ds2 != null)
                    {
                        gvUse.DataSource = ds2;
                        gvUse.DataBind();
                    }
                }
                else if (ddlusr.SelectedItem.Text == "Admin")
                {
                    string sql2 = "SELECT [OrderId],[Usr_mobile],[Cust_mobile],[Items],[Adm_Mobile]FROM [Come2myCityDB].[dbo].[EzeeMarketing_addorder] where Adm_Mobile = '" + txtusrMobileNo.Text + "'";
                    ds2 = cc.ExecuteDataset(sql2);

                    if (ds2 != null)
                    {
                        gvUse.DataSource = ds2;
                        gvUse.DataBind();
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please Select The User Type')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please enter the Mobile number')</script>");
            }

        }
        catch (Exception ex)
        {

        }
    }
}

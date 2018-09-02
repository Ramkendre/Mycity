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

public partial class html_FriendAddressBook : System.Web.UI.Page
{
    DataTable dt;
    CommonCode cc = new CommonCode();
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    DataSet ds;
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
            }
        }

    }
    protected void btnViewFriendInGroup_Click(object sender, EventArgs e)
    {
        viewaddressbook();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btntest.Visible = true;
        }
        else
        {
            btntest.Visible = false;
        }
    }
    public void viewaddressbook()
    {
        try
        {
            string usrIdSn = Convert.ToString(Session["User"]);
            if (ddlMyFriendGroup.SelectedValue == "0")
            {
                if (txtGroupSMSFirst.Text != "" && txtGroupSMSLast.Text != "")
                {
                    string FullName = txtGroupSMSFirst.Text + " " + txtGroupSMSLast.Text;

                    string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                    " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "'  and FriRelName like '" + txtGroupSMSFirst.Text + "'";
                    ds = cc.ExecuteDataset(newsql);

                    gvAddressBook.DataSource = ds.Tables[0];
                    gvAddressBook.DataBind();
                }
                else if (txtGroupSMSFirst.Text != "" && txtGroupSMSLast.Text == "")
                {
                    string FullName = txtGroupSMSFirst.Text + " " + txtGroupSMSLast.Text;

                    string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                    " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "'  and FriRelName like '" + txtGroupSMSFirst.Text + "%'";
                    ds = cc.ExecuteDataset(newsql);

                    gvAddressBook.DataSource = ds.Tables[0];
                    gvAddressBook.DataBind();
                }
                else if (txtGroupSMSFirst.Text == "" && txtGroupSMSLast.Text != "")
                {
                    string FullName = txtGroupSMSFirst.Text + " " + txtGroupSMSLast.Text;

                    string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                    " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "' and FriRelName like '" + txtGroupSMSLast.Text + "%'";
                    ds = cc.ExecuteDataset(newsql);

                    gvAddressBook.DataSource = ds.Tables[0];
                    gvAddressBook.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Please enter Name or Select Group.....!')</script>");
                }

            }
            else
            {
                string FNumber = Convert.ToString(ddlMyFriendGroup.SelectedValue);
                string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                 " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "' and  FR" + FNumber + "='" + ddlMyFriendGroup.SelectedValue + "'";
                ds = cc.ExecuteDataset(newsql);

                gvAddressBook.DataSource = ds.Tables[0];
                gvAddressBook.DataBind();
            }
        }
        catch (Exception ec)
        {

        }
    }
    protected void btntest_Click(object sender, EventArgs e)
    {
        GetData();
        //Session["page"] = DropDownList1.SelectedValue;
        Response.Redirect("PrintAddress.aspx");


    }
    private void GetData()
    {
        dt = CreateDataTable();
        CheckBox chkAll = (CheckBox)gvAddressBook.HeaderRow
                            .Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvAddressBook.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                dt = AddRow(gvAddressBook.Rows[i], dt);
            }
            else
            {
                CheckBox chk = (CheckBox)gvAddressBook.Rows[i]
                                .Cells[0].FindControl("chk");

                if (chk.Checked)
                {
                    //int a = Convert.ToInt32(gvAll.DataKeys[gvAll.Rows.Count].Value); 
                    dt = AddRow(gvAddressBook.Rows[i], dt);
                }

            }
        }
        Session["SelectedRecords"] = dt;
    }


    private DataTable CreateDataTable()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("usrFullName");
        dt.Columns.Add("usrMobileNo");
        dt.Columns.Add("usrAddress");
        dt.Columns.Add("usrPIN");
        //dt.Columns.Add("distName");
        dt.AcceptChanges();
        return dt;
    }

    private DataTable AddRow(GridViewRow gvRow, DataTable dt)
    {
        DataRow[] dr = dt.Select("usrFullName = '" + gvRow.Cells[1].Text + "'");
        if (dr.Length <= 0)
        {
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1]["usrFullName"] = gvRow.Cells[1].Text;
            dt.Rows[dt.Rows.Count - 1]["usrMobileNo"] = gvRow.Cells[2].Text;
            dt.Rows[dt.Rows.Count - 1]["usrAddress"] = gvRow.Cells[3].Text;
            dt.Rows[dt.Rows.Count - 1]["usrPIN"] = gvRow.Cells[4].Text;
            //dt.Rows[dt.Rows.Count - 1]["distName"] = gvRow.Cells[5].Text;
            dt.AcceptChanges();
        }
        return dt;
    }

    protected void AddresschkAll_CheckedChanged(object sender, EventArgs e)
    {


        foreach (GridViewRow rowItem in gvAddressBook.Rows)
        {
            CheckBox chkAll = (CheckBox)gvAddressBook.HeaderRow
                            .Cells[0].FindControl("chkAll");
            chkAll.Checked = ((CheckBox)sender).Checked;

            if (((CheckBox)sender).Checked)
            {
                for (int i = 0; i < gvAddressBook.Rows.Count; i++)
                {
                    CheckBox chk11 = (CheckBox)gvAddressBook.Rows[i]
                                .Cells[0].FindControl("chk");
                    chk11.Checked = true;

                }
                rowItem.BackColor = System.Drawing.Color.FromName("#D1DDF1");
            }
            else
            {
                for (int i = 0; i < gvAddressBook.Rows.Count; i++)
                {
                    CheckBox chk11 = (CheckBox)gvAddressBook.Rows[i]
                                .Cells[0].FindControl("chk");
                    chk11.Checked = false;

                }
            }
        }
    }
    //protected void gvAddressBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvAddressBook.PageIndex = e.NewPageIndex;
    //    viewaddressbook();
    //}
    //protected void gvAddressBook_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int id = gvAddressBook.SelectedIndex;

    //}

}

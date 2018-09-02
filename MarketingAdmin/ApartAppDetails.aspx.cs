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

public partial class MarketingAdmin_ApartAppDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            txtRefMobileNo.Text = "9422325020";

        } DateFormatStatus();
    }

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    public void LoadGrid()
    {
        try
        {
            string Sql = "Select EzeeApp_Id, IMEINo, SIMNo, MemberName ,AppMobileNo, Purpose , Active from Apart_RegEzeeDevice order by EzeeApp_Id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[6].Text.ToString();
                    if (Data == "0")
                    {
                        row.Cells[6].Text = "Personal";
                    }
                    else if (Data == "1")
                    {
                        row.Cells[6].Text = "Community";
                    }
                    else if (Data == "2")
                    {
                        row.Cells[6].Text = "Political";
                    }
                    else if (Data == "3")
                    {
                        row.Cells[6].Text = "Apartment";
                    }
                }
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[7].Text.ToString();
                    if (Data == "1")
                    {
                        row.Cells[7].Text = "Active";
                    }
                    else if (Data == "0")
                    {
                        row.Cells[7].Text = "DeActive";
                    }

                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Details")
            {
                ddlPurpose.SelectedValue = "4";
                string Id = Convert.ToString(e.CommandArgument);
                lblId.Text = Convert.ToString(Id);
                string Sql = "Select IMEINo, SIMNo, MemberName, AppMobileNo, RefMobileNo,Purpose, PartyName,RegDate ,PassCode,KeyVersion,Active from Apart_RegEzeeDevice where EzeeApp_Id=" + Id + "";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //lblFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemberName"]);
                    //lblAppMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["AppMobileNo"]);
                    //lblRefMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["RefMobileNo"]);
                    //lblPartyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]);
                    //lblRegDate.Text = cc.DTGet_LocalEvent(Convert.ToString(ds.Tables[0].Rows[0]["RegDate"]));
                    //lblPassCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PassCode"]);
                    //string purpose = Convert.ToString(ds.Tables[0].Rows[0]["Purpose"]);
                    //Panel1.Visible = true;
                    //if (purpose == "0")
                    //{
                    //    lblPurpose.Text = "Personal";
                    //}
                    //else if (purpose == "1")
                    //{
                    //    lblPurpose.Text = "Community";
                    //}
                    //else if (purpose == "2")
                    //{
                    //    lblPurpose.Text = "Political";
                    //}
                    //else if (purpose == "3")
                    //{
                    //    lblPurpose.Text = "Apartment";
                    //}


                    txtIMEINo.Text = Convert.ToString(ds.Tables[0].Rows[0]["IMEINo"]);
                    txtSIMNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SIMNo"]);
                    txtFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemberName"]);
                    txtMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["AppMobileNo"]);
                    txtRefMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["RefMobileNo"]);
                    txtPartyName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName"]);
                    txtKeyVersion.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeyVersion"]);
                    txtPasscode.Text = Convert.ToString(ds.Tables[0].Rows[0]["PassCode"]);
                    ddlPurpose.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Purpose"]);
                    rdbActive.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Active"]);
                    btnSubmit.Text = "Update";
                }
            }
            else if (e.CommandName == "Active")
            {
                string Id = Convert.ToString(e.CommandArgument);
                string Sql = "Update Apart_RegEzeeDevice set Active=1 where EzeeApp_Id=" + Id + "";
                int i = cc.ExecuteNonQuery(Sql);
                if (i == 1)
                {
                    LoadGrid();
                    Clear();
                    Response.Write("<script>(alert)('Activited Sucessfully....!')</script>");
                }
            }
            else if (e.CommandName == "DeActive")
            {
                string Id = Convert.ToString(e.CommandArgument);
                string Sql = "Update Apart_RegEzeeDevice set Active=0 where EzeeApp_Id=" + Id + "";
                int i = cc.ExecuteNonQuery(Sql);
                if (i == 1)
                {
                    Clear();
                    LoadGrid();
                    Response.Write("<script>(alert)('DeActivited Sucessfully....!')</script>");
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select EzeeApp_Id, IMEINo, SIMNo, MemberName ,AppMobileNo, Purpose , Active from Apart_RegEzeeDevice where AppMobileNo='" + txtMobileno.Text + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[6].Text.ToString();
                    if (Data == "0")
                    {
                        row.Cells[6].Text = "Personal";
                    }
                    else if (Data == "1")
                    {
                        row.Cells[6].Text = "Community";
                    }
                    else if (Data == "2")
                    {
                        row.Cells[6].Text = "Political";
                    }
                    else if (Data == "3")
                    {
                        row.Cells[6].Text = "Apartment";
                    }
                }
                foreach (GridViewRow row in gvItem.Rows)
                {
                    string Data = row.Cells[7].Text.ToString();
                    if (Data == "1")
                    {
                        row.Cells[7].Text = "Active";
                    }
                    else if (Data == "0")
                    {
                        row.Cells[7].Text = "DeActive";
                    }

                }
                txtFullName.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemberName"]);
            }
            else
            {
                Sql = "Select usrFirstName, usrLastName from UserMaster where usrMobileNo='" + txtMobileno.Text + "'";
                DataSet ds1 = cc.ExecuteDataset(Sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    string fname = Convert.ToString(ds1.Tables[0].Rows[0]["usrFirstName"]);
                    string lname = Convert.ToString(ds1.Tables[0].Rows[0]["usrLastName"]);
                    txtFullName.Text = fname + " " + lname;
                }
                else
                {
                    Response.Write("<script>(alert)('This Mobile Not register On Myct............!')</script>");
                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(lblId.Text);
            if (Id == "" || Id == null)
            {
                AddRecord();

            }
            else
            {
                UpdateRecord(Id);
            }
        }
        catch (Exception ex)
        { }
    }
    public void AddRecord()
    {
        try
        {
            if (txtMobileno.Text == "")
            {
                Response.Write("<script>(alert)('Please enter Mobileno............!')</script>");
            }
            else if (txtIMEINo.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The IMEI No...........!')</script>");
            }
            else if (txtSIMNo.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The SIM NO...........!')</script>");
            }
            else if (txtRefMobileNo.Text == "")
            {
                Response.Write("<script>(alert)('Enter Reference No...........!')</script>");
            }
            else if (txtPartyName.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter the Party name...........!')</script>");
            }
            else if (txtPasscode.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The Passcode...........!')</script>");
            }
            //else if (ddlKeyVersion.SelectedItem.Text == "--Select--")
            //{
            //    Response.Write("<script>(alert)('Enter The KeyVersion...........!')</script>");
            //}
            else if (ddlPurpose.SelectedValue == "4")
            {
                Response.Write("<script>(alert)('Please Select Purpose...........!')</script>");
            }
            else
            {
                string Sql = "Select usrUserId from UserMaster where usrMobileNo='" + txtMobileno.Text + "'";
                string UserId = Convert.ToString(cc.ExecuteScalar(Sql));

                Sql = "Select IMEINo from Apart_RegEzeeDevice where IMEINo='" + txtIMEINo.Text + "' and AppMobileNo='" + txtMobileno.Text + "'";
                string IMEIno = Convert.ToString(cc.ExecuteScalar(Sql));

                if (IMEIno == "" || IMEIno == null)
                {
                    Sql = "Insert into Apart_RegEzeeDevice (IMEINo,SIMNo,MyctUserId,MemberName,AppMobileNo,Purpose,RefMobileNo,PartyName,PassCode,KeyVersion,Active,RegDate) " +
                    "values('" + txtIMEINo.Text + "','" + txtSIMNo.Text + "','" + UserId + "','" + txtFullName.Text + "','" + txtMobileno.Text + "'," + ddlPurpose.SelectedValue + ",'" + txtRefMobileNo.Text + "','" + txtPartyName.Text + "','" + txtPasscode.Text + "','" + txtKeyVersion.Text + "'," + rdbActive.SelectedValue + ",'" + DateFormat + "')";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {
                        Response.Write("<script>(alert)('Record Added Sucessfully.........!')</script>");
                        Clear();
                        LoadGrid();
                    }
                    else
                    {
                        Response.Write("<script>(alert)('Record Added Not Sucessfully.........!')</script>");
                    }
                }
                else { }
            }
        }
        catch (Exception ex)
        { }
    }
    public void UpdateRecord(string Id)
    {
        try
        {
            if (txtMobileno.Text == "")
            {
                Response.Write("<script>(alert)('Please enter Mobileno............!')</script>");
            }
            else if (txtIMEINo.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The IMEI No...........!')</script>");
            }
            else if (txtSIMNo.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The SIM NO...........!')</script>");
            }
            else if (txtRefMobileNo.Text == "")
            {
                Response.Write("<script>(alert)('Enter Reference No...........!')</script>");
            }
            else if (txtPartyName.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter the Party name...........!')</script>");
            }
            else if (txtPasscode.Text == "")
            {
                Response.Write("<script>(alert)('Please Enter The Passcode...........!')</script>");
            }
            //else if (txtKeyVersionText == "--Select--")
            //{
            //    Response.Write("<script>(alert)('Enter The KeyVersion...........!')</script>");
            //}
            else if (ddlPurpose.SelectedValue == "4")
            {
                Response.Write("<script>(alert)('Please Select Purpose...........!')</script>");
            }
            else
            {
                string Sql = "Select usrUserId from UserMaster where usrMobileNo='" + txtMobileno.Text + "'";
                string UserId = Convert.ToString(cc.ExecuteScalar(Sql));

                Sql = "Select IMEINo from Apart_RegEzeeDevice where IMEINo='" + txtIMEINo.Text + "' and AppMobileNo='" + txtMobileno.Text + "'";
                string IMEIno = Convert.ToString(cc.ExecuteScalar(Sql));

                if (UserId != "" || UserId != null)
                {
                    Sql = "Update Apart_RegEzeeDevice Set IMEINo='" + txtIMEINo.Text + "',SIMNo='" + txtSIMNo.Text + "',MyctUserId='" + UserId + "',MemberName='" + txtFullName.Text + "',AppMobileNo='" + txtMobileno.Text + "',Purpose='" + ddlPurpose.SelectedValue + "', " +
                    " RefMobileNo='" + txtRefMobileNo.Text + "',PartyName='" + txtPartyName.Text + "',PassCode='" + txtPasscode.Text + "',KeyVersion='" + txtKeyVersion.Text + "',RegDate='" + DateFormat + "' ,Active=" + rdbActive.SelectedValue + " where EzeeApp_Id=" + Id + "";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {
                        Response.Write("<script>(alert)('Record Updated  Sucessfully.........!')</script>");
                        Clear();
                        LoadGrid();

                    }
                    else
                    {
                        Response.Write("<script>(alert)('Record Updated Not Sucessfully.........!')</script>");
                    }
                }
                else { }
            }
        }
        catch (Exception ex)
        { }
    }
    public void Clear()
    {
        txtMobileno.Text = "";
        txtFullName.Text = "";
        txtIMEINo.Text = "";
        txtPartyName.Text = "";
        txtPasscode.Text = "";
        // txtRefMobileNo.Text = "";
        txtSIMNo.Text = "";
        //txtKeyVersion
        ddlPurpose.SelectedValue = "4";
        lblId.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}

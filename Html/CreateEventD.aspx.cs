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

public partial class html_CreateEventD : System.Web.UI.Page
{
    MyctEvent me = new MyctEvent();
    string DateFormat, Year, Month;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            DateFormatStatus();
            if (!IsPostBack)
            {
                LoadData();
                // LoadGrid();
            }
        }

    }
    //----------------------------------------------------------Current Date Format---------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        Year = SystemDate.Year.ToString();
        Month = SystemDate.Month.ToString();
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    public void LoadData()
    {
        try
        {
            string Sql = "SELECT EventId,EventName,convert(varchar, convert(datetime, DateofMessage), 105) As DateMessage,time1,Location,convert(varchar, convert(datetime, EntryDate), 105) As CreateDate FROM CreateMyctEvent " +
                         "where usrUserId='" + Convert.ToString(Session["User"]) + "' order by EventId desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    {
        txtNameOfEvent.Text = "";
        txtDateOfMgs.Text = "";
        txtTime.Text = "";
        txtLocation.Text = "";
        txtSocialDisp.Text = "";
        txtRalative.Text = "";
        txtRelation.Text = "";
        rdbVisit.ClearSelection();
        rdbSendmgs.ClearSelection();
        btnSubmit.Text = "Submit";
        lblId.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(lblId.Text);
            if (String.IsNullOrEmpty(Id))
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
        finally
        { }
    }
    private void AddRecord()
    {
        try
        {
            if (rdbVisit.SelectedValue == "")
            {
                Response.Write("<script>alert('Please select Visit.....!')</script>");
            }
            else if (rdbSendmgs.SelectedValue == "")
            {
                Response.Write("<script>alert('Please select Send massage.....!')</script>");
            }
            else
            {
                string NameEvent = Convert.ToString(txtNameOfEvent.Text);
                string DateofMessage = Convert.ToString(txtDateOfMgs.Text);
                string time = Convert.ToString(txtTime.Text);
                string Location = Convert.ToString(txtLocation.Text);
                string SocialDscrip = Convert.ToString(txtSocialDisp.Text);
                string Ralative = Convert.ToString(txtRalative.Text);
                string Relation = Convert.ToString(txtRelation.Text);
                string Visit = Convert.ToString(rdbVisit.SelectedValue);
                string SendMgs = Convert.ToString(rdbSendmgs.SelectedValue);
                string CreatedBy = "Myct";
                string UserId = Convert.ToString(Session["User"]);
                int k = me.AddEvent("0", "0", NameEvent, DateofMessage, time, Location, SocialDscrip, Ralative, Relation, Visit, SendMgs, DateFormat, CreatedBy, UserId);
                if (k == 1)
                {
                    Clear();
                    LoadData();
                    Response.Write("<script>alert('Event Created Successfully!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Event not Created Successfully!')</script>");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void UpdateRecord(string Id)
    {
        try
        {
            if (rdbVisit.SelectedValue == "")
            {
                Response.Write("<script>alert('Please select Visit.....!')</script>");
            }
            else if (rdbSendmgs.SelectedValue == "")
            {
                Response.Write("<script>alert('Please select Send massage.....!')</script>");
            }
            else
            {
                string NameEvent = Convert.ToString(txtNameOfEvent.Text);
                string DateofMessage = Convert.ToString(txtDateOfMgs.Text);
                string time = Convert.ToString(txtTime.Text);
                string Location = Convert.ToString(txtLocation.Text);
                string SocialDscrip = Convert.ToString(txtSocialDisp.Text);
                string Ralative = Convert.ToString(txtRalative.Text);
                string Relation = Convert.ToString(txtRelation.Text);
                string Visit = Convert.ToString(rdbVisit.SelectedValue);
                string SendMgs = Convert.ToString(rdbSendmgs.SelectedValue);
                string CreatedBy = "Myct";
                string UserId = Convert.ToString(Session["User"]);
                //int k = me.UpdateEvent("0", "0", NameEvent, DateofMessage, time, Location, SocialDscrip, Ralative, Relation, Visit, SendMgs, DateFormat, CreatedBy, UserId, Id);
                //if (k == 1)
                //{
                //    Clear();
                //    Response.Write("<script>alert('Event Created Successfully!')</script>");
                //}
                //else
                //{
                //    Response.Write("<script>alert('Event not Created Successfully!')</script>");
                //}
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Modify")
            {
                lblId.Text = Convert.ToString(e.CommandArgument);
                string Sql = "SELECT EventId,usrUserId,EventName,DateofMessage,time1,Location,SocialDscrip,Ralative,Relation,Visit,SendMgs,EntryDate,Createby,IMEINo,SIMNo " +
                             "FROM CreateMyctEvent where EventId= " + lblId.Text + "";
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtNameOfEvent.Text = Convert.ToString(ds.Tables[0].Rows[0]["EventName"]);
                    txtDateOfMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["DateofMessage"]);
                    txtTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["time1"]);
                    txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);
                    txtSocialDisp.Text = Convert.ToString(ds.Tables[0].Rows[0]["SocialDscrip"]);
                    txtRalative.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ralative"]);
                    txtRelation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Relation"]);
                    rdbVisit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Visit"]);
                    rdbSendmgs.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SendMgs"]);
                }
            }
        }
        catch (Exception ex)
        { }
    }
}

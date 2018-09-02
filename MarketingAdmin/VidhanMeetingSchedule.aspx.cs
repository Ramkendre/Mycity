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

public partial class MarketingAdmin_VidhanMeetingSchedule : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    string dt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();

        }
        DateFormatStatus();
    }
    public void LoadGrid()
    {
        string Sql = "Select Id , Committee_name from committeedetail where RoleId=29";
        DataSet ds = cc.ExecuteDataset(Sql);
        gvToday.DataSource = ds.Tables[0];
        gvToday.DataBind();

        string Sql1 = "Select Id, RoomNo , TimeDetails,EntryDate from committeedetail where RoleId=29";
        DataSet ds1 = cc.ExecuteDataset(Sql1);
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {

            int Id = Convert.ToInt32(ds1.Tables[0].Rows[i]["Id"]);
            Id++;
            TextBox txtTime = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtTime");
            TextBox txtRoomNo = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtRoomNo");
            string TimeStr = "", RoomStr = "";
            txtTime.Text = "";
            txtRoomNo.Text = "";
            TimeStr = "";
            RoomStr = "";

            TimeStr = Convert.ToString(ds1.Tables[0].Rows[i]["TimeDetails"]);
            RoomStr = Convert.ToString(ds1.Tables[0].Rows[i]["RoomNo"]);
            string DateSql = Convert.ToString(ds1.Tables[0].Rows[i]["EntryDate"]);
            string[] Dt = DateSql.Split(' ');
            string da = Dt[0].ToString();
            string[] hh = da.Split('/');

            DateSql = hh[2].ToString() + "-" + hh[0].ToString() + "-" + hh[1].ToString();

            txtDate.Text = DateSql;
            if (TimeStr == "" && RoomStr == "")
            {
                txtTime.Text = TimeStr;
                txtRoomNo.Text = RoomStr;
            }
            else
            {
                txtTime.Text = TimeStr;
                txtRoomNo.Text = RoomStr;

            }
        }
    }

    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtDate.Text == "" || txtDate.Text == null)
            {
                Response.Write("<script>alert('please Select Date to Calender.....!')</script>");
            }
            else
            {
                for (int i = 0; i < gvToday.Rows.Count; i++)
                {
                    TextBox txtTime = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtTime");
                    TextBox txtRoomNo = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtRoomNo");

                    if (txtTime.Text == "" && txtRoomNo.Text == "")
                    {
                        string id1 = Convert.ToString(gvToday.Rows[i].Cells[0].Text);
                        string Sql = "Update committeedetail set RoomNo='',TimeDetails='', EntryDate='" + txtDate.Text + "' where Id=" + id1 + "";
                        int k = cc.ExecuteNonQuery(Sql);
                    }
                    else
                    {

                        string id1 = Convert.ToString(gvToday.Rows[i].Cells[0].Text);
                        // string RoomTime = Convert.ToString(txtRoomNo.Text) + Convert.ToString(txtTime.Text);
                        string Sql = "Update committeedetail set RoomNo='" + txtRoomNo.Text + "' , TimeDetails='" + txtTime.Text + "' , EntryDate='" + txtDate.Text + "' where Id=" + id1 + "";
                        int k = cc.ExecuteNonQuery(Sql);


                    }
                }
                Response.Write("<script>alert('Updated successfully.....!')</script>");
            }
        }
        catch (Exception ex)
        { }

    }
    public void Clear()
    {
        for (int i = 0; i < gvToday.Rows.Count; i++)
        {
            TextBox txtTime = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtTime");
            TextBox txtRoomNo = (TextBox)gvToday.Rows[i].Cells[0].FindControl("txtRoomNo");
            txtTime.Text = "";
            txtRoomNo.Text = "";
        }
        string Sql = "Update committeedetail set RoomNo='',TimeDetails='', EntryDate='" + txtDate.Text + "' where roleid=29";
        int k = cc.ExecuteNonQuery(Sql);
        txtDate.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}

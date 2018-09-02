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

public partial class MarketingAdmin_VidhanMeetingDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    string dt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        if (!IsPostBack)
        {
            LoadGrid();
            DateDetails();
        }

    }
    public void LoadGrid()
    {
        string Sql = "Select Id , Committee_name,RoomNo ,TimeDetails  from committeedetail where RoleId=29";
        DataSet ds = cc.ExecuteDataset(Sql);
        gvToday.DataSource = ds.Tables[0];
        gvToday.DataBind();
        //foreach (GridViewRow row in gvToday.Rows)
        //{
        //    string Data = row.Cells[4].Text.ToString();
        //    Data = cc.DTGet_LocalEvent(Data);
        //    row.Cells[4].Text = Data;
        //}
    }
    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }

    public void DateDetails()
    {
        try
        {
            string Sql = "Select EntryDate from committeedetail where Id=1";// and EntryDate='" + DateFormat + "'";
            string Date = Convert.ToString(cc.ExecuteScalar(Sql));
            string[] tmp = Date.Split(' ');

            tmp = tmp[0].Split('/');
            Date = tmp[1].ToString() + "/" + tmp[0].ToString() + "/" + tmp[2].ToString() + "";
            lblDate.Text = Date;
        }
        catch (Exception ex)
        { }
    }

}


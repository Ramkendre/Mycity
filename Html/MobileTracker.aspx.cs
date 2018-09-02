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

public partial class html_MobileTracker : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            //LoadGrid();
        }
    }
    public void LoadData()
    {
        string imei = Convert.ToString(Request.QueryString["p1"]);
        string simno = Convert.ToString(Request.QueryString["p2"]);
        string latitude = Convert.ToString(Request.QueryString["p3"]);
        string longitude = Convert.ToString(Request.QueryString["p4"]);
        string date = Convert.ToString(Request.QueryString["p5"]);
        string time = Convert.ToString(Request.QueryString["p6"]);
        if (imei != "" && simno != "" && latitude != "" && longitude != "" && date != "" && time != "")
        {
            string Sql = "Insert Into MobileTracker(Iemi,SimNo,latitude,date,time,longitude) values ('" + imei + "','" + simno + "','" + latitude + "','" + date + "','" + time + "','" + longitude + "')";
            int i = cc.ExecuteNonQuery(Sql);
        }
    }
    //public void LoadGrid()
    //{
    //    string Sql = "Select Id, Iemi,SimNo,latitude,longitude,date,time from MobileTracker order by Id desc ";
    //    DataSet ds = cc.ExecuteDataset(Sql);
    //    gvItem.DataSource = ds.Tables[0];
    //    gvItem.DataBind();
    //}
}

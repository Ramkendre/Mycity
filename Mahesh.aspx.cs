using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;

public partial class Mahesh : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblDate.Text = Convert.ToString(System.DateTime.Now);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "Continew123")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            con.Open();
            string usrId = "";
            string sql = "select * from userMaster";
            DataSet ds1 = new DataSet();
            ds1 = cc.ExecuteDataset(sql);
            foreach (DataRow dr2 in ds1.Tables[0].Rows)
            {
                string thisDir = Server.MapPath("~");
                usrId = Convert.ToString(dr2["usrUserId"]);
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + usrId + "\\Profile_Photo\\"))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + usrId + "\\Profile_Photo\\");

                    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + usrId + "\\Profile_Photo\\default_user.jpg");

                }


            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter Currect Security Password.')", true);
        }

    }
    protected void t1_Tick(object sender, EventArgs e)
    {       
        
        TimeZoneInfo timeZoneInfo;
        DateTime dateTime;       
        timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");        
        dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);       
        string ttt = dateTime.ToString("yyyy-MM-dd HH-mm-ss");
        if (date(dateTime))
        {
            string dateFlag = Convert.ToString(dateTime);
            string []dateArr = dateFlag .Split (' ');
            string ymd = dateArr[0].ToString();
            string hms = dateArr[1].ToString();

            string[] dArr = ymd.Split('/'); 
            int d =Convert .ToInt32 ( dArr [1].ToString ());
            if (d == 1)
            {
                MonthFlagUpdate(ttt);
            }
            else
            {
                DayFlagUpdate(ttt);
            }

        }
        else
        {
            lblDate.Text = Convert.ToString(ttt.ToString());
        }
    }

    public bool date(DateTime dt)
    {
        bool fl = false;      
        if (dt.Hour == 23)
        {
            if (dt.Minute == 58)
            {
                if (dt.Second == 58 || dt.Second == 59)
                {
                    fl = true;
                }
            }
            else
            {
               fl=false ;
            }
        }
        else
        {
            fl=false ;
        }
        return fl;
    }

    public void DayFlagUpdate(string lstUpdate)
    {
        string DalyFlag = "update userMaster set dCount=0";
        int i = cc.ExecuteNonQuery(DalyFlag );
        Label1.Text = "Update of day flag.";
        lblLastUpdate.Text = "Last Update: " + lstUpdate.ToString();

    }

    public void MonthFlagUpdate(string lstUpdate)
    {
        string DalyFlag = "update userMaster set dCount=0,mCount=500";
        int i = cc.ExecuteNonQuery(DalyFlag);
        lblLastUpdate.Text = "Last Update: " + lstUpdate.ToString();
    }
}

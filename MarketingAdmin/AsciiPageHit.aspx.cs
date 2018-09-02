using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;
public partial class MarketingAdmin_AsciiPageHit : System.Web.UI.Page
{
    string DateFormat;
    string ipAddress, hostName;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        ipAddress = IpAddress();
        if (!IsPostBack)
        {

        }
    }
    private string IpAddress()
    {
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }

    public string GetVisitorIpAddress()
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return "Your ip is " + stringIpAddress;
    }
    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        DateFormat = dt.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }
    public void dd()
    {
        if (txtMgs.Text == "")
        {
            Errordiv.Visible = true;
            lblError.Text = "Please Enter the Message Text....!";
        }
        else
        {
            byte[] StringAscII = System.Text.Encoding.ASCII.GetBytes(txtMgs.Text);

            string Str = "";
            string data = "";

            for (int i = 0; i < StringAscII.Length; i++)
            {

                string b = Convert.ToString(StringAscII[i] + ",");//if i=0 a= 65, if i=1 a=66 and so on
                Str = Convert.ToString(b);
                data = data + Str;
            }
            txtAscii.Text = data;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dd();
    }
    protected void btnHint_Click(object sender, EventArgs e)
    {
        //Response.Redirect("http://www.myct.in/html/MobileASCIIsms.aspx?receiverMobileNo=NA&senderMobileNo=91" + txtMobileNo.Text + "&receivedSmsBody=" +
        //  txtMgsUrl.Text + "&receivedDateTime=" + DateFormat + "&p1=89912215000006839428&p2=911234851041999&p3=p3&p4=p4&p5=p5");

        if (txtMobileNo.Text == "")
        {
            Errordiv.Visible = true;
            lblError.Text = "Please Enter the Mobile no.....!";
        }
        else if (txtMgsUrl.Text == "")
        {
            Errordiv.Visible = true;
            lblError.Text = "Please paste the Ascii code.....!";
        }
        else
        {
            string url = "http://www.myct.in/html/MobileASCIIsms.aspx?receiverMobileNo=NA&senderMobileNo=91" + txtMobileNo.Text + "&receivedSmsBody=" +
                txtMgsUrl.Text + "&receivedDateTime=" + DateFormat + "&p1=89912215000006839428&p2=911234851041999&p3=" + ipAddress + "&p4=p4&p5=p5";

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
            objRequest.Method = "POST";

            objRequest.ContentType = "application/x-www-form-urlencoded";
            myWriter = new StreamWriter(objRequest.GetRequestStream());

            myWriter.Close();
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                sr.Close();
                Response.Write("<script>alert('Your Message Send Successfully....')</script>");
            }
            clear();
        }
    }
    public void clear()
    {
        txtMobileNo.Text = "";
        txtMgsUrl.Text = "";
        txtAscii.Text = "";
        txtMgs.Text = "";
        Errordiv.Visible = false;
    }
}

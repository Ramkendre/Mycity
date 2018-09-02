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

public partial class html_EventPrint : System.Web.UI.Page
{
    static string strcon;
    EventMyctBLL objEventMyctBLL = new EventMyctBLL();
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        strcon = Convert.ToString(Request.QueryString[0]);
        if (!IsPostBack)
        {
            objEventMyctBLL.Id1 = Convert.ToInt16(strcon);
            objEventMyctBLL.Selectrecord(objEventMyctBLL);

            lblBrideName.Text = Convert.ToString(objEventMyctBLL.BrideName1);
            lblGroomName.Text = Convert.ToString(objEventMyctBLL.GroomName1);
            //lblInvitationFrom.Text = Convert.ToString(objEventMyctBLL.InvitionFrom1);
            lblDateOfMarrage.Text = Convert.ToString(DateSplit(objEventMyctBLL.DateOfMgs1));
            //lblTimeOfMarrage.Text = Convert.ToString(objEventMyctBLL.TimeOfMgs1);
            //lblLocation.Text = Convert.ToString(objEventMyctBLL.Location1);
            // txtDiscription.Text = Convert.ToString(objEventMyctBLL.SpecialDescription1);
            string FristName = Convert.ToString(objEventMyctBLL.FristName1);
            string LastName = Convert.ToString(objEventMyctBLL.LastName1);
            lblPreshak.Text = FristName + " " + LastName;
           // lblMobile.Text = Convert.ToString(objEventMyctBLL.MobileNo1);
            lblAddress.Text = Convert.ToString(objEventMyctBLL.Address1);
            lblMgs.Text = Convert.ToString(objEventMyctBLL.SendMgs1);
            //  rdbPriority.Text = Convert.ToString(objEventMyctBLL.Priority1);



            //------------------------------Faithfully-----------------------------
         
            objEventMyctBLL.UsrUserId = Convert.ToString(Session["User"].ToString());
            objEventMyctBLL.SelectUserRecord(objEventMyctBLL);
            string FirstNameUser = Convert.ToString(objEventMyctBLL.UsrFirstName);
            string LastNameUser = Convert.ToString(objEventMyctBLL.UsrLastName);
            lblFaithfully.Text = FirstNameUser + " " + LastNameUser;
        }
    }
    public string DateSplit(string data)
    {
        string[] dt = data.Split(' ');
        string[] Dts = dt[0].Split('/');
        data = Dts[1] + "/" + Dts[0] + "/" + Dts[2];
        return data;
    }
}

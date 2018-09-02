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

public partial class html_Members : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    int status;

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
                try
                {
                    totalcount1();
                }
                catch { }
            }
        }

    }
    private void totalcount1()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            string sql = "select count(FR1) as FR1 from friendrelationmaster where FR1='1' and userid='" + urUserRegBLLObj.usrUserId + "' ";
            string sql2 = sql + "select count(FR2) as FR2 from friendrelationmaster where FR2='2' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql3 = sql2 + "select count(FR3) as FR3 from friendrelationmaster where FR3='3' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql4 = sql3 + "select count(FR4) as FR4 from friendrelationmaster where FR4='4' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql5 = sql4 + "select count(FR5) as FR5 from friendrelationmaster where FR5='5' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql6 = sql5 + "select count(FR6) as FR6 from friendrelationmaster where FR6='6' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql7 = sql6 + "select count(FR7) as FR7 from friendrelationmaster where FR7='7' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql8 = sql7 + "select count(FR8) as FR8 from friendrelationmaster where FR8='8' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql9 = sql8 + "select count(FR9) as FR9 from friendrelationmaster where FR9='9' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql10 = sql9 + "select count(FR10) as FR10 from friendrelationmaster where FR10='10' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql11 = sql10 + "select count(FR11) as FR11 from friendrelationmaster where FR11='11' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql12 = sql11 + "select count(FR12) as FR12 from friendrelationmaster where FR12='12' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql13 = sql12 + "select count(FR13) as FR13 from friendrelationmaster where FR13='13' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql14 = sql13 + "select count(FR14) as FR14 from friendrelationmaster where FR14='14' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql15 = sql14 + "select count(FR15) as FR15 from friendrelationmaster where FR15='15' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql16 = sql15 + "select count(FR16) as FR16 from friendrelationmaster where FR16='16' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql17 = sql16 + "select count(FR17) as FR17 from friendrelationmaster where FR17='17' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql18 = sql17 + "select count(FR18) as FR18 from friendrelationmaster where FR18='18' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql19 = sql18 + "select count(FR19) as FR19 from friendrelationmaster where FR19='19' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql20 = sql19 + "select count(FR20) as FR20 from friendrelationmaster where FR20='20' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql21 = sql20 + "select count(FR21) as FR21 from friendrelationmaster where FR21='21' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql22 = sql21 + "select count(FR22) as FR22 from friendrelationmaster where FR22='22' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql23 = sql22 + "select count(FR23) as FR23 from friendrelationmaster where FR23='23' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql24 = sql23 + "select count(FR24) as FR24 from friendrelationmaster where FR24='24' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql25 = sql24 + "select count(FR25) as FR25 from friendrelationmaster where FR25='25' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql26 = sql25 + "select count(FR26) as FR26 from friendrelationmaster where FR26='26' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql27 = sql26 + "select count(FR27) as FR27 from friendrelationmaster where FR27='27' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql28 = sql27 + "select count(FR28) as FR28 from friendrelationmaster where FR28='28' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql29 = sql28 + "select count(FR29) as FR29 from friendrelationmaster where FR29='29' and userid='" + urUserRegBLLObj.usrUserId + "'";
            string sql30 = sql29 + "select count(FR30) as FR30 from friendrelationmaster where FR30='30' and userid='" + urUserRegBLLObj.usrUserId + "'";
            //string sql5 = sql4 + "select count(FR5) as FR5 from friendrelationmaster where FR5='5' and userid='" + urUserRegBLLObj.usrUserId + "'";



            DataSet ds = cc.ExecuteDataset(sql30);

            lblall.Text = Convert.ToString(ds.Tables[0].Rows[0]["FR1"]);
            lblFR2.Text = Convert.ToString(ds.Tables[1].Rows[0]["FR2"]);
            lblFR3.Text = Convert.ToString(ds.Tables[2].Rows[0]["FR3"]);
            lblFR4.Text = Convert.ToString(ds.Tables[3].Rows[0]["FR4"]);
            lblFR5.Text = Convert.ToString(ds.Tables[4].Rows[0]["FR5"]);
            lblFR6.Text = Convert.ToString(ds.Tables[5].Rows[0]["FR6"]);
            lblFR7.Text = Convert.ToString(ds.Tables[6].Rows[0]["FR7"]);
            lblFR8.Text = Convert.ToString(ds.Tables[7].Rows[0]["FR8"]);
            lblFR9.Text = Convert.ToString(ds.Tables[8].Rows[0]["FR9"]);
            lblFR10.Text = Convert.ToString(ds.Tables[9].Rows[0]["FR10"]);
            lblFR11.Text = Convert.ToString(ds.Tables[10].Rows[0]["FR11"]);
            lblFR12.Text = Convert.ToString(ds.Tables[11].Rows[0]["FR12"]);
            lblFR13.Text = Convert.ToString(ds.Tables[12].Rows[0]["FR13"]);
            lblFR14.Text = Convert.ToString(ds.Tables[13].Rows[0]["FR14"]);
            lblFR15.Text = Convert.ToString(ds.Tables[14].Rows[0]["FR15"]);
            lblFR16.Text = Convert.ToString(ds.Tables[15].Rows[0]["FR16"]);
            lblFR17.Text = Convert.ToString(ds.Tables[16].Rows[0]["FR17"]);
            lblFR18.Text = Convert.ToString(ds.Tables[17].Rows[0]["FR18"]);
            lblFR19.Text = Convert.ToString(ds.Tables[18].Rows[0]["FR19"]);
            lblFR20.Text = Convert.ToString(ds.Tables[19].Rows[0]["FR20"]);
            lblFR21.Text = Convert.ToString(ds.Tables[20].Rows[0]["FR21"]);
            lblFR22.Text = Convert.ToString(ds.Tables[21].Rows[0]["FR22"]);
            lblFR23.Text = Convert.ToString(ds.Tables[22].Rows[0]["FR23"]);
            lblFR24.Text = Convert.ToString(ds.Tables[23].Rows[0]["FR24"]);
            lblFR25.Text = Convert.ToString(ds.Tables[24].Rows[0]["FR25"]);
            lblFR26.Text = Convert.ToString(ds.Tables[25].Rows[0]["FR26"]);
            lblFR27.Text = Convert.ToString(ds.Tables[26].Rows[0]["FR27"]);
            lblFR28.Text = Convert.ToString(ds.Tables[27].Rows[0]["FR28"]);
            lblFR29.Text = Convert.ToString(ds.Tables[28].Rows[0]["FR29"]);
            lblFR30.Text = Convert.ToString(ds.Tables[29].Rows[0]["FR30"]);
        }
        catch (Exception ex)
        {
        }

    }
}

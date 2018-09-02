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

public partial class PopUpFile_PromotionalDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    Int32 Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        try
        {
            string sql = "SELECT ID ,SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,balance,EntryDate FROM PromotionalSendSMSReport where Id=" + Id + "";
            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblSendFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["SendFrom"]);
                lblSendTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SendTo"]);
                lblSentMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["sentMessage"]);
                lblTotalSent.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalSent"]);
                lblTotallength.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totallength"]);
                lblTotalSms.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalSms"]);
                lblbalance.Text = Convert.ToString(ds.Tables[0].Rows[0]["balance"]);
                lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["EntryDate"]);


            }
        }
        catch (Exception xe)
        { }
    }
}

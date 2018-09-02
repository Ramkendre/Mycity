using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MarketingAdmin_VerifySMS : System.Web.UI.Page
{
    VerifySMSBLL objBLL = new VerifySMSBLL();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadGvLongCodeSMSReceve();
        }
    }
    protected void gvLongCodeSMSReceve_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void loadGvLongCodeSMSReceve()
    {
        List<VerifySMSBLL> objBLLvar = new List<VerifySMSBLL>();
        objBLLvar = objBLL.getSMSHistory(objBLL );
        gvLongCodeSMSReceve.DataSource = objBLLvar;
        gvLongCodeSMSReceve.DataBind();
        objBLLvar = objBLL.getSendSMSHistory(objBLL );
        gvSMSsend.DataSource = objBLLvar;
        gvSMSsend.DataBind();
    
    }
}

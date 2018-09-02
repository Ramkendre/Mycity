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

public partial class Html_MainEventsID : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventMain_IDBLL objMain_IDBLL = new EventMain_IDBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String UserIdSession = Convert.ToString(Session["User"]);
            if (UserIdSession == "")
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    //Loadgrid();
                }
            }
        }
    }
    protected void btnSubSubmit_Click(object sender, EventArgs e)
    {
        string ID = Convert.ToString(lblId.Text);
        if (ID == "" || ID == null)
        {
            AddrecordSUBID();
        }
    }
    public void AddrecordSUBID()
    {
        objMain_IDBLL.UserId1 = Convert.ToString(Session["User"].ToString());
       
        objMain_IDBLL.Name1 = Convert.ToString(TxtSubName.Text.ToUpper());
        objMain_IDBLL.Description1 = Convert.ToString(txtSubDesc.Text);
        int Status = objMain_IDBLL.AddRecordSubBLL(objMain_IDBLL);
        if (Status == 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
}

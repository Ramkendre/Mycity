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

public partial class Html_Main_ID : System.Web.UI.Page
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
    protected void btnMainSubmit_Click(object sender, EventArgs e)
    {
        string ID = Convert.ToString(lblId.Text);
        if (ID == "" || ID == "null")
        {
            AddrecordMainID();
        }
        //else
        //{ 
        
        //}
    }
    public void AddrecordMainID()
    {
        objMain_IDBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        objMain_IDBLL.ID1 = Convert.ToInt16(txtID.Text);
        objMain_IDBLL.Sub_ID1 = Convert.ToInt16(txtSub_ID.Text);
        objMain_IDBLL.Name1 = Convert.ToString(txtName.Text);
        objMain_IDBLL.Description1 = Convert.ToString(txtDesc.Text);
        objMain_IDBLL.User1 = Convert.ToString(txtUser.Text);
        int Status = objMain_IDBLL.AddRecordBLL(objMain_IDBLL);
        if (Status == 1)
        {
            //loadgrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void AddrecordSUBID()
    {
        objMain_IDBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        objMain_IDBLL.ID1 = Convert.ToInt16(txtSubID.Text);
        objMain_IDBLL.Name1 = Convert.ToString(TxtSubName.Text);
        objMain_IDBLL.Description1 = Convert.ToString(txtSubDesc.Text);
        int Status = objMain_IDBLL.AddRecordSubBLL(objMain_IDBLL);
        if (Status == 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
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
}

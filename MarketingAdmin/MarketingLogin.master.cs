using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Master_MainMaster : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string tmp = SessionContext.CityName;
        if (!IsPostBack)
        {
            try
            {
                string UserName = Convert.ToString(Session["MarketingUser"]);

                if (UserName != "")
                {
                    if (UserName == "Admin")
                    {
                        pnlAdmin.Visible = true;
                        pnlUser.Visible = false;
                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                        pnlUser.Visible = true;
                    }
                  
                    
                }
                else
                {
                    pnlUser.Visible = false;
                    pnlAdmin.Visible = false;
                   
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }  
    }

    
}

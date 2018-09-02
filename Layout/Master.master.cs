using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Layout_AdminMaster : System.Web.UI.MasterPage
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = Convert.ToString(Session["CompanyName"]);
        //if ((Convert.ToString(Session["LoginId"]) == null && Convert.ToString(Session["Rname"]) != "Administator") || (Convert.ToString(Session["LoginId"]) == null && Convert.ToString(Session["Rname"]) != "Principle") || (Convert.ToString(Session["subadmin1"]) == null && Convert.ToString(Session["Rname"]) != "subadmin1"))
        //{
        if ((Convert.ToString(Session["LoginId"]) == null || Convert.ToString(Session["LoginId"]) == "" && Convert.ToString(Session["Rname"]) != "Administator"))
        {
            Response.Redirect("../Login.aspx");

        }
        if (!IsPostBack)
        {

            getAllMainMenu();
            //getAllMainMenu1();
        }
        //ListControlCollections();

    }
    private void getAllMainMenu()
    {
        try
        {
            int Role = Convert.ToInt32(Session["Role"]);
            string Sql = " Select MenuId from Role where RoleId=" + Role + "";
            string Menus = Convert.ToString(cc.ExecuteScalar(Sql));
            Sql = "Select distinct MenuId from Menu where MenuId in("+Menus +")";


            mPractice.Visible = false;
            mExam.Visible = false;
            mUserDetails.Visible = false;

            //mEmployee.Visible = false;
            //mStudent.Visible = false;
            //mExamination.Visible = false;
            //mLibrary.Visible = false;
            //mHostel.Visible = false;
            //mAccount.Visible = false;
            //mReports.Visible = false;
            
         
 
            DataSet ds =cc.ExecuteDataset(Sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string Id = Convert.ToString(dr["MenuId"]);
                if (Id == "18")
                {
                   mPractice.Visible = true;
                }
                else if (Id == "19")
                {
                   mExam.Visible = true;
                }               
                else if (Id == "7")
                {
                    mUserDetails.Visible = true;
                }
                
            }

            
        }
        catch (Exception ex)
        { }
    }
   
    //public void meniitem()
    //{
    //    if (Label3.Text == "")
    //    {
    //        if (MenuItem1.SelectedValue.CompareTo("Exam") == 0)
    //        {

    //            MenuItem1.SelectedItem.Enabled = false;

    //        }
    //    }
    //}
}

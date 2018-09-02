using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

public partial class Master_MainMaster : System.Web.UI.MasterPage
{
    //DataSet ds = new DataSet();
    static string menuid = "";
    MenuItem tn;
    Connection scon = new Connection();
    CommonCode cc = new CommonCode();


    SqlConnection con = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {

            if (Convert.ToString(Session["MarketingUser"]) == null || Convert.ToString(Session["MarketingUser"]) == "")
            {
                Response.Redirect("../MarketingAdmin/Login1.aspx");

            }
            getmenu();
            string UserName = Convert.ToString(Session["MarketingUser"]);


        }

        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void mnuMainMenu_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
    public void getmenu()
    {
        con = scon.Connect();

        try
        {
            //con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            string str = "select PageAccessPerm from [Come2myCityDB].[come2mycity].[SubMenuPermission] where RoleId='" + Session["RoleId"].ToString() + "'";
            string Menus = Convert.ToString(cc.ExecuteScalar(str));
            string rid = Session["RoleId"].ToString();
            if (rid == "1")
            {
                pnlAdminLeftMenu.Visible = true;
            }
            //if (Session["RoleId"] == "1")
            //{
            //    pnlAdminLeftMenu.Visible = true;
            //}
            string Sql = "Select distinct pageparentid,pagename from [Come2myCityDB].[come2mycity].[PageMenuMaster] where pageid in(" + Menus + ")";
            mAdminUser.Visible = false;
            mSMS.Visible = false;
            mLongCode.Visible = false;
            mMemberRegistration.Visible = false;
            mNews.Visible = false;
            mudise.Visible = false;
            Vmandal.Visible = false;

            DataSet ds = cc.ExecuteDataset(Sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                string Id = Convert.ToString(dr["pageparentid"]);
                if (Id == "2")
                {
                    mAdminUser.Visible = true;


                }
                else if (Id == "7")
                {
                    mSMS.Visible = true;


                }
                else if (Id == "14")
                {
                    mLongCode.Visible = true;


                }
                else if (Id == "18")
                {
                    mMemberRegistration.Visible = true;

                }
                else if (Id == "20")
                {
                    mNews.Visible = true;

                }
                else if (Id == "53")
                {
                    mudise.Visible = true;

                }
                else if (Id == "63")
                {
                    Vmandal.Visible = true;
                }


            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
    }
    //public void populate()
    //{
    //    con = scon.Connect();

    //    try
    //    {
    //        int pid = -1;
    //        string str = "";
    //        //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    //        //  string st = Session["UserRole"].ToString();
    //        //if (Session["UserRole"].ToString() == "Administrator")
    //        //{
    //        //    str = "select PageId,PageDescription,PageUrl,(select count(*) FROM tbl_PageMaster WHERE PageParentId=pm.PageId) childnodecount FROM tbl_PageMaster pm where PageParentId=" + pid + "";
    //        //}
    //        //else
    //        //{
    //        str = "select PageId,PageDescription,PageUrl,(select count(*) FROM PageMenuMaster WHERE PageParentId=pm.PageId) childnodecount FROM PageMenuMaster pm where PageParentId=" + pid + " and PageId in (" + menuid + ")";
    //        //}
    //        SqlDataAdapter da = new SqlDataAdapter(str, con);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        //PopulateNodes(dt, mnuMainMenu.Items);
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //}
    //public void PopulateNodes(DataTable dt, MenuItemCollection menuitems)
    //{
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        tn = new MenuItem();
    //        tn.Text = dr["PageDescription"].ToString();
    //        tn.Value = dr["PageId"].ToString();
    //        tn.NavigateUrl = dr["PageUrl"].ToString();
    //        menuitems.Add(tn);
    //        int parntid = Convert.ToInt32(tn.Value.ToString());
    //        string pname = tn.Text;
    //        int chcount = Convert.ToInt32(dr[3].ToString());
    //        if (chcount > 0)
    //        {
    //            populateSubMenu(parntid, tn);
    //        }

    //    }
    //}
    //public void populateSubMenu(int PageParentId, MenuItem ParentItem)
    //{
    //    con = scon.Connect();

    //    try
    //    {
    //        //SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    //        // string str = "select PageId,PageDescription,PageUrl, (select count(*) FROM tbl_PageMaster WHERE PageParentId=pm.PageId) childnodecount FROM tbl_PageMaster pm where PageParentId=@PageParentId and PageId in (" + menuid + ")";
    //        string str1 = "";
    //        //if (Session["UserRole"].ToString() == "Administrator")
    //        //{
    //        //    str1 = "select PageId,PageDescription,PageUrl,(select count(*) FROM tbl_PageMaster WHERE PageParentId=pm.PageId) childnodecount FROM tbl_PageMaster pm where PageParentId=@PageParentId";
    //        //}
    //        //else
    //        {
    //            str1 = "select PageId,PageDescription,PageUrl,(select count(*) FROM PageMenuMaster WHERE PageParentId=pm.PageId) childnodecount FROM PageMenuMaster pm where PageParentId=@PageParentId and PageId in (" + menuid + ")";
    //        }
    //        SqlCommand cmd = new SqlCommand(str1, con);
    //        cmd.Parameters.Add("@PageParentId", SqlDbType.Int).Value = PageParentId;
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        da.Fill(dt);
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            tn = new MenuItem();
    //            tn.Text = dr["PageDescription"].ToString();
    //            tn.Value = dr["PageId"].ToString();
    //            tn.NavigateUrl = dr["PageUrl"].ToString();
    //            ParentItem.ChildItems.Add(tn);
    //            int chcount = Convert.ToInt32(dr[3].ToString());
    //            int parntid = Convert.ToInt32(tn.Value.ToString());
    //            string pname = tn.Text;
    //            if (chcount > 0)
    //            {
    //                populateSubMenu(parntid, tn);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //}




}
//private void pnlUser1()
//{
//    try
//    {
//        userid.Visible = false;
//        rp.Visible = false;
//        ag.Visible = false;
//        sp.Visible = false;
//        sm1.Visible = false;
//        dk.Visible = false;
//        //vs.Visible = false;
//        sc.Visible = false;
//        efu.Visible = false;
//        Nws.Visible = false;
//        up1.Visible = false;

//    }
//    catch (Exception ex)
//    {
//        string m = ex.Message;
//    }
//}

//private void pnlAdminLeftMenu1()
//{
//    try
//    {
//        Cm.Visible = false;
//        sm.Visible = false;
//        Dstm.Visible = false;
//        Ctym.Visible = false;
//        Catr.Visible = false;
//        Atr.Visible = false;
//        It.Visible = false;
//        IcV.Visible = false;
//        IcI.Visible = false;
//        Adv.Visible = false;
//        up1.Visible = false;


//    }
//    catch (Exception ex)
//    {
//        string m = ex.Message;
//    }
//}


//private void pnlAdminLeftMenu2()
//{
//    try
//    {
//        Cm.Visible = true;
//        sm.Visible = true;
//        Dstm.Visible = true;
//        Ctym.Visible = true;
//        Catr.Visible = true;
//        Atr.Visible = true;
//        It.Visible = true;
//        IcV.Visible = true;
//        IcI.Visible = true;
//        Adv.Visible = true;
//        up1.Visible = true;
//        JP.Visible = true;


//    }
//    catch (Exception ex)
//    {
//        string m = ex.Message;
//    }
//}

//    private void assignnmenu()
//    {
//        ArrayList a = new ArrayList();
//        string[] tmpdt=new string[50];
//        int rid= Convert.ToInt32(Session["RoleId"] );
//        try
//        {
//            string mid = "select MenuId from role where  RoleId=" + rid + "";

//            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
//            {
//                try
//                {
//                    using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.Text, mid))
//                    {
//                        while (dr.Read())
//                        {
//                            a.Add(dr["MenuId"]);
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//                finally
//                {
//                    con.Close();
//                }



//            }
//           for (int i = 0; i < a.Count; i++)
//            { 
//                string s=a[i] as string ;
//                 tmpdt = s.Split(',');
//            } 
//            for (int i = 0; i< tmpdt.Length; i++)
//                {
//                 if (tmpdt[i] == "24")
//                 {
//                     userid.Visible = true;
//                 }
//                 else if (tmpdt[i] == "25")
//                 {
//                     rp.Visible = true;

//                 }
//                 else if (tmpdt[i] == "26")
//                 {
//                     ag.Visible = true;


//                 }
//                 else if (tmpdt[i] == "27")
//                 {
//                     sp.Visible = true;
//                 }
//                 else if (tmpdt[i] == "28")
//                 {
//                     sm1.Visible = true;
//                 }
//                 else if (tmpdt[i] == "29")
//                 {
//                     dk.Visible = true;

//                 }
//                 else if (tmpdt[i] == "30")
//                 {
//                     //vs.Visible = true;
//                 }
//                 else if (tmpdt[i] == "31")
//                 {
//                     efu.Visible = true;

//                 }
//                 else if (tmpdt[i] == "32")
//                 {
//                     Nws.Visible = true;
//                 }
//                 else if (tmpdt[i] == "33")
//                 {
//                     Cm.Visible = true;

//                 }
//                 else if (tmpdt[i] == "34")
//                 {
//                     sm.Visible = true;

//                 }
//                 else if (tmpdt[i] == "35")
//                 {
//                     Dstm.Visible = true;
//                 }
//                 else if (tmpdt[i] == "36")
//                 {
//                     Ctym.Visible = true;

//                 }
//                 else if (tmpdt[i] == "37")
//                 {
//                     Catr.Visible = true;

//                 }
//                 else if (tmpdt[i] == "38")
//                 {
//                     Atr.Visible = true;
//                 }
//                 else if (tmpdt[i] == "39")
//                 {
//                     Atr.Visible = true;

//                 }
//                 else if (tmpdt[i] == "40")
//                 {
//                     IcV.Visible = true;

//                 }
//                 else if (tmpdt[i] == "41")
//                 {
//                     IcI.Visible = true;
//                 }
//                 else if (tmpdt[i] == "42")
//                 {
//                     Adv.Visible = true;
//                 }
//                 else if (tmpdt[i] == "43")
//                 {
//                     sc.Visible = true;

//                 }
//                     else if (tmpdt[i] == "48")
//                 {
//                     up1.Visible = true;

//                 }
//                 else if (tmpdt[i] == "49")
//                 {
//                     up1.Visible = true;

//                 }
//                 else
//                 {

//                 }
//            }



//        }
//        catch (Exception ex)
//        {
//            string m = ex.Message;
//        }

//}


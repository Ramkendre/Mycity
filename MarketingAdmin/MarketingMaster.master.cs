using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

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
                pnlUser1();
                pnlAdminLeftMenu1();
                string UserName = Convert.ToString(Session["MarketingUser"]);
                string role = Convert.ToString(Session["Role"]);
                if (UserName != "")
                {
                    if (UserName == "Admin" || role == "Adminnistrator")
                    {
                        pnlAdmin.Visible = true;
                        pnlUser.Visible = false;
                        pnlAdminLeftMenu.Visible = true;
                        pnlAdminLeftMenu2();
                    }
                    else if (role == "My city user")
                    {
                        pnlAdmin.Visible = false;
                        pnlUser.Visible = true;
                        userid.Visible = false;
                        pnlAdminLeftMenu.Visible = true;
                        cht.Visible = false;
                        assignnmenu();

                    }
                    else
                    {
                        pnlAdmin.Visible = false;
                        pnlUser.Visible = true;
                        pnlAdminLeftMenu.Visible = true;


                        assignnmenu();


                    }


                }
                else
                {

                    Response.Redirect("Login.aspx");

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
    private void pnlUser1()
    {
        try
        {
            userid.Visible = false;
            rp.Visible = false;
            ag.Visible = false;
            sp.Visible = false;
            sm1.Visible = false;
            dk.Visible = false;
            vs.Visible = false;
            sc.Visible = false;
            efu.Visible = false;
            Nws.Visible = false;
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    private void pnlAdminLeftMenu1()
    {
        try
        {
            Cm.Visible = false;
            sm.Visible = false;
            Dstm.Visible = false;
            Ctym.Visible = false;
            Catr.Visible = false;
            Atr.Visible = false;
            It.Visible = false;
            IcV.Visible = false;
            IcI.Visible = false;
            Adv.Visible = false;

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }


    private void pnlAdminLeftMenu2()
    {
        try
        {
            Cm.Visible = true;
            sm.Visible = true;
            Dstm.Visible = true;
            Ctym.Visible = true;
            Catr.Visible = true;
            Atr.Visible = true;
            It.Visible = true;
            IcV.Visible = true;
            IcI.Visible = true;
            Adv.Visible = true;

        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }

    private void assignnmenu()
    {
        ArrayList a = new ArrayList();
        string[] tmpdt=new string[50];
        int rid= Convert.ToInt32(Session["RoleId"] );
        try
        {
            string mid = "select MenuId from role where  RoleId=" + rid + "";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                try
                {
                    using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.Text, mid))
                    {
                        while (dr.Read())
                        {
                            a.Add(dr["MenuId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }



            }
           for (int i = 0; i < a.Count; i++)
            { 
                string s=a[i] as string ;
                 tmpdt = s.Split(',');
            } 
            for (int i = 0; i< tmpdt.Length; i++)
                {
                 if (tmpdt[i] == "24")
                 {
                     userid.Visible = true;
                 }
                 else if (tmpdt[i] == "25")
                 {
                     rp.Visible = true;

                 }
                 else if (tmpdt[i] == "26")
                 {
                     ag.Visible = true;


                 }
                 else if (tmpdt[i] == "27")
                 {
                     sp.Visible = true;
                 }
                 else if (tmpdt[i] == "28")
                 {
                     sm1.Visible = true;
                 }
                 else if (tmpdt[i] == "29")
                 {
                     dk.Visible = true;

                 }
                 else if (tmpdt[i] == "30")
                 {
                     vs.Visible = true;
                 }
                 else if (tmpdt[i] == "31")
                 {
                     efu.Visible = true;

                 }
                 else if (tmpdt[i] == "32")
                 {
                     Nws.Visible = true;
                 }
                 else if (tmpdt[i] == "33")
                 {
                     Cm.Visible = true;

                 }
                 else if (tmpdt[i] == "34")
                 {
                     sm.Visible = true;

                 }
                 else if (tmpdt[i] == "35")
                 {
                     Dstm.Visible = true;
                 }
                 else if (tmpdt[i] == "36")
                 {
                     Ctym.Visible = true;

                 }
                 else if (tmpdt[i] == "37")
                 {
                     Catr.Visible = true;

                 }
                 else if (tmpdt[i] == "38")
                 {
                     Atr.Visible = true;
                 }
                 else if (tmpdt[i] == "39")
                 {
                     Atr.Visible = true;

                 }
                 else if (tmpdt[i] == "40")
                 {
                     IcV.Visible = true;

                 }
                 else if (tmpdt[i] == "41")
                 {
                     IcI.Visible = true;
                 }
                 else if (tmpdt[i] == "42")
                 {
                     Adv.Visible = true;
                 }
                 else if (tmpdt[i] == "43")
                 {
                     sc.Visible = true;

                 }
                 else
                 {

                 }
            }
        


        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
   
}
}

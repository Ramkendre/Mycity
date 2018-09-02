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
using System.IO;


public partial class MarketingAdmin_Hirarchyreport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetRecord();
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            GetRecordHM();
            GetRecordTOHM();
        }

    }

    public void LoadGrid()
    {

    }


    public void GetRecord()
    {
        try
        {

            string userid = Convert.ToString(Session["MarketingUser"]);
            string Sql = "Select roleid from AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
            string Id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (!(Id == null || Id == ""))
            {

                //string sql = "select distinct asm11.id As ID, asm2.rolename as r2, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 , " +
                //"asm3.rolename as r3, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 , " +
                //"asm4.rolename as r4, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                //"asm5.rolename as r5, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 , " +
                //"asm6.rolename as r6, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                //"asm7.rolename as r7, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 , " +
                //"asm8.rolename as r8, U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                //"asm9.rolename as r9, U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                //"asm10.rolename as r10,  U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10, " +
                //"asm11.rolename as r11, U11.usrFirstName+' '+U11.usrLastName as CT, U11.usrMobileNo as CT_MNo, e11.userid as L11 ,TScode.SchoolCode " +

                //"from TreeDemo e2  " +
                //"join UserMaster as U2 on U2.usrUserId=e2.userid " +
                //"join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +

                //"join TreeDemo e3 on e2.id=e3.parentid " +
                //"join UserMaster as U3 on U3.usrUserId=e3.userid " +
                //"join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +

                //"join TreeDemo e4 on e3.id=e4.parentid  " +
                //"join UserMaster as U4 on U4.usrUserId=e4.userid " +
                //"join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid " +

                //"join TreeDemo e5 on e4.id=e5.parentid  " +
                //"join UserMaster as U5 on U5.usrUserId=e5.userid " +
                //"join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid " +


                //"join TreeDemo e6 on e5.id=e6.parentid  " +
                //"join UserMaster as U6 on U6.usrUserId=e6.userid " +
                //"join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid " +


                //"join TreeDemo e7 on e6.id=e7.parentid  " +
                //"join UserMaster as U7 on U7.usrUserId=e7.userid " +
                //"join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid " +


                //"join TreeDemo e8  on e7.id=e8.parentid  " +
                //"join UserMaster as U8 on U8.usrUserId=e8.userid " +
                //"join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid " +

                //"join TreeDemo e9 on e8.id=e9.parentid  " +
                //"join UserMaster as U9 on U9.usrUserId=e9.userid " +
                //"join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid " +


                //"join TreeDemo e10 on e9.id=e10.parentid  " +
                //"join UserMaster as U10 on U10.usrUserId=e10.userid " +
                //"join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid " +

                //"join TreeDemo e11 on e10.id=e11.parentid  " +
                //"join UserMaster as U11 on U11.usrUserId=e11.userid " +
                //"join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid " +
                //"join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  where asm10.roleid=76 ";


                string sql = " select distinct asm11.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
                        "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
                         " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                         " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
                         " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                         " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
                         " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                         " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                         " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
                         " sp11.RoleName as r11,e11.RoleId, U11.usrFirstName+' '+U11.usrLastName as CT, U11.usrMobileNo as CT_MNo, e11.userid as L11 ,TScode.SchoolCode  " +
                         " from TreeDemo e2 " +

                     " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                     " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
                     " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
                     " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

                     " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                     " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                     " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
                     " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

                     " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
                     " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
                     " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
                     " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

                     " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
                     " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
                     " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
                     " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

                     " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
                     " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
                     " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
                     " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


                     " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
                     " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
                     " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
                     " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

                      " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
                     "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
                      " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
                      " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


                      " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
                      " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
                      " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
                      " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


                      " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
                      " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
                      " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
                      " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


                      " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
                      " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
                      " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
                      " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";

                if (Id == "15")
                {
                    sql = sql + " and e2.userid ='" + userid + "'";
                }
                else if (Id == "16")
                {
                    sql = sql + " and e3.userid ='" + userid + "'";
                }
                else if (Id == "17")
                {
                    sql = sql + " and e4.userid ='" + userid + "'";
                }
                else if (Id == "18")
                {
                    sql = sql + " and e5.userid ='" + userid + "'";
                }
                else if (Id == "19")
                {
                    sql = sql + " and e6.userid ='" + userid + "'";
                }
                else if (Id == "20")
                {
                    sql = sql + " and e7.userid ='" + userid + "'";
                }
                else if (Id == "21")
                {
                    sql = sql + " and e8.userid ='" + userid + "'";
                }
                else if (Id == "75")
                {
                    sql = sql + " and e9.userid ='" + userid + "'";
                }
                else if (Id == "76")
                {
                    sql = sql + " and e10.userid ='" + userid + "'";
                }
                else if (Id == "77")
                {
                    sql = sql + " and e11.userid ='" + userid + "'";
                }

                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvschoolcode.DataSource = ds.Tables[0];
                    gvschoolcode.DataBind();

                }
            }
            else
            {

                string sql = " select distinct asm11.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
              "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
               " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
               " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
               " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
               " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
               " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
               " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
               " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
               " sp11.RoleName as r11,e11.RoleId, U11.usrFirstName+' '+U11.usrLastName as CT, U11.usrMobileNo as CT_MNo, e11.userid as L11 ,TScode.SchoolCode  " +
               " from TreeDemo e2 " +

           " join UserMaster as U2 on U2.usrUserId=e2.userid " +
           " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
           " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
           " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

           " join UserMaster as U3 on U3.usrUserId=e3.userid " +
           " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
           " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
           " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

           " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
           " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
           " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
           " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

           " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
           " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
           " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
           " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

           " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
           " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
           " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
           " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


           " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
           " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
           " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
           " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

            " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
           "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
            " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
            " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


            " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
            " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
            " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
            " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


            " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
            " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
            " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
            " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


            " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
            " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
            " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
            " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";


                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvschoolcode.DataSource = ds.Tables[0];
                    gvschoolcode.DataBind();

                }

            }
        }
        catch (Exception ex)
        {


        }
    }
    public void GetRecordTOHM()
    {
        try
        {

            string userid = Convert.ToString(Session["MarketingUser"]);
            string Sql = "Select roleid from AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
            string Id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (!(Id == null || Id == ""))
            {

                string sql = " select distinct asm10.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
                       "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
                        " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                        " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
                        " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                        " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
                        " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                        " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                        " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
                        " TScode.SchoolCode  " +
                        " from TreeDemo e2 " +

                    " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                    " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
                    " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
                    " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

                    " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                    " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                    " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
                    " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

                    " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
                    " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
                    " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
                    " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

                    " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
                    " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
                    " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
                    " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

                    " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
                    " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
                    " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
                    " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


                    " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
                    " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
                    " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
                    " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

                     " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
                    "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
                     " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
                     " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


                     " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
                     " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
                     " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
                     " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


                     " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
                     " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
                     " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
                     " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


                     " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
                     " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
                     " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
                     " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";

                if (Id == "15")
                {
                    sql = sql + " and e2.userid ='" + userid + "'";
                }
                else if (Id == "16")
                {
                    sql = sql + " and e3.userid ='" + userid + "'";
                }
                else if (Id == "17")
                {
                    sql = sql + " and e4.userid ='" + userid + "'";
                }
                else if (Id == "18")
                {
                    sql = sql + " and e5.userid ='" + userid + "'";
                }
                else if (Id == "19")
                {
                    sql = sql + " and e6.userid ='" + userid + "'";
                }
                else if (Id == "20")
                {
                    sql = sql + " and e7.userid ='" + userid + "'";
                }
                else if (Id == "21")
                {
                    sql = sql + " and e8.userid ='" + userid + "'";
                }
                else if (Id == "75")
                {
                    sql = sql + " and e9.userid ='" + userid + "'";
                }
                else if (Id == "76")
                {
                    sql = sql + " and e10.userid ='" + userid + "'";
                }
                else if (Id == "77")
                {
                    sql = sql + " and e11.userid ='" + userid + "'";
                }

                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvToHM.DataSource = ds.Tables[0];
                    gvToHM.DataBind();

                }
            }
            else
            {

                string sql = " select distinct asm10.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
                       "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
                        " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                        " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
                        " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                        " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
                        " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                        " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                        " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
                        " TScode.SchoolCode  " +
                        " from TreeDemo e2 " +

                    " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                    " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
                    " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
                    " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

                    " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                    " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                    " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
                    " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

                    " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
                    " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
                    " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
                    " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

                    " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
                    " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
                    " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
                    " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

                    " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
                    " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
                    " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
                    " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


                    " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
                    " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
                    " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
                    " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

                     " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
                    "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
                     " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
                     " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


                     " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
                     " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
                     " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
                     " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


                     " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
                     " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
                     " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
                     " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


                     " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
                     " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
                     " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
                     " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";

                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvToHM.DataSource = ds.Tables[0];
                    gvToHM.DataBind();

                }

            }
        }
        catch (Exception ex)
        {


        }
    }

    public void GetRecordHM()
    {
        try
        {

            string userid = Convert.ToString(Session["MarketingUser"]);
            string Sql = "Select roleid from AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
            string Id = Convert.ToString(cc.ExecuteScalar(Sql));
            if (!(Id == null || Id == ""))
            {

                string sql = " select distinct asm11.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
                       "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
                        " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                        " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
                        " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                        " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
                        " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                        " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                        " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
                        " sp11.RoleName as r11,e11.RoleId, U11.usrFirstName+' '+U11.usrLastName as CT, U11.usrMobileNo as CT_MNo, e11.userid as L11 ,TScode.SchoolCode  " +
                        " from TreeDemo e2 " +

                    " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                    " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
                    " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
                    " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

                    " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                    " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                    " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
                    " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

                    " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
                    " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
                    " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
                    " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

                    " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
                    " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
                    " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
                    " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

                    " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
                    " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
                    " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
                    " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


                    " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
                    " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
                    " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
                    " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

                     " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
                    "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
                     " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
                     " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


                     " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
                     " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
                     " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
                     " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


                     " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
                     " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
                     " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
                     " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


                     " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
                     " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
                     " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
                     " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";

                if (Id == "15")
                {
                    sql = sql + " and e2.userid ='" + userid + "'";
                }
                else if (Id == "16")
                {
                    sql = sql + " and e3.userid ='" + userid + "'";
                }
                else if (Id == "17")
                {
                    sql = sql + " and e4.userid ='" + userid + "'";
                }
                else if (Id == "18")
                {
                    sql = sql + " and e5.userid ='" + userid + "'";
                }
                else if (Id == "19")
                {
                    sql = sql + " and e6.userid ='" + userid + "'";
                }
                else if (Id == "20")
                {
                    sql = sql + " and e7.userid ='" + userid + "'";
                }
                else if (Id == "21")
                {
                    sql = sql + " and e8.userid ='" + userid + "'";
                }
                else if (Id == "75")
                {
                    sql = sql + " and e9.userid ='" + userid + "'";
                }
                else if (Id == "76")
                {
                    sql = sql + " and e10.userid ='" + userid + "'";
                }
                else if (Id == "77")
                {
                    sql = sql + " and e11.userid ='" + userid + "'";
                }

                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvHmTeacher.DataSource = ds.Tables[0];
                    gvHmTeacher.DataBind();

                }
            }
            else
            {

                string sql = " select distinct asm11.id As ID, sp2.RoleName as r2, e2.RoleId, U2.usrFirstName+' '+U2.usrLastName as DSEName, U2.usrMobileNo as DSE_MNo, e2.userid as L2 ,  " +
                        "  sp3.RoleName as r3,e3.RoleId, U3.usrFirstName+' '+U3.usrLastName as DE, U3.usrMobileNo as DE_MNo,e3.userid as L3 ,  " +
                         " sp4.RoleName as r4, e4.RoleId, U4.usrFirstName+' '+U4.usrLastName as DDE, U4.usrMobileNo as DDE_MNo,e4.userid as L4 , " +
                         " sp5.RoleName as r5,e5.RoleId, U5.usrFirstName+' '+U5.usrLastName as EO, U5.usrMobileNo as EO_MNo,e5.userid as L5 ,  " +
                         " sp6.RoleName as r6, e6.RoleId, U6.usrFirstName+' '+U6.usrLastName as DEO, U6.usrMobileNo as DEO_MNo,e6.userid as L6 , " +
                         " sp7.RoleName as r7, e7.RoleId, U7.usrFirstName+' '+U7.usrLastName as BEO, U7.usrMobileNo as BEO_MNo,e7.userid as L7 ,  " +
                         " sp8.RoleName as r8, e8.RoleId,U8.usrFirstName+' '+U8.usrLastName as ExtO, U8.usrMobileNo as ExtO_MNo,e8.userid as L8 , " +
                         " sp9.RoleName as r9, e9.RoleId,U9.usrFirstName+' '+U9.usrLastName as CH, U9.usrMobileNo as CH_MNo,e9.userid as L9 , " +
                         " sp10.RoleName as r10, e10.RoleId, U10.usrFirstName+' '+U10.usrLastName as HM, U10.usrMobileNo as HM_MNo,e10.userid as L10,  " +
                         " sp11.RoleName as r11,e11.RoleId, U11.usrFirstName+' '+U11.usrLastName as CT, U11.usrMobileNo as CT_MNo, e11.userid as L11 ,TScode.SchoolCode  " +
                         " from TreeDemo e2 " +

                     " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                     " join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +
                     " join TreeDemo e3 on e2.id=e3.parentid  and e2.RoleId=15" +
                     " join SubMenuPermission sp2 on sp2.Roleid=e2.RoleId" +

                     " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                     " join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                     " join TreeDemo e4 on e3.id=e4.parentid   and e3.RoleId=16 " +
                     " join SubMenuPermission sp3 on sp3.Roleid=e3.RoleId " +

                     " join UserMaster as U4 on U4.usrUserId=e4.userid  " +
                     " join AdminSubMarketingSubUser as asm4 on asm4.friendid=e4.userid  " +
                     " join TreeDemo e5 on e4.id=e5.parentid    and e4.RoleId=17 " +
                     " join SubMenuPermission sp4 on sp4.Roleid=e4.RoleId " +

                     " join UserMaster as U5 on U5.usrUserId=e5.userid  " +
                     " join AdminSubMarketingSubUser as asm5 on asm5.friendid=e5.userid  " +
                     " join TreeDemo e6 on e5.id=e6.parentid    and e5.RoleId=18 " +
                     " join SubMenuPermission sp5 on sp5.Roleid=e5.RoleId " +

                     " join UserMaster as U6 on U6.usrUserId=e6.userid  " +
                     " join AdminSubMarketingSubUser as asm6 on asm6.friendid=e6.userid  " +
                     " join TreeDemo e7 on e6.id=e7.parentid   and e6.RoleId=19 " +
                     " join SubMenuPermission sp6 on sp6.Roleid=e6.RoleId " +


                     " join UserMaster as U7 on U7.usrUserId=e7.userid  " +
                     " join AdminSubMarketingSubUser as asm7 on asm7.friendid=e7.userid  " +
                     " join TreeDemo e8  on e7.id=e8.parentid  and e7.RoleId=20 " +
                     " join SubMenuPermission sp7 on sp7.Roleid=e7.RoleId " +

                      " join UserMaster as U8 on U8.usrUserId=e8.userid  " +
                     "  join AdminSubMarketingSubUser as asm8 on asm8.friendid=e8.userid  " +
                      " join TreeDemo e9 on e8.id=e9.parentid   and e8.RoleId=21 " +
                      " join SubMenuPermission sp8 on sp8.Roleid=e8.RoleId " +


                      " join UserMaster as U9 on U9.usrUserId=e9.userid  " +
                      " join AdminSubMarketingSubUser as asm9 on asm9.friendid=e9.userid  " +
                      " join TreeDemo e10 on e9.id=e10.parentid  and e9.RoleId=75 " +
                      " join SubMenuPermission sp9 on sp9.Roleid=e9.RoleId  " +


                      " join UserMaster as U10 on U10.usrUserId=e10.userid  " +
                      " join AdminSubMarketingSubUser as asm10 on asm10.friendid=e10.userid  " +
                      " join TreeDemo e11 on e10.id=e11.parentid  and e10.RoleId=76 " +
                      " join SubMenuPermission sp10 on sp10.Roleid=e10.RoleId " +


                      " join UserMaster as U11 on U11.usrUserId=e11.userid  " +
                      " join AdminSubMarketingSubUser as asm11 on asm11.friendid=e11.userid  " +
                      " join UDISE_TeacherMaster as TScode on TScode.junior_id=e11.userid  " +
                      " join SubMenuPermission sp11 on sp11.Roleid=e11.RoleId   where asm10.roleid=76  ";


                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvHmTeacher.DataSource = ds.Tables[0];
                    gvHmTeacher.DataBind();

                }

            }
        }
        catch (Exception ex)
        {


        }
    }
    protected void gvschoolcode_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvschoolcode.PageIndex = e.NewPageIndex;
        GetRecord();
    }


    protected void gvschoolcode_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }


    protected void gvschoolcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnDownloadExl_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnRadio.SelectedValue == "2")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                gvToHM.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            else if (btnRadio.SelectedValue == "1")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                gvHmTeacher.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            else
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                gvschoolcode.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnRadio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (btnRadio.SelectedValue == "2")
        {
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel2.Visible = true;
        }
        else if (btnRadio.SelectedValue == "1")
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
            Panel1.Visible = false;
        }
        else
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
            Panel2.Visible = false;
        }
    }
    protected void gvHmTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHmTeacher.PageIndex = e.NewPageIndex;
        GetRecordHM();
    }
    protected void gvToHM_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvToHM.PageIndex = e.NewPageIndex;
        GetRecordTOHM();
    }
}

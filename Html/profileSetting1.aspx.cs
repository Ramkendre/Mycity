using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
public partial class html_pro_1 : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLobj = new FriendGroupBLL();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    ChangePwdInOnlineExam.ChangePassword onlineexam = new ChangePwdInOnlineExam.ChangePassword();
    string s = "", fname = "", lname = "";
    string[] infix;
    CommonCode cc = new CommonCode();
    int status;

    public string registeredMobileNo;
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

                    //gvGroupshow();
                    show();
                    totalcount1();
                    gvFriendShow1();

                }
                catch { }
            }
        }

    }
    private void gvFriendShow()
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        string sql = "select FriRelId,Relation from FriendRelationMaster where userid='" + urUserRegBLLObj.usrUserId + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvRemoveFriend.DataSource = ds.Tables[0];
        gvRemoveFriend.DataBind();

    }

    private void gvFriendShow1()
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        //string sql = "select FriRelId,Relation from FriendRelationMaster where userid='" + urUserRegBLLObj.usrUserId + "'";
        string sql = "select usrFirstName+'  '+usrLastname as name, relation,FriRelId from " +
"FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId  " +
"where userid='" + urUserRegBLLObj.usrUserId + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvRemoveFriend.DataSource = ds.Tables[0];
        gvRemoveFriend.DataBind();

    }

    public void LoadUserInfo()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            DataTable dtUserMobileNumberSelect = urUserRegBLLObj.BLLUserMobileNoSelectById(urUserRegBLLObj);
            DataRow dRowMobileNo = dtUserMobileNumberSelect.Rows[0];
            lblRegisteredMobileNo.Text = Convert.ToString(dRowMobileNo["usrMobileNo"]);
            //txtNewMobileNo.Text = "123123";
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            DataSet dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
            gvRemoveFriend.DataSource = dtFriendRelList;
            gvRemoveFriend.DataBind();
            ViewState["RemoveFriend"] = dtFriendRelList;



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvRemoveFriend_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        ChangePassword();
    }

    //Change the Password for particular user
    public void ChangePassword()
    {

        bool flag = false;
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(txtOldPasswod.Text);
            urUserRegBLLObj.usrChangePassword = cc.DESEncrypt(txtConfirmNewPassword.Text);

            status = urUserRegBLLObj.BLLUserRegistrationChangePassword(urUserRegBLLObj);
            if (status > 0)
            {

                List<UserRegistrationBLL> usrInfoList = new List<UserRegistrationBLL>();
                DataTable dtUserInfoList = urUserRegBLLObj.BLLGetUserDetails(urUserRegBLLObj);
                DataRow dRowUserInfoList = dtUserInfoList.Rows[0];

                //string myMobileNo = "91" + Convert.ToString(dRowUserInfoList["usrMobileNo"]);

                string myMobileNo = Convert.ToString(dRowUserInfoList["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfoList["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfoList["usrFirstName"]);

                // string mPassword = cc.DESDecrypt(urUserRegBLLObj.usrChangePassword);
                int result = onlineexam.UpdatePwd(myMobileNo, Convert.ToString(dRowUserInfoList["usrPassword"]));
                string sendFrom = "COM2MYCT";

                string passwordMessage = "Dear " + myName + ",Your a/c password changed for come2mycity.com.New Password is: " + myPassword + " " + cc.AddSMS(myMobileNo);


                //  ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password  changed')", true);
                //string msg = "Your New Password is: " + cc.DESDecrypt(urUserRegBLLObj.usrChangePassword);
                flag = cc.SendMessageImp1(sendFrom, myMobileNo, passwordMessage);
                flag = cc.SendMessage1(sendFrom, myMobileNo, passwordMessage);

                if (flag == true)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.')", true);
                    // System.Windows.Forms.MessageBox.Show("Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.", "Come2MyCity");
                    // Response.Redirect("MyProfile.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.')", true);
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully But Message is not sent')", true);
                    // System.Windows.Forms.MessageBox.Show("Password Changed Successfully But Message is not sent", "Come2MyCity");
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Not changed')", true);
                // System.Windows.Forms.MessageBox.Show("Password Not changed", "Come2MyCity");
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Not changed')", true);
    }



    public void ChangeRegisteredMobileNo()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrMobileNo = txtNewMobileNo.Text;
            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            string MobileNo = Convert.ToString(txtNewMobileNo.Text);
            if (MobileNo.Length == 10)
            {
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);

                if (status == 0)
                {
                    txtNewMobileNo.Text = "";
                    txtNewMobileNo.Focus();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Given New Mobile Number already registered in come2mycity.com')", true);

                    // System.Windows.Forms.MessageBox.Show("Given New Mobile Number already registered in come2mycity.com", "Come2MyCity");
                }
                else
                {
                    status = urUserRegBLLObj.BLLUserRegisteredMobileNoUpdate(urUserRegBLLObj);

                    if (status > 0)
                    {

                        string senderId = "COM2MYCT";
                        //string myMobileNo = "91" + urUserRegBLLObj.usrMobileNo;
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = Convert.ToString(Session["userName"]);
                        string passwordMessage = "Dear " + myName + ",Password for ur Login with your New Registered Mobile No is:" + myPassword + " " + cc.AddSMS(myMobileNo);

                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Changed.Login Again')", true);
                        Response.Write("<script>alert('Mobile number Changed.Login Again')</script>");
                        // System.Windows.Forms.MessageBox.Show("Mobile number Changed Successfully.Login Again", "Come2MyCity");
                        Response.Redirect("Logout.aspx");
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Not changed.')", true);
                        Response.Write("<script>alert('Mobile number Not changed.')</script>");
                        // System.Windows.Forms.MessageBox.Show("Mobile number Not changed.Please try again", "Come2MyCity");
                        txtNewMobileNo.Text = "";

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('please Enter the 10 Disit mobile No..!')</script>");
            }
        }
        catch (Exception ex)
        {
            // throw ex;
        }
    }



    protected void btnNewMobileNoRegister_Click(object sender, EventArgs e)
    {
        ChangeRegisteredMobileNo();
        txtNewMobileNo.Text = "";

    }


    protected void gvRemoveFriend_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Remove")
        {

            urUserRegBLLObj.frnrelFriendId = Convert.ToString(e.CommandArgument);
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);

            status = urUserRegBLLObj.BLLUserFriendRelativeRemove(urUserRegBLLObj);

            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Removed')", true);
                urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
                DataSet dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not Removed')", true);
            }

            gvFriendShow1();


        }
        else if (e.CommandName == "Edit")
        {
            string Id = Convert.ToString(e.CommandArgument);

            if (Convert.ToString(e.CommandName) == "Edit")
            {
                Response.Redirect("FriendRelativeupdate.aspx?Id=" + Id);
            }











            // DataSet ds = cc.ExecuteDataset(Sql);


            //           foreach (DataRow dr in ds.Tables[0].Rows)
            //           {

            //               lblName.Text = Convert.ToString(dr["Name"]);
            //               //string name1 = lblName.Text;
            //               txtRelation.Text = Convert.ToString(dr["Relation"]);
            //               string GroupId = Convert.ToString(dr["GroupId"]);

            //               for (int i = 0; i < chkGroup.Items.Count - 1; i++)
            //               {
            //                   if (GroupId == Convert.ToString(chkGroup.Items[i].Value.ToString()))
            //                   {
            //                       chkGroup.Items[i].Selected = true;
            //                   }
            //               }
            //           }
            //           try
            //           {
            //               tmp.Value = Id;
            //               con.Open();
            //               string sql = "Select FriRelName from FriendRelationMaster where FriRelId= '" + Id.ToString() + "'";
            //               SqlCommand cmd = new SqlCommand(sql, con);


            //               SqlDataReader dr = cmd.ExecuteReader();
            //               DataSet dset = cc.ExecuteDataset(sql);
            //               foreach (DataRow dr1 in dset.Tables[0].Rows)
            //               {
            //                   fname = Convert.ToString(dr1["FriRelName"]);

            //               }
            //               string fullname = fname;
            //               infix = fullname.Split(' ');
            //               //ddlinfix.Items.Add(infix[0]);
            //               if (infix[1] == " " || infix[1] == null)
            //               {
            //                   ddlinfix.Items.Add("");
            //               }
            //               else
            //               {

            //                   ddlinfix.Items.Add(infix[1]);
            //               }








            //{
            //    ddlinfix.DataTextField = dr["UserFirstNameN"].ToString();
            //    ddlinfix.DataValueField = dr["User"].ToString();
            //}


            //  SqlDataAdapter da = new SqlDataAdapter(sql, con);
            //    DataSet dset = new DataSet();

            //    da.Fill(dset);
            //    ddlinfix.DataSource = dset;
            //     ddlinfix.DataTextField = "---Select--";

            //Session["UserFirstNameN"] = ddlinfix.SelectedItem.Text.ToString();
            // Session["UserLastNameN"] = ddlinfix.SelectedItem.Text.ToString();

            //ddlinfix.DataValueField = "usrUserId";
            //ddlinfix.DataTextField = "usrFirstName";
            //ddlinfix.DataTextField = "usrLastName";

            //    ddlinfix.DataBind();



            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


        }
        //mdlEditGroup.Show();


    }
    protected void gvSearchFriend_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    //protected void btnUpdateContact_Click(object sender, EventArgs e)
    //{

    //    string Id = tmp.Value;
    //    urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
    //    urUserRegBLLObj.frnrelFriendId = Convert.ToString(Id);

    //    urUserRegBLLObj.FrnrelPrefix = Convert.ToString(ddlprefix.SelectedItem.Text);
    //    if (ddlprefix.SelectedItem.Text == null)
    //    {
    //        urUserRegBLLObj.FrnrelPrefix = "Dear";
    //    }
    //    urUserRegBLLObj.Frnrelinfix = Convert.ToString(ddlinfix.SelectedItem.Text);
    //    if (ddlinfix.SelectedItem.Text == null)
    //    {
    //        urUserRegBLLObj.Frnrelinfix = infix[0];
    //    }
    //    urUserRegBLLObj.Frnrelpostfix = Convert.ToString(ddlpostfix.SelectedItem.Text);
    //    if (ddlpostfix.SelectedItem.Text == null)
    //    {
    //        urUserRegBLLObj.Frnrelpostfix = " ";
    //    }

    //    try
    //    {
    //        status = urUserRegBLLObj.BLLPrefixUpdate(urUserRegBLLObj);
    //        if (status == 0)
    //        {
    //            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists')", true);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //    string Sql = "Delete from friendGroupRelation where RelId=" + Id + "  ";
    //    Sql = Sql + " Update FriendRelationMaster set Relation='" + txtRelation.Text.ToString() + "' " +
    //        " where FriRelId=" + Id + " ";
    //    //sql1=Sql+"update "
    //    //for (int i = 0; i < chkGroup.Items.Count - 1; i++)
    //    //{
    //    //    if (chkGroup.Items[i].Selected == true)
    //    //    {
    //    //        Sql = Sql + " Insert into FriendGroupRelation (RelId, GroupId) Values " +
    //    //            " (" + Id + "," + chkGroup.Items[i].Value.ToString() + " ) ";
    //    //    }
    //    //}
    //    CommonCode cc = new CommonCode();
    //    int tmp1 = cc.ExecuteNonQuery(Sql);
    //    urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
    //   DataSet dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
    //    gvRemoveFriend.DataSource = dtFriendRelList;
    //    gvRemoveFriend.DataBind();

    //    urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
    //    string query = "select * from FriendRelationMaster where UserId='" + urUserRegBLLObj.frnrelUserId.ToString() + "'";
    //    DataSet ds = cc.ExecuteDataset(query);
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        string userid = Convert.ToString(dr["UserId"]);
    //        string frienduserid = Convert.ToString(dr["FriendId"]);

    //    }


    //}





    public void LoadFriendGroup(UserRegistrationBLL ur)
    {

        //chkGroup 
        DataTable dtFriendGroup = urUserRegBLLObj.BLLShowAllFriendGroup(urUserRegBLLObj);

        string Sql = " Select GroupName from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
        string Data = Convert.ToString(cc.ExecuteScalar(Sql));

        string[] tmp = Data.Split(',');
        int i = 0;
        foreach (DataRow dr in dtFriendGroup.Rows)
        {
            string tmpName = Convert.ToString(dr["GroupName"]);
            string tmpData = "";
            try
            {
                tmpData = tmp[i].ToString();
            }
            catch
            { }

            if (tmpData != "")
            {
                dr["GroupName"] = tmpData;
            }

            i++;
        }
    }

    //    chkGroup.DataSource = dtFriendGroup;
    //    chkGroup.DataValueField = "GroupId";
    //    chkGroup.DataTextField = "GroupName";
    //    chkGroup.DataBind();
    //}


    protected void gvRemoveFriend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRemoveFriend.EditIndex = -1;
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        DataSet dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();
    }


    protected void gvRemoveFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRemoveFriend.PageIndex = e.NewPageIndex;
        //DataTable dtFriendRel = (DataTable)ViewState["RemoveFriend"];
        //gvRemoveFriend.DataSource = dtFriendRel;
        //gvRemoveFriend.DataBind();
        gvFriendShow1();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }

    protected void gvSearchFriend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    string grpId;
    string grpName;
    protected void btnSearchRel_Click(object sender, EventArgs e)
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        urUserRegBLLObj.usrFirstName = Convert.ToString(txtFName.Text);
        urUserRegBLLObj.usrLastName = Convert.ToString(txtLName.Text);
        urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNo.Text);
        DataSet dtFriendRelList = urUserRegBLLObj.DalFienSearchFriend(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();
        ViewState["RemoveFriend"] = dtFriendRelList;
    }
    protected void btnDefineGroup_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    string Sql = "", GroupId = "", GroupName = "";
        //    foreach (GridViewRow gr in gvGroup.Rows)
        //    {
        //        try
        //        {
        //            //lblGroupId
        //            Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");
        //            GroupId = GroupId + "," + lbl.Text.ToString();
        //            TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
        //            GroupName = GroupName + "," + txt.Text.ToString();
        //        }
        //        catch (Exception ex)
        //        { }

        //    }
        //    Sql = "Update UserMaster set GroupId='" + GroupId.Substring(1) + "',GroupName='" + GroupName.Substring(1) + "' " +
        //        " Where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
        //    cc.ExecuteNonQuery(Sql);
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Updated Successfully')", true);
        //}
        //catch (Exception ex)
        //{
        //    //throw ex;
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Not Updated')", true);
        //}
    }

    //public void LoadGroupId()
    //{


    //    try
    //    {
    //        string Sql = "select FriendGroupMaster.friendGroupName as Name,FriendGroupMaster.friendGroupId as Id,count(FriendRelationMaster.friendGroup) as countsub from FriendGroupMaster " +
    //                     "    inner join FriendRelationMaster on FriendRelationMaster.friendGroup=FriendGroupMaster.friendGroupId" +

    //                     "     where FriendRelationMaster.UserId='" + Convert.ToString(Session["User"]) + "'" +
    //                      "   group by FriendGroupMaster.friendGroupName,FriendGroupMaster.friendGroupId";
    //        DataSet ds = new DataSet();
    //        ds = cc.ExecuteDataset(Sql);
    //        gvGroup.DataSource = ds.Tables[0];
    //        gvGroup.DataBind();
    //        //totalcount();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    private void gvGroupshow()
    {
        try
        {
            //   string Sql = " Select GroupId as Id, FroupName as Name from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            //   SqlDataAdapter da = new SqlDataAdapter(Sql,cn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //  object s = ds.Tables[0].Rows[0][0];
            //  //object s1 = ds.Tables[0].Rows[0][1];
            //  string ss = (string)s;
            //  // string[] ArrLine = ss.Split(',');


            //  // gvGroup.DataSource = ArrLine;
            //  // gvGroup.DataBind();

            //ArrayList arrlist = new ArrayList();
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    arrlist.Add(dr);
            //}
            //gvGroup.DataSource = ds;
            //gvGroup.DataBind();

            string sql = "select GroupId as Id, GroupName as Name from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            DataSet ds = cc.ExecuteDataset(sql);

            DataTable dt = ds.Tables[0];
            string strId = dt.Rows[0][0].ToString();// 0 is index of ID column in datatable
            string strName = dt.Rows[0][1].ToString();// 1 is index of Name column in datatable

            //dt.Rows.Clear();
            int rowCount = 0;
            while (strId.Length != 0)
            {
                int id = Convert.ToInt32(strId.Substring(0, strId.IndexOf(',')));
                strId = strId.Substring(strId.IndexOf(',') + 1);
                string name = strName.Substring(0, strName.IndexOf(','));
                strName = strName.Substring(strId.IndexOf(',') + 1);

                dt.Rows[rowCount]["ID"] = id; // ID is column name of your table dt
                dt.Rows[rowCount]["Name"] = name;// Name is column name of your table dt
            }

            //YourDataGridView.DataSource = dt;
            //YourDataGridView.DataBind();
            gvgroup.DataSource = dt;
            gvgroup.DataBind();

        }
        catch (Exception ex)
        {
            string s = ex.Message;
        }

        //    public void splitgridcell()
        //{
        //    try
        //    {
        //        object s = ds.Tables[0].Rows[0][0];

        //        string ss = (string)s;
        //        string[] ArrLine = ss.Split(' ');


        //        GridView1.DataSource = ArrLine;
        //        GridView1.DataBind();


        //    }
        //    catch (Exception ex)
        //    {
        //        string s = ex.Message;
        //    }
        //}

        //    gvGroup.DataSource = ds.Tables[0];


        //gvGroup.DataBind();
        //foreach (GridViewRow gr in gvGroup.Rows)
        //{
        //    try
        //    {
        //        lblGroupId
        //        Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");
        //        Label lbl1=(Label)gr.Cells[0]..FindControl("lblGroupId");
        //        GroupId = GroupId + "," + lbl.Text.ToString();
        //        TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
        //        GroupName = GroupName + "," + txt.Text.ToString();

        //        Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");

        //        GroupId = GroupId + "," + lbl.Text.ToString();
        //        TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
        //        GroupName = GroupName + "," + txt.Text.ToString();
        //      string[] str=GroupId.Split(',');
        //      string[] str1= GroupName.Split(',');
        //      for (int i = 0; i < str.Length; i++)
        //      {
        //          gr.Cells[0].Text = str[1].ToString();
        //          gr.Cells[1].Text = str1[1].ToString();

        //      }


        //    }
        //    catch (Exception ex)
        //    { }

        //}
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


            SqlDataAdapter da = new SqlDataAdapter(sql30, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
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




    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "", GroupId = "", GroupName = "";
            foreach (GridViewRow gr in gvgroup.Rows)
            {
                try
                {
                    //lblGroupId
                    Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");
                    GroupId = GroupId + "," + lbl.Text.ToString();
                    TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
                    GroupName = GroupName + "," + txt.Text.ToString();
                }
                catch (Exception ex)
                { }

            }
            Sql = "Update UserMaster set GroupId='" + GroupId.Substring(1) + "',GroupName='" + GroupName.Substring(1) + "' " +
                " Where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            cc.ExecuteNonQuery(Sql);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Updated Successfully')", true);
        }
        catch (Exception ex)
        {
            //throw ex;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Not Updated')", true);
        }
    }
    public void show()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            string sql = "select groupid,groupname from usermaster where usrUserid='" + urUserRegBLLObj.usrUserId + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            object ss = ds.Tables[0].Rows[0][0];

            string sss = (string)ss;

            string[] ArrLine = sss.Split(',');
            object p = ds.Tables[0].Rows[0][1];
            string pp = (string)p;
            string[] groupname = pp.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("groupid", Type.GetType("System.String"));
            dt.Columns.Add("groupname", Type.GetType("System.String"));

            dt.Rows.Add();
            DataTable table = new DataTable();

            table.Columns.Add("groupid", Type.GetType("System.String"));
            foreach (string value in ArrLine)
            {
                DataRow row = table.NewRow();
                row["groupid"] = value;
                table.Rows.Add(row);
            }
            table.Columns.Add("groupname", Type.GetType("System.String"));
            int i = 0;
            foreach (string value in groupname)
            {
                DataRow row = table.NewRow();
                //DataRow sd[0][1]=table.NewRow();

                row["groupname"] = value;
                //table.Rows.Add(row);

                table.Rows[i++][1] = value;

            }
            gvgroup.DataSource = table;
            gvgroup.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvgroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            string FNumber = Convert.ToString(ddlMyFriendGroup.SelectedValue);
            string Sql = "Delete From FriendRelationMaster where userId='" + Convert.ToString(Session["User"]) + "' and FR" + FNumber + "='" + ddlMyFriendGroup.SelectedValue + "' and FR1=1";
            int k = cc.ExecuteNonQuery(Sql);
            if (k > 1)
            {
                totalcount1();
                ShowFriendList();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Deleted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Not Deleted Successfully')", true);
            }
        }
        catch (Exception ex)
        { }
    }
    protected void ddlMyFriendGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowFriendList();
    }
    public void ShowFriendList()
    {
        try
        {
            string usrIdSn = Convert.ToString(Session["User"]);
            if (ddlMyFriendGroup.SelectedValue == "0")
            {


            }
            else
            {
                string FNumber = Convert.ToString(ddlMyFriendGroup.SelectedValue);
                string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                 " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "' and  FR" + FNumber + "='" + ddlMyFriendGroup.SelectedValue + "'";
                DataSet ds = cc.ExecuteDataset(newsql);

                gvAddressBook.DataSource = ds.Tables[0];
                gvAddressBook.DataBind();
            }
        }
        catch (Exception ec)
        {

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ShowFriendList();
    }

}








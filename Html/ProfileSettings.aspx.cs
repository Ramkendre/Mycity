using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

public partial class Html_ProfileSettings : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLobj = new FriendGroupBLL();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    string s="", fname="",lname="";
    string[] infix;
    CommonCode cc = new CommonCode();
    int status;
    public string registeredMobileNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (!IsPostBack)
            {
                try
                {
                    LoadUserInfo();
                    LoadFriendGroup();
                    //gvSearchFriend.Visible = false;
                    gvRemoveFriend.Visible = true;
                    LoadGroupId();
                }
                catch { }
            }
        
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
            DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
            gvRemoveFriend.DataSource = dtFriendRelList;
            gvRemoveFriend.DataBind();
            ViewState["RemoveFriend"] = dtFriendRelList;



        }
        catch (Exception ex)
        {
            throw ex;
        }
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

                string sendFrom = "COM2MYCT";

                string passwordMessage = "" + myName + ",Your a/c password changed for come2mycity.com.New Password is: " + myPassword + " " + cc.AddSMS(myMobileNo);


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
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Changed.Login Again')", true);
                    // System.Windows.Forms.MessageBox.Show("Mobile number Changed Successfully.Login Again", "Come2MyCity");
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Not changed.')", true);
                    // System.Windows.Forms.MessageBox.Show("Mobile number Not changed.Please try again", "Come2MyCity");
                    txtNewMobileNo.Text = "";

                }
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
        //string name1 = "";
        ////string Id1="";
        //string Id1 = Convert.ToString(e.CommandArgument);
        //tmp.Value = Id1;
        //string Sql1 = " SELECT DISTINCT UserMaster.usrFirstName +' '+ UserMaster.usrLastName as Name , " +
        //    " FriendRelationMaster.Relation, FriendGroupRelation.GroupId  " +
        // " FROM  FriendGroupRelation INNER JOIN " +
        //         " FriendRelationMaster ON FriendGroupRelation.RelId = FriendRelationMaster.FriRelId INNER JOIN " +
        //         " UserMaster ON FriendRelationMaster.FriendId = UserMaster.usrUserId " +
        //         " where FriendRelationMaster.FriRelId=" + Id1 + "";
        //CommonCode cc1 = new CommonCode();
        //DataSet ds1 = cc1.ExecuteDataset(Sql1);
        //foreach (DataRow dr in ds1.Tables[0].Rows)
        //{
        //    name1 = Convert.ToString(dr["Name"]);
        //    string Relation = Convert.ToString(dr["Relation"]);

        //}
        if (e.CommandName == "Remove")
        {
            urUserRegBLLObj.frnrelFriendId = Convert.ToString(e.CommandArgument);
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);

            status = urUserRegBLLObj.BLLUserFriendRelativeRemove(urUserRegBLLObj);

            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Removed')", true);
                urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
                DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
                gvRemoveFriend.DataSource = dtFriendRelList;
                gvRemoveFriend.DataBind();
                //gvSearchFriend.DataSource = dtFriendRelList;
                //gvSearchFriend.DataBind();
                //TextfirstN.Text = "";
                //TextlastN.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not Removed')", true);
            }

        }
        else if (e.CommandName == "Edit")
        {
           s = Convert.ToString(e.CommandArgument); 
            urUserRegBLLObj.frnrelFriendId = Convert.ToString(e.CommandArgument);
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
            
            LoadFriendGroup();
            string Id = Convert.ToString( e.CommandArgument);
          
            tmp.Value=Id;
            string Sql = " SELECT DISTINCT UserMaster.usrFirstName +' '+ UserMaster.usrLastName as Name , " +
                " FriendRelationMaster.Relation, FriendGroupRelation.GroupId  " +
             " FROM         FriendGroupRelation INNER JOIN "+
                     " FriendRelationMaster ON FriendGroupRelation.RelId = FriendRelationMaster.FriRelId INNER JOIN "+
                     " UserMaster ON FriendRelationMaster.FriendId = UserMaster.usrUserId "+
                     " where FriendRelationMaster.FriRelId="+Id+"";
            CommonCode cc = new CommonCode();
            DataSet ds = cc.ExecuteDataset(Sql);
            
          
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                lblName.Text = Convert.ToString(dr["Name"]);
                //string name1 = lblName.Text;
                txtRelation.Text = Convert.ToString(dr["Relation"]);
                string GroupId = Convert.ToString(dr["GroupId"]);
              
                for (int i = 0; i < chkGroup.Items.Count - 1; i++)
                {
                    if (GroupId == Convert.ToString(chkGroup.Items[i].Value.ToString()))
                    {
                        chkGroup.Items[i].Selected = true;
                    }
                }
            }
            try
            {
                 tmp.Value=Id;
                con.Open();
                string sql = "Select FriRelName from FriendRelationMaster where FriRelId= '" + Id.ToString() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
            

                SqlDataReader dr = cmd.ExecuteReader();
                DataSet dset = cc.ExecuteDataset(sql);
                 foreach (DataRow dr1 in dset.Tables[0].Rows)
                 {
                    fname =Convert.ToString(dr1["FriRelName"]);
                     
                 }
                 string fullname = fname;
             infix = fullname.Split(' ');
               ddlinfix.Items.Add(infix[0]);
               if (infix[1] ==" "||infix[1]==null)
               {
                   ddlinfix.Items.Add("");
               }
               else
               {

                   ddlinfix.Items.Add(infix[1]);
               }


            
               

                


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
               
                ddlinfix.DataBind();



           }
            catch (Exception ex)
            {
                throw ex;
            }

            mdlEditGroup.Show();
        }

    }
    protected void gvSearchFriend_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string name1 = "";
        ////string Id1="";
        //string Id1 = Convert.ToString(e.CommandArgument);
        //tmp.Value = Id1;
        //string Sql1 = " SELECT DISTINCT UserMaster.usrFirstName +' '+ UserMaster.usrLastName as Name , " +
        //    " FriendRelationMaster.Relation, FriendGroupRelation.GroupId  " +
        // " FROM         FriendGroupRelation INNER JOIN " +
        //         " FriendRelationMaster ON FriendGroupRelation.RelId = FriendRelationMaster.FriRelId INNER JOIN " +
        //         " UserMaster ON FriendRelationMaster.FriendId = UserMaster.usrUserId " +
        //         " where FriendRelationMaster.FriRelId=" + Id1 + "";
        //CommonCode cc1 = new CommonCode();
        //DataSet ds1 = cc1.ExecuteDataset(Sql1);
        //foreach (DataRow dr in ds1.Tables[0].Rows)
        //{
        //    name1 = Convert.ToString(dr["Name"]);
        //    string Relation = Convert.ToString(dr["Relation"]);

        //}
        //if (e.CommandName == "Remove")
        //{
        //    urUserRegBLLObj.frnrelFriendId = Convert.ToString(e.CommandArgument);
        //    urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);

        //    status = urUserRegBLLObj.BLLUserFriendRelativeRemove(urUserRegBLLObj);

        //    if (status == 1)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Removed')", true);
        //        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        //        DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
        //        gvRemoveFriend.DataSource = dtFriendRelList;
        //        gvRemoveFriend.DataBind();
        //        //gvSearchFriend.DataSource = dtFriendRelList;
        //        //gvSearchFriend.DataBind();
        //        //TextfirstN.Text = "";
        //        //TextlastN.Text = "";
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not Removed')", true);
        //    }

        //}
        //else if (e.CommandName == "Edit")
        //{
        //    LoadFriendGroup();
        //    string Id = Convert.ToString(e.CommandArgument);

        //    tmp.Value = Id;
        //    string Sql = " SELECT DISTINCT UserMaster.usrFirstName +' '+ UserMaster.usrLastName as Name , " +
        //        " FriendRelationMaster.Relation, FriendGroupRelation.GroupId  " +
        //     " FROM         FriendGroupRelation INNER JOIN " +
        //             " FriendRelationMaster ON FriendGroupRelation.RelId = FriendRelationMaster.FriRelId INNER JOIN " +
        //             " UserMaster ON FriendRelationMaster.FriendId = UserMaster.usrUserId " +
        //             " where FriendRelationMaster.FriRelId=" + Id + "";
        //    CommonCode cc = new CommonCode();
        //    DataSet ds = cc.ExecuteDataset(Sql);
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        lblName.Text = Convert.ToString(dr["Name"]);
        //        //string name1 = lblName.Text;
        //        txtRelation.Text = Convert.ToString(dr["Relation"]);
        //        string GroupId = Convert.ToString(dr["GroupId"]);
        //        for (int i = 0; i < chkGroup.Items.Count - 1; i++)
        //        {
        //            if (GroupId == Convert.ToString(chkGroup.Items[i].Value.ToString()))
        //            {
        //                chkGroup.Items[i].Selected = true;
        //            }
        //        }
        //    }

        //    mdlEditGroup.Show();
        //}

    }
    protected void btnUpdateContact_Click(object sender, EventArgs e)
    {
       //Update the Group
        //s = urUserRegBLLObj.frnrelUserId;
        string Id = tmp.Value;
        urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
        urUserRegBLLObj.frnrelFriendId =Convert.ToString(Id);
        
        urUserRegBLLObj.FrnrelPrefix = Convert.ToString(ddlprefix.SelectedItem.Text);
        if (ddlprefix.SelectedItem.Text == null)
        {
            urUserRegBLLObj.FrnrelPrefix = "Dear";
        }
        urUserRegBLLObj.Frnrelinfix = Convert.ToString(ddlinfix.SelectedItem.Text);
        if (ddlinfix.SelectedItem.Text == null)
        {
            urUserRegBLLObj.Frnrelinfix = infix[0];
        }
        urUserRegBLLObj.Frnrelpostfix = Convert.ToString(ddlpostfix.SelectedItem.Text);
        if (ddlpostfix.SelectedItem.Text == null)
        {
            urUserRegBLLObj.Frnrelpostfix = " ";
        }

        try
        {
            status = urUserRegBLLObj.BLLPrefixUpdate(urUserRegBLLObj);
            if (status == 0)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
        string Sql = "Delete from friendGroupRelation where RelId=" + Id + "  ";
        Sql = Sql + " Update FriendRelationMaster set Relation='" + txtRelation.Text.ToString() + "' " +
            " where FriRelId="+Id+" ";
        //sql1=Sql+"update "
        for (int i = 0; i < chkGroup.Items.Count - 1; i++)
        {
            if (chkGroup.Items[i].Selected==true)
            {
               Sql=Sql +" Insert into FriendGroupRelation (RelId, GroupId) Values "+
                   " ("+Id+","+chkGroup.Items[i].Value.ToString()+" ) ";
            }
        }
        CommonCode cc=new CommonCode();
        int tmp1 = cc.ExecuteNonQuery(Sql);
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();

        urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
        string query = "select * from FriendRelationMaster where UserId='"+urUserRegBLLObj.frnrelUserId.ToString()+"'";
        DataSet ds = cc.ExecuteDataset(query);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
           string userid = Convert.ToString(dr["UserId"]);
           string frienduserid = Convert.ToString(dr["FriendId"]);

        }
        

    }

    protected void gvRemoveFriend_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
    }


    protected void gvRemoveFriend_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }


    public void LoadFriendGroup()
    {

        //chkGroup 
        DataTable dtFriendGroup = fgBLLobj.BLLShowAllFriendGroup();

       
           string  Sql = " Select GroupName from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            string Data = Convert.ToString(cc.ExecuteScalar(Sql));

            string[] tmp = Data.Split(',');
            int i = 0;
            foreach (DataRow dr in dtFriendGroup.Rows)
            {
                string tmpName = Convert.ToString(dr["friendGroupName"]);
                string tmpData = "";
                try
                {
                    tmpData = tmp[i].ToString();
                }
                catch
                { }

                if (tmpData != "")
                {
                    dr["friendGroupName"] = tmpData;
                }

                i++;
            }

        chkGroup.DataSource = dtFriendGroup;
        chkGroup.DataValueField = "friendGroupId";
        chkGroup.DataTextField = "friendGroupName";
        chkGroup.DataBind();
    }


    protected void gvRemoveFriend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvRemoveFriend.EditIndex = -1;
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();
    }

   
    protected void gvRemoveFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRemoveFriend.PageIndex = e.NewPageIndex;
        DataTable dtFriendRel = (DataTable)ViewState["RemoveFriend"];
        gvRemoveFriend.DataSource = dtFriendRel;
        gvRemoveFriend.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //gvSearchFriend.Visible = true;
        //gvRemoveFriend.Visible = false;
        //urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        //urUserRegBLLObj.usrFirstName = TextfirstN.Text.ToString();
        //urUserRegBLLObj.usrLastName = TextlastN.Text.ToString();
        //DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowByName(urUserRegBLLObj);
        //gvSearchFriend.DataSource = dtFriendRelList;
        //gvSearchFriend.DataBind();
    }
   
    //protected void gvSearchFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gvSearchFriend.PageIndex = e.NewPageIndex;
    //    DataTable dtFriendRel = (DataTable)ViewState["RemoveFriend"];
    //    gvSearchFriend.DataSource = dtFriendRel;
    //    gvSearchFriend.DataBind();
    //}
    //protected void gvSearchFriend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvSearchFriend.EditIndex = -1;
    //    urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
    //    DataTable dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);
    //    gvSearchFriend.DataSource = dtFriendRelList;
    //    gvSearchFriend.DataBind();
    //}
    protected void gvSearchFriend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    string grpId;
    string grpName;
    protected void btnSearchRel_Click(object sender, EventArgs e)
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        urUserRegBLLObj.usrFirstName = Convert.ToString(txtFName .Text );
        urUserRegBLLObj.usrLastName = Convert.ToString(txtLName .Text );
        urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNo .Text );
        DataTable dtFriendRelList = urUserRegBLLObj.DalFienSearchFriend(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();
        ViewState["RemoveFriend"] = dtFriendRelList;
    }
    protected void btnDefineGroup_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "",GroupId="",GroupName="";
            foreach (GridViewRow gr in gvGroup.Rows)
            {
                try
                {
                    //lblGroupId
                    Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");
                    GroupId = GroupId + "," + lbl.Text.ToString();
                    TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
                    GroupName =GroupName +","+ txt.Text.ToString();
                }
                catch (Exception ex)
                { }
                
            }
            Sql="Update UserMaster set GroupId='"+GroupId.Substring(1)+"',GroupName='"+GroupName.Substring(1)+"' "+
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

    public void LoadGroupId()
    {
        //try
        //{
        //    string Sql = "Select friendGroupId as Id, friendGroupName as GroupName from friendGroupMaster ";
            
        //    DataSet ds = cc.ExecuteDataset(Sql);
        //    ds.Tables[0].Columns.Add("mem",typeof (string ));
        //    Sql = " Select GroupName from UserMaster where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
        //    string Data = Convert.ToString(cc.ExecuteScalar(Sql));

        //    string memCount = "select friendGroup,count(*) as counting from FriendRelationMaster where UserId='" + Convert.ToString(Session["User"]) + "' group by friendGroup";
        //    DataSet dsc = new DataSet();
        //    dsc = cc.ExecuteDataset(memCount);
        //    string[] tmp = Data.Split(',');
        //    int i = 0;
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        string tmpName = Convert.ToString(dr["GroupName"]);
        //        string tmpData = "";
        //        try
        //        {
        //            tmpData = tmp[i].ToString();
        //        }
        //        catch
        //        { }

        //        if (tmpData != "")
        //        {
        //            string cou = "0";
        //            foreach (DataRow drc in dsc.Tables[0].Rows)
        //            {
        //                if (Convert.ToString (drc["friendGroup"]) == (i+5).ToString ())
        //                {
        //                    cou = Convert.ToString(drc["counting"]);
        //                }
        //                else if (i.ToString() == "0")
        //                {
        //                    int ss = Convert.ToInt32(cou) + Convert.ToInt32((drc["counting"]));
        //                    cou = ss.ToString();
        //                }

        //                //else if (Convert.ToString(drc["friendGroup"]) == (i + 3).ToString())
        //                //{
        //                //    cou = Convert.ToString(drc["counting"]);
        //                //}
        //                dr["Name"] = tmpData;
        //                dr["mem"] = cou.ToString();
        //            }
        //            //dr["Name"] = tmpData;
        //            //dr["mem"] = cou.ToString();
        //            //dr["Name"] = tmpData;
        //        }

        //        i++;
        //    }

        //    gvGroup.DataSource = ds.Tables[0];
        //    gvGroup.DataBind();

        //    try
        //    {
        //        TextBox txt = (TextBox)gvGroup.Rows[0].Cells[1].FindControl("txtGroupName");
        //        txt.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    { }

        //}
        //catch (Exception ex)
        //{
        //    string msg = ex.Message;
        //}

        try
        {
            string Sql = "select FriendGroupMaster.friendGroupName as Name,FriendGroupMaster.friendGroupId as Id,count(FriendRelationMaster.friendGroup) as countsub from FriendGroupMaster " +
                         "    inner join FriendRelationMaster on FriendRelationMaster.friendGroup=FriendGroupMaster.friendGroupId" +

                         "     where FriendRelationMaster.UserId='" + Convert.ToString(Session["User"]) + "'" +
                          "   group by FriendGroupMaster.friendGroupName,FriendGroupMaster.friendGroupId";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(Sql);
            gvGroup.DataSource = ds.Tables[0];
            gvGroup.DataBind();
            totalcount();
        }
        catch (Exception ex)
        { 
        
        }
    }

    public void totalcount()
    {

        int total = 0, sub = 0;
        foreach (GridViewRow row in gvGroup.Rows)
        {
             Label lbl = (Label)row.FindControl("lblMemCount");
            if (lbl.Text != "")
            {
                total =total+Convert.ToInt32(lbl.Text);
                txttotal.Text = total.ToString();
            }
        }
        
    }
    
    
    }




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

public partial class MarketingAdmin_School : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();
    int status = 1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StuPanel.Visible = false;
            SchoolPanel.Visible = false;
            AddStudentPanel.Visible = false;
            Button4.Visible = false;
            sendSmsPanel.Visible = false;
            //lblEntRollNo.Visible = false;
            //lblCommonSms.Visible = false;
            //txtCommonSms.Visible = false;
            //txtPrAbSMS.Visible = false;
            fillSchool();
            //FillClassList();
            fillGvSchool();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        StuPanel.Visible = false;
        sendSmsPanel.Visible = false;
        SchoolPanel.Visible = true;
        AddStudentPanel.Visible = false;
        FillClassList();
        fillGvSchool();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        StuPanel.Visible = true;
        AddStudentPanel.Visible = false;
        SchoolPanel.Visible = false;
        Label10.Visible = false;
        Label12.Visible = false;
        Label13.Visible = false;
        Label14.Visible = false;
        lblTeacherName.Visible = false;
        ddlTecGroup.Visible = false;
        ddlClassList.Visible = false;
        ddlSchoolList.Visible = false;
        btnAddStudent.Visible = false;
        Button4.Visible = false;
        gvStudentList.Visible = false;
        //sendSmsPanel.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string cls = Convert.ToString(txtClassAdd.Text);
        if (cls.ToString() != "")
        {
            string sqlFind = "select ClassId from ClassMaster where ClassName='" + cls.ToString() + "'";
            string find = "";
            find = Convert.ToString(cc.ExecuteScalar(sqlFind));
            if (find.ToString() == "")
            {
                string addStr = "insert into ClassMaster (ClassName) values('" + cls.ToString() + "')";
                int jjj = cc.ExecuteNonQuery(addStr);
                if (jjj > 0)
                {
                    txtClassAdd.Text = "";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Class added.')", true);
                }
            }
            else
            {
                txtClassAdd.Text = "";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Class Already Added.')", true);
            }
        }
        else
        {
            txtClassAdd.Text = "";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter Class Name.')", true);
        }

        FillClassList();
        //CheckBox1.Checked = false;
        txtClassAdd.Text = "";

    }
    public void FillClassList()
    {
        string sqlClass = "select ClassId,ClassName from ClassMaster";
        DataSet ds = cc.ExecuteDataset(sqlClass );
        lstClass.DataSource = ds;
        lstClass.DataTextField = "ClassName";
        lstClass.DataValueField = "ClassId";
        lstClass.DataBind();

        //ddlClassList.DataSource = ds;
        //ddlClassList.DataTextField = "ClassName";
        //ddlClassList.DataValueField = "ClassId";
        //ddlClassList.DataBind();
        //ddlClassList.Items.Add("--Select--");
        //ddlClassList.SelectedIndex = ddlClassList.Items.Count - 1;
        //ddlClassList.Items[ddlClassList.Items.Count - 1].Value = "";



    }
    public void FillClassListStu(string sd)
    {
        string sqlClass = "select CM.ClassId,CM.ClassName from ClassMaster CM inner join SchoolClassRel SCR on CM.ClassId = SCR.ClassId INNER join SchoolMaster SM on SCR.SchoolId=SM.SchoolId     where SM.SchoolId="+Convert .ToInt32 ( sd);

        DataSet ds = cc.ExecuteDataset(sqlClass);
        //lstClass.DataSource = ds;
        //lstClass.DataTextField = "ClassName";
        //lstClass.DataValueField = "ClassId";
        //lstClass.DataBind();

        ddlClassList.DataSource = ds;
        ddlClassList.DataTextField = "ClassName";
        ddlClassList.DataValueField = "ClassId";
        ddlClassList.DataBind();
        ddlClassList.Items.Add("--Select--");
        ddlClassList.SelectedIndex = ddlClassList.Items.Count - 1;
        ddlClassList.Items[ddlClassList.Items.Count - 1].Value = "";



    }

    public void fillSchool()
    {
        string sqlFillSchool = "select SchoolId,SchoolName from schoolMaster";
        DataSet dss = new DataSet();
        dss = cc.ExecuteDataset(sqlFillSchool );
        ddlSchoolList.DataSource = dss;
        ddlSchoolList.DataTextField = "SchoolName";
        ddlSchoolList.DataValueField = "SchoolId";
        ddlSchoolList.DataBind();
        ddlSchoolList.Items.Add("--Select--");
        ddlSchoolList.SelectedIndex = ddlSchoolList.Items.Count - 1;
        ddlSchoolList.Items[ddlSchoolList.Items.Count - 1].Value = "";

    
    }
    //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    //{
        
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        if (txtSchoolName.Text != "")
        {
            if (txtSchoolAdd.Text != "")
            {
                if (txtContPerson.Text != "")
                {
                    if (txtConNumber.Text != "")
                    {
                       
                            int schoolId = schoolAdd();
                            int clsid=0;
                            string sqlAddClass = "";
                            foreach (ListItem item in lstClass.Items)
                            {
                                if (item.Selected == true)
                                {
                                    clsid = Convert.ToInt32(item.Value);
                                    sqlAddClass = "insert into SchoolClassRel(SchoolId,ClassId) values(" + schoolId + "," + clsid + ")";
                                    int k = cc.ExecuteNonQuery(sqlAddClass);
                                }
                            }
                            Response.Write("<SCRIPT> alert('School Added.') </SCRIPT>");
                       
                    }
                    else
                    {
                        Response.Write("<SCRIPT> alert('Please fill contact number.') </SCRIPT>");
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please fill contact number.')", true);
                    }
                }
                else
                {
                    Response.Write("<SCRIPT> alert('Please fill contact person.') </SCRIPT>");
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please fill contact person.')", true);
                }
            }
            else
            {
                Response.Write("<SCRIPT> alert('Please fill School/College address.') </SCRIPT>");
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please fill School/College address.')", true);
            }
        }
        else
        {
            Response.Write("<SCRIPT> alert('Please fill School/College Name.') </SCRIPT>");
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please fill School/College Name.')", true);
        }
        fillGvSchool();
    }
    public int schoolAdd()
    {
        int sid = 0;
        string sqlAddSchool = "insert into SchoolMaster(SchoolName,SchoolAdd,ContactPerson,ContactNo) values('"+txtSchoolName .Text +"','"+txtSchoolAdd .Text +"','"+txtContPerson.Text  +"','"+txtConNumber.Text  +"')";
        sid = cc.ExecuteNonQuery(sqlAddSchool );
        string finfId = "select SchoolId from SchoolMaster where SchoolName='" + txtSchoolName.Text + "' AND SchoolAdd='" + txtSchoolAdd.Text + "' AND ContactPerson='" + txtContPerson.Text + "' AND ContactNo='" + txtConNumber.Text + "'";
        sid = Convert.ToInt32(cc.ExecuteScalar(finfId));
        return sid;
    }
    public void fillGvSchool()
    {
        string sqlGvfill = "select SchoolName,SchoolAdd,ContactPerson,ContactNo from SchoolMaster";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlGvfill );



        //DataTable tb = new DataTable();
        //tb = ds.Tables[0];
        //tb.Columns.Add("class", typeof(string));
        //foreach (DataRow dr in tb.Rows )
        //{
        //    tb.Rows.Add(dr , "abcd");
        //}


        gvSchoolClasses.DataSource = ds;
        gvSchoolClasses.DataBind();
    }
    protected void btnTecMoNoSearch_Click(object sender, EventArgs e)
    {
        string tecMoNo = Convert.ToString(txtTecMoNo.Text);
        ViewState["TeacherMoNo"] = tecMoNo;
        string sqlQ = "select usrFirstName+' '+usrLastName as name,GroupId,GroupName from userMaster where usrMobileNo='"+tecMoNo .ToString ()+"'";
        string tnm = "", tgrid = "", tgrnm = "";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlQ );
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            tnm = Convert.ToString(dr["name"]);
            tgrid = Convert.ToString(dr["GroupId"]);
            tgrnm = Convert.ToString(dr["GroupName"]);
        }
        DataTable dt = new DataTable();
        dt.Columns.Add("GrId",typeof (string ));
        dt.Columns.Add("GrName", typeof(string));
        string[] GroupId = tgrid.Split(',');
        string[] GroupNames = tgrnm.Split(',');
        for (int i = 0; i < 30; i++)
        {
            string ss =GroupNames [i ].ToString ();
            dt.Rows.Add(i ,ss );
        }

        ViewState["TeacherGroup"] = dt;
        ddlTecGroup.DataSource = dt;
        ddlTecGroup.DataTextField = "GrName";
        ddlTecGroup.DataValueField = "GrId";
        ddlTecGroup.DataBind();
        ddlTecGroup.Items.Add("--Select--");
        ddlTecGroup.SelectedIndex = ddlTecGroup.Items.Count - 1;
        ddlTecGroup.Items[ddlTecGroup.Items.Count - 1].Value = "";

        Label10.Visible = true;
        Label12.Visible = true;
        Label13.Visible = true;
        Label14.Visible = true;
        lblTeacherName.Visible = true;
        lblTeacherName.Text = tnm.ToString();
        ddlTecGroup.Visible = true;
        ddlClassList.Visible = true;
        ddlSchoolList.Visible = true;
        btnAddStudent.Visible = true;
        Button4.Visible = true;

    }
    protected void ddlSchoolList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string jk = ddlSchoolList.SelectedIndex.ToString();
        string jk = Convert.ToString(ddlSchoolList.SelectedValue);

        FillClassListStu(jk);
    }
    protected void ddlClassList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sid = Convert.ToString(ddlSchoolList.SelectedValue);
        string cid = Convert.ToString(ddlClassList.SelectedValue);
        string sqlFI ="declare @rno nvarchar(100) ";
               sqlFI+=" declare @cls nvarchar(200)";
               sqlFI+=" declare @school nvarchar(200)";
               sqlFI += " set @cls='" + cid .ToString ()+ "'";
               sqlFI += " set @school='" + sid .ToString ()+ "'";

               sqlFI += " select f.usrUserId,CONVERT (int,f.usrFIrollNo1) as rno,f.usrFIname1 as fn,f.usrFIgender1 as g,u.usrFirstName as mn,u.usrLastName as ln,u.usrMobileNo as mno";
               sqlFI += " from tblFamilyInfoMaster f inner join userMaster u on f.usrUserId=u.usrUserId where f.usrFIclass1=@cls AND f.usrFIschool1=@school order by  rno";

               sqlFI += " select f.usrUserId,CONVERT (int,f.usrFIrollNo2) as rno,f.usrFIname2 as fn,f.usrFIgender2 as g,u.usrFirstName as mn,u.usrLastName as ln,u.usrMobileNo as mno";
               sqlFI += " from tblFamilyInfoMaster f inner join userMaster u on f.usrUserId=u.usrUserId where f.usrFIclass2=@cls AND f.usrFIschool2=@school order by  rno";

               sqlFI += " select f.usrUserId,CONVERT (int,f.usrFIrollNo3) as rno,f.usrFIname3 as fn,f.usrFIgender3 as g,u.usrFirstName as mn,u.usrLastName as ln,u.usrMobileNo as mno";
               sqlFI += " from tblFamilyInfoMaster f inner join userMaster u on f.usrUserId=u.usrUserId where f.usrFIclass3=@cls AND f.usrFIschool3=@school order by  rno";

        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlFI );
        int c1 = 0, c2 = 0, c3 = 0;
        //try
        //{
            DataTable dt = new DataTable();
            dt.Columns.Add("rno", typeof(string));
            dt.Columns.Add("fn", typeof(string));
            dt.Columns.Add("mn", typeof(string));
            dt.Columns.Add("ln", typeof(string));
            dt.Columns.Add("g", typeof(string));
            dt.Columns.Add("mno", typeof(string));

            try
            {
                c1 = ds.Tables[0].Rows.Count;
                if (c1 >= 1)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (Convert.ToString(dr["g"]) == "1")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Male"), Convert.ToString(dr["mno"]));
                        }
                        else if (Convert.ToString(dr["g"]) == "2")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Female"), Convert.ToString(dr["mno"]));
                        }

                    }
                }
            }catch (Exception rer)
            {
              
            }

            try
            {
                c2 = ds.Tables[1].Rows.Count;
                if (c2 >= 1)
                {

                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        if (Convert.ToString(dr["g"]) == "1")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Male"), Convert.ToString(dr["mno"]));
                        }
                        else if (Convert.ToString(dr["g"]) == "2")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Female"), Convert.ToString(dr["mno"]));
                        }

                    }
                }
            }
            catch (Exception rer)
            {

            }

            try
            {
                c3 = ds.Tables[2].Rows.Count;
                if (c3 >= 1)
                {

                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        if (Convert.ToString(dr["g"]) == "1")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Male"), Convert.ToString(dr["mno"]));
                        }
                        else if (Convert.ToString(dr["g"]) == "2")
                        {
                            dt.Rows.Add(Convert.ToString(dr["rno"]), Convert.ToString(dr["fn"]), Convert.ToString(dr["mn"]), Convert.ToString(dr["ln"]), Convert.ToString("Female"), Convert.ToString(dr["mno"]));
                        }

                    }
                }
            }
            catch (Exception rer)
            {

            }
                
            

            

                

                 if (c1 >= 1 || c2 >= 1 || c3 >= 1)
                 {
                     gvStudentList.Visible = true;
                     gvStudentList.DataSource = dt;
                     gvStudentList.DataBind();
                 }
                 else
                 {
                     gvStudentList.Visible = false;
                 }
           

           
        //}
        //catch (Exception rr)
        //{
        //    //throw rr;
        //    gvStudentList.Visible = false;
        //}
        
               
        
    }
    protected void btnAddStudent_Click(object sender, EventArgs e)
    {
        AddStudentPanel.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string mobile = Convert.ToString(txtTecMoNo.Text);
        int grId = Convert.ToInt32(ddlTecGroup.SelectedValue);
        urRegistBll.usrMobileNo = Convert.ToString(txtTecMoNo .Text );
        urRegistBll.usrAltMobileNo = Convert.ToString(txtSFmono.Text);
        urRegistBll.frnrelFrnRelName = Convert.ToString(txtSFfname.Text);
        urRegistBll.usrLastName = Convert.ToString(txtSFlname.Text);
        AddFriendByLongCodeF(urRegistBll, mobile, grId);
        string fmno = "", snm = "", sgender = "", sno = "", rollno = "",cno="",slno="";
        fmno = Convert.ToString(txtSFmono.Text);
        snm = Convert.ToString(txtSFfsonName.Text);
        sgender = Convert.ToString(ddlSFgenger.SelectedValue);
        sno = Convert.ToString(ddlSFsonNo.SelectedValue);
        cno = Convert.ToString(ddlClassList .SelectedValue );
        slno = Convert.ToString(ddlSchoolList.SelectedValue);
        rollno = Convert.ToString(txtSFrollNo.Text);
        AddStudent(fmno, snm, sgender, sno, rollno, cno, slno);

    }

    public void AddStudent(string fmno,string snm,string sgender,string sno,string rollno,string cno,string  slno)
    {
        string sql="";
        string usrSql = "select usrUserId from userMaster where usrMobileNo='"+fmno .ToString ()+"'";
        string usrId = Convert.ToString(cc .ExecuteScalar (usrSql ));
        string alreadySql = "select usrUserId from tblFamilyInfoMaster where usrUserId='"+usrId .ToString ()+"'";
        string newUserId = Convert.ToString(cc .ExecuteScalar (alreadySql ));
        if (newUserId.ToString() == usrId.ToString())
        {
            if (sno == "1")
            {
                sql = "update tblFamilyInfoMaster set usrFIname1='" + snm.ToString() + "',usrFIgender1='" + sgender.ToString() + "',usrFIschool1='" + slno.ToString() + "',usrFIclass1='" + cno.ToString() + "',usrFIrollNo1='" + rollno.ToString() + "' where usrUserId='"+newUserId .ToString ()+"'";
               
            }
            else if (sno == "2")
            {
                sql = "update tblFamilyInfoMaster set usrFIname2='" + snm.ToString() + "',usrFIgender2='" + sgender.ToString() + "',usrFIschool2='" + slno.ToString() + "',usrFIclass2='" + cno.ToString() + "',usrFIrollNo2='" + rollno.ToString() + "' where usrUserId='" + newUserId.ToString() + "'";
            }
            else if (sno == "3")
            {
                sql = "update tblFamilyInfoMaster set usrFIname3='" + snm.ToString() + "',usrFIgender3='" + sgender.ToString() + "',usrFIschool3='" + slno.ToString() + "',usrFIclass3='" + cno.ToString() + "',usrFIrollNo3='" + rollno.ToString() + "' where usrUserId='" + newUserId.ToString() + "'";
            }
            int insert = 0;
            insert = cc.ExecuteNonQuery(sql);
            if (insert > 0)
            {
                Response.Write("<SCRIPT> alert('Student Inserted.')</SCRIPT>");
                clearStu();
            }
        }
        else
        {
            if (sno == "1")
            {
                sql = "insert into tblFamilyInfoMaster(usrUserId,usrFIname1,usrFIgender1,usrFIschool1,usrFIclass1,usrFIrollNo1)";
                sql += " values ('" + usrId.ToString() + "','" + snm.ToString() + "','" + sgender.ToString() + "','" + slno.ToString() + "','" + cno.ToString() + "','" + rollno.ToString() + "')";
            }
            else if (sno == "2")
            {
                sql = "insert into tblFamilyInfoMaster(usrUserId,usrFIname2,usrFIgender2,usrFIschool2,usrFIclass2,usrFIrollNo2)";
                sql += " values ('" + usrId.ToString() + "','" + snm.ToString() + "','" + sgender.ToString() + "','" + slno.ToString() + "','" + cno.ToString() + "','" + rollno.ToString() + "')";
            }
            else if (sno == "3")
            {
                sql = "insert into tblFamilyInfoMaster(usrUserId,usrFIname3,usrFIgender3,usrFIschool3,usrFIclass3,usrFIrollNo3)";
                sql += " values ('" + usrId.ToString() + "','" + snm.ToString() + "','" + sgender.ToString() + "','" + slno.ToString() + "','" + cno.ToString() + "','" + rollno.ToString() + "')";
            }
            int insert = 0;
            insert = cc.ExecuteNonQuery(sql);
            if (insert > 0)
            {
                Response.Write("<SCRIPT> alert('Student Inserted.')</SCRIPT>");
                clearStu();
            }
        }


    
    }
    public void clearStu()
    {
        txtSFfname.Text = "";
        txtSFlname.Text = "";
        txtSFmono.Text = "";
        txtSFpin.Text = "";
        txtSFfsonName.Text = "";
        ddlSFgenger.SelectedValue = "1";
        ddlSFsonNo.SelectedValue = "1";
        txtSFrollNo.Text = "";
    }
    public void AddFriendByLongCodeF(UserRegistrationBLL ur, string userMobileWhoSendFriendReq, int grid)
    {//Mahesh: Use second parameter mobile for only send sms only, because at run time mobile number of sender change.
        try
        {
            string sender = "";
            string joiner = "";
            bool JoinAll = false;
            string flagMob = ur.usrAltMobileNo;
            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(ur);
                if (status == 0)
                {
                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    int jof = Convert.ToInt32(cc.ExecuteScalar(sqlFlagStr));
                    if (jof > 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = Convert.ToString(jof);
                    }
                    //DataTable dt1 = new DataTable();
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    //dt1 = ds.Tables[0];
                    string userId;
                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelFriendId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = cc.ExecuteDataset(sql1);
                    //dt1 = ds.Tables[0];
                    string FriId;
                    string FriName;
                    foreach (DataRow dr2 in ds1.Tables[0].Rows)
                    {
                        FriId = Convert.ToString(dr2["usrUserId"]);
                        FriName = Convert.ToString(dr2["usrFirstName"]);
                        ur.frnrelUserId = FriId;
                        ur.frnrelFrnRelName = FriName;
                        ur.frnrelRelation = "friend";
                        sender = Convert.ToString(FriName);
                        //ur.frnrelGroup = "1";
                        //status = ur.BLLInsertUserFriendRelative(ur);
                        ur.frnrelGroup = Convert.ToString(grid);

                    }

                    status = ur.BLLInsertUserFriendRelative(ur);
                    if (status > 0)
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "I " + usrName + "(" + sendFrom.ToString() + ") added u in www.myct.in to send SMS." + cc.AddSMS(SendTo);

                        cc.SendMessage1(sendFrom, SendTo, message);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + SendTo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                        }
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }
                    }
                    else
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "Dear " + joiner.ToString() + " u already added " + sender.ToString() + " in www.myct.in to send SMS." + cc.AddSMS(sendFrom);

                        cc.SendMessage1(SendTo, sendFrom, message);

                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }

                    }
                }
                else
                {
                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql3);
                    //dt1 = ds.Tables[0];
                    string userId;
                    flagMob = ur.usrAltMobileNo;
                    string usrName = "";
                    int cityId = 0;
                    string cityName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        ur.frnrelUserId = userId;
                        ur.usrCityId = cityId;
                        joiner = Convert.ToString(usrName);
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sqlFlagStr = "select JoinFlag from userMaster where usrMobileNo='" + flagMob.ToString() + "'";
                    int jof = Convert.ToInt32(cc.ExecuteScalar(sqlFlagStr));
                    if (jof >= 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = Convert.ToString(jof);
                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = cc.ExecuteScalar(sqlquery);

                    urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

                    ur.usrMobileNo = ur.usrAltMobileNo;

                    ur.usrFirstName = ur.frnrelFrnRelName;

                    Random rnd = new Random();
                    urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);
                    if (status > 0)
                    {

                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + ur.usrAltMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = cc.ExecuteDataset(sql1);
                        //dt1 = ds.Tables[0];
                        string FriId;
                        string FriName;
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            ur.frnrelFriendId = FriId;
                            ur.frnrelFrnRelName = FriName;
                            ur.frnrelRelation = "friend";
                            ur.frnrelGroup = Convert.ToString(grid);
                            sender = Convert.ToString(FriName);
                        }

                        status = ur.BLLInsertUserFriendRelative(ur);
                        if (status > 0)
                        {

                        }
                        string senderId = userMobileWhoSendFriendReq.ToString();
                        string myMobileNo = urRegistBll.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                        string myName = ur.frnrelFrnRelName;
                        string thisDir = Server.MapPath("~");

                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in come2mycity.com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for come2myCity.com";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                        }
                        string changeFlagSql = "update come2mycity.test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                        int pkchange = 0;
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        if (pkchange == 0)
                        {
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                        }


                    }

                }
            }
            else
            {
                //NotRegisterMessageForLongCode(urRegistBll);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        sendSmsPanel.Visible = true;
        
        
    }
    //protected void ddlSMStype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string smsType = Convert.ToString(ddlSMStype.SelectedValue);
    //    if (smsType.ToString() == "pr" || smsType.ToString() == "ab")
    //    {
    //        lblEntRollNo.Visible = true;
    //        lblCommonSms.Visible = false;
    //        txtCommonSms.Visible = false;
    //        txtPrAbSMS.Visible = true;
    //        sendSmsPanel.Visible = true;
            
    //    }
    //    else
    //    {
    //        lblEntRollNo.Visible = false;
    //        lblCommonSms.Visible = true;
    //        txtCommonSms.Visible = true;
    //        txtPrAbSMS.Visible = false;
    //        sendSmsPanel.Visible = true;
    //    }
    //}
    protected void btnSendSms_Click(object sender, EventArgs e)
    {
        int smsCount = 0;
        string schoolId = "", ClassId = "", teachNo = "", TecGrNo = "", txtSmsString = "";
        string smsType = Convert.ToString(ddlSMStype.SelectedValue);
        schoolId = Convert.ToString(ddlSchoolList.SelectedValue);
        ClassId = Convert.ToString(ddlClassList.SelectedValue);
        teachNo = txtTecMoNo.Text.ToString();
        TecGrNo = Convert.ToString(ddlTecGroup.SelectedValue);
        txtSmsString = txtPrAbSMS.Text.ToString();
        if (smsType.ToString() == "pr")
        {
            smsCount= sendPresentSms(txtSmsString, ClassId, schoolId, teachNo, TecGrNo, "Present");
        }
        else if (smsType.ToString() == "ab")
        {
           smsCount = sendPresentSms(txtSmsString, ClassId, schoolId, teachNo, TecGrNo, "Absent");
        
        }
        else if (smsType.ToString() == "tsms")
        {
            smsCount = sendPresentTextSms(txtSmsString, ClassId, schoolId, teachNo, TecGrNo, "Absent");
        }
        else
        {
            Response.Write("<SCRIPT> alert('SMS not send.')</SCRIPT>");
        }
        if (smsCount > 0)
        {
            Response.Write("<SCRIPT> alert('SMS Send.')</SCRIPT>");
        }

    }
    public int sendPresentSms(string sms,string cls,string school,string tecMono,string tecGr,string status)
    {
        int count = 0;
        string[] stuRollNo = sms.Split(',');
        string rollNumber = "";
        string techerUserIdSql = "", techerUserId = "";
        techerUserIdSql = "select usrUserId from userMaster where usrMobileno='"+tecMono .ToString ()+"'";
        techerUserId = Convert.ToString(cc.ExecuteScalar(techerUserIdSql));
        string sqlFindFather = "select FIM.usrFIname1,FIM.usrFIname2,FIM.usrFIname3,FIM.usrFIschool1,FIM.usrFIschool2,FIM.usrFIschool3,";
               sqlFindFather+=" FIM.usrFIclass1,FIM.usrFIclass2,FIM.usrFIclass3,FIM.usrFIrollNo1,FIM.usrFIrollNo2,FIM.usrFIrollNo3,UM.usrFirstName,UM.usrMobileNo";
               sqlFindFather+=" from FriendRelationMaster FRM Inner join userMaster UM";
               sqlFindFather+=" on FRM.FriendId=UM.usrUserId";
               sqlFindFather+=" Inner join tblFamilyInfoMaster FIM";
               sqlFindFather+=" on UM.usrUserId = FIM.usrUserId";
               sqlFindFather+=" where FRM.UserId='"+techerUserId .ToString ()+"' AND FRM.friendGroup='"+tecGr .ToString ()+"'";
        DataSet ds = new DataSet ();
        ds = cc.ExecuteDataset (sqlFindFather);
        for (int i = 0; i < stuRollNo.Length; i++)
        {
            string FatherName = "", SonName = "", FatherMobileNo = "";
            rollNumber = stuRollNo[i].ToString();
            foreach (DataRow dr in ds .Tables [0].Rows )
            {
              if (rollNumber.ToString() == dr["usrFIrollNo1"].ToString() && school.ToString() == dr["usrFIschool1"].ToString() && cls.ToString() == dr["usrFIclass1"].ToString())
              {
              FatherName = dr ["usrFirstName"].ToString ();
              FatherMobileNo = dr["usrMobileNo"].ToString();
              SonName = dr["usrFIname1"].ToString();
              }
                else if (rollNumber.ToString() == dr["usrFIrollNo2"].ToString() && school.ToString() == dr["usrFIschool2"].ToString() && cls.ToString() == dr["usrFIclass2"].ToString())
              {
              FatherName = dr ["usrFirstName"].ToString ();
              FatherMobileNo = dr["usrMobileNo"].ToString();
              SonName = dr["usrFIname2"].ToString();
              }
                else if (rollNumber.ToString() == dr["usrFIrollNo3"].ToString() && school.ToString() == dr["usrFIschool3"].ToString() && cls.ToString() == dr["usrFIclass3"].ToString())
              {
              FatherName = dr ["usrFirstName"].ToString ();
              FatherMobileNo = dr["usrMobileNo"].ToString();
              SonName = dr["usrFIname3"].ToString();
              }
              if (FatherMobileNo != "" && FatherName != "" && SonName != "")
              {
                  string sendSMSfromTecher = "Dear " + FatherName.ToString() + ", Your " + SonName.ToString() + " is " + status .ToString ()+ " today in class.From: " + Convert.ToString(cc.ExecuteScalar("select SchoolName from SchoolMaster where SchoolId=" + school.ToString() + "")) + " " + cc.AddSMS(FatherMobileNo);
                  count++;
                  cc.SendMessage1(FatherMobileNo ,FatherMobileNo ,sendSMSfromTecher );
                  break;
              }
            
            }

        }
        return count;
    }
    public int sendPresentTextSms(string sms, string cls, string school, string tecMono, string tecGr, string status)
    {
        int count = 0;
        //string[] stuRollNo = sms.Split(',');
        //string rollNumber = "";
        string techerUserIdSql = "", techerUserId = "";
        techerUserIdSql = "select usrUserId from userMaster where usrMobileno='" + tecMono.ToString() + "'";
        techerUserId = Convert.ToString(cc.ExecuteScalar(techerUserIdSql));
        string sqlFindFather = "select FIM.usrFIname1,FIM.usrFIname2,FIM.usrFIname3,FIM.usrFIschool1,FIM.usrFIschool2,FIM.usrFIschool3,";
        sqlFindFather += " FIM.usrFIclass1,FIM.usrFIclass2,FIM.usrFIclass3,FIM.usrFIrollNo1,FIM.usrFIrollNo2,FIM.usrFIrollNo3,UM.usrFirstName,UM.usrMobileNo";
        sqlFindFather += " from FriendRelationMaster FRM Inner join userMaster UM";
        sqlFindFather += " on FRM.FriendId=UM.usrUserId";
        sqlFindFather += " Inner join tblFamilyInfoMaster FIM";
        sqlFindFather += " on UM.usrUserId = FIM.usrUserId";
        sqlFindFather += " where FRM.UserId='" + techerUserId.ToString() + "' AND FRM.friendGroup='" + tecGr.ToString() + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlFindFather);
        //for (int i = 0; i < stuRollNo.Length; i++)
        //{
            string FatherName = "", SonName = "", FatherMobileNo = "";
            //rollNumber = stuRollNo[i].ToString();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ( school.ToString() == dr["usrFIschool1"].ToString() && cls.ToString() == dr["usrFIclass1"].ToString())
                {
                    FatherName = dr["usrFirstName"].ToString();
                    FatherMobileNo = dr["usrMobileNo"].ToString();
                    SonName = dr["usrFIname1"].ToString();
                }
                else if (school.ToString() == dr["usrFIschool2"].ToString() && cls.ToString() == dr["usrFIclass2"].ToString())
                {
                    FatherName = dr["usrFirstName"].ToString();
                    FatherMobileNo = dr["usrMobileNo"].ToString();
                    SonName = dr["usrFIname2"].ToString();
                }
                else if (school.ToString() == dr["usrFIschool3"].ToString() && cls.ToString() == dr["usrFIclass3"].ToString())
                {
                    FatherName = dr["usrFirstName"].ToString();
                    FatherMobileNo = dr["usrMobileNo"].ToString();
                    SonName = dr["usrFIname3"].ToString();
                }
                if (FatherMobileNo != "" && FatherName != "" && SonName != "")
                {
                    string sendSMSfromTecher = "Dear " + FatherName.ToString() + ", Your " + SonName.ToString() + " have Message: " + sms.ToString() + " From: " + Convert.ToString(cc.ExecuteScalar("select SchoolName from SchoolMaster where SchoolId=" + school.ToString() + "")) + " " + cc.AddSMS(FatherMobileNo);
                    count++;
                    cc.SendMessage1(FatherMobileNo, FatherMobileNo, sendSMSfromTecher);
                    //break;
                }

            }

        //}
        return count;
    }
}

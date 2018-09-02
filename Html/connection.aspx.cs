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

public partial class connection : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    string id = "";
    string mono = "", mime = "", p1 = "", p2 = "", p3 = "", p4 = "", p5 = "";
    string message_id = "";
    int smslength;
    string todaysDate = "";
    int sendercode = 5;
    string Testting = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadData();
        }

    }
    //------------------------------------Message Sorting to miss Call Response-----------------------------------------

    #region SortingofMessage

    public void LoadData()
    {
        //DateTime date = DateTime.Now;
        //todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
        //todaysDate = cc.ChangeDt(todaysDate);
        todaysDate = DateTime.Now.ToString("yyyy-MM-dd");
        mono = Convert.ToString(Request.QueryString["mobilenumber"]);
        mime = Convert.ToString(Request.QueryString["mimenumber"]);
        p1 = Convert.ToString(Request.QueryString["p1"]);
        p2 = Convert.ToString(Request.QueryString["p2"]);
        p3 = Convert.ToString(Request.QueryString["p3"]);
        p4 = Convert.ToString(Request.QueryString["p4"]);
        p5 = Convert.ToString(Request.QueryString["p5"]);

        //mono = "917709213290";
        //mime = "354338051597603";
        //p1 = "20570372610210548012";
        //p2 = "IDEA";
        //p3 = "mmm";
        //p4 = "mmm";
        //p5 = "mmm";

        if (mono != "" && mono!=null)
        {
            try
            {
                mono = mono.Substring(0, 3);
                if (mono.Contains("911"))
                {

                }
                else
                {
                    mono = Convert.ToString(Request.QueryString["mobilenumber"]);
                    //mono = "917620179104";
                    string sql = "insert into connection1(mobileNumber,MIMENumber,p1,p2,p3,p4,p5,recordDate) values('" + mono + "','" + mime + "','" + p1 + "','" + p2 + "','" + p3 + "','" + p4 + "','" + p5 + "','" + todaysDate + "')";
                    int i = cc.ExecuteNonQuery(sql);
                    //////////////////changes done//////////////////////////
                    sql = "select reg_id from LongCodeRegistration where Sim_no='" + p1 + "' and IMEINO='" + mime + "'";
                    string regid = cc.ExecuteScalar(sql);
                    if (regid == "" || regid == null)
                    {
                        sql = "select id from Non_LongCodeRegister where IMEINO='" + mime + "' and SIMNO='" + p1 + "'";
                        string id1 = cc.ExecuteScalar(sql);
                        if (id1 == "" || id1 == null)
                        {
                            string status = "Deactive";
                            sql = "insert into Non_LongCodeRegister(IMEINO,SIMNO,Miscal_Date,Status,misscallcounter)values('" + mime + "','" + p1 + "','" + todaysDate + "','" + status + "',0)";
                            int a = cc.ExecuteNonQuery(sql);

                        }
                        string Sqlk = "Select id , misscallcounter from Non_LongCodeRegister where SIMNO='" + p1 + "' and IMEINO='" + mime + "'";
                        DataSet dds = cc.ExecuteDataset(Sqlk);
                        if (dds.Tables[0].Rows.Count > 0)
                        {
                            int id12 = Convert.ToInt16(dds.Tables[0].Rows[0]["id"]);
                            int Miscalltype = Convert.ToInt16(dds.Tables[0].Rows[0]["misscallcounter"]);
                            if (Miscalltype == 3)
                            { }
                            else
                            {
                                Miscalltype = Miscalltype + 1;
                                string Sqlup = "update Non_LongCodeRegister set misscallcounter=" + Miscalltype + " where SIMNO='" + p1 + "' and IMEINO='" + mime + "' and id =" + id12 + "";
                                int jk = cc.ExecuteNonQuery(Sqlup);
                                if (jk == 1)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    if (mime.ToString() == "354338051597603")
                                    {
                                    cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                                    }
                                    else
                                    {
                                    cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                    }
                                }
                            }
                        }
                    }
                    ///////////////////////////////////////////////////////////////////////////////
                    else
                    {
                        sql = "select send_data, reg_id,UsrUserid,MissCallType,customer_contact1,customer_contact2,customer_contact3,customer_contact4 from LongCodeRegistration where Sim_no='" + p1 + "' and IMEINO='" + mime + "'";
                        DataSet dset = cc.ExecuteDataset(sql);
                        regid = Convert.ToString(dset.Tables[0].Rows[0]["reg_id"]);
                        string userid12 = Convert.ToString(dset.Tables[0].Rows[0]["UsrUserid"]);
                        string Miscalltype = Convert.ToString(dset.Tables[0].Rows[0]["MissCallType"]);
                        string send_data = Convert.ToString(dset.Tables[0].Rows[0]["send_data"]);
                        string Contact1 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact1"]);
                        string Contact2 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact2"]);
                        string Contact3 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact3"]);
                        string Contact4 = Convert.ToString(dset.Tables[0].Rows[0]["customer_contact4"]);

                        if (Miscalltype == "Multiple")
                        {
                            MultipleMissCall(userid12);
                        }
                        else if (Miscalltype == "Single")
                        {
                            SingleMissCall(userid12);
                        }
                        //-------------Emergency---------------------------
                        if (Testting == "AlreadySent")
                        { }
                        else
                        {
                            if (send_data == "3")
                            {
                                string AllContact = Contact1 + "," + Contact2 + "," + Contact3 + "," + Contact4;
                                string Sql = "Select id, EmergencyMgs from MiscalResponse  where  Msg_Status='Active' and mobileno='" + p1 + "' ";
                                DataSet ds = cc.ExecuteDataset(Sql);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    string id = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                                    string EmergencyMgs = Convert.ToString(ds.Tables[0].Rows[0]["EmergencyMgs"]);
                                    string SedMgs = mono + " " + EmergencyMgs;
                                    smslength = EmergencyMgs.Length;
                                    string[] sentmgs = AllContact.Split(',');

                                    if (EmergencyMgs == "" || EmergencyMgs == null)
                                    { }
                                    else
                                    {
                                        for (int p = 0; p < sentmgs.Length; p++)
                                        {
                                            string SentmgsEmg = sentmgs[p].ToString();
                                            if (SentmgsEmg == "" || SentmgsEmg == null)
                                            { }
                                            else
                                            {
                                                if (mime.ToString() == "354338051597603")
                                                {
                                                    bool chk = cc.TransactionalSMSCountryWari("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                                                }
                                                else
                                                {
                                                    bool chk = cc.TransactionalSMSCountry("Miscal", SentmgsEmg, SedMgs, smslength, sendercode);
                                                }
                                                

                                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + SentmgsEmg + "','" + todaysDate + "','" + EmergencyMgs + "'," + id + ")";
                                                string c = cc.ExecuteScalar(sqlinsert);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            
            }
        }
        else
        {
           
        }
    }

    #endregion SortingofMessage

    //------------------------------------Single miss call Funcation----------------------------------------------------

    #region SingleMissCallFuncation

    public void SingleMissCall(string userid12)
    {
        DateTime date = DateTime.Now;
        todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
        string mono1 = "";
        if (mono.Length > 10)
        {
            mono1 = mono.Substring(2);
        }
        else
        {
            mono1 = mono;
        }
        string query = "select usrUserid from usermaster where usrMobileNo='" + mono1 + "'";
        string userid1 = cc.ExecuteScalar(query);
        if (userid1 != "" || userid1 != null)
        {
            string query1 = "select groupno from MiscalFriends where friendid='" + userid1 + "' and userid='" + userid12 + "'";
            string groupno = cc.ExecuteScalar(query1);
            if (groupno == "")
            {
                groupno = "0";
                string sqlcheck = "select id from MiscalResponse where mobileno='" + p1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mime.ToString() == "354338051597603")
                    {
                        cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                    }
                    else
                    {
                        cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                    DataSet ds = cc.ExecuteDataset(sql1);
                    string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                    string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                    string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                    string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mono + "'";
                    string checkid = cc.ExecuteScalar(sql12);
                    if (checkid == null || checkid == "")
                    {
                        string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
                        string a = cc.ExecuteScalar(sqlinsert);
                        string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "'";
                        id = cc.ExecuteScalar(sqltop);
                        if (message == "" || message == null)
                        {
                            string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                            smslength = msg1.Length;
                            if (mime.ToString() == "354338051597603")
                            {
                                cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                            }
                            else
                            {
                                cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                            }
                            //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                            int mess = 0;
                            string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                            string b = cc.ExecuteScalar(sqlinst);

                        }
                        if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                        {

                            string msg = message;
                            smslength = msg.Length;

                            cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                            string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                            string b = cc.ExecuteScalar(sqlinst);
                        }
                        else
                        {
                            string msg = message;
                            smslength = msg.Length;
                            if (mime.ToString() == "354338051597603")
                            {
                                cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                            }
                            else
                            {
                                cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                            }
                            //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                            string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                            string b = cc.ExecuteScalar(sqlinst);
                        }
                    }
                    else
                    {
                        string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mono + "'";
                        DataSet ds1 = cc.ExecuteDataset(sqlserach);
                        foreach (DataRow dr in ds1.Tables[0].Rows)
                        {
                            message_id = Convert.ToString(dr["Message_id"]);
                            if (message_id == mid)
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (message_id != mid)
                        {
                            Testting = "";
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "' and Date='" + todaysDate + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;
                                cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mime.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                                Testting = "";
                            }
                        }
                        else
                        {
                            Testting = "AlreadySent";
                        }
                    }
                }
            }
            //else for not commom group 
            else
            {
                string sqlcheck = "select id from MiscalResponse where mobileno='" + p1 + "'";
                string testid = cc.ExecuteScalar(sqlcheck);
                if (testid == "" || testid == null)
                {
                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                    smslength = msg1.Length;
                    if (mime.ToString() == "354338051597603")
                    {
                        cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                    }
                    else
                    {
                        cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                    }
                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                }
                else
                {
                    query = "select id from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                    string mid1 = cc.ExecuteScalar(query);
                    if (mid1 == "" || mid1 == null)
                    {
                        //string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                        string qry = "select ResponseMsg from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo=0";
                        string msg1 = cc.ExecuteScalar(qry);
                        smslength = msg1.Length;
                        if (mime.ToString() == "354338051597603")
                        {
                            cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                        }
                        else
                        {
                            cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                        }
                        //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                    }
                    else
                    {
                        string sql1 = "select userid,id,ResponseMsg from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                        DataSet ds = cc.ExecuteDataset(sql1);
                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);
                        string mid = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
                        string sql12 = "select id from MiscalResponseCounter where MobileNumber='" + mono + "'";
                        string checkid = cc.ExecuteScalar(sql12);
                        if (checkid == null || checkid == "")
                        {
                            string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
                            string a = cc.ExecuteScalar(sqlinsert);
                            string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "'";
                            id = cc.ExecuteScalar(sqltop);
                            if (message == "" || message == null)
                            {
                                string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                smslength = msg1.Length;
                                if (mime.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                int mess = 0;
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);

                            }
                            if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                            {

                                string msg = message;
                                smslength = msg.Length;
                                if (mime.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                            else
                            {
                                string msg = message;
                                smslength = msg.Length;
                                if (mime.ToString() == "354338051597603")
                                {
                                    cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                                }
                                else
                                {
                                    cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                }
                                //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                string b = cc.ExecuteScalar(sqlinst);
                            }
                        }
                        else
                        {
                            string sqlserach = "select Message_id from MiscalResponseCounter where mobileNumber='" + mono + "'";
                            DataSet ds1 = cc.ExecuteDataset(sqlserach);
                            foreach (DataRow dr in ds1.Tables[0].Rows)
                            {
                                message_id = Convert.ToString(dr["Message_id"]);
                                if (message_id == mid)
                                {

                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (message_id != mid)
                            {
                                Testting = "";
                                string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
                                string a = cc.ExecuteScalar(sqlinsert);
                                string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "' and Date='" + todaysDate + "'";
                                id = cc.ExecuteScalar(sqltop);
                                if (message == "" || message == null)
                                {
                                    string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                                    smslength = msg1.Length;
                                    if (mime.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                                    int mess = 0;
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                if (userid == "c412eef7-0d04-4f97-ac6f-04fa7aadabdf")
                                {

                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mime.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                }
                                else
                                {
                                    string msg = message;
                                    smslength = msg.Length;
                                    if (mime.ToString() == "354338051597603")
                                    {
                                        cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                                    }
                                    else
                                    {
                                        cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    }
                                    //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                                    string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mid + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                                    string b = cc.ExecuteScalar(sqlinst);
                                    Testting = "";
                                }
                            }
                            else
                            {
                                Testting = "AlreadySent";
                            }
                        }
                    }
                }
            }
        }//--
    }

    #endregion SingleMissCallFuncation

    //------------------------------------Multiple miss call Funcation--------------------------------------------------

    #region MultiMissCallFuncation

    public void MultipleMissCall(string userid12)
    {
        DateTime date = DateTime.Now;
        todaysDate = date.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
        string sqlcheck = "select id from MiscalResponse where mobileno='" + p1 + "'";
        string testid = cc.ExecuteScalar(sqlcheck);
        if (testid == "" || testid == null)
        {
            string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz. Contact 9422324927,md@myct.in thanks Via.www.myct.in";
            smslength = msg1.Length;
            if (mime.ToString() == "354338051597603")
            {
                cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
            }
            else
            {
                cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
            }
            //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
        }
        else
        {
            string mono1 = "";
            if (mono.Length > 10)
            {
                mono1 = mono.Substring(2);
            }
            else
            {
                mono1 = mono;
            }
            string query = "select usrUserid from usermaster where usrMobileNo='" + mono1 + "'";
            string userid1 = cc.ExecuteScalar(query);
            if (userid1 != "" || userid1 != null)
            {
                string groupno = "", mid = "";
                string query1 = "select id, groupno from MiscalResponse where mobileno='" + p1 + "' and userid='" + userid12 + "' And Msg_Status='Active'";
                DataSet ds = cc.ExecuteDataset(query1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string MgsId = Convert.ToString(dr["id"]);
                    groupno = Convert.ToString(dr["groupno"]);

                    query1 = "Select Message_id from MiscalResponseCounter where MobileNumber='" + mono + "' and Message_id='" + MgsId + "'";
                    mid = Convert.ToString(cc.ExecuteScalar(query1));
                    if (mid == "")
                    {
                        Testting = "";
                        string sql1 = "select userid,ResponseMsg from MiscalResponse where mobileno='" + p1 + "' and Msg_Status='Active' and GroupNo='" + groupno + "'";
                        ds = cc.ExecuteDataset(sql1);
                        string message = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                        string userid = Convert.ToString(ds.Tables[0].Rows[0]["userid"]);


                        string sqlinsert = "insert into MiscalResponseCounter(MobileNumber,Date,Message,Message_id)values('" + mono + "','" + todaysDate + "','','')";
                        string a = cc.ExecuteScalar(sqlinsert);
                        string sqltop = "select id from MiscalResponseCounter where Message='' and Message_id='' and MobileNumber='" + mono + "'";
                        id = cc.ExecuteScalar(sqltop);
                        if (message == "" || message == null)
                        {
                            string msg1 = "Dear Sir/Madam, Thanks to use Miss Call Function of www.myct.in for settings,Plz.Contact 9422324927,md@myct.in thanks Via.www.myct.in";
                            smslength = msg1.Length;
                            if (mime.ToString() == "354338051597603")
                            {
                                cc.TransactionalSMSCountryWari("Miscal", mono, msg1, smslength, sendercode);
                            }
                            else
                            {
                                cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                            }
                            //cc.TransactionalSMSCountry("Miscal", mono, msg1, smslength, sendercode);
                            int mess = 0;
                            string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + mess + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                            string b = cc.ExecuteScalar(sqlinst);

                        }

                        else
                        {
                            string msg = message;
                            smslength = msg.Length;
                            if (mime.ToString() == "354338051597603")
                            {
                                cc.TransactionalSMSCountryWari("Miscal", mono, msg, smslength, sendercode);
                            }
                            else
                            {
                                cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                            }
                            //cc.TransactionalSMSCountry("Miscal", mono, msg, smslength, sendercode);
                            string sqlinst = "update MiscalResponseCounter set Message='" + message + "',Message_id='" + MgsId + "' where id='" + id + "' and MobileNumber='" + mono + "' ";
                            string b = cc.ExecuteScalar(sqlinst);
                        }
                    }
                    else
                    {
                        Testting = "AlreadySent";
                    }
                    break;
                }
            }
        }
    }

    #endregion MultiMissCallFuncation
}













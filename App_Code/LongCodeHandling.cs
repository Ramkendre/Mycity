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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.CodeDom;

/// <summary>
/// Summary description for LongCodeHandling
/// </summary>
public class LongCodeHandling : System.Web.UI.Page
{
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();
    int status;
    CommonCode cc = new CommonCode();
    Location ll = new Location();
    string mmmsg0;
    string mmmsg1;
    string mmmsg2;
    //string mmmsg3;
    //string mmmsg4;
    int JoinGr = 0;
    string PinMessage = "", PinMobile = "";
	public LongCodeHandling()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string checkPinExist(string pinMsg)
    {
        string pinCode = "";
        char[] PinArr = pinMsg.ToCharArray();
        for (int i = 0; i < PinArr.Length; i++)
        {
            if (PinArr[i] >= 48 && PinArr[i] <= 57)
            {
                if (PinArr[i + 1] >= 48 && PinArr[i + 1] <= 57)
                {
                    if (PinArr[i + 2] >= 48 && PinArr[i + 2] <= 57)
                    {
                        if (PinArr[i + 3] >= 48 && PinArr[i + 3] <= 57)
                        {
                            if (PinArr[i + 4] >= 48 && PinArr[i + 4] <= 57)
                            {
                                if (PinArr[i + 5] >= 48 && PinArr[i + 5] <= 57)
                                {
                                    pinCode = PinArr[i].ToString() + PinArr[i + 1].ToString() + PinArr[i + 2].ToString() + PinArr[i + 3].ToString() + PinArr[i + 4].ToString() + PinArr[i + 5].ToString();
                                    return pinCode;
                                }
                            }
                        }
                    }
                }
            }
        }
        return pinCode;

    }
    public void ReeSetPass(UserRegistrationBLL ur)
    {
        string updatePass = cc.DESEncrypt(ur.usrMessageString);
        string sqlUpdate = "update userMaster set usrPassword='" + updatePass.ToString() + "' where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
        int i = cc.ExecuteNonQuery(sqlUpdate);
        if (i > 0)
        {
            string nameSql = "select usrFirstName+' '+usrLastName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";

            string name = "";
            name = cc.ExecuteScalar(nameSql);
            string responseMsg = "Dear " + name.ToString() + ", Your Password :: '" + ur.usrMessageString.ToString() + "' is updated. " + cc.AddSMS(ur.usrMobileNo);
            cc.SendMessage1("MYCT.IN", ur.usrMobileNo, responseMsg);
        }
    }
    public void sendMailSMSwithoutReg(UserRegistrationBLL ur)
    {
        //status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
        //if (status == 0)
        //{
        //UserRegistrationBLL usrBllBojNew = new UserRegistrationBLL();
        DataSet ds = new DataSet();
        string sqlFetch = "select ur.usrFirstName+' '+ur.usrLastName as name,ur.usrCityId as ctid,ct.cityName,dt.distName as distName, stt.stateName as stName from userMaster ur inner join CityMaster ct on ur.usrCityId=ct.cityId inner join DistrictMaster dt on ct.distId = dt.distId inner join StateMaster stt on stt.stateId = dt.stateId where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";

        ds = cc.ExecuteDataset(sqlFetch);
        string Name = "";
        int CityId = 0, KeyWordId = 0;
        string ctnm = "", dtnm = "", stnm = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            Name = Convert.ToString(dr["name"]);
            CityId = Convert.ToInt32(dr["ctid"]);
            ctnm = Convert.ToString(dr["cityName"]);
            dtnm = Convert.ToString(dr["distName"]);
            stnm = Convert.ToString(dr["stName"]);

        }
        if (Name.ToString() == "")
        {
            if (ur.usrFirstName == "")
            {
                Name = "Unknown";
            }
            else
            {
                Name = ur.usrFirstName;
            }
        }
        if (CityId == 0)
            CityId = 1;

        string kwidSql = "select keywordId from KeywordDefinition where keywordName ='" + ur.usrKeyWord.ToString() + "'";
        KeyWordId = Convert.ToInt32(cc.ExecuteScalar(kwidSql));
        string sqlSaveComp = "insert into CompMaster(CompKeyWdId,CompSMS,CompMaker,CityId) values(" + KeyWordId + ",'" + ur.longCodegrSMS.ToString() + "','" + Name.ToString() + "'," + CityId + ")";
        int statusFlag = cc.ExecuteNonQuery(sqlSaveComp);
        if (statusFlag > 0)
        {
            string subject = "", NewSmsResp = "", emlBody = "", emlTo = "", backUsrResponse = "", usrMoNo = "", sender = "";
            usrMoNo = ur.usrMobileNo.ToString();
            sender = "myct.in";
            string emlSql = "select email from KeywordDefinition where KeywordName='" + ur.usrKeyWord.ToString() + "'";
            emlTo = Convert.ToString(cc.ExecuteScalar(emlSql));
            if (ur.usrKeyWord == "SAKAL" || ur.usrKeyWord == "NBP" || ur.usrKeyWord == "MATA" || ur.usrKeyWord == "DESHONNATI" || ur.usrKeyWord == "LOKMAT")
            {
                string paper = "";
                if (ur.usrKeyWord == "NBP")
                {
                    paper = "Navbharat";
                }
                else
                {
                    paper = ur.usrKeyWord;
                }
                NewSmsResp = "Thank's dear, Your news send to ur favret news paper " + paper.ToString() + " " + cc.AddSMS(usrMoNo);
                subject = "Updated News From " + Name.ToString();
                emlBody = "\nNEWS: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                //ll.sendEmail(emlTo, subject, emlBody);
                cc.SendMessage1(sender, usrMoNo, NewSmsResp);

            }
            //else if (ur.usrKeyWord == "JAIN" || ur.usrKeyWord == "Jain" || ur.usrKeyWord == "jain")
            //{


            //    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
            //    subject = "Complaint From " + Name.ToString();
            //    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
            //    emlBody += "\n\n.............www.myct.in";
            //    //NewSmsResp = "THANKS to join JAIN group in all India mobile directory on www.myct.in to receive imp sms.";
            //    NewSmsResp = "WELCOME to Shri Guru Ganesh Tapodham. Thanks to join all india JAIN group Mobile directory. Update it by Updating ur profile on www.myct.in with pswrd ";
            //    ur.usrMessageString = NewSmsResp.ToString();
            //    //ll.sendEmail(emlTo, subject, emlBody);
            //    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
            //    if (status == 0)
            //    {
            //        string sqlPass = "select usrPassword from userMaster where usrMobileNo='"+usrMoNo .ToString ()+"'";
            //        string passDec =Convert .ToString ( cc.DESDecrypt(cc.ExecuteScalar (sqlPass )));
            //        //NewSmsResp += "Ur login pswd fr myct.in is "+passDec .ToString ()+" Via: www.myct.in"; 
            //        NewSmsResp += "" + passDec .ToString ()+ ".";
            //        cc.SendMessageTra (sender, usrMoNo, NewSmsResp);
            //    }
            //    else
            //    {
            //        string MyKey = "JAIN SAMAJ";
            //        RegisterByLongCodePINNew(ur, MyKey);
            //    }
            //}
            else if (ur.usrKeyWord == "JAIN" || ur.usrKeyWord == "TELI" || ur.usrKeyWord == "JANGID" || ur.usrKeyWord == "JB" || ur.usrKeyWord == "ALLAH" || ur.usrKeyWord == "JM" || ur.usrKeyWord == "MALI" || ur.usrKeyWord == "MSCIT" || ur.usrKeyWord == "OM" || ur.usrKeyWord == "SAHU" || ur.usrKeyWord == "DIDIMA")
            {
                string MyKey = ur.usrKeyWord.ToString();
                string SendMyKey = "";
                string MyKeyResp = "";
                if (MyKey == "JM")
                {
                    MyKeyResp = "Maheshwari";

                }
                else if (MyKey == "JB")
                {
                    MyKeyResp = "Jai Bhim";
                }
                else if (MyKey == "ALLAH")
                {
                    MyKeyResp = "Muslim";
                }
                else if (MyKey == "JAIN")
                {
                    MyKeyResp = MyKey.ToString();
                    SendMyKey = "JAIN SAMAJ";

                }
                else if (MyKey == "SAHU")
                {
                    MyKeyResp = MyKey.ToString();
                    SendMyKey = "SAHU SAMAJ";

                }
                else if (MyKey == "OM")
                {
                    MyKeyResp = MyKey.ToString();
                    SendMyKey = "BHARAT SWABHIMAN";

                }
                else if (MyKey == "MSS")
                {
                    MyKeyResp = MyKey.ToString();
                    SendMyKey = "Maratha";

                }
                else
                {
                    MyKeyResp = MyKey.ToString();
                    SendMyKey = MyKeyResp;
                }

                backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                subject = "Complaint From " + Name.ToString();
                emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                NewSmsResp = "THANKS to join " + MyKeyResp.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                ur.usrMessageString = NewSmsResp.ToString();
                //ll.sendEmail(emlTo, subject, emlBody);
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                    NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                    cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                }
                else
                {
                    //string MyKey = "RAVIDASSIA";
                    RegisterByLongCodePINNew(ur, SendMyKey);
                }
            }
            else if (ur.usrKeyWord == "RAVIDASSIA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "RAVIDASIYA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "Ravidassia" || ur.usrKeyWord == "ravidassia")
            {
                ur.usrKeyWord = "RAVIDASSIA";
                backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                subject = "Complaint From " + Name.ToString();
                emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                NewSmsResp = "THANKS to join RAVIDASSIA group in all India mobile directory on www.myct.in to receive imp sms.";
                ur.usrMessageString = NewSmsResp.ToString();
                //ll.sendEmail(emlTo, subject, emlBody);
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                    NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                    cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                }
                else
                {
                    string MyKey = "RAVIDASSIA";
                    RegisterByLongCodePINNew(ur, MyKey);
                }
            }
            else if (ur.usrKeyWord == "JANGID" || ur.usrKeyWord == "MALI" || ur.usrKeyWord == "SAHU" || ur.usrKeyWord == "MSCIT" || ur.usrKeyWord == "OM" || ur.usrKeyWord == "DIDIMA")
            {
                string keyResp = "";
                if (ur.usrKeyWord == "OM")
                {
                    keyResp = "BHARAT SWABHIMAN";

                }
                if (ur.usrKeyWord == "SAHU")
                {
                    keyResp = "SAHU SAMAJ";

                }
                else
                {
                    keyResp = ur.usrKeyWord;

                }

                string MyKey = keyResp;
                backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                subject = "Complaint From " + Name.ToString();
                emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                NewSmsResp = "THANKS to join " + keyResp.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                ur.usrMessageString = NewSmsResp.ToString();
                //ll.sendEmail(emlTo, subject, emlBody);
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                    NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                    cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                }
                else
                {
                    //string MyKey = "RAVIDASSIA";
                    RegisterByLongCodePINNew(ur, MyKey);
                }
            }
            //else if (ur.usrKeyWord == "MSS" || ur.usrKeyWord == "Mss" || ur.usrKeyWord == "mss")
            //{
            //    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
            //    subject = "Complaint From " + Name.ToString();
            //    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
            //    emlBody += "\n\n.............www.myct.in";
            //    NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org)";
            //    ur.usrMessageString = NewSmsResp.ToString();
            //    //ll.sendEmail(emlTo, subject, emlBody);
            //    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
            //    if (status == 0)
            //    {
            //        cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
            //    }
            //    else
            //    {
            //        string MyKey = "MSS";
            //        RegisterByLongCodePINNew(ur, MyKey);
            //    }
            //}
            else if (ur.usrKeyWord == "MHMSM" || ur.usrKeyWord == "MhMsm" || ur.usrKeyWord == "mhmsm")
            {
                backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                subject = "Complaint From " + Name.ToString();
                emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org)";
                ur.usrMessageString = NewSmsResp.ToString();
                //ll.sendEmail(emlTo, subject, emlBody);
                status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                if (status == 0)
                {
                    cc.SendMessage1(sender, usrMoNo, NewSmsResp);
                }
                else
                {
                    string MyKey = "MHMSM";
                    RegisterByLongCodePINNew(ur, MyKey);
                }
            }
            else
            {
                backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                subject = "Complaint From " + Name.ToString();
                emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                emlBody += "\n\n.............www.myct.in";
                NewSmsResp = "Thanks, complaint received. To confirm it sms again for registration as  <PINCODE> <FIRSTNAME> <SURNAME> on 9243100142 vis:www.myct.in";
                //ll.sendEmail(emlTo, subject, emlBody);
                cc.SendMessage1(sender, usrMoNo, NewSmsResp);
            }




            //}

        }
        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
        int pkchange = 0;
        pkchange = cc.ExecuteNonQuery(changeFlagSql);
        if (pkchange == 0)
        {
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }


    }


    public void CopyGroupByKeyWord(UserRegistrationBLL ur)
    {

        string message = "", from = "", to = "", grf = "", grt = "";
        int grFrom = 0, grTo = 0;
        message = ur.usrMessageString;
        string[] mss = message.Split(' ');
        from = ur.usrMobileNo;
        if (mss.Length >= 3)
        {
            grf = Convert.ToString(mss[0].ToString());
            to = Convert.ToString(mss[1]);
            grt = Convert.ToString(mss[2].ToString());
        }
        else if (mss.Length >= 2)
        {
            grf = Convert.ToString(mss[0].ToString());
            to = Convert.ToString(mss[1]);
            grt = "FR1";
        }
        ur.usrMobileNo = to.ToString();
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            grFrom = Convert.ToInt32(grf.Substring(2));
            grTo = Convert.ToInt32(grt.Substring(2));
            string sqlToUserId = "select usrUserId from userMaster where usrMObileNo='" + to.ToString() + "'";
            string toUsrId = Convert.ToString(cc.ExecuteScalar(sqlToUserId));
            string sqlFrUi = "select fr.FriendId from FriendRelationMaster fr inner join userMaster um on fr.UserId = um.usrUserId";
            sqlFrUi += " where um.usrMobileNo='" + from.ToString() + "' and friendGroup='" + grFrom.ToString() + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sqlFrUi);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string sqlInsert = "insert into FriendRelationMaster(UserId ,FriendId,FriRelName,friendGroup) values('" + toUsrId.ToString() + "','" + dr["FriendId"].ToString() + "','Friend','" + grTo.ToString() + "')";
                int jjj = cc.ExecuteNonQuery(sqlInsert);

            }
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }

    }

    public bool checkPinKeyWordByVal(string kwd)
    {
        bool flg = true;
        char[] arrPin = kwd.ToCharArray();
        for (int i1 = 0; i1 < arrPin.Length; i1++)
        {
            if (arrPin[i1] >= 48 && arrPin[i1] <= 57)
            {

            }
            else
            {
                flg = false;
                break;
            }
        }
        if (flg == true)
        {
            if (Convert.ToInt32(kwd) >= 099999 && Convert.ToInt32(kwd) <= 999999)
            {
                flg = true;
                return flg;
            }
            else
            {
                flg = false;
                return flg;
            }
        }


        return flg;
    }

    public int CheckPin(string pinCode)
    {
        int flag = 0;
        try
        {
            int pin = Convert.ToInt32(pinCode);
            if (pin <= 999999 && pin >= 099999)
            {
                flag = 1;
            }

        }
        catch (Exception e)
        {
            flag = 0;
            return flag;
        }

        return flag;
    }

    public void setDNDbyLongCode(UserRegistrationBLL ur)
    {
        string DND0 = "Fully blocked";
        string DND1 = "Receiving SMS relating to Banking / Insurance / Financial Products / Credit Cards";
        string DND2 = "Receiving SMS relating to Real Estate";
        string DND3 = "Receiving SMS relating to Education";
        string DND4 = "Receiving SMS relating to Health";
        string DND5 = "Receiving SMS relating to Consumer goods and automobiles";
        string DND6 = "Receiving SMS relating to Communication / Broadcasting / Entertainment / IT";
        string DND7 = "Receiving SMS relating to Tourism and Leisure";
        string response = "Dear ";
        DataSet ds = new DataSet();
        string sqlnm = "select usrFirstName+' '+usrLastName as Name from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
        response += cc.ExecuteScalar(sqlnm.ToString()) + " your DND Status: ";
        if (ur.usrDND == 0)
        {
            response += DND0;
        }
        else if (ur.usrDND == 1)
        {
            response += DND1;
        }
        else if (ur.usrDND == 2)
        {
            response += DND2;
        }
        else if (ur.usrDND == 3)
        {
            response += DND3;
        }
        else if (ur.usrDND == 4)
        {
            response += DND4;
        }
        else if (ur.usrDND == 5)
        {
            response += DND5;
        }
        else if (ur.usrDND == 6)
        {
            response += DND6;
        }
        else if (ur.usrDND == 7)
        {
            response += DND7;
        }
        response += " registered with www.myct.in successfully.";

        string DNDAct = "update userMaster set DND=" + ur.usrDND + " where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
        int iii = cc.ExecuteNonQuery(DNDAct);
        if (iii > 0)
        {
            cc.SendMessage1("www.myct.in", ur.usrMobileNo, response);
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }


    }

    public string checkSMSstr(string sms)
    {
        string status = "TRUE";
        string[] arr = sms.Split(' ');
        if (arr.Length > 5)
        {
            status = "TRUE";
            return status;
        }
        else
        {
            status = "FALSE";
        }
        try
        {
            string sss = Convert.ToString(arr[0]);
            char[] charArr = sss.ToCharArray();
            if (charArr[0] >= 48 && charArr[0] <= 57)
            {
                if (charArr[1] >= 48 && charArr[1] <= 57)
                {
                    status = "FALSE";
                }
            }
        }
        catch (Exception rr)
        {
            status = "TRUE";
            throw rr;
            return status;
        }


        return status;
    }

    public void saveNewsSMS(string mobile, string message1, string keyword)
    {
        string citySQL = "Select usrCityId from UserMaster Where usrMobileNo='" + mobile.ToString() + "'";
        int cid = Convert.ToInt32(cc.ExecuteScalar(citySQL));
        string sql1 = "select usrFirstName+' '+usrLastName as name from userMaster where usrMobileNo='" + mobile.ToString() + "'";
        string Name = cc.ExecuteScalar(sql1);
        string GrNameVal = keyword.ToString();
        string grnmword = "", GroupTypeName = "";
        if (GrNameVal == "ANNA")
        {
            grnmword = "Anna Group";
            GroupTypeName = "Social Group";
        }
        else if (GrNameVal == "LOKMAT")
        {
            grnmword = "Lokmat Group";
            GroupTypeName = "Favorite News Papers Group";
        }
        else if (GrNameVal == "SAKAL")
        {
            grnmword = "Sakal Group";
            GroupTypeName = "Favorite News Papers Group";
        }
        else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
        {
            grnmword = "Mata Group";
            GroupTypeName = "Favorite News Papers Group";
        }
        else if (GrNameVal == "DESHONNATI")
        {
            grnmword = "Deshonnati";
            GroupTypeName = "Favorite News Papers Group";
        }


        string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
        string groupId = cc.ExecuteScalar(groupName);
        string missingval = "set IDENTITY_INSERT News_Update ON  DECLARE @next int  DECLARE @min int select @min = MIN($IDENTITY) from News_Update  IF @min = IDENT_SEED('News_Update')  select @next = MIN($IDENTITY) + IDENT_INCR('News_Update')   FROM News_Update t1 Where $IDENTITY BETWEEN IDENT_SEED('News_Update') AND 32767 AND NOT EXISTS( select * from News_Update t2  where t2.$IDENTITY = t1.$IDENTITY+IDENT_INCR('News_Update'))  ELSE select @next = IDENT_SEED('News_Update') ";
        missingval += "Insert into News_Update(id,NewsFrom,News,GroupValId,CityId) Values(@next,'" + Name.ToString() + "','" + message1.ToString() + "'," + Convert.ToInt32(groupId) + "," + cid + ")";
        int i = cc.ExecuteNonQuery(missingval);
        //string sql2 = "Insert into News_Update(NewsFrom,News,GroupValId,CityId) Values('" + Name.ToString() + "','" + message1.ToString() + "'," + Convert.ToInt32(groupId) + "," + cid + ")";
        //int i =cc.ExecuteNonQuery(sql2 );
        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
        int pkchange = 0;
        pkchange = cc.ExecuteNonQuery(changeFlagSql);
        if (pkchange == 0)
        {
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }
    }

    public int checkGroupSMSCode(string smsCode)
    {
        int flag = 0;
        try
        {
            //int pin = Convert.ToInt32(smsCode);
            //if (pin <= 30 && pin >= 01)
            //{
            //    flag = 1;
            //}
            char[] arr = smsCode.ToCharArray();
            int i = 0;
            while (i < arr.Length && arr.Length < 3)
            {
                if (arr[i] >= 48 && arr[i] <= 57)
                {
                    flag = 1;
                    i++;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }

        }
        catch (Exception e)
        {
            flag = 0;
            return flag;
        }

        return flag;


    }


    public void UpdateName(UserRegistrationBLL urRegistBll1)
    {
        try
        {
            status = urRegistBll.BLLUpdateUserNameByLongCode(urRegistBll1);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urRegistBll1.usrMobileNo;
                string Name = urRegistBll1.usrFirstName + " " + urRegistBll1.usrLastName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void UpdateFirstName(UserRegistrationBLL urRegistBll2)
    {
        try
        {
            status = urRegistBll.BLLUpdateFirstNameByLongCode(urRegistBll2);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = urRegistBll2.usrMobileNo;
                string Name = urRegistBll2.usrFirstName;
                string Message = "Dear " + Name + ", Your Name is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void changeMobileNoByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrAltMobileNo;
                string Message = "Dear Given number is already registered with com." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
            else
            {

                status = urRegistBll.BLLChangeMobileNoByLongCode(ur);
                if (status > 0)
                {
                    string senderId = "COM2MYCT";
                    string mobileNo = ur.usrMobileNo;
                    string altMobileNo = ur.usrAltMobileNo;
                    string myPassword = cc.DESDecrypt(ur.usrPassword);
                    string thisDir = Server.MapPath("~");
                    if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                    {
                        System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                        File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                    }

                    string message = "Dear,Password for ur Login with your New Registered Mobile No is:" + myPassword + " " + cc.AddSMS(mobileNo);
                    cc.SendMessage1(senderId, mobileNo, message);
                    cc.SendMessageImp1(senderId, altMobileNo, message);
                    string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateAddressByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLUpdateUserAddressByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Address is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void addGroupByLongCode(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            //DataTable dt1 = new DataTable();
            string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);

                //ur.frnrelFrnRelName = usrName;
                //ur.frnrelRelation = "friend";
                //ur.frnrelGroup = "1";

            }

            string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
            DataSet ds11 = new DataSet();
            ds11 = cc.ExecuteDataset(pincity);
            string cid = "", cName = "", did = "", sid = "";
            foreach (DataRow drs in ds11.Tables[0].Rows)
            {

                cid = Convert.ToString(drs["cityId"]);
                cName = Convert.ToString(drs["cityName"]);
                did = Convert.ToString(drs["distId"]);
                sid = Convert.ToString(drs["stateId"]);
                ur.usrCityName = Convert.ToString(cName);
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }

            if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            string GrNameVal = ur.usrKeyWord;
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal == "LOKMAT")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "YUVANXT")
            {
                grnmword = "Yuvanxt Group";
                GroupTypeName = "Favorite News Papers Group";
            }


            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int groupFlag = 0, UsrMastFlag = 0;
            string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
            string uID = "";
            uID = cc.ExecuteScalar(checkPrevGrReg);
            if (uID.ToString() == "")
            {
                groupFlag = cc.ExecuteNonQuery(UpdateGroup);
            }
            UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            if (groupFlag > 0 && UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "";
                if (GrNameVal == "YUVANXT")
                {
                    grnmword = "Lokmat Yuvanxt Group";
                    GroupTypeName = "Favorite News Papers Group";
                    smsString = "Thanks " + ur.usrFirstName + " 2 join " + grnmword.ToString() + ". U will get regular updates by sms/mail " + cc.AddSMS(mobileNo);
                }
                else
                {
                    smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                }
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
            else
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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


            string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
            DataSet ds11 = new DataSet();
            ds11 = cc.ExecuteDataset(pincity);
            string cid = "", cName = "", did = "", sid = "";
            foreach (DataRow drs in ds11.Tables[0].Rows)
            {

                cid = Convert.ToString(drs["cityId"]);
                cName = Convert.ToString(drs["cityName"]);
                did = Convert.ToString(drs["distId"]);
                sid = Convert.ToString(drs["stateId"]);
                ur.usrCityName = Convert.ToString(cName);
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + ur.usrFirstName + " registered you " + cName + " city in com. U use it to send SMS.Dear " + ur.usrFirstName + ",Password for ur First Login is " + myPassword + " for com";
                cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                //string thisDir = Server.MapPath("~");
                //if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                //{
                //    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                //    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                //}

                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }
            string GrNameVal = ur.usrKeyWord;
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal == "LOKMAT")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "YUVANXT")
            {
                grnmword = "Yuvanxt Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToUInt32(groupId) + ")";
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int groupFlag = 0, UsrMastFlag = 0;
            groupFlag = cc.ExecuteNonQuery(UpdateGroup);
            UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            if (groupFlag > 0 && UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "";
                if (GrNameVal == "YUVANXT")
                {
                    grnmword = "Lokmat Yuvanxt Group";
                    GroupTypeName = "Favorite News Papers Group";
                    smsString = "Thanks " + ur.usrFirstName + " 2 join " + grnmword.ToString() + ". U will get regular updates by sms/mail " + cc.AddSMS(mobileNo);
                }
                else
                {
                    smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                }
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }


        }


    }

    public bool CheckPaidSmsGroup(string key)
    {
        bool flag = false;
        char[] keyArr = key.ToCharArray();
        if (keyArr[0] == 'P' || keyArr[0] == 'P')
        {
            if (keyArr[1] >= 48 && keyArr[1] <= 57)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

        }
        else
        {
            flag = false;
        }

        return flag;
    }
    public void sendPaidGroupSms(UserRegistrationBLL ur, int GrId)
    {
        int smsCount = 0;
        string keyWord = ur.usrKeyWord;
        string msg = ur.usrMessageString;
        string usrMobileNo = ur.usrMobileNo;
        string usrSql = "select usrFirstName,usrUserId,paidCount from userMaster where usrMobileNo='" + usrMobileNo.ToString() + "'";
        string unm = "", UserId = "";
        int pdBal = 0;
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(usrSql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            unm = Convert.ToString(dr["usrFirstName"]);
            UserId = Convert.ToString(dr["usrUserId"]);
            pdBal = Convert.ToInt32(dr["paidCount"]);
        }
        string sqlGroupMem = "select GM.MemMoNo from tblGroupSmsMember GM inner join tblPaidSmsGroup GID on GM.GrIdRf = GID.GrId where GM.GroupId='2' AND GID.UserId='" + UserId.ToString() + "'";
        DataSet ds1 = new DataSet();
        ds1 = cc.ExecuteDataset(sqlGroupMem);
        if (msg.Length <= 140)
        {
            smsCount = ds1.Tables[0].Rows.Count;
        }
        else if (msg.Length <= 300)
        {
            smsCount = 2 * ds1.Tables[0].Rows.Count;
        }
        else if (msg.Length <= 460)
        {
            smsCount = 3 * ds1.Tables[0].Rows.Count;
        }
        if (pdBal >= smsCount)
        {
            string smsSendStr = msg + " -www.myct.in";
            string mono = "";
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                mono = Convert.ToString(dr["MemMoNo"]);
                cc.SendMessage1(mono, mono, smsSendStr);

            }
            string SqlUpdateBal = "update UserMaster set paidCount=" + (pdBal - smsCount) + " where usrMobileNo='" + usrMobileNo.ToString() + "'";
            int ijk = cc.ExecuteNonQuery(SqlUpdateBal);
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }

        }
        else
        {
            string ResStr = "Dear " + unm.ToString() + ", You dont have PAID sufficiant balance to send SMS.";
            cc.SendMessage1(usrMobileNo, usrMobileNo, ResStr);
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }


    }
    public void addGroupByLongCodeJNS(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            //DataTable dt1 = new DataTable();
            string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);

                //ur.frnrelFrnRelName = usrName;
                //ur.frnrelRelation = "friend";
                //ur.frnrelGroup = "1";

            }

            string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
            DataSet ds11 = new DataSet();
            ds11 = cc.ExecuteDataset(pincity);
            string cid = "", cName = "", did = "", sid = "";
            foreach (DataRow drs in ds11.Tables[0].Rows)
            {

                cid = Convert.ToString(drs["cityId"]);
                cName = Convert.ToString(drs["cityName"]);
                did = Convert.ToString(drs["distId"]);
                sid = Convert.ToString(drs["stateId"]);
                ur.usrCityName = Convert.ToString(cName);
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }

            if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            string GrNameVal = ur.usrKeyWord;
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal == "LOKMAT")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "JNS")
            {
                grnmword = "Jest Nagarik Sangh";
                GroupTypeName = "Social Group";
            }


            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int groupFlag = 0, UsrMastFlag = 0;
            string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
            string uID = "";
            uID = cc.ExecuteScalar(checkPrevGrReg);
            if (uID.ToString() == "")
            {
                groupFlag = cc.ExecuteNonQuery(UpdateGroup);
            }
            UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            if (groupFlag > 0 && UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
            else
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + GroupTypeName.ToString() + " as " + grnmword.ToString() + "." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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


            string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
            DataSet ds11 = new DataSet();
            ds11 = cc.ExecuteDataset(pincity);
            string cid = "", cName = "", did = "", sid = "";
            foreach (DataRow drs in ds11.Tables[0].Rows)
            {

                cid = Convert.ToString(drs["cityId"]);
                cName = Convert.ToString(drs["cityName"]);
                did = Convert.ToString(drs["distId"]);
                sid = Convert.ToString(drs["stateId"]);
                ur.usrCityName = Convert.ToString(cName);
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            if ((Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);

            }
            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + ur.usrFirstName + " registered you " + cName + " city in com. U use it to send SMS.Dear " + ur.usrFirstName + ",Password for ur First Login is " + myPassword + " for com";
                cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }
            string GrNameVal = ur.usrKeyWord;
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal == "LOKMAT")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA" || GrNameVal == "MATAA")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "JNS")
            {
                grnmword = "Jest Nagarik Sangh";
                GroupTypeName = "Social Group";
            }
            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword.ToString() + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToUInt32(groupId) + ")";
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int groupFlag = 0, UsrMastFlag = 0;
            groupFlag = cc.ExecuteNonQuery(UpdateGroup);
            UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            if (groupFlag > 0 && UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + GroupTypeName.ToString() + " as " + grnmword.ToString() + " is updated succefully." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }


        }


    }


    public void JoinGroupByLongCode(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            //DataTable dt1 = new DataTable();
            string sql = "select usrUserId, usrFirstName,usrLastName,usrCityId from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);

            }
            string GrNameVal = ur.usrKeyWord.ToUpper();
            string grnmword = "", GroupTypeName = "";
            if (GrNameVal == "ANNA ")
            {
                grnmword = "Anna Group";
                GroupTypeName = "Social Group";
            }
            else if (GrNameVal.ToString() == "LOKMAT ")
            {
                grnmword = "Lokmat Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "SAKAL ")
            {
                grnmword = "Sakal Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "MATA " || GrNameVal == "MATAA ")
            {
                grnmword = "Mata Group";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "DESHONNATI ")
            {
                grnmword = "Deshonnati";
                GroupTypeName = "Favorite News Papers Group";
            }
            else if (GrNameVal == "I Congress ")
            {
                grnmword = "I Congress grop";
                GroupTypeName = "Favorite Political Group";

            }
            else if (GrNameVal == "NCP ")
            {
                grnmword = "NCP group";
                GroupTypeName = "Favorite Political Group";
            }
            else if (GrNameVal == "BJP ")
            {
                grnmword = "BJP Group";
                GroupTypeName = "Favorite Political Group";
            }
            else if (GrNameVal == "NCP YOUTH ")
            {
                grnmword = "NCP youth group";
                GroupTypeName = "Favorite Political Group";
            }
            else
            {
                grnmword = "Complaint Group";
                GroupTypeName = "Favorite Complaint Group";
            }

            string groupName = "select GroupValueId from GroupValue where GroupValueName='" + grnmword + "'";
            string groupId = cc.ExecuteScalar(groupName);
            string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
            int groupFlag = 0;
            string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
            string uID = "";
            uID = cc.ExecuteScalar(checkPrevGrReg);
            if (uID.ToString() == "")
            {
                groupFlag = cc.ExecuteNonQuery(UpdateGroup);
            }
            string groupItemId = "select GroupItemId from GroupValue where GroupValueId=" + Convert.ToInt32(groupId);
            string groupItemIdVal = cc.ExecuteScalar(groupItemId);
            string GroupName = "Select GroupName from GroupItem where GroupId=" + Convert.ToInt32(groupItemIdVal);
            string GroupNameVal = cc.ExecuteScalar(GroupName);
            if (groupFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your " + Convert.ToString(GroupNameVal) + " as " + ur.usrKeyWord + " is updated succefully." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
            }
            else
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " you already joined " + Convert.ToString(GroupNameVal) + " as " + ur.usrKeyWord + "." + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }


    }

    public void UpdateAreaByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            status = urRegistBll.BLLUpdateAreaByLongCode(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear Your Area is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateByLongCodePIN(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }

            status = urRegistBll.BLLUpdatePinByLongCodePIN(ur);
            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string mobileNo = ur.usrMobileNo;
                string Message = "Dear user your PIN code is Updated Successfully." + cc.AddSMS(mobileNo);
                cc.SendMessage1(senderId, mobileNo, Message);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void RegisterByLongCodePINNew(UserRegistrationBLL ur, string KeyWord)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }



            ur.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            ur.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(ur);


            if (status > 0)
            {
                string groupName = "select GroupValueId from GroupValue where GroupValueName='" + KeyWord.ToString() + "'";
                string groupId = cc.ExecuteScalar(groupName);
                string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                int groupFlag = 0;
                string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                string uID = "";
                uID = cc.ExecuteScalar(checkPrevGrReg);
                if (uID.ToString() == "")
                {
                    groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                }
                string senderId = "MYCT.IN";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);
                string passwordMessage = ur.usrMessageString;
                //passwordMessage += "Ur login pswd fr myct.in is "+myPassword .ToString ()+" Via: www.myct.in";
                passwordMessage += " Ur login pswd fr myct.in is " + myPassword.ToString() + ".Via: www.myct.in";
                string passMsgNew = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + myPassword.ToString() + " Tell to do the same to all MSS members for comunication";
                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                //string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on com. U use it to send SMS.Password for ur First Login is " + myPassword + " for com";
                //cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                //cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    //System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    //File.Copy(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }



        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void RegisterByLongCodePIN(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);


            }



            urRegistBll.usrUserId = System.Guid.NewGuid().ToString();

            Random rnd = new Random();
            urRegistBll.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            status = urRegistBll.BLLInsertUserRegistrationInitial(urRegistBll);


            if (status > 0)
            {
                string senderId = "COM2MYCT";
                string myMobileNo = urRegistBll.usrMobileNo;
                string myPassword = cc.DESDecrypt(urRegistBll.usrPassword);

                //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + ur.usrFirstName + " registered you in city " + cName + " on com. U use it to send SMS.Password for ur First Login is " + myPassword + " for com";
                cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                string thisDir = Server.MapPath("~");
                if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                    File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                }

                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }

            }



        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void RecoverPasswordByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            DataTable dtUserInfoList;
            string mobileNo = ur.usrMobileNo; ;
            urRegistBll.BLLUserPasswordRecovery(mobileNo, out dtUserInfoList, out status);

            if (status > 0)
            {
                DataTable dtUserSMSInfoList = dtUserInfoList;
                DataRow dRowUserInfo = dtUserSMSInfoList.Rows[0];
                //string myMobileNo = "91"+Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myMobileNo = Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfo["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfo["usrFullName"]);


                string sendFrom = "COM2MYCT";
                //string passwordMessage = "Dear " + myName + ", Your Password For Login is :: " + myPassword + " " + cc.AdvMessage();
                string passwordMessage = "Dear " + myName + ", Your Password For Login is :: '" + myPassword + "'. " + cc.AddSMS(myMobileNo);
                string strPassTra = "THANKS to join group in all India mobile directory on www.myct.in to receive imp sms. Ur login pswd fr myct.in is '" + myPassword.ToString() + "'. Via: www.myct.in";
                cc.SendMessageTra(sendFrom, myMobileNo, strPassTra);
                //cc.SendMessageImp1(sendFrom, myMobileNo, strPassTra);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SendMessageToAllByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            int smsBal = 0, dBal = 0, mBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0;
            string LCsms = ur.longCodegrSMS;
            string[] smsArr = LCsms.Split(' ');
            string ActualSMS = "";
            string smsCode = smsArr[0].ToString();
            for (int i = 1; i < smsArr.Length - 1; i++)
            {
                ActualSMS += smsArr[i].ToString() + " ";
            }
            string sql = "select SMSbal,mCount,dCount,usrUserId, usrFirstName,usrLastName,usrCityId ,GroupName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "", UserGroupsNames = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                UserGroupsNames = Convert.ToString(dr1["GroupName"]);
                smsBal = Convert.ToInt32(dr1["SMSbal"]);
                dBal = Convert.ToInt32(dr1["dCount"]);
                mBal = Convert.ToInt32(dr1["mCount"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);
                ur.UsrGroupNames = Convert.ToString(UserGroupsNames);

            }
            string[] arrUrGrNames = UserGroupsNames.Split(',');
            int GrNameId = Convert.ToInt32(smsCode);
            GrNameId = GrNameId + 1;
            string GrNameIs = arrUrGrNames[GrNameId].ToString();
            string GrMembers = "";
            if (GrNameId > 2)
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "' AND friendGroup='" + GrNameId.ToString() + "'";
            }
            else
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "'";
            }
            DataSet ds111 = new DataSet();
            ds111 = cc.ExecuteDataset(GrMembers);
            string GrMemberId = "";
            string GrMemMoNoSQL = "", GrMemMoNo = "";
            string sender = ur.usrMobileNo;
            string sms = ActualSMS.ToString();
            smsLength = sms.Length;
            totalSms = ds111.Tables[0].Rows.Count;
            if (smsLength <= 80)
            {
                smsCharge = 1 * totalSms;
            }
            else if (smsLength <= 240)
            {
                smsCharge = 2 * totalSms;
            }
            else
            {
                smsCharge = 3 * totalSms;
            }
            if ((smsCharge <= ((50 - dBal) + smsBal)) && (smsCharge <= (mBal + smsBal)))
            {
                string dndSql = "";
                int dndFales = 0;
                foreach (DataRow dr123 in ds111.Tables[0].Rows)
                {
                    sender = ur.usrMobileNo;
                    GrMemberId = Convert.ToString(dr123["FriendId"]);
                    GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                    GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                    dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                    string MydndFlg = cc.ExecuteScalar(dndSql);
                    if (MydndFlg == "")
                    {
                        dndFales = 1;
                    }
                    else
                    {
                        dndFales = Convert.ToInt32(MydndFlg);
                    }
                    if (dndFales == 0)
                    {
                        sms = sms + " " + ur.usrFirstName + "(" + sender.ToString() + ") " + cc.AddSMS(GrMemMoNo);
                        cc.SendMessage1(sender, GrMemMoNo, sms);
                    }
                    else
                    {
                        smsCharge--;
                    }
                    //string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    //int pkchange = 0;
                    //pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //if (pkchange == 0)
                    //{
                    //    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    //}
                    sms = "";
                    sms = ActualSMS.ToString();
                }
                if (smsCharge >= (50 - dBal))
                {
                    smsBal = smsBal - (smsCharge - (50 - dBal));
                    mBal = mBal - (50 - dBal);
                    dBal += (50 - dBal);
                }
                else
                {

                    dBal = dBal + smsCharge;
                    mBal = mBal - smsCharge;


                }
                string sqlBalUpdate = "update userMaster set SMSbal=" + smsBal.ToString() + ",mCount=" + mBal.ToString() + ",dCount=" + dBal.ToString() + " where usrMobileNo='" + sender.ToString() + "'";
                int i = cc.ExecuteNonQuery(sqlBalUpdate);

            }
            else
            {
                string smsResponse = "Dear " + ur.usrFirstName + ", You dont have sufficient bal. Your Daily Free Bal=" + (50 - dBal).ToString() + ",Monthly Free Bal=" + mBal.ToString() + ",Paid Bal=" + smsBal.ToString() + "." + cc.AddSMS(sender);
                cc.SendMessage1(sender, sender, smsResponse);
            }




        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SendMessageToAllStuPAByLongCode(UserRegistrationBLL ur, string mobile, int grId, string smsAP)
    {
        try
        {
            int smsBal = 0, dBal = 0, mBal = 0, smsLength = 0, totalSms = 0, smsCharge = 0;
            string LCsms = ur.longCodegrSMS;
            string[] smsArr = LCsms.Split(' ');
            string ActualSMS = "";
            string smsCode = smsArr[0].ToString();
            for (int i = 1; i < smsArr.Length - 1; i++)
            {
                ActualSMS += smsArr[i].ToString() + " ";
            }
            string sql = "select SMSbal,mCount,dCount,usrUserId, usrFirstName,usrLastName,usrCityId ,GroupName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql);
            //dt1 = ds.Tables[0];
            string userId;
            string usrFName = "", usrLName = "", UserGroupsNames = "";
            int cityId;
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                userId = Convert.ToString(dr1["usrUserId"]);
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
                cityId = Convert.ToInt32(dr1["usrCityId"]);
                UserGroupsNames = Convert.ToString(dr1["GroupName"]);
                smsBal = Convert.ToInt32(dr1["SMSbal"]);
                dBal = Convert.ToInt32(dr1["dCount"]);
                mBal = Convert.ToInt32(dr1["mCount"]);
                ur.usrUserId = Convert.ToString(userId);
                ur.usrFirstName = Convert.ToString(usrFName);
                ur.usrLastName = Convert.ToString(usrLName);
                ur.UsrGroupNames = Convert.ToString(UserGroupsNames);

            }
            string[] arrUrGrNames = UserGroupsNames.Split(',');
            int GrNameId = Convert.ToInt32(smsCode);
            GrNameId = GrNameId - 1;
            string GrNameIs = arrUrGrNames[GrNameId].ToString();
            string GrMembers = "";
            if (GrNameId >= 2)
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "' AND friendGroup='" + GrNameId.ToString() + "'";
            }
            else
            {
                GrMembers = "Select FriendId from FriendRelationMaster where UserId='" + ur.usrUserId + "'";
            }
            DataSet ds111 = new DataSet();
            ds111 = cc.ExecuteDataset(GrMembers);
            string GrMemberId = "";
            string GrMemMoNoSQL = "", GrMemMoNo = "";
            string sender = ur.usrMobileNo;
            string sms = ActualSMS.ToString();
            smsLength = sms.Length;
            totalSms = ds111.Tables[0].Rows.Count;
            if (smsLength <= 80)
            {
                smsCharge = 1 * totalSms;
            }
            else if (smsLength <= 240)
            {
                smsCharge = 2 * totalSms;
            }
            else
            {
                smsCharge = 3 * totalSms;
            }
            if ((smsCharge <= ((50 - dBal) + smsBal)) && (smsCharge <= (mBal + smsBal)))
            {
                string dndSql = "";
                int dndFales = 0;
                string SchoolId = "", ClassId = "";
                string[] RollNo = ActualSMS.Split(',');
                string nonSendSmsUser = "";
                foreach (DataRow dr123 in ds111.Tables[0].Rows)
                {
                    bool PAflag = false;
                    string StuPAname = "", StuPAschoolName = "";
                    GrMemberId = Convert.ToString(dr123["FriendId"]);
                    bool sendPAsmsFlag = false;
                    for (int mr = 0; mr < RollNo.Length && sendPAsmsFlag == false; mr++)
                    {
                        string lowLoop = "select usrUserId from tblFamilyInfoMaster where usrUserId='" + GrMemberId.ToString() + "' and (usrFIrollNo1='" + RollNo[mr].ToString() + "' or usrFIrollNo2='" + RollNo[mr].ToString() + "' or usrFIrollNo3='" + RollNo[mr].ToString() + "')";
                        string LowLoopId = cc.ExecuteScalar(lowLoop);
                        if (LowLoopId.ToString() != "")
                        {
                            DataSet mrpa1 = new DataSet();
                            DataSet mrpa2 = new DataSet();
                            DataSet mrpa3 = new DataSet();
                            string sqlPA1 = "select fi.usrFiname1,sm.SchoolName ,fi.usrFIschool1,fi.usrFIclass1 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool1=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo1='" + RollNo[mr].ToString() + "'";
                            string sqlPA2 = "select fi.usrFiname2,sm.SchoolName ,fi.usrFIschool2,fi.usrFIclass2 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool2=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo2='" + RollNo[mr].ToString() + "'";
                            string sqlPA3 = "select fi.usrFiname3,sm.SchoolName ,fi.usrFIschool3,fi.usrFIclass3 from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool3=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo3='" + RollNo[mr].ToString() + "'";
                            mrpa1 = cc.ExecuteDataset(sqlPA1);
                            mrpa2 = cc.ExecuteDataset(sqlPA2);
                            mrpa3 = cc.ExecuteDataset(sqlPA3);
                            if (mrpa1.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa1.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname1"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool1"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass1"].ToString());
                                    }
                                    PAflag = true;
                                }

                            }
                            else if (mrpa2.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa2.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname2"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    if (SchoolId.ToString() == "" && ClassId.ToString() == "")
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool2"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass2"].ToString());
                                    }
                                    PAflag = true;
                                }
                            }
                            else if (mrpa3.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow drr in mrpa3.Tables[0].Rows)
                                {
                                    StuPAname = drr["usrFiname3"].ToString();
                                    StuPAschoolName = drr["SchoolName"].ToString();
                                    {
                                        SchoolId = Convert.ToString(drr["usrFIschool3"].ToString());
                                        ClassId = Convert.ToString(drr["usrFIclass3"].ToString());
                                    }
                                    PAflag = true;
                                }
                            }

                            if (PAflag == true)
                            {
                                sendPAsmsFlag = true;
                                sender = ur.usrMobileNo;
                                GrMemberId = Convert.ToString(dr123["FriendId"]);
                                GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                                GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                                dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                                string MydndFlg = cc.ExecuteScalar(dndSql);
                                if (MydndFlg == "")
                                {
                                    dndFales = 1;
                                }
                                else
                                {
                                    dndFales = Convert.ToInt32(MydndFlg);
                                }
                                if (dndFales == 0)
                                {
                                    sms = "";
                                    string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                    string FatherName = cc.ExecuteScalar(FatherSql);
                                    sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                    sms = sms + " By-" + ur.usrFirstName + "(" + sender.ToString() + ") " + cc.AddSMS(GrMemMoNo);
                                    cc.SendMessage1(sender, GrMemMoNo, sms);
                                }
                                else
                                {
                                    smsCharge--;
                                }
                            }
                            else
                            {
                                sendPAsmsFlag = false;
                            }
                        }
                    }


                    if (sendPAsmsFlag == false)
                    {
                        nonSendSmsUser += Convert.ToString(dr123["FriendId"]) + ",";
                    }
                }
                // Non Entry Roll Number Students.
                if (SchoolId.ToString() != "" && ClassId.ToString() != "")
                {
                    string TotalRollNumbers = "";
                    string remRollSql1 = "select usrFIrollNo1 from tblFamilyInfoMaster where usrFIschool1='" + SchoolId.ToString() + "' AND usrFIClass1='" + ClassId.ToString() + "'";
                    string remRollSql2 = "select usrFIrollNo2 from tblFamilyInfoMaster where usrFIschool2='" + SchoolId.ToString() + "' AND usrFIClass2='" + ClassId.ToString() + "'";
                    string remRollSql3 = "select usrFIrollNo3 from tblFamilyInfoMaster where usrFIschool3='" + SchoolId.ToString() + "' AND usrFIClass3='" + ClassId.ToString() + "'";
                    DataSet dsr1 = new DataSet();
                    DataSet dsr2 = new DataSet();
                    DataSet dsr3 = new DataSet();
                    dsr1 = cc.ExecuteDataset(remRollSql1);
                    dsr2 = cc.ExecuteDataset(remRollSql2);
                    dsr3 = cc.ExecuteDataset(remRollSql3);
                    foreach (DataRow dr in dsr1.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo1"]) + ",";
                    }
                    foreach (DataRow dr in dsr2.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo2"]) + ",";
                    }
                    foreach (DataRow dr in dsr3.Tables[0].Rows)
                    {
                        TotalRollNumbers += Convert.ToString(dr["usrFIrollNo3"]) + ",";
                    }
                    string[] totRNo = TotalRollNumbers.Split(',');
                    string[] sendSmsRno = ActualSMS.Split(',');
                    string[] nonSendUser = nonSendSmsUser.Split(',');
                    for (int m = 0; m < totRNo.Length; m++)
                    {
                        bool nsflagNew = false;
                        for (int r = 0; r < sendSmsRno.Length; r++)
                        {
                            if (totRNo[m].ToString() == sendSmsRno[r].ToString())
                            {
                                nsflagNew = true;
                                break;
                            }
                            else
                            {
                            }
                        }

                        if (nsflagNew == false)
                        {
                            for (int stu = 0; stu < nonSendUser.Length; stu++)
                            {
                                bool PAflag = false;
                                string StuPAname = "", StuPAschoolName = "";
                                GrMemberId = Convert.ToString(nonSendUser[stu]);
                                bool sendPAsmsFlag = false;
                                //for (int mr = 0; mr < RollNo.Length && sendPAsmsFlag == false ; mr++)
                                //{
                                string lowLoop = "select usrUserId from tblFamilyInfoMaster where usrUserId='" + GrMemberId.ToString() + "' and (usrFIrollNo1='" + totRNo[m].ToString() + "' or usrFIrollNo2='" + totRNo[m].ToString() + "' or usrFIrollNo3='" + totRNo[m].ToString() + "')";
                                string LowLoopId = cc.ExecuteScalar(lowLoop);
                                if (LowLoopId.ToString() != "")
                                {
                                    DataSet mrpa1 = new DataSet();
                                    DataSet mrpa2 = new DataSet();
                                    DataSet mrpa3 = new DataSet();
                                    string sqlPA1 = "select fi.usrFiname1,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool1=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo1='" + totRNo[m].ToString() + "'";
                                    string sqlPA2 = "select fi.usrFiname2,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool2=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo2='" + totRNo[m].ToString() + "'";
                                    string sqlPA3 = "select fi.usrFiname3,sm.SchoolName from tblFamilyInfoMaster fi inner join SchoolMaster sm on fi.usrFIschool3=sm.SchoolId where usrUserID='" + GrMemberId.ToString() + "' AND usrFIrollNo3='" + totRNo[m].ToString() + "'";
                                    mrpa1 = cc.ExecuteDataset(sqlPA1);
                                    mrpa2 = cc.ExecuteDataset(sqlPA2);
                                    mrpa3 = cc.ExecuteDataset(sqlPA3);
                                    if (mrpa1.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa1.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname1"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool1"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass1"].ToString());
                                            PAflag = true;
                                        }

                                    }
                                    else if (mrpa2.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa2.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname2"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool2"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass2"].ToString());
                                            PAflag = true;
                                        }
                                    }
                                    else if (mrpa3.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow drr in mrpa3.Tables[0].Rows)
                                        {
                                            StuPAname = drr["usrFiname3"].ToString();
                                            StuPAschoolName = drr["SchoolName"].ToString();
                                            //SchoolId = Convert.ToString(drr["usrFIschool3"].ToString());
                                            //ClassId = Convert.ToString(drr["usrFIclass3"].ToString());
                                            PAflag = true;
                                        }
                                    }
                                    if (PAflag == true)
                                    {
                                        sendPAsmsFlag = true;
                                        sender = ur.usrMobileNo;
                                        GrMemberId = Convert.ToString(nonSendUser[stu]);
                                        GrMemMoNoSQL = "Select usrMobileNo from UserMaster where usrUserId='" + GrMemberId + "'";
                                        GrMemMoNo = cc.ExecuteScalar(GrMemMoNoSQL);
                                        dndSql = "Select DND from UserMaster where usrUserId='" + GrMemberId + "'"; ;
                                        string MydndFlg = cc.ExecuteScalar(dndSql);
                                        if (MydndFlg == "")
                                        {
                                            dndFales = 1;
                                        }
                                        else
                                        {
                                            dndFales = Convert.ToInt32(MydndFlg);
                                        }
                                        if (dndFales == 0)
                                        {
                                            if (smsAP.ToString() == "PRESENT")
                                            {
                                                smsAP = "APSENT";
                                                sms = "";
                                                string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                                string FatherName = cc.ExecuteScalar(FatherSql);
                                                sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                            }
                                            else if (smsAP.ToString() == "APSENT")
                                            {
                                                smsAP = "PRESENT";
                                                sms = "";
                                                string FatherSql = "select usrFirstName from userMaster where usrMobileNo='" + GrMemMoNo.ToString() + "'";
                                                string FatherName = cc.ExecuteScalar(FatherSql);
                                                sms = "Dear " + FatherName.ToString() + " your " + StuPAname.ToString() + " is " + smsAP.ToString() + " today in " + StuPAschoolName.ToString() + "";
                                            }
                                            sms = sms + " By-" + ur.usrFirstName + "(" + sender.ToString() + ") " + cc.AddSMS(GrMemMoNo);
                                            cc.SendMessage1(sender, GrMemMoNo, sms);
                                        }
                                        else
                                        {
                                            smsCharge--;
                                        }

                                    }
                                    //}
                                }
                                //}




                            }

                        }

                    }

                }




                if (smsCharge >= (50 - dBal))
                {
                    smsBal = smsBal - (smsCharge - (50 - dBal));
                    mBal = mBal - (50 - dBal);
                    dBal += (50 - dBal);
                }
                else
                {

                    dBal = dBal + smsCharge;
                    mBal = mBal - smsCharge;


                }
                string sqlBalUpdate = "update userMaster set SMSbal=" + smsBal.ToString() + ",mCount=" + mBal.ToString() + ",dCount=" + dBal.ToString() + " where usrMobileNo='" + sender.ToString() + "'";
                int i = cc.ExecuteNonQuery(sqlBalUpdate);

            }
            else
            {
                string smsResponse = "Dear " + ur.usrFirstName + ", You dont have sufficient bal. Your Daily Free Bal=" + (50 - dBal).ToString() + ",Monthly Free Bal=" + mBal.ToString() + ",Paid Bal=" + smsBal.ToString() + "." + cc.AddSMS(sender);
                cc.SendMessage1(sender, sender, smsResponse);
            }
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdatePinByLongCode(UserRegistrationBLL ur)
    {
        try
        {
            string cid = "", cName = "", did = "", sid = "";
            if (!(Convert.ToInt32(ur.usrPIN) <= 411053 && Convert.ToInt32(ur.usrPIN) >= 411001))
            {
                string pincity = "select cityId,cityName,distId,stateId from CityMaster where PIN='" + ur.usrPIN + "'";
                DataSet ds11 = new DataSet();
                ds11 = cc.ExecuteDataset(pincity);

                foreach (DataRow drs in ds11.Tables[0].Rows)
                {

                    cid = Convert.ToString(drs["cityId"]);
                    cName = Convert.ToString(drs["cityName"]);
                    did = Convert.ToString(drs["distId"]);
                    sid = Convert.ToString(drs["stateId"]);
                    ur.usrCityId = Convert.ToInt32(cid);
                    ur.usrDistrictId = Convert.ToInt32(did);
                    ur.usrStateId = Convert.ToInt32(sid);

                }
            }
            else
            {
                cid = "37";
                cName = "Pune City";
                did = "300";
                sid = "15";
                ur.usrCityId = Convert.ToInt32(cid);
                ur.usrDistrictId = Convert.ToInt32(did);
                ur.usrStateId = Convert.ToInt32(sid);
            }
            string storeUserMaster = "update UserMaster set usrCityId=" + Convert.ToInt64(ur.usrCityId) + ",usrPIN='" + ur.usrPIN + "',usrCity='" + ur.usrCityName + "',usrState='" + Convert.ToString(ur.usrStateId) + "',";
            storeUserMaster += "usrDistrict='" + Convert.ToString(ur.usrDistrictId) + "' where usrMobileNo='" + ur.usrMobileNo + "'";
            int UsrMastFlag = cc.ExecuteNonQuery(storeUserMaster);
            string usrNm = "";
            if (ur.usrFirstName == "" && ur.usrLastName == "")
            {
                string str = "select usrFirstName+' '+usrLastName as name from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                usrNm = cc.ExecuteScalar(str);
            }

            if (UsrMastFlag > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsString = "";
                if (ur.usrFirstName == "")
                {
                    smsString = "Dear " + usrNm.ToString() + " your City,District,State and PIN code is updated succefully." + cc.AddSMS(mobileNo);
                }
                else
                {
                    smsString = "Dear " + ur.usrFirstName + " " + ur.usrLastName + " your City,District,State and PIN code is updated succefully." + cc.AddSMS(mobileNo);
                }
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsString);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                int pkchange = 0;
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                if (pkchange == 0)
                {
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                }
            }

        }
        catch (Exception e)
        {

        }



    }



    public void AddFriendByLongCode(UserRegistrationBLL ur, string userMobileWhoSendFriendReq)
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
                    if (jof >= 1)
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = "1";
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
                        ur.frnrelUserId = userId;
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
                        ur.frnrelFriendId = FriId;
                        ur.frnrelFrnRelName = FriName;
                        ur.frnrelRelation = "friend";
                        string JoinFlagSQL = "select JoinFlag from userMaster where usrMobileNo='" + ur.usrAltMobileNo.ToString() + "'";
                        string jf = cc.ExecuteScalar(JoinFlagSQL);
                        ur.frnrelGroup = jf.ToString();
                        //ur.frnrelGroup = "1";
                        sender = Convert.ToString(FriName);
                    }

                    status = ur.BLLInsertUserFriendRelative(ur);
                    if (status > 0)
                    {
                        string SendTo = ur.usrAltMobileNo;
                        string sendFrom = ur.usrMobileNo;
                        string message = "I " + usrName + " (" + sendFrom.ToString() + ") added u in com to send SMS." + cc.AddSMS(SendTo);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "(" + SendTo.ToString() + ") also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                        }
                        cc.SendMessage1(sendFrom, SendTo, message);
                        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
                    string jof = Convert.ToString(cc.ExecuteScalar(sqlFlagStr));
                    if (jof == "True")
                    {
                        JoinAll = true;
                        ur.JoinFlagProp = "1";
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
                            string JoinFlagSQL = "select JoinFlag from userMaster where usrMobileNo='" + ur.usrAltMobileNo.ToString() + "'";
                            string jf = cc.ExecuteScalar(JoinFlagSQL);
                            ur.frnrelGroup = jf.ToString();
                            //ur.frnrelGroup = "1";
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


                        //string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AdvMessage();
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for com";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                        }
                        string thisDir = Server.MapPath("~");
                        if (!System.IO.Directory.Exists(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\"))
                        {
                            System.IO.Directory.CreateDirectory(thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\");

                            File.Copy(thisDir + "\\User_Resource\\Profile_Photo\\default_user.jpg", thisDir + "\\User_Resource\\" + ur.usrUserId + "\\Profile_Photo\\default_user.jpg");

                        }

                        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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

    public bool checkGr(string keyword)
    {
        bool s = false;
        char[] arr = keyword.ToCharArray();
        if (arr[0] == 'f' || arr[0] == 'F' || arr[0] == 'R' || arr[0] == 'r')
        {
            if (arr[1] == 'R' || arr[1] == 'r' || arr[0] == 'F' || arr[0] == 'f')
            {
                if (checkDigit(arr[2]) >= 48 && checkDigit(arr[2]) <= 57)
                {
                    int len = arr.Length;
                    if (len > 3)
                    {
                        if (checkDigit(arr[3]) >= 48 && checkDigit(arr[2]) <= 57)
                        {
                            s = true;
                        }
                        else
                        {
                            s = true;
                        }
                    }
                    else
                    {
                        s = true;
                    }

                }
            }
        }
        return s;
    }
    public bool checPGr(string keyword)
    {
        bool s = false;
        char[] arr = keyword.ToCharArray();
        if (arr[0] == 'p' || arr[0] == 'P' || arr[0] == 'a' || arr[0] == 'A')
        {
            if (arr[1] == 'R' || arr[1] == 'r' || arr[1] == 'p' || arr[1] == 'P')
            {
                if (checkDigit(arr[2]) >= 48 && checkDigit(arr[2]) <= 57)
                {
                    int len = arr.Length;
                    if (len > 3)
                    {
                        if (checkDigit(arr[3]) >= 48 && checkDigit(arr[2]) <= 57)
                        {
                            s = true;
                        }
                        else
                        {
                            s = true;
                        }
                    }
                    else
                    {
                        s = true;
                    }

                }
            }
        }
        return s;
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
                    string kk = cc.ExecuteScalar(sqlFlagStr);
                    int jof = Convert.ToInt32(kk);
                    if (jof >= 1)
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
                        string message = "I " + usrName + "(" + sendFrom.ToString() + ") added u in com to send SMS." + cc.AddSMS(SendTo);

                        cc.SendMessage1(sendFrom, SendTo, message);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + SendTo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(sendFrom);
                            cc.SendMessage1(SendTo, sendFrom, resJoinAll);
                        }
                        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
                        string message = "Dear " + joiner.ToString() + " u already added " + sender.ToString() + " in com to send SMS." + cc.AddSMS(sendFrom);

                        cc.SendMessage1(SendTo, sendFrom, message);

                        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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
                    string kk = cc.ExecuteScalar(sqlFlagStr);
                    int jof = Convert.ToInt32(kk);
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
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in com. U use it to send SMS.Dear " + myName + ",Password for ur First Login is " + myPassword + " for com";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        if (JoinAll == true)
                        {
                            string resJoinAll = "Thanks " + joiner.ToString() + ", I " + sender.ToString() + "( " + myMobileNo.ToString() + " ) also added u on www.myct.in " + cc.AddSMS(senderId);
                            cc.SendMessage1(myMobileNo, senderId, resJoinAll);
                        }
                        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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

    public void UpdateDOBByLongCode(UserRegistrationBLL ur)
    {
        try
        {

            status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
            if (status == 0)
            {
                string updateDOB = "Update UserMaster set usrDOB='" + ur.usrDOB + "' where usrMobileNo='" + ur.usrMobileNo + "'";
                int statusDOB = cc.ExecuteNonQuery(updateDOB);
                if (statusDOB > 0)
                {
                    string sql = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    string usrFName = "", usrLName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        usrFName = Convert.ToString(dr1["usrFirstName"]);
                        usrLName = Convert.ToString(dr1["usrLastName"]);
                    }
                    string mobileNo = ur.usrMobileNo;
                    string smsDOB = "Dear " + usrFName + " " + usrLName + " your Date of Birth is updated successfully. " + cc.AddSMS(mobileNo);
                    string senderId = "COM2MYCT";

                    cc.SendMessage1(senderId, mobileNo, smsDOB);
                    string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                    int pkchange = 0;
                    pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    if (pkchange == 0)
                    {
                        pkchange = cc.ExecuteNonQuery(changeFlagSql);
                    }

                }



            }
        }
        catch (Exception p)
        {

        }


    }
    public void DeleteUserKeyWord(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sql1);
            string usrFName = "", usrLName = "";
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                usrFName = Convert.ToString(dr1["usrFirstName"]);
                usrLName = Convert.ToString(dr1["usrLastName"]);
            }

            string sql = "delete UserMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int i = cc.ExecuteNonQuery(sql);
            if (i > 0)
            {
                string mobileNo = ur.usrMobileNo;
                string smsDOB = "Dear " + usrFName + " " + usrLName + " you deleted successfully from com . " + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsDOB);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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

        }

    }

    public void JoinAllKeyword(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            string sql = "update UserMaster set JoinFlag = 1 where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int i = cc.ExecuteNonQuery(sql);
            if (i > 0)
            {
                string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql1);
                string usrFName = "", usrLName = "";
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                }
                string mobileNo = ur.usrMobileNo;
                string smsDOB = "Dear " + usrFName + " " + usrLName + ", now persons who add u as a frnd will also b in ur frnd book" + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsDOB);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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

        }


    }
    public void JoinGrKeyword(UserRegistrationBLL ur, int grNo)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            string sql = "update UserMaster set JoinFlag = " + (grNo + 1) + " where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int i = cc.ExecuteNonQuery(sql);
            if (i > 0)
            {
                string sql1 = "select usrFirstName,usrLastName from UserMaster where usrMobileNo='" + ur.usrMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql1);
                string usrFName = "", usrLName = "";
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    usrFName = Convert.ToString(dr1["usrFirstName"]);
                    usrLName = Convert.ToString(dr1["usrLastName"]);
                }
                string GrNames = "select GroupName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
                string GrNames1 = cc.ExecuteScalar(GrNames);
                string[] GrArr = GrNames1.Split(',');
                string GrNm = Convert.ToString(GrArr[grNo + 1]);
                string mobileNo = ur.usrMobileNo;
                string smsDOB = "Dear " + usrFName + " " + usrLName + ", now ur friends add in group " + GrNm.ToString() + " " + cc.AddSMS(mobileNo);
                string senderId = "COM2MYCT";

                cc.SendMessage1(senderId, mobileNo, smsDOB);
                string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
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

        }


    }


    public void removeKewWord(string urMo, string frMo, UserRegistrationBLL ur)
    {
        ur.usrMobileNo = urMo;
        ur.usrAltMobileNo = frMo;
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            status = urRegistBll.BLLIsExistUserRegistrationInitialByLc(ur);
            if (status == 0)
            {
                string sql1 = "", sql2 = "", delSql1 = "", delSql2 = "";
                string usrId = "", frId = "";
                sql1 = "select usrUserId from userMaster where usrMobileNo='" + urMo.ToString() + "'";
                sql2 = "select usrUserId from userMaster where usrMobileNo='" + frMo.ToString() + "'";
                usrId = cc.ExecuteScalar(sql1);
                frId = cc.ExecuteScalar(sql2);
                delSql1 = "delete FriendRelationMaster where UserId='" + usrId.ToString() + "' and FriendId='" + frId.ToString() + "'";
                delSql2 = "delete FriendRelationMaster where UserId='" + frId.ToString() + "' and FriendId='" + usrId.ToString() + "'";
                int s = cc.ExecuteNonQuery(delSql1);
                int t = cc.ExecuteNonQuery(delSql2);
            }
            string usr = "", fr = "", usrQury = "", frQuery = "";
            usrQury = "select usrFirstName from userMaster where usrMobileNo='" + urMo.ToString() + "'";
            frQuery = "select usrFirstName from userMaster where usrMobileNo='" + frMo.ToString() + "'";
            usr = cc.ExecuteScalar(usrQury);
            fr = cc.ExecuteScalar(frQuery);
            string sms = "Dear " + usr.ToString() + ", You removed " + fr.ToString() + " friend successfully. " + cc.AddSMS(urMo);
            string senderId = "COM2MYCT";
            cc.SendMessage1(senderId, urMo, sms);
        }
        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
        int pkchange = 0;
        pkchange = cc.ExecuteNonQuery(changeFlagSql);
        if (pkchange == 0)
        {
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }

    }

    public int checkDigit(char s)
    {
        int d = 10;
        try
        {
            d = Convert.ToInt32(s);
        }
        catch (Exception ff)
        {
            return d;
        }
        return d;
    }
    public void UpdateEmailByLongCode(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial(ur);
        if (status == 0)
        {
            string sql = "update userMaster set usrEmailId='" + ur.usrEmailId.ToString() + "' where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            int i = cc.ExecuteNonQuery(sql);
            string sqlName = "select usrFirstName+' '+usrLastName as MyName from userMaster where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";
            string MyName = cc.ExecuteScalar(sqlName);

            string senderId = "COM2MYCT";
            string urMo = ur.usrMobileNo;
            string passSql = "select usrPassword from userMaster where usrMobileNo='" + urMo.ToString() + "'";
            string pass1 = cc.ExecuteScalar(passSql);
            string FinPass = cc.DESDecrypt(pass1);
            // Dear Murlidhar Bhutada ur password 12345 sent to ur updated E-Mail
            string sms = "Dear " + MyName.ToString() + " ur password: " + FinPass.ToString() + " sent to ur updated E-Mail " + cc.AddSMS(urMo);
            cc.SendMessage1(senderId, urMo, sms);

        }
        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
        int pkchange = 0;
        pkchange = cc.ExecuteNonQuery(changeFlagSql);
        if (pkchange == 0)
        {
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }

    }
    public bool checkGroupKeyword(string kwd)
    {
        bool flag = false;
        try
        {
            int i = 0;
            string sql = "select Active from KeywordDefinition where KeywordName='" + kwd.ToString() + "'";
            string strFlag = cc.ExecuteScalar(sql);
            if (strFlag != "")
            {
                i = Convert.ToInt32(strFlag);
                if (i >= 0)
                {
                    flag = true;
                    return flag;
                }
                else
                {
                    flag = false;
                    return flag;
                }

            }
            else
            {
                flag = false;
                return flag;
            }


        }
        catch (Exception rrr)
        {
            flag = false;
            return flag;
            throw rrr;
        }

    }

    public void FillBalKeyword(string from, string to, int amtOfsms, UserRegistrationBLL ur)
    {
        ur.usrMobileNo = from;
        string SmsTransactionUpdate = "insert into BalTransaction(FromUsr,ToUsr,SmsAmt) values ('" + from + "','" + to + "'," + amtOfsms + ")";
        status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
        if (status == 0)
        {
            ur.usrMobileNo = to;
            status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
            if (status == 0)
            {
                string checkFromBal = "select SMSbal from UserMaster where usrMobileNo ='" + from.ToString() + "'";
                int fromBal = Convert.ToInt32(cc.ExecuteScalar(checkFromBal));
                if (fromBal >= amtOfsms)
                {
                    string tobal = "select SMSbal from UserMaster where usrMobileNo ='" + to.ToString() + "'";
                    int toBalAdd = Convert.ToInt32(cc.ExecuteScalar(tobal));
                    string remBal = "update UserMaster set SMSbal =" + (fromBal - amtOfsms) + " where usrMobileNo ='" + from.ToString() + "'";
                    int i = cc.ExecuteNonQuery(remBal);
                    if (i > 0)
                    {
                        string addBal = "update UserMaster set SMSbal =" + (toBalAdd + amtOfsms) + " where usrMobileNo ='" + to.ToString() + "'";
                        int j = cc.ExecuteNonQuery(addBal);
                        if (j > 0)
                        {
                            string fromResp = "Dear user your transaction is successfully updated. Your Current Balance:" + (fromBal - amtOfsms) + " SMS." + cc.AddSMS(from);
                            string toResp = "Dear user your recharge is successfully complited. Your current Balance:" + (toBalAdd + amtOfsms) + " SMS." + cc.AddSMS(to);
                            string sendfrom = "myct.in";
                            cc.SendMessage1(sendfrom, from, fromResp);
                            cc.SendMessage1(sendfrom, to, toResp);
                            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
                            int pkchange = 0;
                            pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            if (pkchange == 0)
                            {
                                pkchange = cc.ExecuteNonQuery(changeFlagSql);
                            }
                            int balUp = cc.ExecuteNonQuery(SmsTransactionUpdate);

                        }
                    }
                }

            }
        }


    }

    public void smsBalKeyword(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
        if (status == 0)
        {
            string balSql = "select SMSbal from UserMaster where usrMobileNo ='" + ur.usrMobileNo.ToString() + "'";
            string bal = Convert.ToString(cc.ExecuteScalar(balSql));
            string resp = "Dear user your current sms balance:" + bal.ToString() + "" + cc.AddSMS(ur.usrMobileNo);
            cc.SendMessage1(ur.usrMobileNo, ur.usrMobileNo, resp);
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(ur.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }

    }


    public void sendMailSMS(UserRegistrationBLL ur)
    {
        status = urRegistBll.BLLIsExistUserRegistrationInitial1(ur);
        if (status == 0)
        {
            DataSet ds = new DataSet();
            string sqlFetch = "select ur.usrUserId, ur.usrFirstName+' '+ur.usrLastName as name,ur.usrCityId as ctid,ct.cityName,dt.distName as distName, stt.stateName as stName from userMaster ur inner join CityMaster ct on ur.usrCityId=ct.cityId inner join DistrictMaster dt on ct.distId = dt.distId inner join StateMaster stt on stt.stateId = dt.stateId where usrMobileNo='" + ur.usrMobileNo.ToString() + "'";

            ds = cc.ExecuteDataset(sqlFetch);
            string Name = "";
            int CityId = 0, KeyWordId = 0;
            string ctnm = "", dtnm = "", stnm = "", NewSmsResp = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Name = Convert.ToString(dr["name"]);
                CityId = Convert.ToInt32(dr["ctid"]);
                ctnm = Convert.ToString(dr["cityName"]);
                dtnm = Convert.ToString(dr["distName"]);
                stnm = Convert.ToString(dr["stName"]);
                ur.usrUserId = Convert.ToString(dr["usrUserId"]);

            }
            string kwidSql = "select keywordId from KeywordDefinition where keywordName ='" + ur.usrKeyWord.ToString() + "'";
            KeyWordId = Convert.ToInt32(cc.ExecuteScalar(kwidSql));
            string sqlSaveComp = "insert into CompMaster(CompKeyWdId,CompSMS,CompMaker,CityId) values(" + KeyWordId + ",'" + ur.longCodegrSMS.ToString() + "','" + Name.ToString() + "'," + CityId + ")";
            int statusFlag = cc.ExecuteNonQuery(sqlSaveComp);
            if (statusFlag > 0)
            {
                string subject = "", emlBody = "", emlTo = "", backUsrResponse = "", usrMoNo = "", sender = "";
                usrMoNo = ur.usrMobileNo.ToString();
                sender = "myct.in";
                string emlSql = "select email from KeywordDefinition where KeywordName='" + ur.usrKeyWord.ToString() + "'";
                emlTo = Convert.ToString(cc.ExecuteScalar(emlSql));
                if (ur.usrKeyWord == "SAKAL" || ur.usrKeyWord == "NBP" || ur.usrKeyWord == "MATA" || ur.usrKeyWord == "DESHONNATI" || ur.usrKeyWord == "LOKMAT")
                {
                    string paper = "";
                    if (ur.usrKeyWord == "NBP")
                    {
                        paper = "Navbharat";
                    }
                    else
                    {
                        paper = ur.usrKeyWord;
                    }
                    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your news send to ur favret news paper " + paper.ToString() + " " + cc.AddSMS(usrMoNo);
                    subject = "Updated News From " + Name.ToString();
                    emlBody = "\nNEWS: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    ll.sendEmail(emlTo, subject, emlBody);
                    cc.SendMessage1(sender, usrMoNo, backUsrResponse);

                }
                else if (ur.usrKeyWord == "MSS" || ur.usrKeyWord == "Mss" || ur.usrKeyWord == "mss")
                {
                    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                    subject = "Complaint From " + Name.ToString();
                    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    NewSmsResp = "Welcome to Maratha Seva Sangh(www.mhmsm.org) Via:www.myct.in";
                    string passSql = "Select usrPassword from userMAster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    string ppp = cc.ExecuteScalar(passSql);
                    string finalPass = cc.DESDecrypt(ppp);
                    string NewMssSms = "JAY Jijau Welcome by Maratha Seva Sangh(MSS) Update ur profile on www.myct.in Ur paswrd of login " + finalPass.ToString() + " Tell to do the same to all MSS members for comunication ";
                    ur.usrMessageString = NewSmsResp.ToString();
                    ll.sendEmail(emlTo, subject, emlBody);
                    cc.SendMessageTra(sender, usrMoNo, NewMssSms);
                }
                else if (ur.usrKeyWord == "MHMSM" || ur.usrKeyWord == "MhMsm" || ur.usrKeyWord == "mhmsm")
                {
                    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                    subject = "Complaint From " + Name.ToString();
                    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    NewSmsResp = "Welcome to Maharashtra state madhyamik shala shikshetar sanghatnanche mahamandal(www.mhmsm.org) Via:www.myct.in";
                    ur.usrMessageString = NewSmsResp.ToString();
                    ll.sendEmail(emlTo, subject, emlBody);
                    cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                }
                else if (ur.usrKeyWord == "JAIN" || ur.usrKeyWord == "SAHU" || ur.usrKeyWord == "TELI" || ur.usrKeyWord == "JANGID" || ur.usrKeyWord == "JB" || ur.usrKeyWord == "ALLAH" || ur.usrKeyWord == "JM" || ur.usrKeyWord == "MALI" || ur.usrKeyWord == "MSCIT" || ur.usrKeyWord == "OM" || ur.usrKeyWord == "DIDIMA")
                {
                    string MyKey = ur.usrKeyWord.ToString();
                    string MyKeyResp = "";
                    if (MyKey == "JM")
                    {
                        MyKeyResp = "Maheshwari";
                    }
                    else if (MyKey == "JB")
                    {
                        MyKeyResp = "Jai Bhim";
                    }
                    else if (MyKey == "ALLAH")
                    {
                        MyKeyResp = "Muslim";
                    }
                    else if (MyKey == "OM")
                    {
                        MyKeyResp = "BHARAT SWABHIMAN";
                    }
                    else if (MyKey == "SAHU")
                    {
                        MyKeyResp = "SAHU SAMAJ";
                    }
                    else
                    {
                        MyKeyResp = MyKey.ToString();
                    }

                    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                    subject = "Complaint From " + Name.ToString();
                    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    NewSmsResp = "THANKS to join " + MyKeyResp.ToString() + " group in all India mobile directory on www.myct.in to receive imp sms.";
                    ur.usrMessageString = NewSmsResp.ToString();
                    //ll.sendEmail(emlTo, subject, emlBody);
                    status = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
                    if (status == 0)
                    {
                        string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                        string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                        NewSmsResp += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                        cc.SendMessageTra(sender, usrMoNo, NewSmsResp);
                    }
                    else
                    {
                        //string MyKey = "RAVIDASSIA";
                        RegisterByLongCodePINNew(ur, MyKey);
                    }
                }
                else if (ur.usrKeyWord == "RAVIDASSIA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "RAVIDASIYA" || ur.usrKeyWord == "RAVIDASIA" || ur.usrKeyWord == "Ravidassia" || ur.usrKeyWord == "ravidassia")
                {
                    ur.usrKeyWord = "RAVIDASSIA";
                    string groupName = "select GroupValueId from GroupValue where GroupValueName='RAVIDASSIA'";
                    string groupId = cc.ExecuteScalar(groupName);
                    string UpdateGroup = "Insert into UserGroup(UserId,GroupId) values('" + Convert.ToString(ur.usrUserId) + "'," + Convert.ToInt32(groupId) + ")";
                    int groupFlag = 0;
                    string checkPrevGrReg = "select UserId from UserGroup where UserId='" + Convert.ToString(ur.usrUserId) + "' AND GroupId=" + Convert.ToInt32(groupId);
                    string uID = "";
                    uID = cc.ExecuteScalar(checkPrevGrReg);
                    if (uID.ToString() == "")
                    {
                        groupFlag = cc.ExecuteNonQuery(UpdateGroup);
                    }
                    //Thanks to join |A| group all India mobile directory. u r registered on www.myct.in to receive important messages concern to u. Via: www.myct.in
                    string[] nm = Name.Split(' ');
                    backUsrResponse = "THANKS to join RAVIDASSIA group in all India mobile directory on www.myct.in to receive imp sms.";
                    subject = "Complaint From " + Name.ToString();
                    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    string sqlPass = "select usrPassword from userMaster where usrMobileNo='" + usrMoNo.ToString() + "'";
                    string passDec = Convert.ToString(cc.DESDecrypt(cc.ExecuteScalar(sqlPass)));
                    backUsrResponse += "Ur login pswd fr myct.in is " + passDec.ToString() + " Via: www.myct.in";
                    ll.sendEmail(emlTo, subject, emlBody);
                    cc.SendMessageTra(sender, usrMoNo, backUsrResponse);

                }
                else
                {
                    backUsrResponse = "Thank's dear " + Name.ToString() + ", Your complaint send to " + ur.usrKeyWord.ToString() + ". " + cc.AddSMS(usrMoNo);
                    subject = "Complaint From " + Name.ToString();
                    emlBody = "\nCOMPLAINT: " + ur.longCodegrSMS.ToString() + "\n\nFROM: " + Name.ToString() + "\nCity: " + ctnm.ToString() + "\nDistrict:" + dtnm.ToString() + "\nState:" + stnm.ToString();
                    emlBody += "\n\n.............www.myct.in";
                    ll.sendEmail(emlTo, subject, emlBody);
                    cc.SendMessage1(sender, usrMoNo, backUsrResponse);
                }



            }

        }
        string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
        int pkchange = 0;
        pkchange = cc.ExecuteNonQuery(changeFlagSql);
        if (pkchange == 0)
        {
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
        }


    }
    //public bool sendEmailInfo()
    //{
    //    bool flag = false;
    //    try
    //    {

    //        string strmm = "";
    //        string txtTo = "ezeesoftindia@gmail.com";
    //        string txtMessage = Convert.ToString(strmm);
    //        string txtSubject = "";
    //        string txtGmailId = "come2mywebsitedomain";
    //        string txtPassword = "vision2011";

    //        MailSender.SendEmail(txtGmailId + "@gmail.com", txtPassword, txtTo, txtSubject, txtMessage, System.Web.Mail.MailFormat.Text, "");
    //        flag = true;
    //    }
    //    catch (Exception ex)
    //    {

    //    }

    //    return flag;
    //}
    public void SaveBlog(string kwd, string mono, string blog, UserRegistrationBLL ur)
    {

        string sqlSubGrNm = "select SubGroupName from KeywordDefinition where KeywordName='" + kwd.ToString() + "'";
        string subGrNm = Convert.ToString(cc.ExecuteScalar(sqlSubGrNm));
        string sqlGrId = "select GroupValueId from GroupValue where GroupValueName='" + subGrNm.ToString() + "'";
        int GrId = Convert.ToInt32(cc.ExecuteScalar(sqlGrId));
        //string sqlWriter = "select usrFirstName+' '+usrLastName from UserMaster where usrMobileNo='"+mono .ToString ()+"'";
        //string BgWriter = Convert.ToString(cc .ExecuteScalar (sqlWriter));
        string sqlBlogInsert = "insert into tblBlog(bgGrId,BgWriter,Bg) values (" + GrId + ",'" + mono.ToString() + "','" + blog.ToString() + "')";
        int i = cc.ExecuteNonQuery(sqlBlogInsert.ToString());
        if (i >= 0)
        {
            string changeFlagSql = "update test set FlagStatus = 0 where PK=" + Convert.ToInt32(urRegistBll.usrPKval);
            int pkchange = 0;
            pkchange = cc.ExecuteNonQuery(changeFlagSql);
            if (pkchange == 0)
            {
                pkchange = cc.ExecuteNonQuery(changeFlagSql);
            }
        }

    }

}

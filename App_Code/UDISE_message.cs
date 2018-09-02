using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for UDISE_message
/// </summary>
public class UDISE_message
{
    CommonCode cc = new CommonCode();

	public UDISE_message()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public void sendmessage(string leader_userId, string JuniourMno, string RegBoys, string PresentBoys, string RegGirls, string presentGirls, string checkschoolCode)
    {

        try
        {

            string SQL = "select usrLastName,usrMobileNo,usrPassword from usermaster where usrMobileNo='" + JuniourMno + "'";
            SQL = SQL + "select usrMobileNo  from usermaster where usrUserid='" + leader_userId + "'";
            DataSet ds = cc.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // string sqll = "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
                // string leaderMobileNo = cc.ExecuteScalar(sqll);
                string usrLastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                string myMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
               // string myPassword = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
                string passwordMessage;
               string leader_Mobileno = Convert.ToString(ds.Tables[1].Rows[0]["usrMobileNo"]);
                // string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);

                 passwordMessage = "Dear " + usrLastName + " in ur school '" + checkschoolCode + "' total RB*" + RegBoys + "*RG*" + RegGirls + "*  PB*" + PresentBoys + "* PG*" + presentGirls + " Stds r Recorded pl update changes up 7PM." + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.SendMessageLongCodeSMS("UDISE", myMobileNo, passwordMessage, smslength);
                string SQl = "select usrMobileNo ,usrLastName from  UserMaster where  usrUserId in (select friendid from  UserMaster inner join AdminSubMarketingSubOrdinate on AdminSubMarketingSubOrdinate.userid=UserMaster.usruserid where usrmobileno='" + JuniourMno + "')";
                DataSet ds1 = cc.ExecuteDataset(SQl);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    usrLastName = Convert.ToString(ds1.Tables[0].Rows[i]["usrLastName"]);
                    myMobileNo = Convert.ToString(ds1.Tables[0].Rows[i]["usrMobileNo"]);
                    passwordMessage = "Dear " + usrLastName + " in ur school '" + checkschoolCode + "' total RB*" + RegBoys + "*RG*" + RegGirls + "*  PB*" + PresentBoys + "* PG*" + presentGirls + " Stds r Recorded pl update changes up 7PM." + cc.AddSMS(myMobileNo);
                    smslength = passwordMessage.Length;
                    cc.SendMessageLongCodeSMS("UDISE", myMobileNo, passwordMessage, smslength);

                }
            }
                                 

        }
        catch (Exception ex)
        {

        }

    }


    public void sendmessageTo_All( string TotalSchool, string leader_userId, string JuniourMno, string RegBoys, string PresentBoys, string RegGirls, string presentGirls)
    {

        try
        {

            string SQL = "select usrLastName,usrMobileNo,usrPassword from usermaster where usrMobileNo='" + JuniourMno + "'";
            SQL = SQL + "select usrMobileNo  from usermaster where usrUserid='" + leader_userId + "'";
            DataSet ds = cc.ExecuteDataset(SQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // string sqll = "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
                // string leaderMobileNo = cc.ExecuteScalar(sqll);
                string usrLastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
                string myMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
                // string myPassword = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
                string passwordMessage;
                string leader_Mobileno = Convert.ToString(ds.Tables[1].Rows[0]["usrMobileNo"]);
                passwordMessage = "Dear " + usrLastName + " Sir in " + TotalSchool + " schools Under U total RB*" + RegBoys + "*RG*" + RegGirls + "*PB*" + PresentBoys + "*PG*" + presentGirls + " Stds r Recorded today" + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                //    cc.SendMessageLongCodeSMS("UDISE", myMobileNo, passwordMessage, smslength);  

                string SQl = "select usrMobileNo ,usrLastName from  UserMaster where  usrUserId in (select friendid from  UserMaster inner join AdminSubMarketingSubOrdinate on AdminSubMarketingSubOrdinate.userid=UserMaster.usruserid where usrmobileno='" + JuniourMno + "')";
                DataSet ds1 = cc.ExecuteDataset(SQl);
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    usrLastName = Convert.ToString(ds1.Tables[0].Rows[i]["usrLastName"]);
                    myMobileNo = Convert.ToString(ds1.Tables[0].Rows[i]["usrMobileNo"]);
                    passwordMessage = "Dear " + usrLastName + " Sir/Mam in " + TotalSchool + " schools Under U total RB*" + RegBoys + "*RG*" + RegGirls + "*PB*" + PresentBoys + "*PG*" + presentGirls + " Stds r Recorded today" + cc.AddSMS(myMobileNo);
                    smslength = passwordMessage.Length;
                    //     cc.SendMessageLongCodeSMS("UDISE", myMobileNo, passwordMessage, smslength);

                }
            }


        }
        catch (Exception ex)
        {

        }

    }


}

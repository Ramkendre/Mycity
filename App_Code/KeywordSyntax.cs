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
/// Summary description for KeywordSyntax
/// </summary>
public class KeywordSyntax
{
    CommonCode cc = new CommonCode();
    string syntax = "";
    int smslength;
    public KeywordSyntax()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SendKeywordSyntax(string keywords, string mobile)
    {
        if (keywords == "HEAD" || keywords == "MAIN")
        {
            syntax = "" + keywords + "*<mobileno>*Name*<Name>*Add*<Address>*Pin*<Pincode>*Email*<EmailId>*Uid*<aadhar card no.>*Vid*<voting card>*dob/age*<dob/age>*job<job> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "LEADER" || keywords == "WORKER" || keywords == "JUNIOR")
        {
            syntax = "" + keywords + "*(mobileno)*(Name)*(Address)*(Pincode)*(EmailId) via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "FAMILY" || keywords == "MEMBER")
        {
            syntax = "" + keywords + "*<Head MobileNo>*<relation>*<mobileno>*Name*<Name>*Add*<Address>*Pin*<Pincode>*Uid*<aadhar card no.>*Vid*<voting card>*dob/age*<dob/age>*job<job> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "REG" || keywords == "OM" || keywords == "NCP" || keywords == "MPSC" || keywords == "TTD" || keywords == "ANNA" || keywords == "RAVIDASSIA")
        {
            syntax = "" + keywords + "*<Head MobileNo>*<relation>*<mobileno>*Name*<Name>*Add*<Address>*Pin*<Pincode>*Uid*<aadhar card no.>*Vid*<voting card>*dob/age*<dob/age>*job<job> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "SET-GROUP0-MISSED-CALL-SMS-TO" || keywords == "SET-GROUP1-MISSED-CALL-SMS-TO" || keywords == "SET-GROUP2-MISSED-CALL-SMS-To" || keywords == "SET-GROUP3-MISSED-CALL-SMS-To" || keywords == "SET-GROUP4-MISSED-CALL-SMS-To" || keywords == "SET-GROUP5-MISSED-CALL-SMS-To" || keywords == "SET-GROUP6-MISSED-CALL-SMS-To" || keywords == "SET-GROUP7-MISSED-CALL-SMS-To" || keywords == "SET-GROUP8-MISSED-CALL-SMS-To" || keywords == "SET-GROUP9-MISSED-CALL-SMS-To")
        {
            syntax = "" + keywords + "* message via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "COPY")
        {
            syntax = "Copy <GroupName> <MobileNumber> <GroupName> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "REMOVE")
        {
            syntax = "Remove <mobilenumber> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "BLOG")
        {
            syntax = "Blog <GroupName> <Message> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "NAME")
        {
            syntax = "Name <Fullname> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }

        else if (keywords == "BALANCE")
        {
            syntax = "Balance <Transactional-Balance> <Promotional-Balance> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "DND")
        {
            syntax = "";
        } 
        else if (keywords == "CMNO")
        {
            syntax = "Cmno <Newmobileno> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "ADDRESS" || keywords == "ADD")
        {
            syntax = "Add <ur address> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "DOB")
        {
            syntax = "Dob <ur dateofbirth> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "EMAIL" || keywords == "@" || keywords == "E-MAIL")
        {
            syntax = "" + keywords + " <ur email id> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "AREA" || keywords == "VILLAGE")
        {
            syntax = "" + keywords + " <name-of-area> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "PIN" || keywords == "PINCODE")
        {
            syntax = "" + keywords + "Pin <pincode> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "MSEB")
        {
            syntax = "Mseb <msebnumber> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "UID")
        {
            syntax = "UID <aadhar card number> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "VID")
        {
            syntax = "VID <voting card number> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "JOB")
        {
            syntax = "Job <Name of job> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "PAN")
        {
            syntax = "Pan <pancard-number> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "DLN")
        {
            syntax = "Dln <driving-licence-number> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "MOBILE2")
        {
            syntax = "Mobile2 <alternate-mobilenumber> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }

        else if (keywords == "PASSWORD")
        {
            syntax = "Password <new-password> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }

       
        else if (keywords == "REPORT")
        {
            syntax = "Report * <Ur report message> via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);


        }
        else if (keywords == "CHANELSMS")
        {
            syntax = "Chanelsms * <message> via  www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);


        }

        else if (keywords == "NSSPUNE")
        {
            syntax = "" + keywords + "*ur Fname Lname*ur college name followed by ur detail address * ur 6 digit PIN code. Note * is must at 3 proper places. Send sms to 9243100142 www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "UDISE")
        {
            syntax = "" + keywords + "*ur Fname Lname*ur college name followed by ur detail address * ur 6 digit PIN code. Note * is must at 3 proper places. Send sms to 9243100142 www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "MDM")
        {
            syntax = "" + keywords + "*1st std*--*2nd std*--*3rd std*--*4th std**--*5th std*--6th std*--*7th std*--*8th std*--9th std*--*10th std*-- www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "TEACHER")
        {
            syntax = "" + keywords + "*Mob No*First n Last Name*Dise Sch. Code*class*section Send this sms frm HM mob no on 9243100142 to reg class teacher fr given class & sec www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "HM")
        {
            syntax = "" + keywords + "*Mob No*First n Last Name*11 digit Dise Sch. Code Send this sms frm Extension Officer mobile on 9243100142 to reg Head Master fr given Sch.Code www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "DAR")
        {
            syntax = "" + keywords + "*5*A*RB*45*RG*25*PB*43*PG*22 Send as above Daily Attendance Report(DAR) on 9243100142 of ur class. Above Ex is of Sec A of 5th class. Via www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
            
        }
        else if (keywords == "CAR")
        {
            syntax = "" + keywords + "*5*A*RB*45*RG*25*PB*43*PG*22 Send as above Absent Teacher DAR from HM Mob. on 9243100142. Above Ex is of Sec A of 5th class. www.myct.in";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);

        }
        else if (keywords == "STAFF")
        {
            syntax = "" + keywords + "*RM*xx*RF*xx*PM*xx*PF*xx";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }
        else if (keywords == "REPLACEJR")
        {
            syntax = "" + keywords + "*<Old Teachar Mob No>*<New Teacher Mob No>*FirstName LastName";
            smslength = syntax.Length;
            cc.SendMessageLongCodeSMS("mobile/longcode", mobile, syntax, smslength);
        }


    }
}

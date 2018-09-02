using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for MyctEvent
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MyctEvent : System.Web.Services.WebService
{
    int k = 0;
    CommonCode cc = new CommonCode();
    public MyctEvent()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description = "Add Data Create Event")]
    public int AddEvent(string IMEINo, string SimNo, string NameEvent, string DateofMessage, string time, string Location, string SocialDscrip, string Ralative, string Relation, string Visit, string SendMgs, string DateFormat, string CreatedBy, string UserId)
    {
        try
        {
            if (IMEINo == "0" && SimNo == "0")
            {
                string Sql = "Insert into CreateMyctEvent(usrUserId,EventName,DateofMessage,time1,Location,SocialDscrip,Ralative,Relation,Visit,SendMgs,EntryDate,Createby,IMEINo,SIMNo) " +
                             " values('" + UserId + "','" + NameEvent + "','" + Convert.ToDateTime(DateofMessage) + "','" + time + "','" + Location + "','" + SocialDscrip + "','" + Ralative + "','" + Relation + "','" + Visit + "','" + SendMgs + "','" + Convert.ToDateTime(DateFormat) + "','" + CreatedBy + "','" + IMEINo + "','" + SimNo + "')";
                k = cc.ExecuteNonQuery(Sql);
                if (k == 1)
                {

                }
            }
            else
            {
                string mobileNo = verifymobile(IMEINo, SimNo);
                if (!String.IsNullOrEmpty(mobileNo))
                {
                    string sqlget = "select usrUserid from usermaster where usrMobileNo='" + mobileNo + "'";
                    string getuserID = cc.ExecuteScalar(sqlget);
                    if (!String.IsNullOrEmpty(getuserID))
                    {
                        string Sql = "Insert into CreateMyctEvent(usrUserId,EventName,DateofMessage,time1,Location,SocialDscrip,Ralative,Relation,Visit,SendMgs,EntryDate,Createby,IMEINo,SIMNo) " +
                                 " values('" + UserId + "','" + NameEvent + "','" + DateofMessage + "','" + time + "','" + Location + "','" + SocialDscrip + "','" + Ralative + "','" + Relation + "','" + Visit + "','" + SendMgs + "','" + DateFormat + "','" + CreatedBy + "','" + IMEINo + "','" + SimNo + "')";
                        k = cc.ExecuteNonQuery(Sql);
                        if (k == 1)
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
        return k;
    }


    public int UpdateEvent(string IMEINo, string SimNo, string NameEvent, string DateofMessage, string time, string Location, string SocialDscrip, string Ralative, string Relation, string Visit, string SendMgs, string DateFormat, string CreatedBy, string UserId, string Id)
    {
        try
        {
            if (IMEINo == "0" && SimNo == "0")
            {
                string Sql = "Insert into CreateMyctEvent(usrUserId,EventName,DateofMessage,time1,Location,SocialDscrip,Ralative,Relation,Visit,SendMgs,EntryDate,Createby,IMEINo,SIMNo) " +
                             " values('" + UserId + "','" + NameEvent + "','" + Convert.ToDateTime(DateofMessage) + "','" + time + "','" + Location + "','" + SocialDscrip + "','" + Ralative + "','" + Relation + "','" + Visit + "','" + SendMgs + "','" + Convert.ToDateTime(DateFormat) + "','" + CreatedBy + "','" + IMEINo + "','" + SimNo + "')";
                k = cc.ExecuteNonQuery(Sql);
                if (k == 1)
                {

                }
            }
            else
            {
                string mobileNo = verifymobile(IMEINo, SimNo);
                if (!String.IsNullOrEmpty(mobileNo))
                {
                    string sqlget = "select usrUserid from usermaster where usrMobileNo='" + mobileNo + "'";
                    string getuserID = cc.ExecuteScalar(sqlget);
                    if (!String.IsNullOrEmpty(getuserID))
                    {
                        string Sql = "Insert into CreateMyctEvent(usrUserId,EventName,DateofMessage,time1,Location,SocialDscrip,Ralative,Relation,Visit,SendMgs,EntryDate,Createby,IMEINo,SIMNo) " +
                                 " values('" + UserId + "','" + NameEvent + "','" + DateofMessage + "','" + time + "','" + Location + "','" + SocialDscrip + "','" + Ralative + "','" + Relation + "','" + Visit + "','" + SendMgs + "','" + DateFormat + "','" + CreatedBy + "','" + IMEINo + "','" + SimNo + "')";
                        k = cc.ExecuteNonQuery(Sql);
                        if (k == 1)
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
        return k;
    }
    //------------------------------------------Verify the Mobile no---------------------------------------------------------------------------

    #region verifymobile
    public string verifymobile(string IMEINo, string SimNo)
    {
        string mobileno = "";
        try
        {
            string Sql = "Select mobileNo from EzeeDrugsAppDetail where strDevId='" + IMEINo + "' and strSimSerialNo='" + SimNo + "'";
            mobileno = Convert.ToString(cc.ExecuteScalar(Sql));
        }
        catch (Exception ex)
        {

        }
        return mobileno;
    }
    #endregion verifymobile


}


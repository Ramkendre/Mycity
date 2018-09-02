using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MarketingAdmin_SendMsg : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void Send_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select Id,Name,Msg, TotalMsg, Sent, Balance,Days,StartDate, DayRemaining from SMSPushing ";
            DataSet dsmsg = cc.ExecuteDataset(Sql);
            foreach (DataRow drmsg in dsmsg.Tables[0].Rows)
            {
                string msgId=Convert.ToString(drmsg["Id"]);
                Sql = "Select CityId from smsPushingCity where smsPushingId=" + msgId + " ";
                Sql = Sql + "Select GroupId from smsPushingGroup where smsPushingId=" + msgId + " ";
                DataSet dsCri = cc.ExecuteDataset(Sql);
                string City = "", Group = "";
                foreach (DataRow dr in dsCri.Tables[0].Rows)
                {
                    City = City + ", " + Convert.ToString(dr["CityId"]);
                }
                City = City.Substring(1);
                foreach (DataRow dr in dsCri.Tables[1].Rows)
                {
                    Group  = Group  + ", " + Convert.ToString(dr["GroupId"]);
                }
                Group = Group.Substring(1);
                try
                {
                    string Name = Convert.ToString(drmsg["Name"]);
                    string Msg = Convert.ToString(drmsg["Msg"]);

                    int TotalMsg = Convert.ToInt32(drmsg["TotalMsg"]);
                    int Sent = Convert.ToInt32(drmsg["Sent"]);
                    int Balance = TotalMsg - Sent;
                    DateTime dt = Convert.ToDateTime(drmsg["StartDate"]);
                    int Days = Convert.ToInt32(drmsg["Days"]);
                    TimeSpan ts = System.DateTime.Now - dt;
                    int DayRemaining = Days - ts.Days;
                    int NoOfMsgPerDay = TotalMsg / Days;
                    int hastoSent = ts.Days  * NoOfMsgPerDay;
                    int RemainingMsg = Balance - hastoSent;
                    int Count = 0;
                    if (hastoSent > RemainingMsg)
                    {
                        hastoSent = RemainingMsg;
                    }
                    if (hastoSent > 0)
                    {

                        Sql = "Select usrmobileno from UserMaster where usrCityId in(" + City + ") " +
                        " and usrUserId in(Select Userid from UserGroup where GroupId in(" + Group + ")) And " +
                        " usrMobileNo not in( Select MobileNo from SMSPushedMobile where SMSPushingId=" + msgId + ")";

                        DataSet dsMobile = cc.ExecuteDataset(Sql);

                        if (dsMobile.Tables[0].Rows.Count < hastoSent)
                        {
                            Sql = "";
                            int flag = 0;
                            try
                            {
                                for (int i = 0; i < hastoSent; i++)
                                {
                                    flag = i;
                                    string MobileNo = Convert.ToString(dsMobile.Tables[0].Rows[i]["usrMobileno"]);
                                    //Send Message to MobileNo
                                    bool flag1 = cc.SendMessage1(Name , MobileNo, Msg );
                                    Count++;
                                    Sql = Sql + " Insert into smsStoring(SenderMobile,ReceiverMobile, Msg,Date) Values " +
                                          " ('" + Name + "','" + MobileNo + "','" + Msg + "','" + System.DateTime.Now + "') ";

                                    Sql = Sql + " Insert into SMSPushedMobile(SMSPushingId, MobileNo,SendDate) Values " +
                                        " (" + msgId + ",'" + MobileNo + "','" + System.DateTime.Now + "') ";

                                }
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    cc.ExecuteNonQuery("Delete from SMSPushedMobile where SMSPushingId=" + msgId + "");
                                    string Sql1 = "Select usrmobileno from UserMaster where usrCityId in(" + City + ") " +
                                        " and usrUserId in(Select Userid from UserGroup where GroupId in(" + Group + ")) And " +
                                        " usrMobileNo not in( Select MobileNo from SMSPushedMobile where SMSPushingId=" + msgId + ")";

                                    dsMobile = cc.ExecuteDataset(Sql1);


                                    for (int ii=0; flag < hastoSent; flag++,ii++)
                                    {
                                        string MobileNo = Convert.ToString(dsMobile.Tables[0].Rows[ii]["usrMobileno"]);
                                        //Send Message to MobileNo
                                        cc.SendMessage1(Name, MobileNo, Msg);
                                        Count++;
                                        Sql = Sql + " Insert into smsStoring(SenderMobile,ReceiverMobile, Msg,Date) Values " +
                                              " ('" + Name + "','" + MobileNo + "','" + Msg + "','" + System.DateTime.Now + "') ";

                                        Sql = Sql + " Insert into SMSPushedMobile(SMSPushingId, MobileNo,SendDate) Values " +
                                            " (" + msgId + ",'" + MobileNo + "','" + System.DateTime.Now + "') ";

                                    }
                                }
                                catch (Exception ex1)
                                { }
                            }
                        }
                        else
                        {
                            Sql = "";
                            for (int i = 0; i < hastoSent; i++)
                            {
                                string MobileNo= Convert.ToString(dsMobile.Tables[0].Rows[i]["usrMobileno"]);
                                //Send Message to MobileNo
                                cc.SendMessage1(Name, MobileNo, Msg);
                                Count++;
                                Sql = Sql + " Insert into smsStoring(SenderMobile,ReceiverMobile, Msg,Date) Values " +
                                      " ('"+Name+"','"+MobileNo+"','"+Msg +"','"+System.DateTime.Now+"') ";

                                Sql = Sql + " Insert into SMSPushedMobile(SMSPushingId, MobileNo,SendDate) Values " +
                                    " ("+msgId+",'"+MobileNo+"','"+System.DateTime.Now+"') ";
                               
                            }
                        }
                    }

                    Sql =Sql + "Update SMSPushing set Sent=Sent+" + Count + ", Balance=Balance-" + Count + ", DayRemaining=" + DayRemaining + " " +
                        " where Id =" + msgId + "";
                    cc.ExecuteNonQuery(Sql);

                }
                catch (Exception ex)
                {
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}

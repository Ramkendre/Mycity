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

public partial class MarketingAdmin_DataReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string roleid = "";
    string sql = "";
    string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DateTime date = DateTime.Now;
            string todaysDate = date.ToShortDateString();

            string userid1 = Convert.ToString(Session["MarketingUser"]);
            string record = "select roleid from AdminSubMarketingSubUser where friendid='" + userid1 + "'";
            string roleid = cc.ExecuteScalar(record);
            if (roleid == "2")
            {
                string sql = "select * from CELevel1 where sender_mobileno='" + userid1 + "' and send_date='" + todaysDate + "' ";
                DataSet ds = cc.ExecuteDataset(sql);
                userid = Convert.ToString(Session["MarketingUser"]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdisplayshow();
                }
                else
                {
                    GetRecord();
                    gvdisplayshow();
                }
            }
            else if (roleid == "3")
            {
                userid1 = Convert.ToString(Session["MarketingUser"]);
                record = "select userid from AdminSubMarketingSubUser where friendid='" + userid1 + "'";
                userid = cc.ExecuteScalar(record);
                string sql = "select * from CELevel1 where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "' ";
                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdisplayshow();
                }
                else
                {
                    GetRecord();
                    gvdisplayshow();
                }

            }
            else if (roleid == "4")
            {
                userid1 = Convert.ToString(Session["MarketingUser"]);
                record = "select reference_id3 from AdminSubMarketingSubUser where friendid='" + userid1 + "'";
                userid = cc.ExecuteScalar(record);
                string sql = "select * from CELevel1 where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "' ";
                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdisplayshow();
                }
                else
                {
                    GetRecord();
                    gvdisplayshow();
                }
            }
            else if (roleid == "5")
            {
                userid1 = Convert.ToString(Session["MarketingUser"]);
                record = "select reference_id3 from AdminSubMarketingSubUser where friendid='" + userid1 + "'";
                userid = cc.ExecuteScalar(record);
                string sql = "select * from CELevel1 where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "' ";
                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdisplayshow();
                }
                else
                {
                    GetRecord();
                    gvdisplayshow();
                }
            }
            else if (roleid == "6")
            {
                userid1 = Convert.ToString(Session["MarketingUser"]);
                record = "select reference_id3 from AdminSubMarketingSubUser where friendid='" + userid1 + "'";
                userid = cc.ExecuteScalar(record);
                string sql = "select * from CELevel1 where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "' ";
                DataSet ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvdisplayshow();
                }
                else
                {
                    GetRecord();
                    gvdisplayshow();
                }
            }


        }
        catch (Exception ex)
        {
        }


    }
    private void gvdisplayshow()
    {
       // DateTime date = DateTime.Now;
        //string todaysDate = date.ToShortDateString();
        string date = System.DateTime.Now.ToString();
        //string todaysDate = date.ToShortDateString();
        string todaysDate = cc.DTInsert_Local(date);
        string UserName = Convert.ToString(Session["MarketingUser"]);
        sql = "select roleid from AdminSubMarketingSubUser where friendid='" + UserName + "'";
        roleid = cc.ExecuteScalar(sql);


        if (roleid == "2")
        {   

            
            sql = "select top 1 p3,p5,p7,send_date from CELevel1 where sender_mobileno='" + UserName + "' and send_date='" + todaysDate + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            gvdisplay.DataSource = ds.Tables[0];
            gvdisplay.DataBind();
            foreach (GridViewRow row in gvdisplay.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[3].Text = Data;
            }

        }
        else if (roleid == "3")
        {
            
            sql = "select top 1 p3,p5,p7,send_date from SELevel2 where sender_mobileno='" + UserName + "' and send_date='" + todaysDate + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            gvdisplay.DataSource = ds.Tables[0];
            gvdisplay.DataBind();
            foreach (GridViewRow row in gvdisplay.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[3].Text = Data;
            }


        }
        else if (roleid == "4")
        {
            
            sql = "select top 1 p3,p5,p7,send_date from EELevel3 where sender_mobileno='" + UserName + "' and send_date='" + todaysDate + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            gvdisplay.DataSource = ds.Tables[0];
            gvdisplay.DataBind();
            foreach (GridViewRow row in gvdisplay.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[3].Text = Data;
            }


        }
        else if (roleid == "5")
        {
            
            sql = "select top 1 p3,p5,p7,send_date from DataCollection where ref_id='" + UserName + "' and send_date='" + todaysDate + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            gvdisplay.DataSource = ds.Tables[0];
            gvdisplay.DataBind();
            foreach (GridViewRow row in gvdisplay.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[3].Text = Data;
            }


        }
        else
        { }


    }

    private void GetRecord()
    {
        string sql20 = "";
        string mobileno = "";
        string messagesend = "";
        string id = "";

        string date = System.DateTime.Now.ToString();
        //string todaysDate = date.ToShortDateString();
        string todaysDate = cc.DTInsert_Local(date);
        int r3 = 0, r5 = 0, r7 = 0;
        string senderid = "myct.in";

        string sq1 = "select friendid from AdminSubMarketingSubUser where userid='" + userid + "'";
        DataSet ds = cc.ExecuteDataset(sq1);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            r3 = 0;
            r5 = 0;
            r7 = 0;
            string f1 = Convert.ToString(dr["friendid"]);
            string sql2 = "select friendid from AdminSubMarketingSubUser where userid='" + f1 + "'";
            DataSet ds2 = cc.ExecuteDataset(sql2);
            foreach (DataRow dr2 in ds2.Tables[0].Rows)
            {
                r3 = 0;
                r5 = 0;
                r7 = 0;
                string f2 = Convert.ToString(dr2["friendid"]);
                string sql3 = "select friendid from AdminSubMarketingSubUser where userid='" + f2 + "'";
                DataSet ds3 = cc.ExecuteDataset(sql3);
                foreach (DataRow dr3 in ds3.Tables[0].Rows)
                {
                    r3 = 0;
                    r5 = 0;
                    r7 = 0;
                    string f3 = Convert.ToString(dr3["friendid"]);
                    string sql4 = "select friendid from AdminSubMarketingSubUser where userid='" + f3 + "'";
                    DataSet ds4 = cc.ExecuteDataset(sql4);
                    foreach (DataRow dr4 in ds4.Tables[0].Rows)
                    {
                        string f4 = Convert.ToString(dr4["friendid"]);
                        string sql6 = "select * from DataCollection where sender_mobileno='" + f4 + "' and send_date='" + todaysDate + "'";
                        DataSet ds6 = cc.ExecuteDataset(sql6);
                        foreach (DataRow dr6 in ds6.Tables[0].Rows)
                        {
                            string sql5 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7 from DataCollection where sender_mobileno='" + f4 + "' and ref_id='" + f3 + "' and send_date='" + todaysDate + "'";
                            DataSet ds5 = cc.ExecuteDataset(sql5);
                            foreach (DataRow dr5 in ds5.Tables[0].Rows)
                            {
                                int p3 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P3"]);
                                int p5 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P5"]);
                                int p7 = Convert.ToInt32(ds5.Tables[0].Rows[0]["P7"]);
                                r3 = r3 + p3;
                                r5 = r5 + p5;
                                r7 = r7 + p7;


                            }


                        }



                    }

                    string sql7 = "insert into AELevel4(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f3 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + f2 + "','" + todaysDate + "')";
                    int a = cc.ExecuteNonQuery(sql7);
                    sql20 = "select usrMobileNo from usermaster where usrUserid='" + f3 + "'";
                    mobileno = cc.ExecuteScalar(sql20);
                    messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
                    //cc.SendMessageTra(senderid, mobileno, messagesend);

                    string sql131 = "select * from DataCollection where sender_mobileno='" + f3 + "' and send_date='" + todaysDate + "'";
                    DataSet ds141 = cc.ExecuteDataset(sql131);
                    foreach (DataRow dr14 in ds141.Tables[0].Rows)
                    {
                        int p3 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds141.Tables[0].Rows[0]["P7"]);

                        string sql141 = "insert into AELevel4(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f3 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + f2 + "','" + todaysDate + "')";
                        int aa1 = cc.ExecuteNonQuery(sql141);

                    }

                }
                ////////////////Finish calculation of JE and insert into AE or End of JE/////////////////////

                string sql19 = "select * from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds19 = cc.ExecuteDataset(sql19);
                foreach (DataRow dr19 in ds19.Tables[0].Rows)
                {
                    id = Convert.ToString(dr19["sender_mobileno"]);
                    string sql8 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from AELevel4 where ref_id='" + f2 + "' and send_date='" + todaysDate + "'";
                    DataSet ds7 = cc.ExecuteDataset(sql8);
                    foreach (DataRow dr7 in ds7.Tables[0].Rows)
                    {
                        r3 = 0;
                        r5 = 0;
                        r7 = 0;
                        int p3 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P3"]);
                        int p5 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P5"]);
                        int p7 = Convert.ToInt32(ds7.Tables[0].Rows[0]["P7"]);
                        r3 = r3 + p3;
                        r5 = r5 + p5;
                        r7 = r7 + p7;
                    }

                }

                string sql10 = "insert into EELevel3(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f2 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + f1 + "','" + todaysDate + "')";
                int c = cc.ExecuteNonQuery(sql10);
                sql20 = "select usrMobileNo from usermaster where usrUserid='" + f2 + "'";
                mobileno = cc.ExecuteScalar(sql20);
                messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
                //cc.SendMessageTra(senderid, mobileno, messagesend);
                string sql1311 = "select * from DataCollection where sender_mobileno='" + f2 + "' and send_date='" + todaysDate + "'";
                DataSet ds1411 = cc.ExecuteDataset(sql1311);
                foreach (DataRow dr141 in ds1411.Tables[0].Rows)
                {
                    int p3 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds1411.Tables[0].Rows[0]["P7"]);

                    string sql141 = "insert into EELevel3(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f2 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + f1 + "','" + todaysDate + "')";
                    int aa1 = cc.ExecuteNonQuery(sql141);
                }



            }
            ///////////////////End of EE//////////////////////////////
            string sql12 = "select * from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds13 = cc.ExecuteDataset(sql12);
            foreach (DataRow dr12 in ds13.Tables[0].Rows)
            {
                id = Convert.ToString(dr12["sender_mobileno"]);
                string sql11 = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from EELevel3 where ref_id='" + f1 + "' and send_date='" + todaysDate + "'";
                DataSet ds11 = cc.ExecuteDataset(sql11);
                foreach (DataRow dr11 in ds11.Tables[0].Rows)
                {
                    r3 = 0;
                    r5 = 0;
                    r7 = 0;
                    int p3 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P3"]);
                    int p5 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P5"]);
                    int p7 = Convert.ToInt32(ds11.Tables[0].Rows[0]["P7"]);
                    r3 = r3 + p3;
                    r5 = r5 + p5;
                    r7 = r7 + p7;
                }
            }

            string sql9 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f1 + "','" + r3 + "','" + r5 + "','" + r7 + "','" + userid + "','" + todaysDate + "')";
            int d = cc.ExecuteNonQuery(sql9);
            sql20 = "select usrMobileNo from usermaster where usrUserid='" + f1 + "'";
            mobileno = cc.ExecuteScalar(sql20);
            messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
            //cc.SendMessageTra(senderid, mobileno, messagesend);
            string sql13112 = "select * from DataCollection where sender_mobileno='" + f1 + "' and send_date='" + todaysDate + "'";
            DataSet ds14112 = cc.ExecuteDataset(sql13112);
            foreach (DataRow dr141 in ds14112.Tables[0].Rows)
            {
                int p3 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P3"]);
                int p5 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P5"]);
                int p7 = Convert.ToInt32(ds14112.Tables[0].Rows[0]["P7"]);

                string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + f1 + "','" + p3 + "','" + p5 + "','" + p7 + "','" + userid + "','" + todaysDate + "')";
                int aa1 = cc.ExecuteNonQuery(sql141);

            }

        }
        string sql16 = "select * from DataCollection where sender_mobileno='" + userid + "' and send_date='" + todaysDate + "'";
        DataSet ds16 = cc.ExecuteDataset(sql16);
        foreach (DataRow dr16 in ds16.Tables[0].Rows)
        {
            int p3 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P3"]);
            int p5 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P5"]);
            int p7 = Convert.ToInt32(ds16.Tables[0].Rows[0]["P7"]);
            string sql141 = "insert into SELevel2(sender_mobileno,P3,P5,P7,ref_id,send_date)values('" + userid + "','" + p3 + "','" + p5 + "','" + p7 + "','" + userid + "','" + todaysDate + "')";
            int aa1 = cc.ExecuteNonQuery(sql141);


        }

        /////////////////////////////////End of SE//////////////////////

        string sql13 = "select * from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
        DataSet ds14 = cc.ExecuteDataset(sql13);
        foreach (DataRow dr13 in ds14.Tables[0].Rows)
        {
            id = Convert.ToString(dr13["sender_mobileno"]);
            string sqlfinal = "select Sum(P3) as P3,Sum(P5) as P5, Sum(P7) as P7  from SELevel2 where ref_id='" + userid + "' and send_date='" + todaysDate + "'";
            DataSet dsfinal = cc.ExecuteDataset(sqlfinal);
            int p3 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P3"]);
            int p5 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P5"]);
            int p7 = Convert.ToInt32(dsfinal.Tables[0].Rows[0]["P7"]);
            r3 = p3;
            r5 = p5;
            r7 = p7;

        }

        string sql14 = "insert into CELevel1(sender_mobileno,P3,P5,P7,send_date)values('" + userid + "','" + r3 + "','" + r5 + "','" + r7 + "','" + todaysDate + "')";
        int finaltotal = cc.ExecuteNonQuery(sql14);
        sql20 = "select usrMobileNo from usermaster where usrUserid='" + userid + "'";
        mobileno = cc.ExecuteScalar(sql20);
        messagesend = "Dear user calulation is P3='" + r3 + "',P5='" + r5 + "',P7='" + r7 + "' thanks via www.myct.in";
        cc.SendMessageTra(senderid, mobileno, messagesend);




    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.ApplicationBlocks.Data;

public partial class MarketingAdmin_CSVUpload : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (csvUpload.HasFile)
        {
            string path = "";
            path = Server.MapPath("File_Upload");
            path = path + "\\" + csvUpload.FileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                csvUpload.SaveAs(path);
            }
            else
            {
                csvUpload.SaveAs(path);
            }
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            do
            {
                line = sr.ReadLine();
                string mno = "", fnm = "", lnm = "", pin = "", gr = "", ct = "";
                if (line != null)
                {
                    string[] ArrLine = line.Split(',');
                    mno = ArrLine[0].ToString();
                    fnm = ArrLine[1].ToString();
                    lnm = ArrLine[2].ToString();
                    pin = ArrLine[3].ToString();
                    gr = ArrLine[4].ToString();
                    ct = ArrLine[5].ToString();
                    RegisterNew(mno, fnm, lnm, pin, gr, ct);
                }

            } while (line != null);



        }

    }
    public int BLLIsExistUserRegistrationInitial(string mno)
    {
        //  cn = new SqlConnection(con.Connection.ToString());

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int Check = 1;

        try
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrMobileNo", mno);
            par[1] = new SqlParameter("@status", 11);
            par[1].Direction = ParameterDirection.Output;

            Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
            Check = (int)par[1].Value;

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return Check;
    }

    public DataSet ExecuteDataset(string sqlQuery)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();

        try
        {
            con.Open();
            ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sqlQuery);

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return ds;
    }
    public int ExecuteNonQuery(string Sql)
    {
        int flag = 0;
        SqlConnection cons4 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {

            flag = SqlHelper.ExecuteNonQuery(cons4, CommandType.Text, Sql);

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            cons4.Close();
        }

        return flag;
    }

    public string ExecuteScalar(string Sql)
    {
        string Data = "";
        SqlConnection cons3 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {

            Data = Convert.ToString(SqlHelper.ExecuteScalar(cons3, CommandType.Text, Sql));

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            cons3.Close();
        }

        return Data;
    }

    public bool RegisterNew(string mno, string fnm, string lnm, string pin, string gr, string ct)
    {
        int status = 1;
        bool Check = false;
        //cqc.usrAltMobileNo=mno ;      
        try
        {
            string usrmoNo = textBox2.Text.ToString();
            cqc.usrMobileNo = usrmoNo.ToString();
            status = BLLIsExistUserRegistrationInitial(usrmoNo);
            if (status == 0)
            {
                status = BLLIsExistUserRegistrationInitial(mno);
                if (status == 0)
                {

                    //DataTable dt1 = new DataTable();
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + usrmoNo.ToString() + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql);
                    //dt1 = ds.Tables[0];
                    string userId;
                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + mno.ToString() + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = ExecuteDataset(sql1);
                    string FriId;
                    string FriName;
                    string[] RgArr = gr.Split('&');
                    if (RgArr.Length > 0)
                    {
                        for (int s = 0; s < RgArr.Length; s++)
                        {
                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {
                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                                cqc.frnrelGroup = RgArr[s].ToString();

                            }

                            status = cqc.BLLInsertUserFriendRelative(cqc);


                        }


                    }
                    else
                    {

                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            cqc.frnrelFriendId = FriId;
                            cqc.frnrelFrnRelName = FriName;
                            cqc.frnrelRelation = "friend";
                            cqc.frnrelGroup = "1";

                        }

                        status = cqc.BLLInsertUserFriendRelative(cqc);

                    }
                    //if (status > 0)
                    //{
                    //    string SendTo = mno.ToString();
                    //    string sendFrom = usrmoNo.ToString();
                    //    string message = "I " + usrName + "(" + sendFrom.ToString() + ") added u in come2myCity.com to send free SMS." + cc.AdvMessage();
                    //    //string passwordMessage = "I " + usrName + "(" + sendFrom.ToString() + ") of Abhinav B.Ed college Chikhli,Dist-Buldhana,added u as a Frnd 2 send free SMS frm come2mycity.com. For B.Ed admission help pl call me";
                    //    cc.SendMessage1(sendFrom, SendTo, message);

                    //}
                    Check = true;
                }
                else
                {

                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql3);
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
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                        //ur.frnrelFrnRelName = usrName;
                        //ur.frnrelRelation = "friend";
                        //ur.frnrelGroup = "1";

                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = ExecuteScalar(sqlquery);

                    cqc.usrUserId = System.Guid.NewGuid().ToString();
                    cqc.usrAddress = Convert.ToString(ct);
                    cqc.usrMobileNo = mno.ToString();

                    cqc.usrFirstName = fnm.ToString();
                    cqc.usrLastName = lnm.ToString();
                    cqc.usrPIN = pin.ToString();

                    Random rnd = new Random();
                    cqc.usrPasssword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = cqc.DALInsertUserRegistrationInitial(cqc);
                    if (status > 0)
                    {

                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = ExecuteDataset(sql1);
                        //dt1 = ds.Tables[0];
                        string FriId;
                        string FriName;
                        string[] RgArr = gr.Split('&');
                        if (RgArr.Length > 0)
                        {
                            for (int s = 0; s < RgArr.Length; s++)
                            {
                                foreach (DataRow dr2 in ds1.Tables[0].Rows)
                                {
                                    FriId = Convert.ToString(dr2["usrUserId"]);
                                    FriName = Convert.ToString(dr2["usrFirstName"]);
                                    cqc.frnrelFriendId = FriId;
                                    cqc.frnrelFrnRelName = FriName;
                                    cqc.frnrelRelation = "friend";
                                    cqc.frnrelGroup = RgArr[s].ToString();

                                }

                                status = cqc.BLLInsertUserFriendRelative(cqc);


                            }


                        }
                        else
                        {

                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {
                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                                cqc.frnrelGroup = "1";

                            }


                        }

                        //string FriId;
                        //string FriName;
                        //foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        //{
                        //    FriId = Convert.ToString(dr2["usrUserId"]);
                        //    FriName = Convert.ToString(dr2["usrFirstName"]);
                        //    cqc.frnrelFriendId = FriId;
                        //    cqc.frnrelFrnRelName = FriName;
                        //    cqc.frnrelRelation = "friend";
                        //    cqc.frnrelGroup = "1";

                        //}

                        status = cqc.BLLInsertUserFriendRelative(cqc);
                        if (status > 0)
                        {

                        }
                        string senderId = textBox2.Text.ToString();
                        string myMobileNo = mno.ToString();
                        string myPassword = cc.DESDecrypt(cqc.usrPasssword);
                        string myName = cqc.frnrelFrnRelName;
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u in city " + cityName + " on myct.in.U use it to send free SMS.Password for ur First Login is " + myPassword + " for www.muct.in";
                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        Check = true;
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
        return Check;
    }
}

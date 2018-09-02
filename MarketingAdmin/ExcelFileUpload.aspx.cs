using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using Excel = Microsoft.Office.Interop.Excel;

public partial class MarketingAdmin_Default : System.Web.UI.Page
{
    string[] str;
    int i = 0;
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    String path = HttpContext.Current.Request.PhysicalApplicationPath + "MarketingExcel\\";
    int status;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["MarketingUser"]) == "")
            {
                Response.Redirect("Login.aspx");
             
            }
        }
    }
    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string flnm = fileExcel.FileName;
            string[] exten = flnm.Split('.');
            if (exten[1] == "xls" || exten[1] == "xlsx")
            {
                string Name;
                urUserRegBLLObj.usrUserId = Convert.ToString(Session["MarketingUser"]);
                string thisDir = Server.MapPath("~");
                string epath = thisDir + "\\MarketingExcel\\" + Convert.ToString(Session["MarketingUser"]) + "\\";
                if (exten[1] == "xls")
                {
                    Name = epath + Convert.ToString(Session["MarketingUser"]) + ".xls";
                }
                else
                {
                     Name = epath + Convert.ToString(Session["MarketingUser"]) + ".xlsx";
                }
                if (!System.IO.Directory.Exists(thisDir + "\\MarketingExcel\\" + urUserRegBLLObj.usrUserId))
                {
                    System.IO.Directory.CreateDirectory(thisDir + "\\MarketingExcel\\" + urUserRegBLLObj.usrUserId);
                }
                fileExcel.SaveAs(Name);
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "msg", "alert('file Uploaded Successfully.')", true);
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this,typeof(System.Web.UI.Page),"msg","alert('Please Upload Excel file.')",true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }

    }
    protected void btnFileRead_Click(object sender, EventArgs e)
    {
        try
        {
            string thisDir = Server.MapPath("~");
            string epath = thisDir + "\\MarketingExcel\\" + Convert.ToString(Session["MarketingUser"]) + "\\";
            string Name = epath + Convert.ToString(Session["MarketingUser"]);
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range range;
            DataTable dt = new DataTable();
            dt.Columns.Add("fName");
            dt.Columns.Add("lName");
            dt.Columns.Add("mobileNo");
            dt.Columns.Add("pinNo");
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("fName");
            dt1.Columns.Add("lName");
            dt1.Columns.Add("mobileNo");
            dt1.Columns.Add("pinNo");


            xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(Name, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            int index = 0;
            object rowIndex = 2;


            while (((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 1]).Value2 != null)
            {
                urUserRegBLLObj.usrFirstName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 2]).Value2);
                urUserRegBLLObj.usrLastName = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 3]).Value2);
                urUserRegBLLObj.usrMobileNo = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 4]).Value2);
                urUserRegBLLObj.usrPIN = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 5]).Value2);
                urUserRegBLLObj.usrAddress = Convert.ToString(((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rowIndex, 6]).Value2);
                urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["CityIdN"]);
                urUserRegBLLObj.frnrelGroup = "1";
                string mobNo = urUserRegBLLObj.usrMobileNo;
                int count = Convert.ToInt32(mobNo.Length);
                if (urUserRegBLLObj.usrFirstName != "")
                {
                    if (urUserRegBLLObj.usrLastName != "")
                    {
                        if (count == 10)
                        {
                            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);
                            if (status > 0)
                            {
                                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                                Random rnd = new Random();
                                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                                if (status > 0)
                                {
                                    DataRow drN;
                                    drN = dt.NewRow();
                                    string fName = Convert.ToString(urUserRegBLLObj.usrFirstName);
                                    string lName = Convert.ToString(urUserRegBLLObj.usrLastName);
                                    string mobileNo = Convert.ToString(urUserRegBLLObj.usrMobileNo);
                                    string pinNo = Convert.ToString(urUserRegBLLObj.usrPIN);
                                    drN[0] = fName;
                                    drN[1] = lName;
                                    drN[2] = mobileNo;
                                    drN[3] = pinNo;
                                    dt.Rows.Add(drN);
                                    gvUserRegistered.DataSource = dt;
                                    gvUserRegistered.DataBind();

                                    urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
                                    urUserRegBLLObj.frnrelFriendId = urUserRegBLLObj.usrUserId;
                                    urUserRegBLLObj.frnrelFrnRelName = Convert.ToString(urUserRegBLLObj.usrFirstName + " " + urUserRegBLLObj.usrLastName);

                                    int frcount = urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                                    if (frcount > 0)
                                    {

                                        usrFrndRelSms(urUserRegBLLObj.usrMobileNo);
                                    }
                                }
                            }
                            else
                            {


                                DataRow drN;
                                drN = dt1.NewRow();
                                string fName = Convert.ToString(urUserRegBLLObj.usrFirstName);
                                string lName = Convert.ToString(urUserRegBLLObj.usrLastName);
                                string mobileNo = Convert.ToString(urUserRegBLLObj.usrMobileNo);
                                string pinNo = Convert.ToString(urUserRegBLLObj.usrPIN);
                                drN[0] = fName;
                                drN[1] = lName;
                                drN[2] = mobileNo;
                                drN[3] = pinNo;
                                dt1.Rows.Add(drN);
                                gvUserAlreadyRegistered.DataSource = dt1;
                                gvUserAlreadyRegistered.DataBind();

                            }
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile No should Be 10 Digits for Mob NO.:" + mobNo + "')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Eneter the Last Name of Mobile No :" + mobNo + "')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Eneter the First Name of Mobile No :" + mobNo + "')", true);
                }
                index++;
                rowIndex = 2 + index;
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

        }
        catch (Exception ex)
        {
            throw ex;
            //string msg = ex.Message;
            //Response.Write(ex.Message);
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Eneter the First Name of Mobile No ')", true);
        }
    }
    private void usrFrndRelSms(string mobileNo)
    {
        DataTable dtUserInfoList = urUserRegBLLObj.BLLGetUserRegistrationSMSInfo(mobileNo);
        DataRow drUserinfo = dtUserInfoList.Rows[0];
        string sendTo = Convert.ToString(drUserinfo["usrMobileNo"]);
        string password = cc.DESDecrypt(Convert.ToString(drUserinfo["usrPassword"]));
        string myName = Convert.ToString(drUserinfo["usrFirstName"]);
        string firstName = Convert.ToString(Session["UserFirstNameN"]);
        string lastName = Convert.ToString(Session["UserLastNameN"]);

        string sendFrom = Convert.ToString(Session["Mobile"]);
        string senderName = firstName + " " + lastName;

        string passwordMessage = "I " + senderName + " added u as a Friend/Relative in come2mycity.com. U use it to send free SMS. Dear " + myName + ",Password for ur First Login is " + password;
        cc.SendMessage1(sendFrom, sendTo, passwordMessage);
        cc.SendMessageImp1(sendFrom, sendTo, passwordMessage);
    }
}

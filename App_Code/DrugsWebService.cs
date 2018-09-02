using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
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
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for DrugsWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DrugsWebService : System.Web.Services.WebService {

    CommonCode cc = new CommonCode();
    string pwd;

    DataSet ds;
    int status;  
    public DrugsWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod(Description = "Add New User Register")]
    public string RegisterUser(string FirstName, string lastName, string MobileNo)
    {
        int ID;
        try
        {
            string sql = "select usrPassword from usermaster where usrMobileNo= '" + MobileNo + "' ";
            string already = cc.ExecuteScalar(sql);// check this user already register
            if (already == "" || already == null)
            {
                string userid = System.Guid.NewGuid().ToString();
                Random rnd = new Random();

                pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                         " values('" + userid + "','" + FirstName + "','" + lastName + "','" + MobileNo + "','" + pwd + "')";
                ID = cc.ExecuteNonQuery(Sql);
                if (ID == 1)
                {
                    pwd = cc.DESDecrypt(pwd);
                    return pwd;
                }
                else
                {
                    string error = "error";
                    return error;
                }
            }
            else
            {
                //string sql1 = "select usrPassword from usermaster where usrMobileNo= '" + mobileno + "' ";
                //pwd = cc.ExecuteScalarCt1(sql1);// check this user already register

                pwd = cc.DESDecrypt(already);

            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
        return pwd;
    }

    [WebMethod(Description = "Password Details")]
    public string getpassword(string mobileno)
    {
        string already = "";
        try
        {
            string sql = "select usrPassword from usermaster where usrMobileNo= '" + mobileno + "' ";
            already = cc.ExecuteScalar(sql);// check this user already register
            already = cc.DESDecrypt(already);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return already;
    }


    [WebMethod(Description = "User Details")]
    public DataSet GetDetails(string MobileNo1, string Password1)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                {
                    SqlParameter[] par = new SqlParameter[3];
                    par[0] = new SqlParameter("@UserId", MobileNo1);
                    par[1] = new SqlParameter("@Password", Password1);
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Authenticate", par);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        return ds;
    }

    [WebMethod(Description = "Return IMEI,usrUserName,Password")]
    public string ReturnPassMobile(string Mobileno)
    {
        string mobileNoPass = "";
        //string SQl = " Select mobileNo from EzeeDrugsAppDetail where strDevId='" + IMEINo + "'";
        //string Mobileno = Convert.ToString(cc.ExecuteScalar(SQl));
        //if (Mobileno == "")
        //{ }
        //else
        //{
        string Sql = "Select usrMobileNo,usrPassword,strDevId from UserMaster where usrMobileNo='" + Mobileno + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mobileNoPass = Convert.ToString(ds.Tables[0].Rows[0]["strDevId"]) + " * " + Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]) + " *  " + cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
            }
            else
            {
            }

        

        //}
            return mobileNoPass;
    }

    [WebMethod(Description = "Reg no")]
    public DataSet GetUserbyRefereceNo(string Refno)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                {
                    string Sql = "SELECT firstName,lastName,firmName,mobileNo,typeOfUse_Id,RefMobileNo FROM EzeeDrugsAppDetail where [RefMobileNo] = '" + Refno + "' and [keyword] = 'EZEEDRUG' order by EzeeDrugAppId desc";
                    ds = cc.ExecuteDataset(Sql);
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        return ds;
    }


}


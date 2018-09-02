using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using ClosedXML.Excel;
using System.Data.OleDb;
using System.Configuration;
using System.IO;

public partial class MarketingAdmin_AddCustomerDetails : System.Web.UI.Page
{
    string fileExtension = string.Empty;
    OleDbConnection conn = new OleDbConnection();
    string conPath = "";
    int count;
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExcelUpload_Click(object sender, EventArgs e)
    {
        if (MarketnigAddCustm.HasFile)
        {
            string path = "";
            path = Server.MapPath("File_Upload");
            path = path + "\\" + MarketnigAddCustm.FileName;
            string aa = MarketnigAddCustm.FileName;

            if (File.Exists(path))
            {
                File.Delete(path);
                MarketnigAddCustm.SaveAs(path);
            }
            else
            {
                MarketnigAddCustm.SaveAs(path);
            }

            excelSubject = "UPLOAD";

            string strQuery = "SELECT * FROM [" + excelSubject + "$]";
            DataSet dscount = GetDataTable(strQuery);

            FetchQuestion(dscount);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('File uploaded Successfully..Total Uploaded Record "+ Convert.ToInt32(dscount.Tables[0].Rows.Count) + "')", true);

            lblError.Visible = true;
            lblError.Text = "File Upload Successfully ..Total Uploaded Record "+ Convert.ToInt32(dscount.Tables[0].Rows.Count) +"";
        }
    }

    public DataSet GetDataTable(string strQuery)
    {

        DataSet tempDs = null;
        string filePath = Server.MapPath("File_Upload\\" + MarketnigAddCustm.FileName);
        fileExtension = Path.GetExtension(filePath);

        if (this.fileExtension == ".xls")
        {
            conPath = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }
        else
        {
            conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"";
        }
        conn = new OleDbConnection(conPath);
        try
        {
            conn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
            tempDs = new DataSet();
            adapter.Fill(tempDs);
        }
        catch (Exception ex)
        {
            Response.Write("<Script>alert('" + ex.Message + "')</Script>");
        }
        conn.Close();

        return tempDs;
    }

    string stateid = ""; string districtid = ""; string talukaid = "";
    string custMobNo = ""; string F_Name = ""; string M_Name = ""; string L_Name = "";
    string type = ""; string usrMobNo = ""; string adminMobno = "";

    public void FetchQuestion(DataSet ExcelDs)
    {
        int countVal = ExcelDs.Tables[0].Rows.Count;

        for (int i = 0; i < countVal; i++)
        {
            stateid = Convert.ToString(ExcelDs.Tables[0].Rows[i]["StateID"]);    //Excel Sheet Column name
            districtid = Convert.ToString(ExcelDs.Tables[0].Rows[i]["DistrictID"]);
            talukaid = Convert.ToString(ExcelDs.Tables[0].Rows[i]["TalukaID"]);
            custMobNo = Convert.ToString(ExcelDs.Tables[0].Rows[i]["CustomerMobNo"]);
            F_Name = Convert.ToString(ExcelDs.Tables[0].Rows[i]["First Name"]);
            L_Name = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Last Name"]);
            M_Name = Convert.ToString(ExcelDs.Tables[0].Rows[i]["FirmName"]);
            type = Convert.ToString(ExcelDs.Tables[0].Rows[i]["Type"]);
            usrMobNo = Convert.ToString(ExcelDs.Tables[0].Rows[i]["UserMobNo"]);
            adminMobno = Convert.ToString(ExcelDs.Tables[0].Rows[i]["AdminMobNo"]);

            if (adminMobno == "" || custMobNo == "" || F_Name == "" || L_Name == "" || type == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Do not allow Admin Mobile No Customer Mobile No and First Name field Blank')", true);
            }
            else 
            {
                Addexcel(stateid, districtid, talukaid, custMobNo, F_Name, L_Name, M_Name, type, usrMobNo, adminMobno);
                count++;
            }
            
        }
    }

    DataSet ExcelDB;
    public string excelSubject = "";
    string SqlQry = "";
    public void Addexcel(string stateid, string districtid, string talukaid, string custMobNo, string F_Name, string L_Name, string M_Name, string type, string usrMobNo, string adminMobno)
    {
        try
        {
            SqlQry = "select [Cust_mobile] from [Come2myCityDB].[dbo].[EzeeMarketingCustDetails] where [Cust_mobile]='" + custMobNo + "'";
            DataSet ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {

                SqlQry = "Update [Come2myCityDB].[dbo].[EzeeMarketingCustDetails] set [StateId]='" + stateid + "',[DistrictId]='" + districtid + "',[TalukaId]='" + talukaid + "',[Cust_mobile]='" + ds.Tables[0].Rows[0][0].ToString() + "'" +
                         ",[FirstName]='" + F_Name + "',[LastName]='" + L_Name + "',[FirmName]='" + M_Name + "',[Type]='" + type + "',[AppMobNo]='" + usrMobNo + "',[AdminMobNo]='" + adminMobno + "' where [Cust_mobile]='" + ds.Tables[0].Rows[0][0].ToString() + "'";
                cc.ExecuteNonQuery(SqlQry);
            }
            else
            {
                //SqlQry = "insert into [Come2myCityDB].[dbo].[EzeeMarketingReferenceCustomer] ([MobileNo],[AppMobNo],[CreatedBy],[CreatedDate])" +
                //               "values('+91" + custMobNo + "','" + usrMobNo + "','" + usrMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                //cc.ExecuteNonQuery(SqlQry);

                //SqlQry = "select Max([CustId]) From [Come2myCityDB].[dbo].[EzeeMarketingReferenceCustomer]";
                //string Custid = cc.ExecuteScalar(SqlQry);


                string str = " INSERT INTO [Come2myCityDB].[dbo].[EzeeMarketingCustDetails] " +
                                   " ([StateId],[DistrictId],[TalukaId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[AppMobNo],[AdminMobNo]) VALUES" +
                                   " (N'" + stateid + "',N'" + districtid + "',N'" + talukaid + "',N'" + custMobNo + "',N'" + F_Name + "',N'" + L_Name + "',N'" + M_Name + "',N'" + type + "',N'" + usrMobNo + "',N'" + adminMobno + "')";
                cc.ExecuteNonQuery(str);
            }
        }
        catch
        {

        }
    }
    protected void btnExcelDwnloadfrmt_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingExcel/EzeeMarketingAddCustomer.xlsx");
    }
}
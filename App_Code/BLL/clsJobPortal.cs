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
/// Summary description for clsJobPortal
/// </summary>
public class clsJobPortal
{

    CommonCode cc = new CommonCode();
    int status;
    dalJobportal objjob = new dalJobportal();

    private string strCategory;

    public string Category
    {
        get { return strCategory; }
        set { strCategory = value; }
    }

    private Int32 intQualification;

    public Int32 Qualification
    {
        get { return intQualification; }
        set { intQualification = value; }
    }


    private Int32 intJobTypeId;
   


    public Int32 JobTypeId
    {
        get { return intJobTypeId; }
        set { intJobTypeId = value; }
    }
    private string strExpYear;

    public string ExpYear
    {
        get { return strExpYear; }
        set { strExpYear = value; }
    }
    private string strExpMonths;

    public string ExpMonths
    {
        get { return strExpMonths; }
        set { strExpMonths = value; }
    }

    private string strSalary;

    public string Salary
    {
        get { return strSalary; }
        set { strSalary= value; }
    }
    
    private string strResumeName;

    public string ResumeName
    {
        get { return strResumeName; }
        set { strResumeName = value; }
    }
    private string intState;

    public string State
    {
        get { return intState; }
        set { intState= value; }
    }
    private string strDist;

    public string Dist
    {
        get { return strDist; }
        set { strDist = value; }
    }
    private string strCityName;

    public string CityName
    {
        get { return strCityName; }
        set { strCityName = value; }
    }
    private Int32 intusrMobileNo;

    public Int32 usrMobileNo
    {
        get { return intusrMobileNo; }
        set { intusrMobileNo = value; }
    }
    private Int32 intCityid;

    public Int32 Cityid
    {
        get { return intCityid; }
        set { intCityid = value; }
    }
    private string strUserId;

    public string UserId
    {
        get { return strUserId; }
        set { strUserId = value; }
    }



    private string strDesignation;

    public string Designation
    {
        get { return strDesignation; }
        set { strDesignation = value; }
    }
    private string strcompanyName;

    public string companyName
    {
        get { return strcompanyName; }
        set { strcompanyName = value; }
    }

    private Int32 intEmpRequired;

    public Int32 EmpRequired
    {
        get { return intEmpRequired; }
        set { intEmpRequired = value; }
    }
    private string strPincode;

    public string Pincode
    {
        get { return strPincode; }
        set { strPincode = value; }
    }


	public clsJobPortal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable BLLGetSelectedJobBySId(clsJobPortal Job, int i)
    {
        DataTable dtJobSelectByCategoryId = objjob.DALJobSelectByCategoryId(Job, i);
        return dtJobSelectByCategoryId;
    }

    public DataSet BLLLoadCategory(clsJobPortal Job)
    {
        string Sql = "Select * from Functions";

        DataSet ds = cc.ExecuteDataset(Sql);
        return ds;
    }

    public int BLLInsertSearchJobInfo(clsJobPortal objJobPortal)
    {

        status = objjob.BLLInsertSearchJobInfo(objJobPortal);
        return status;
    }

 public int BLLInsertPostResumeInfo(clsJobPortal objJobPortal)
 {

     status = objjob.BLLInsertPostResumeInfo(objJobPortal);
     return status;
 }
 public int BLLInsertPostJobInfo(clsJobPortal objJobPortal)
 {

     status = objjob.BLLInsertPostJobInfo(objJobPortal);
     return status;
 }

}

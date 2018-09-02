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
/// Summary description for BLLCompanyDetails
/// </summary>
public class BLLCompanyDetails
{
    DALCompanyDetails dalCompanyobj = new DALCompanyDetails();

   
   
    int status;
	public BLLCompanyDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _companyid;

    public string Companyid
    {
        get { return _companyid; }
        set { _companyid = value; }
    }
    private string _companyname;

    public string Companyname
    {
        get { return _companyname; }
        set { _companyname = value; }
    }
    private string _companytype;

    public string Companytype
    {
        get { return _companytype; }
        set { _companytype = value; }
    }
    private int _state;

    public int State
    {
        get { return _state; }
        set { _state = value; }
    }
    private int _district;

    public int District
    {
        get { return _district; }
        set { _district = value; }
    }
    private int _city;

    public int City
    {
        get { return _city; }
        set { _city = value; }
    }
    private string _address;

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    private string _contactperson;

    public string Contactperson
    {
        get { return _contactperson; }
        set { _contactperson = value; }
    }
    private string _contactno;

    public string Contactno
    {
        get { return _contactno; }
        set { _contactno = value; }
    }
    
    private string _advertiseFromdate;

    public string AdvertiseFromdate
    {
        get { return _advertiseFromdate; }
        set { _advertiseFromdate = value; }
    }
    private string _advertiseTodate;

    public string AdvertiseTodate
    {
        get { return _advertiseTodate; }
        set { _advertiseTodate = value; }
    }

    private string _advertiseIn;

    public string AdvertiseIn
    {
        get { return _advertiseIn; }
        set { _advertiseIn = value; }
    }

    private int _industrytype;

    public int Industrytype
    {
        get { return _industrytype; }
        set { _industrytype = value; }
    }

    private string _advfilename;

    public string Advfilename
    {
        get { return _advfilename; }
        set { _advfilename = value; }
    }

    private string  _jobtype;

    public string  Jobtype
    {
        get { return _jobtype; }
        set { _jobtype = value; }
    }
    private string _skills;

    public string Skills
    {
        get { return _skills; }
        set { _skills = value; }
    }
    private string _jobdesignation;

    public string Jobdesignation
    {
        get { return _jobdesignation; }
        set { _jobdesignation = value; }
    }
    private string _reqQualification;

    public string ReqQualification
    {
        get { return _reqQualification; }
        set { _reqQualification = value; }
    }
    private int _noofemployee;

    public int Noofemployee
    {
        get { return _noofemployee; }
        set { _noofemployee = value; }
    }
    private string _reqexp;

    public string Reqexp
    {
        get { return _reqexp; }
        set { _reqexp = value; }
    }
    private string _salary;

    public string Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }
    private string _formname;

    public string Formname
    {
        get { return _formname; }
        set { _formname = value; }
    }
    private string _currentdate;

    public string Currentdate
    {
        get { return _currentdate; }
        set { _currentdate = value; }
    }

    //private string _contactno;
    private string _feespaid;

    public string Feespaid
    {
        get { return _feespaid; }
        set { _feespaid = value; }
    }
    private string _feesdated;

    public string Feesdated
    {
        get { return _feesdated; }
        set { _feesdated = value; }
    }

    private string _candidatename;

    public string Candidatename
    {
        get { return _candidatename; }
        set { _candidatename = value; }
    }

    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _jobstatus;

    public string Jobstatus
    {
        get { return _jobstatus; }
        set { _jobstatus = value; }
    }


    private string _validfrom;

    public string Validfrom
    {
        get { return _validfrom; }
        set { _validfrom = value; }
    }
    private string _validto;

    public string Validto
    {
        get { return _validto; }
        set { _validto = value; }
    }
    public int BLLCompanyRegistrationInsert(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALInsertCompanyDetails(obj);
        return status;
        
    }
    public int BLLUpdateCompanyDetails(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALUpdateCompanyDetails(obj);
        return status;

    }

    public DataSet BLLGetCompanydetails(BLLCompanyDetails obj)
    {
        DataSet dtCompanydetails = dalCompanyobj.DALSearchbycompanyno(obj);
        return dtCompanydetails;
    }

    public int BLLExistcompanyno(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALExistcompanyno(obj);
        return status;
    }
    public int BLLAdvertiseInsert(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALInsertAdvertise(obj);
        return status;

    }
    public int BLLUpdateAdvertiseStatus(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALUpdateAdvertisestatus(obj);
        return status;

    }
   
    public DataSet BLLGetALLCompanydetails(BLLCompanyDetails obj)
    {
        DataSet dtALLCompanydetails = dalCompanyobj.DALSearchAllbycompanyid(obj);
        return dtALLCompanydetails;
    }
    public int BLLUpdateCompanyProfile(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALupdateCompanyProfile(obj);
        return status;
    }

    public DataSet BLLGetAdvDetails(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetAdvInfo(obj);
        return dtgetdetails;
       
    }
    public DataSet BLLGetCompanyAdvt(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetAdvertisment(obj);
        return dtgetdetails;
    }
   

    public DataSet BLLGetQuali(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetQualification(obj);
        return dtgetdetails;
    }

    public DataSet BLLGetIndustrylist(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetIndustry(obj);
        return dtgetdetails;
    }
    public int BLLInsertLatestJobRecruit(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALInsertLatestJobRecruit(obj);
        return status;
    }
    public int BLLUpdateLatestJobRecruit(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALUpdateLatestJobRecruit(obj);
        return status;
    }
    public int BLLUpdateLatestGovtJobRecruit(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALUpdateLatestGovtJobRecruit(obj);
        return status;
    }

    public DataSet BLLGetLatestJob(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetLatestJob(obj);
        return dtgetdetails;
    }
    public DataSet BLLGetLatestGovtJob(BLLCompanyDetails obj)
    {
        DataSet dtgetdetails = dalCompanyobj.DALGetLatestGovtJob(obj);
        return dtgetdetails;
    }

    public int BLLInsertCompanyReceipt(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALInsertCandidateReceipt(obj);
        return status;
    }

    public DataSet BLLGetReceiptdetails(BLLCompanyDetails obj)
    {
        DataSet dtgetreceiptdetails = dalCompanyobj.DALGetReceiptInfo(obj);
        return dtgetreceiptdetails;
    }
    public DataSet BLLGetAppliedCandidate(BLLCompanyDetails obj)
    {
        DataSet dtCompanydetails = dalCompanyobj.DALViewAppliedcandidate(obj);
        return dtCompanydetails;
    }
    public DataSet BLLViewCompanyDetails(BLLCompanyDetails obj)
    {
        DataSet dtCompanydetails = dalCompanyobj.DALViewCompanyDetails(obj);
        return dtCompanydetails;
    }
    public DataSet BLLViewCompanyDetailsonly(BLLCompanyDetails obj)
    {
        DataSet dtCompanydetails = dalCompanyobj.DALViewCompanyDetailsonly(obj);
        return dtCompanydetails;
    }
    public DataSet BLLViewCompanyAdvertisment(BLLCompanyDetails obj)
    {
        DataSet dtCompanydetails = dalCompanyobj.DALViewCompanyAdvertisment(obj);
        return dtCompanydetails;
    }

    public int  BLLCheckcompanyexist(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALCheckcompanyexist(obj);
        return status;
    }
    public int BLLChecklatestjobexist(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALChecklatestjobexist(obj);
        return status;
    }
    public int BLLCheckAdvertiseexist(BLLCompanyDetails obj)
    {
        status = dalCompanyobj.DALCheckAdvertismentexist(obj);
        return status;
    }

}

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
/// Summary description for JobSeekerdetailsBLL
/// </summary>
public class JobSeekerdetailsBLL
{
    JobSeekerdetailsDAL objdalJobseeker = new JobSeekerdetailsDAL();
    int status;
	public JobSeekerdetailsBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _usrMobileNo;

    public string UsrMobileNo
    {
        get { return _usrMobileNo; }
        set { _usrMobileNo = value; }
    }
    private int _Id;

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _resume_title;

    public string Resume_title
    {
        get { return _resume_title; }
        set { _resume_title = value; }
    }
    private string _resume_name;

    public string Resume_name
    {
        get { return _resume_name; }
        set { _resume_name = value; }
    }
    private string _designation;

    public string Designation
    {
        get { return _designation; }
        set { _designation = value; }
    }
    private string _industrytype;

    public string Industrytype
    {
        get { return _industrytype; }
        set { _industrytype = value; }
    }
    private string _jobtype;

    public string Jobtype
    {
        get { return _jobtype; }
        set { _jobtype = value; }
    }
    private string _currentrole;

    public string Currentrole
    {
        get { return _currentrole; }
        set { _currentrole = value; }
    }
    private string _workexp;

    public string Workexp
    {
        get { return _workexp; }
        set { _workexp = value; }
    }
    private string _currentworking;

    public string Currentworking
    {
        get { return _currentworking; }
        set { _currentworking = value; }
    }
    private string _durationfrom;

    public string Durationfrom
    {
        get { return _durationfrom; }
        set { _durationfrom = value; }
    }
    private string _durationto;

    public string Durationto
    {
        get { return _durationto; }
        set { _durationto = value; }
    }
    private string _annualsalary;

    public string Annualsalary
    {
        get { return _annualsalary; }
        set { _annualsalary = value; }
    }
    private string _preferredlocation;

    public string Preferredlocation
    {
        get { return _preferredlocation; }
        set { _preferredlocation = value; }
    }
    private string _currentlocation;

    public string Currentlocation
    {
        get { return _currentlocation; }
        set { _currentlocation = value; }
    }

    private string _KeySkill;

    public string KeySkill
    {
        get { return _KeySkill; }
        set { _KeySkill = value; }
    }

    private string _graduatecourse;

    public string Graduatecourse
    {
        get { return _graduatecourse; }
        set { _graduatecourse = value; }
    }
    private string _specialized;

    public string Specialized
    {
        get { return _specialized; }
        set { _specialized = value; }
    }
    private string _Graduationpassout;

    public string Graduationpassout
    {
        get { return _Graduationpassout; }
        set { _Graduationpassout = value; }
    }
    private string _graduateuniversity;

    public string Graduateuniversity
    {
        get { return _graduateuniversity; }
        set { _graduateuniversity = value; }
    }
    private string _companyid;

    public string Companyid
    {
        get { return _companyid; }
        set { _companyid = value; }
    }
    private string _applieddate;

    public string Applieddate
    {
        get { return _applieddate; }
        set { _applieddate = value; }
    }

    /// <summary>
    /// ///Ketan
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private string req_qualification;

    public string Req_qualification
    {
        get { return req_qualification; }
        set { req_qualification = value; }
    }
    private string no_of_employee;

    public string No_of_employee
    {
        get { return no_of_employee; }
        set { no_of_employee = value; }
    }
    private string req_exp;

    public string Req_exp
    {
        get { return req_exp; }
        set { req_exp = value; }
    }
    private string register_date;

    public string Register_date
    {
        get { return register_date; }
        set { register_date = value; }
    }
    private string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    //private string city;

    //public string City
    //{
    //    get { return city; }
    //    set { city = value; }
    //}
    private string City;

    public string City1
    {
        get { return City; }
        set { City = value; }
    }
    private string contactperson;

    public string Contactperson
    {
        get { return contactperson; }
        set { contactperson = value; }
    }
    private string contactno;

    public string Contactno
    {
        get { return contactno; }
        set { contactno = value; }
    }
    private string Qualification;
    public string Qualification1
    {
        get { return Qualification; }
        set { Qualification = value; }
    }
    private string FrmDate;
    public string FrmDate1
    {
        get { return FrmDate; }
        set { FrmDate = value; }
    }
    private string ToDate;
    public string ToDate1
    {
        get { return ToDate; }
        set { ToDate = value; }
    }
    private string Specialization;
    public string Specialization1
    {
        get { return Specialization; }
        set { Specialization = value; }
    }
    //private string YearPassout;
    //public string YearPassout1
    //{
    //    get { return YearPassout; }
    //    set { YearPassout = value; }
    //}
    private string University;
    public string University1
    {
        get { return University; }
        set { University = value; }
    }

    private string CollegeName;
    public string CollegeName1
    {
        get { return CollegeName; }
        set { CollegeName = value; }
    }

    private string Marks;
    public string Marks1
    {
        get { return Marks; }
        set { Marks = value; }
    }
    private string InstName;
    public string InstName1
    {
        get { return InstName; }
        set { InstName = value; }
    }
    private string Salary;

    public string Salary1
    {
        get { return Salary; }
        set { Salary = value; }
    }
    private string YearPassout;
    public string YearPassout1
    {
        get { return YearPassout; }
        set { YearPassout = value; }
    }
    private string FArea;
    public string FArea1
    {
        get { return FArea; }
        set { FArea = value; }
    }

    private string CourseType;
    public string CourseType1
    {
        get { return CourseType; }
        set { CourseType = value; }
    }

    private string AreYou;
    public string AreYou1
    {
        get { return AreYou; }
        set { AreYou = value; }
    }

    private string CompName;
    public string CompName1
    {
        get { return CompName; }
        set { CompName = value; }
    }

    private string ExperienceYr;
    public string ExperienceYr1
    {
        get { return ExperienceYr; }
        set { ExperienceYr = value; }
    }

    private string ExperienceMonth;
    public string ExperienceMonth1
    {
        get { return ExperienceMonth; }
        set { ExperienceMonth = value; }
    }

    //private string KeySkill;
    //public string KeySkill1
    //{
    //    get { return KeySkill; }
    //    set { KeySkill = value; }
    //}
    private string JTitle;
    public string JTitle1
    {
        get { return JTitle; }
        set { JTitle = value; }
    }
    private string CName;

    public string CName1
    {
        get { return CName; }
        set { CName = value; }
    }
    private string InSector;

    public string InSector1
    {
        get { return InSector; }
        set { InSector = value; }
    }
    private string JRole;

    public string JRole1
    {
        get { return JRole; }
        set { JRole = value; }
    }
    private string JRequirment;

    public string JRequirment1
    {
        get { return JRequirment; }
        set { JRequirment = value; }
    }
    private string VaccancyTill;

    public string VaccancyTill1
    {
        get { return VaccancyTill; }
        set { VaccancyTill = value; }
    }
    private string SalaryOffered;

    public string SalaryOffered1
    {
        get { return SalaryOffered; }
        set { SalaryOffered = value; }
    }


    private string FreExp;

    public string FreExp1
    {
        get { return FreExp; }
        set { FreExp = value; }
    }

    private int PID;

    public int PID1
    {
        get { return PID; }
        set { PID = value; }
    }

    
    private int CID;

    public int CID1
    {
        get { return CID; }
        set { CID = value; }
    }

    private string TrainingOffered;

    public string TrainingOffered1
    {
        get { return TrainingOffered; }
        set { TrainingOffered = value; }
    }
    private string UserId;
    public string UserId1
    {
        get { return UserId; }
        set { UserId = value; }
    }

    private string NameOfComp;
    public string NameOfComp1
    {
        get { return NameOfComp; }
        set { NameOfComp = value; }
    }

    private string EntryDate;
    public string EntryDate1
    {
        get { return EntryDate; }
        set { EntryDate = value; }
    }

    public DataSet LoadGrid(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.LoadGridJobSeeker(obj);
        return dtgetrecord;
    }
    public DataSet BLLViewAppliedJobs(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALViewAppliedJobs(obj);
        return dtgetrecord;
    }


    public DataSet BLLViewLocation(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALViewLocation(obj);
        return dtgetrecord;
    }
    public DataSet BLLViewSalary(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALViewSalary(obj);
        return dtgetrecord;
    }
    public DataSet BLLViewExperience(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALViewExperience(obj);
        return dtgetrecord;
    }

    public DataSet BLLGetCompanyname(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALGetCompanyname(obj);
        return dtgetrecord;
    }


    public  DataSet BLLGetRecordbyno(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALSearchbyNo(obj);
        return dtgetrecord;
    }
    public int BLLInitalInsertCandidate(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.IntialInsertCandidate(obj);
        return status;
    }
    public int BLLGetstatus(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALGetstatus(obj);
        return status;
    }
    public int BLLUpdateResume(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALUpdateResume(obj);
        return status;
    }
    public int BLLUpdateJobCategory(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALUpdateJobCategory(obj);
        return status;
    }

    public int BLLUpdateWorkHistory(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALUpdateWorkHistory(obj);
        return status;
    }
    public int BLLUpdateLocation(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALUpdateLocation(obj);
        return status;
    }
    public int BLLUpdateEducation(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALUpdateEducation(obj);
        return status;
    }
    public int BLLInsertCandidateApplied(JobSeekerdetailsBLL obj)
    {
        status = objdalJobseeker.DALInsertCandidateApplied(obj);
        return status;
    }
    public DataSet loadjobseekerApplied(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.LoadGridJobSeeker(obj);
        return dtgetrecord;
    }

    public DataSet BLLCompanydetailsbyid(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALGetCompanydetailsbyid(obj);
        return dtgetrecord;
    }
    public DataSet BLLCompanydetailsbyLocation(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALGetCompanydetailsbylocation(obj);
        return dtgetrecord;
    }

    public DataSet BLLCompanydetailsbySkills(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALGetCompanydetailsbySkills(obj);
        return dtgetrecord;
    }


    public DataSet BLLCompanydetailsbyAdvance(JobSeekerdetailsBLL obj)
    {
        DataSet dtgetrecord = objdalJobseeker.DALGetCompanydetailsbyAdvance(obj);
        return dtgetrecord;
    }


}

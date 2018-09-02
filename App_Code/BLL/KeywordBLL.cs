using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for KeywordBLL
/// </summary>
public class KeywordBLL
{
    KeywordDAL keywordDALObj = new KeywordDAL();
    DataTable dtBLLKeyword=new DataTable();
	public KeywordBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    int status;
    private string _keywordName;
    private string _keywordDescription;
    private string _KeyEmail;
    private string _responseMsg;
    private int _Active;
    private string _validUpto;
    private string _keywordCreationDate;
    private string _groupName;
    private string _subGroupName;
    private string _KeyEmailSub;
    private string _KeyEmailBody;

    public string keyEmailSub
    {
        get { return _KeyEmailSub; }
        set { _KeyEmailSub = value; }
    }

    public string keyEmailBody
    {
        get { return _KeyEmailBody; }
        set { _KeyEmailBody = value; }
    }
    public string keywordName
    {
        get 
        {
            return _keywordName;
        }
        set
        {
            _keywordName = value;
        }
    }
    public string Email
    {
        get { return _KeyEmail; }
        set { _KeyEmail = value; }
    
    }

    public string keywordDescription
    {
        get
        {
            return _keywordDescription;
        }
        set
        {
            _keywordDescription = value;
        }
    }
    public string responseMsg
    {
        get
        {
            return _responseMsg;
        }
        set
        {
            _responseMsg = value;
        }
    }
    public int Active
    {
        get
        {
            return _Active;
        }
        set
        {
            _Active = value;
        }
    }
    public string validUpto
    {
        get
        {
            return _validUpto;
        }
        set
        {
            _validUpto = value;
        }
    }
    public string keywordCreationDate
    {
        get
        {
            return _keywordCreationDate;
        }
        set
        {
            _keywordCreationDate = value;
        }
    }
    public string groupName
    {
        get
        {
            return _groupName;
        }
        set
        {
            _groupName = value; 
        }
    }

    public string subGroupName
    {
        get
        {
            return _subGroupName;
        }
        set
        {
            _subGroupName = value;
        }
    }
    private int strgroupid;

    public int groupid
    {
        get { return strgroupid; }
        set { strgroupid = value; }
    }
    private int strSubGroupid;

    public int SubGroupid
    {
        get { return strSubGroupid; }
        set { strSubGroupid = value; }
    }

    private string _IMEINO;

    public string IMEINO
    {
        get { return _IMEINO; }
        set { _IMEINO = value; }
    }
    private string _simno;

    public string Simno
    {
        get { return _simno; }
        set { _simno = value; }
    }
    private string _Fwdmobileno;

    public string Fwdmobileno
    {
        get { return _Fwdmobileno; }
        set { _Fwdmobileno = value; }
    }

    private string _keywordstatus;

    public string Keywordstatus
    {
        get { return _keywordstatus; }
        set { _keywordstatus = value; }
    }

    private int _Id;

    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _keywordfor;

    public string Keywordfor
    {
        get { return _keywordfor; }
        set { _keywordfor = value; }
    }

    public int BLLKeywordInsert(KeywordBLL kw)
    {
        status = keywordDALObj.DALKeywordInsert(kw);
        return status;
    }
    public int BLLMiscalKeywordInsert(KeywordBLL kw)
    {
        status = keywordDALObj.DALMiscalKeywordInsert(kw);
        return status;
    }
    public int BLLMiscalKeywordinLongcodeInsert(KeywordBLL kw)
    {
        status = keywordDALObj.DALMiscalKeywordinLongCodeInsert(kw);
        return status;
    }


    public int BLLMiscalKeywordUpdate(KeywordBLL kw)
    {
        status = keywordDALObj.DALMiscalKeywordUpdate(kw);
            return status;
    }
    public int BLLKeywordIsExist(KeywordBLL kwIs)
    {
        status = keywordDALObj.DALKeywordIsExist(kwIs);
        return status;
    }
    public DataTable BLLKeywordSelectAll()
    {
        dtBLLKeyword = keywordDALObj.DALKeywordSelectAll();
        return dtBLLKeyword;
    }
    public DataTable BLLMiscalKeywordSelectAll(KeywordBLL kwIs)
    {
        dtBLLKeyword = keywordDALObj.DALMiscalKeywordSelectAll2(kwIs);
        return dtBLLKeyword;
    }
    public int BLLKeywordUpdate(KeywordBLL kBLL)
    {
        status = keywordDALObj.DALKeywordUpdate(kBLL);
        return status;
    }
    public int BLLKeywordUpdateDeactive(KeywordBLL kBLL)
    {
        status = keywordDALObj.DALKeywordUpdateDeactive(kBLL);
        return status;
    }


    public DataTable BLLSelectAllGroup()
    {
        dtBLLKeyword = keywordDALObj.DALSelectAllGroup();
        return dtBLLKeyword;
    }
    public DataTable BLLSelectSubGroupById(int gId)
    {
        dtBLLKeyword = keywordDALObj.DALSelectSubGroupById(gId);
        return dtBLLKeyword;
    }
    public int BLLMiscalKeywordIsExist(KeywordBLL kwIs)
    {
        status = keywordDALObj.DALMiscalKeywordIsExist(kwIs);
        return status;
    }
}

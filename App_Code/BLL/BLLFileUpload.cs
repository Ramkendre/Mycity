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
/// Summary description for BLLFileUpload
/// </summary>
public class BLLFileUpload
{
    DALFileUpload dalfile = new DALFileUpload();
    int status;
    public BLLFileUpload()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string _commiteename;

    public string Commiteename
    {
        get { return _commiteename; }
        set { _commiteename = value; }
    }
    private string _commiteeurl;

    public string Commiteeurl
    {
        get { return _commiteeurl; }
        set { _commiteeurl = value; }
    }

    private string _filename;

    public string Filename
    {
        get { return _filename; }
        set { _filename = value; }
    }
    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private int _roleid;

    public int Roleid
    {
        get { return _roleid; }
        set { _roleid = value; }
    }

    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }

    public int BLLinsertFileupload(BLLFileUpload bllfile)
    {
        status = dalfile.DALinsertFileUpload(bllfile);
        return status;
    }
   
    public int BLLInsertUserCommitteeUpdated(BLLFileUpload bllfile)
    {
        status = dalfile.insertUserCommiteeUpdated(bllfile);
        return status;
    }
   
        
   
}

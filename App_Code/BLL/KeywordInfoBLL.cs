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
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for KeywordInfoBLL
/// </summary>
public class KeywordInfoBLL
{
    public KeywordInfoBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private Int64 KeyId;

    public Int64 KeyId1
    {
        get { return KeyId; }
        set { KeyId = value; }
    }
    private string KeywordName;

    public string KeywordName1
    {
        get { return KeywordName; }
        set { KeywordName = value; }
    }
    private string KeywordSyntax;

    public string KeywordSyntax1
    {
        get { return KeywordSyntax; }
        set { KeywordSyntax = value; }
    }
    private string KeywordPurpose;

    public string KeywordPurpose1
    {
        get { return KeywordPurpose; }
        set { KeywordPurpose = value; }
    }
    private string KeyDiscip;

    public string KeyDiscip1
    {
        get { return KeyDiscip; }
        set { KeyDiscip = value; }
    }
    private string WebsiteGroup;

    public string WebsiteGroup1
    {
        get { return WebsiteGroup; }
        set { WebsiteGroup = value; }
    }
    private string EntryDate;

    public string EntryDate1
    {
        get { return EntryDate; }
        set { EntryDate = value; }
    }
    private string Other;

    public string Other1
    {
        get { return Other; }
        set { Other = value; }
    }

    KeywordInfoDAL KEYDAL = new KeywordInfoDAL();

    public int AddInfo(KeywordInfoBLL KBLL)
    {
        int i = KEYDAL.AddKeywordInfo(KBLL);
        return i;
    }
    public int UpdateInfo(KeywordInfoBLL KBLL)
    {
        int i = KEYDAL.UpdateKeywordInfo(KBLL);
        return i;
    }

    DataSet ds = new DataSet();

    public DataSet LoadInfo(KeywordInfoBLL KBLL)
    {
        return ds = KEYDAL.LoadKeywordInfo(KBLL);
    }

    public void SelectInfo(KeywordInfoBLL KBLL)
    {
        KEYDAL.SelectKeywordInfo(KBLL);
    }
}

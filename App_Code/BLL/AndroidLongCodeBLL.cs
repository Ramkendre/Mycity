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
/// Summary description for AndroidLongCodeBLL
/// </summary>
public class AndroidLongCodeBLL
{
    AndroidLongCodeDAL dalobj = new AndroidLongCodeDAL();
	public AndroidLongCodeBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int status;
    private string _p1;

    public string P1
    {
        get { return _p1; }
        set { _p1 = value; }
    }
    private string _p2;

    public string P2
    {
        get { return _p2; }
        set { _p2 = value; }
    }
    private string _p3;

    public string P3
    {
        get { return _p3; }
        set { _p3 = value; }
    }
    private string _p4;

    public string P4
    {
        get { return _p4; }
        set { _p4 = value; }
    }
    private string _p5;

    public string P5
    {
        get { return _p5; }
        set { _p5 = value; }
    }
    private string _p6;

    public string P6
    {
        get { return _p6; }
        set { _p6 = value; }
    }
    private string _p7;

    public string P7
    {
        get { return _p7; }
        set { _p7 = value; }
    }
    private string _p8;

    public string P8
    {
        get { return _p8; }
        set { _p8 = value; }
    }
    private string _p9;

    public string P9
    {
        get { return _p9; }
        set { _p9 = value; }
    }
    private string _p10;

    public string P10
    {
        get { return _p10; }
        set { _p10 = value; }
    }
    private string _p11;

    public string P11
    {
        get { return _p11; }
        set { _p11 = value; }
    }
    private string _p12;

    public string P12
    {
        get { return _p12; }
        set { _p12 = value; }
    }
    private string _p13;

    public string P13
    {
        get { return _p13; }
        set { _p13 = value; }
    }
    private string _p14;

    public string P14
    {
        get { return _p14; }
        set { _p14 = value; }
    }
    private string _p15;

    public string P15
    {
        get { return _p15; }
        set { _p15 = value; }
    }
    private string _p16;

    public string P16
    {
        get { return _p16; }
        set { _p16 = value; }
    }
    private string _p17;

    public string P17
    {
        get { return _p17; }
        set { _p17 = value; }
    }
    private string _p18;

    public string P18
    {
        get { return _p18; }
        set { _p18 = value; }
    }

    private string _p19;

    public string P19
    {
        get { return _p19; }
        set { _p19 = value; }
    }

    private string _p20;

    public string P20
    {
        get { return _p20; }
        set { _p20 = value; }
    }
    private string _p21;

    public string P21
    {
        get { return _p21; }
        set { _p21 = value; }
    }
    private string _p22;

    public string P22
    {
        get { return _p22; }
        set { _p22 = value; }
    }
    private string _p23;

    public string P23
    {
        get { return _p23; }
        set { _p23 = value; }
    }
    private string _p24;

    public string P24
    {
        get { return _p24; }
        set { _p24 = value; }
    }
    private string _p25;

    public string P25
    {
        get { return _p25; }
        set { _p25 = value; }
    }
    private string _p26;

    public string P26
    {
        get { return _p26; }
        set { _p26 = value; }
    }
    private string _p27;

    public string P27
    {
        get { return _p27; }
        set { _p27 = value; }
    }
    private string _p28;

    public string P28
    {
        get { return _p28; }
        set { _p28 = value; }
    }
    private string _p29;

    public string P29
    {
        get { return _p29; }
        set { _p29 = value; }
    }
    private string _p30;

    public string P30
    {
        get { return _p30; }
        set { _p30 = value; }
    }
    private string _p31;

    public string P31
    {
        get { return _p31; }
        set { _p31 = value; }
    }
    private string _p32;

    public string P32
    {
        get { return _p32; }
        set { _p32 = value; }
    }
    private string _p33;

    public string P33
    {
        get { return _p33; }
        set { _p33 = value; }
    }
    private string _p34;

    public string P34
    {
        get { return _p34; }
        set { _p34 = value; }
    }
    private string _p35;

    public string P35
    {
        get { return _p35; }
        set { _p35 = value; }
    }
    private string _p36;

    public string P36
    {
        get { return _p36; }
        set { _p36 = value; }
    }

    //-----------------

    private string _p37;

    public string P37
    {
        get { return _p37; }
        set { _p37 = value; }
    }
    private string _p38;

    public string P38
    {
        get { return _p38; }
        set { _p38 = value; }
    }
    private string _p39;

    public string P39
    {
        get { return _p39; }
        set { _p39 = value; }
    }
    private string _p40;

    public string P40
    {
        get { return _p40; }
        set { _p40 = value; }
    }
    private string _p41;

    public string P41
    {
        get { return _p41; }
        set { _p41 = value; }
    }
    private string _p42;

    public string P42
    {
        get { return _p42; }
        set { _p42 = value; }
    }
    private string _p43;

    public string P43
    {
        get { return _p43; }
        set { _p43 = value; }
    }
    private string _p44;

    public string P44
    {
        get { return _p44; }
        set { _p44 = value; }
    }




    private string _date;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    private string _imeino;

    public string Imeino
    {
        get { return _imeino; }
        set { _imeino = value; }
    }
    private string _simno;

    public string Simno
    {
        get { return _simno; }
        set { _simno = value; }
    }
    private string _mobile;

    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    public int BLLInsertAndroidData(AndroidLongCodeBLL ur)
    {
        return status=dalobj.DALInsertAndroidData(ur);
    }

    public string BLLGetUseridAndroid(AndroidLongCodeBLL ur)
    {
        string mobile = "";
        return mobile = dalobj.DALGetUseridAndroid(ur);
    }



}

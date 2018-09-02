using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EzeeMarketingClass
/// </summary>
public class EzeeMarketingClass
{
	public EzeeMarketingClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public class Expense
{
    private string _date;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }
    private string _expensetype;

    public string Expensetype
    {
        get { return _expensetype; }
        set { _expensetype = value; }
    }
    private string _amount;

    public string Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    private string _description;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    private string _rate;

    public string Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }
    private string _quantity;

    public string Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
    private string _paymentstatus;

    public string Paymentstatus
    {
        get { return _paymentstatus; }
        set { _paymentstatus = value; }
    }
    private string _userMobNo;

    public string UserMobNo
    {
        get { return _userMobNo; }
        set { _userMobNo = value; }
        //set
        //{
        //    if (value.Length == 10)
        //    {
        //        _userMobNo = value;
        //    }
        //    else
        //    {
        //        _userMobNo = "Enter Mobile No ten digit";
        //    }
        //}
    }
    private string _refMobNo;

    public string RefMobNo
    {
        get { return _refMobNo; }
        set { _refMobNo = value; }
        //set
        //{
        //    if (value.Length == 10)
        //    {
        //        _refMobNo = value;
        //    }
        //    else
        //    {
        //        _refMobNo = "Enter Mobile No ten digit";
        //    }
        //}
    }
    private string _imeiNo;

    public string ImeiNo
    {
        get { return _imeiNo; }
        set { _imeiNo = value; }
    }
    private string _localAppId;

    public string LocalAppId
    {
        get { return _localAppId; }
        set { _localAppId = value; }
    }
    private string _rerurnId;

    public string RerurnId
    {
        get { return _rerurnId; }
        set { _rerurnId = value; }
    }
    private string _unit;

    public string Unit
    {
        get { return _unit; }
        set { _unit = value; }
    }
}
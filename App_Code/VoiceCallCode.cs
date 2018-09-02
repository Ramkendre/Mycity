using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;

public class VoiceCallCode
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    public VoiceCallCode()
    {
        DateFormatStatus();
    }
    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }
    public string LoadData(string Mobile_No)
    {
        string stringResult = null;
        string api_key = "iSny8dnb5ndnDLeXcGs9";
        string access_key = "AhjydMUnCLeKX8JzcB5yYEj6C8aO8V7NLhnVQC7w";
        string Mobile_Number = "<to>" + Mobile_No + "</to>";
        string request = "";
        string stringpost = null;
        request = "<request action='http://www.smscountry.com/testdr.aspx' method='get'>" + Mobile_Number + "<play>http://smscountry.com/voice_clips/baby_song_03044619.wav</play></request>";
        stringpost = "api_key=" + api_key + "&access_key=" + access_key + "&xml=" + request;
        HttpWebRequest objWebRequest = null;
        HttpWebResponse objWebResponse = null;
        StreamWriter objStreamWriter = null;
        StreamReader objStreamReader = null;
        try
        {
            objWebRequest = (HttpWebRequest)WebRequest.Create("http://voiceapi.smscountry.com/api ");
            objWebRequest.Method = "POST";
            objWebRequest.ContentType = "application/x-www-form-urlencoded";
            objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
            objStreamWriter.Write(stringpost);
            objStreamWriter.Flush();
            objStreamWriter.Close();
            objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
            objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
            stringResult = objStreamReader.ReadToEnd();
            objStreamReader.Close();
            SortVoiceCallInfo(stringResult.Replace('"',' '));
        }
        catch (Exception ex)
        {
            stringResult = Convert.ToString(ex.Message);
        }
        finally
        {
            if ((objStreamWriter != null))
            {
                objStreamWriter.Close();
            }
            if ((objStreamReader != null))
            {
                objStreamReader.Close();
            }
            objWebRequest = null;
            objWebResponse = null;
        }
        return stringResult;
    }

    public void SortVoiceCallInfo(string VoiceInfo)
    {
        // {"smscresponse":{"calluid":"d4214e84-3edc-4948-859b-90355a364862-1386839045o","to":"9028681018","dnd_numbers":"","callstatus":"received","event":"newcall","direction":"outbound"}}

        //  string AllString = "smscresponse:calluid:d4214e84-3edc-4948-859b-90355a364862-1386839045o,to:9028681018,dnd_numbers:,callstatus:received,event:newcall,direction:outbound";
        string[] wholestr = VoiceInfo.Trim().Split(',');
        string Calluid = wholestr[0].ToString();
        string RecivedMobNo = wholestr[1].ToString();
        string Dnd = wholestr[2].ToString();
        string CallStatus = wholestr[3].ToString();
        string Eventstr = wholestr[4].ToString();
        string Direction = wholestr[5].ToString();


        string[] Calluid1 = Calluid.Split(':');
        string[] RecivedMobNo1 = RecivedMobNo.Split(':');
        string[] Dnd1 = Dnd.Split(':');
        string[] CallStatus1 = CallStatus.Split(':');
        string[] Eventstr1 = Eventstr.Split(':');
        string[] Direction1 = Direction.Split(':');

        string Sql = "Insert Into VoiceCallAllReport(SIMNO,IMEINO,VoiceMobileNo,ReciverMobileNo,CallWAV,calluid,callstatus,event,direction,dnd_numbers,Error,EntryDate,SmsCountryString)" +
                     "values('45236589562365545445','45269336522552','7852369852','" + RecivedMobNo1[1].ToString() + "','SSS','" + Calluid1[2].ToString() + "','" + CallStatus1[1].ToString() + "','" +
                      Eventstr1[1].ToString() + "','" + Direction1[1].ToString() + "','" + Dnd1[1].ToString() + "','Error','" + DateFormat + "','" + VoiceInfo + "')";
        int i = cc.ExecuteNonQuery(Sql);
    }

}

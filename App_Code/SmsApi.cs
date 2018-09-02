using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

[DataContract]
class SmsApi
{
    [DataMember]
    public string address { get; set; }
    [DataMember]
    public string companyName { get; set; }
    [DataMember]
    public string emailId { get; set; }
    [DataMember]
    public string firstName { get; set; }
    [DataMember]
    public string phoneNumber { get; set; }
    [DataMember]
    public string userName { get; set; }
}

[DataContract]
public class PostAPI
{
    [DataMember]
    public string user { get; set; }
    [DataMember]
    public string password { get; set; }
    [DataMember]
    public string address { get; set; }
    [DataMember]
    public string companyName { get; set; }
    [DataMember]
    public string emailId { get; set; }
    [DataMember]
    public string firstName { get; set; }
    [DataMember]
    public string phoneNumber { get; set; }
    [DataMember]
    public string subuserName { get; set; }
    [DataMember]
    public string subuserPassword { get; set; }
}

[DataContract]
public class AddBalance
{
    [DataMember]
    public string user { get; set; }
    [DataMember]
    public string password { get; set; }
    [DataMember]
    public string subuserName { get; set; }
    [DataMember]
    public string subuserPassword { get; set; }
    [DataMember]
    public string addbalance { get; set; }
}
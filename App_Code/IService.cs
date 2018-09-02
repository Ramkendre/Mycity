using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: If you change the interface name "IService" here, you must also update the reference to "IService" in Web.config.
[ServiceContract]
public interface IService
{
    [OperationContract]
     ReturnResponse Register(Registration registration);
    [OperationContract]
    ReturnResponse Demo();
	
}
[DataContract]
public class Registration
{
    [DataMember]
    public string mobileNo{get;set;}
    [DataMember]
    public string gcmRegId{get;set;}
    [DataMember]
    public string appKeyword{get;set;}
}
[DataContract]
public class ReturnResponse
{
    [DataMember]
    public string status{get;set;}
}
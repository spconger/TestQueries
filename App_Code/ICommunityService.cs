using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommunityService" in both code and config file together.
[ServiceContract]
public interface ICommunityService
{
    [OperationContract]
    List<string> GetBusinessRules();

    [OperationContract]
    List<string> GetPositions();

    [OperationContract]
    List<EmployeeInfo> GetEmployeeByPosition(string positionName);
}//end interface

[DataContract]
public class EmployeeInfo
{
    [DataMember]
    public string LastName { set; get; }

    [DataMember]
    public string FirstName { set; get; }

    [DataMember]
    public string JobPosition { set; get; }

    [DataMember]
    public string HireDate { set; get; }

}

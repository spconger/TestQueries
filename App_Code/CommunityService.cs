using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommunityService" in code, svc and config file together.
public class CommunityService : ICommunityService
{
    Community_AssistEntities db = new Community_AssistEntities();
    public List<string> GetBusinessRules()
    {
        var rules = from r in db.BusinessRules
                    orderby r.BusinessRuleText
                    select new { r.BusinessRuleText };

        List<string> bRules = new List<string>();
        foreach(var r in rules)
        {
            bRules.Add(r.BusinessRuleText.ToString());
        }

        return bRules;
    }

    public List<EmployeeInfo> GetEmployeeByPosition(string positionName)
    {
        var emps = from e in db.Employees
                   from p in e.EmployeePositions
                   where p.Position.PositionName.Equals(positionName)
                   select new
                   {
                       e.Person.PersonLastName,
                       e.Person.PersonFirstName,
                       p.Position.PositionName,
                       e.EmployeeHireDate
                   };
        List<EmployeeInfo> info = new List<EmployeeInfo>();

        foreach(var k in emps)
        {
            EmployeeInfo ei = new EmployeeInfo();
            ei.LastName = k.PersonLastName;
            ei.FirstName = k.PersonFirstName;
            ei.JobPosition = k.PositionName;
            ei.HireDate = k.EmployeeHireDate.ToShortDateString();

            info.Add(ei);
        }

        return info;
    }

    public List<string> GetPositions()
    {
        var pos = from r in db.Positions
                    orderby r.PositionName
                    select new { r.PositionName};

        List<string> jobs = new List<string>();
        foreach (var p in pos)
        {
            jobs.Add(p.PositionName.ToString());
        }

        return jobs;
    }
}

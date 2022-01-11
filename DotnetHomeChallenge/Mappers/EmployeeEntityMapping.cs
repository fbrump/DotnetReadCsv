using models = DotnetHomeChallenge.Models;
using entities = DotnetHomeChallenge.Entities;

namespace DotnetHomeChallenge.Mappers;

public static class EmployeeEntityMapping
{
    public static entities.Employee ToEntity(this models.Employee employeeModel)
    {
        var entity = new entities.Employee
        {
            Country = employeeModel.Country,
            Department = employeeModel.Department,
            Email = employeeModel.Email,
            Phone = employeeModel.Phone,
            Position = employeeModel.Position,
            FirstName = employeeModel.FirstName,
            HiredAt = employeeModel.HiredAt,
            LastName = employeeModel.LastName,
            TerminatedAt = employeeModel.TerminatedAt,
            EmployeeID = employeeModel.EmployeeID,
            InTraining = employeeModel.ToInTraining(),
            HrStatus = employeeModel.ToHrStatus(),
            CompanyEmail = employeeModel.ToCompanyName(),
        };
        
        return entity;
    }

    private static string ToCompanyName(this models.Employee employeeModel)
        => $"{employeeModel.FirstName[0]}{employeeModel.LastName}@ibsat.com".ToLower();

    private static bool ToInTraining(this models.Employee employeeModel)
        => employeeModel.InTraining == "Yes";

    private static entities.HrStatus ToHrStatus(this models.Employee employeeModel)
    {
        if (employeeModel.TerminatedAt.HasValue)
            return entities.HrStatus.Terminated;
        return employeeModel.ToInTraining() ? entities.HrStatus.InTraining : entities.HrStatus.Active;
    }
}
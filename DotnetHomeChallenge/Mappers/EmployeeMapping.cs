using DotnetHomeChallenge.Models;
using TinyCsvParser.Mapping;

namespace DotnetHomeChallenge.Mappers;

public sealed class EmployeeMapping : CsvMapping<Employee>
{
    public EmployeeMapping()
        : base()
    {
        MapProperty(0, employee => employee.FirstName);
        MapProperty(1, employee => employee.LastName);
        MapProperty(2, employee => employee.Phone);
        MapProperty(3, employee => employee.Email);
        MapProperty(4, employee => employee.Country);
        MapProperty(5, employee => employee.EmployeeID);
        MapProperty(6, employee => employee.InTraining);
        MapProperty(7, employee => employee.Department);
        MapProperty(8, employee => employee.Position);
        MapProperty(9, employee => employee.HiredAt);
        MapProperty(10, employee => employee.TerminatedAt);
    }
}
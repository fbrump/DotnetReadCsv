using DotnetHomeChallenge.Entities;
using DotnetHomeChallenge.Interfaces;

namespace DotnetHomeChallenge.Services;

public sealed class SearchEmployeesService : ISearchEmployeesService
{
    private IEnumerable<Employee> _employees;
    
    public SearchEmployeesService(IEnumerable<Employee> employees)
    {
        this._employees = employees;
    }
    public IEnumerable<Employee> GetByDescription(string description)
    {
        return this._employees.Where(employee =>
            employee.Email.ToUpper().Contains(description.ToUpper()) || 
            employee.FirstName.ToUpper().Contains(description.ToUpper()) || 
            employee.LastName.ToUpper().Contains(description.ToUpper()))
            .ToList();
    }
}
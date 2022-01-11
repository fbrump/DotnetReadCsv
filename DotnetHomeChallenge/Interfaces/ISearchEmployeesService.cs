using DotnetHomeChallenge.Entities;

namespace DotnetHomeChallenge.Interfaces;

public interface ISearchEmployeesService
{
    public IEnumerable<Employee> GetByDescription(string description);
}
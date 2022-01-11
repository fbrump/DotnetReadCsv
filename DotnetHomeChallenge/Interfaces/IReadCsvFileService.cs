using DotnetHomeChallenge.Models;

namespace DotnetHomeChallenge.Interfaces;

public interface IReadCsvFileService
{
    IEnumerable<Employee> Execute(string fileName);
}
using System.Text;
using DotnetHomeChallenge.Interfaces;
using DotnetHomeChallenge.Mappers;
using DotnetHomeChallenge.Models;
using TinyCsvParser;

namespace DotnetHomeChallenge.Services;

public sealed class ReadCsvFileService : IReadCsvFileService
{
    private const char FieldsSeparator = ';';
    private const bool SkipHeader = true;

    public IEnumerable<Employee> Execute(string fileName)
    {
        var csvParserOptions = new CsvParserOptions(SkipHeader, FieldsSeparator);
        var csvMapper = new EmployeeMapping();
        var csvParser = new CsvParser<Employee>(csvParserOptions, csvMapper);

        var employeesFromCsv = csvParser
            .ReadFromFile($@"input/{fileName}.csv", Encoding.ASCII)
            .ToList();

        if (!employeesFromCsv.All(employeeMappingResult => employeeMappingResult.IsValid))
            throw new IOException($"There's any {nameof(Employee)} data that is not valid.");

        foreach (var employeeMappingResult in employeesFromCsv)
        {
            yield return employeeMappingResult.Result;
        }
    }
}
using CommandLine;
using DotnetHomeChallenge.Entities;
using DotnetHomeChallenge.Interfaces;
using DotnetHomeChallenge.Mappers;
using DotnetHomeChallenge.Services;

namespace DotnetHomeChallenge.CommandLines;

[Verb("search", HelpText = "Search employees by entering partial email or partial first name or partial last name")]
public sealed class SearchCommand : ICommand
{
    private const int MaxEntriesList = 5;
    private readonly IReadCsvFileService _service;
    private IReadOnlyList<Employee> _employees;

    public SearchCommand()
    {
        _service = new ReadCsvFileService();
        this._employees = Array.Empty<Employee>();
    }

    [Option('t', "text", Required = false, HelpText = "Text of partial email or partial first name or partial last name; for multiples parameters use ',' e.g. name1,name2")]
    public string Text { get; set; }
    
    /// <summary>
    /// Console app should have option to search employees by entering partial email or partial first name or partial last name
    /// ·       In case of multiple entries a list of max 5 entries should be shown
    /// ·       Each entry should have a employee data card shown in console app
    /// </summary>
    public void Execute()
    {
        this.LoadData();
        
        if (string.IsNullOrEmpty(this.Text))
        {
            this.PrintResults(this._employees);
            return;
        }

        this.SearchByFilter(this._employees);
    }

    private void SearchByFilter(IReadOnlyList<Employee> employees)
    {
        var _searchService = new SearchEmployeesService(employees);

        Console.WriteLine($"Executing Search for '{this.Text}'");

        var filters = this.Text.Split(',')
            .Take(MaxEntriesList);

        var employeesFilterDescription = 
            filters.SelectMany(text => _searchService.GetByDescription(text))
            .ToList();

        this.PrintResults(employeesFilterDescription);
    }

    private void PrintResults(IEnumerable<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"-------------- ID: {employee.EmployeeID} ------------------------");
            Console.WriteLine($"    Name: {employee.FirstName} {employee.LastName} ");
            Console.WriteLine($"    Company Email: {employee.CompanyEmail} Position: {employee.Position} Department: {employee.Department}");
            Console.WriteLine($"    Personal Email: {employee.Email} Country: {employee.Country} Phone: {employee.Phone} ");
            Console.WriteLine($"    Hired At: {employee.HiredAt} In Training: {employee.InTraining} Terminated At: {employee.TerminatedAt}");
            Console.WriteLine($"    HR Status: {employee.HrStatus.ToString()}" );
            
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{DateTime.Now} >> Found {employees.Count()} Employees...");
    }

    private void LoadData()
    {
        if (this._employees.Any())
        {
            Console.WriteLine($"{DateTime.Now} >> Employees have already loaded!");    
            return;
        }
        
        Console.WriteLine($"{DateTime.Now} >> Loading Employees...");
        
        const string fileName = "EmployeeDataTest";

        var employees = this._service.Execute(fileName);
        
        this._employees = employees.Select(t => t.ToEntity()).ToList();

        Console.WriteLine($"{DateTime.Now} >> Loaded {this._employees.Count()} Employees...");
        Console.WriteLine();
        Console.WriteLine();
    }
}

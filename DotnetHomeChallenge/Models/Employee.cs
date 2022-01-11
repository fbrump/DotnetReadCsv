namespace DotnetHomeChallenge.Models;

public class Employee
{
    public string FirstName { get; set; }
    
    public string LastName {get;set;}
    
    public string Phone {get;set;}
    
    public string Email {get;set;}
    
    public string Country {get;set;}
    
    public string EmployeeID {get;set;}
    
    public string InTraining {get;set;}
    
    public string Department {get;set;}
    
    public string Position {get;set;}
    
    public DateTime HiredAt {get;set;}
    
    public DateTime? TerminatedAt {get;set;}
}
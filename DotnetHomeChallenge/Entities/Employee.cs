namespace DotnetHomeChallenge.Entities;

public sealed class Employee
{   
    public string FirstName { get; set; }
    
    public string LastName { get; set;}
    
    public string Phone { get; set;}
    
    public string Email { get; set;}
    
    public string Country { get; set;}
    
    public string EmployeeID { get; set;}
    
    public bool InTraining { get; set;}
    
    public string Department { get; set;}
    
    public string Position { get; set;}
    
    public DateTime HiredAt { get; set;}
    
    public DateTime? TerminatedAt { get; set;}
    
    /// <summary>
    /// HR Status - Based on termination date and in training column
    /// ·       Non terminated employees should have status Active
    /// ·       In training Employees should have status InTraining
    /// ·       Terminated employees should have status Terminated
    /// </summary>
    public HrStatus HrStatus { get; set; }
    
    /// <summary>
    /// Company email
    /// ·       Should be formed using first letter of firstname + lastname + @ibsat.com
    /// </summary>
    public string CompanyEmail { get; set; }
}
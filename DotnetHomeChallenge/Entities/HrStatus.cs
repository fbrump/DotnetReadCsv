using System.ComponentModel;

namespace DotnetHomeChallenge.Entities;

public enum HrStatus
{
    [Description("Active")]
    Active = 0,
    
    [Description("InTraining")]
    InTraining = 1,
    
    [Description("Terminated")]
    Terminated = 2,
}
namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Dispensables;

/// <summary>
/// A variable, parameter, field, method or class is no longer used (usually because it’s obsolete).
/// See also <a href="https://refactoring.guru/smells/dead-code">dead-code</a>
/// </summary>
public class DeadCode : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Dead Code";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"A variable, parameter, field, method or class is no longer used (usually because it’s obsolete).";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"When requirements for the software have changed or corrections have been made, " +
            $"nobody had time to clean up the old code." +
            $"{Environment.NewLine}" +
            $"Such code could also be found in complex conditionals, " +
            $"when one of the branches becomes unreachable (due to error or other circumstances).";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"The quickest way to find dead code is to use a good IDE." +
               $"{Environment.NewLine}" +
               $"- Delete unused code and unneeded files." +
               $"{Environment.NewLine}" +
               $"- In the case of an unnecessary class, Inline Class or Collapse Hierarchy can be applied " +
               $"if a subclass or superclass is used." +
               $"{Environment.NewLine}" +
               $"- To remove unneeded parameters, use Remove Parameter.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Reduced code size." +
               $"{Environment.NewLine}" +
               $"- Simpler support.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
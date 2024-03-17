namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Dispensables;

/// <summary>
/// There’s an unused class, method, field or parameter.
/// See also <a href="https://refactoring.guru/smells/speculative-generality">speculative-generality</a>
/// </summary>
public class SpeculativeGenerality : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Speculative Generality";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"There’s an unused class, method, field or parameter.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Sometimes code is created “just in case” to support anticipated future features that never get implemented. " +
            $"As a result, code becomes hard to understand and support.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- For removing unused abstract classes, try Collapse Hierarchy." +
               $"{Environment.NewLine}" +
               $"- Unnecessary delegation of functionality to another class can be eliminated via Inline Class." +
               $"{Environment.NewLine}" +
               $"- Unused methods? Use Inline Method to get rid of them." +
               $"{Environment.NewLine}" +
               $"- Methods with unused parameters should be given a look with the help of Remove Parameter." +
               $"{Environment.NewLine}" +
               $"- Unused fields can be simply deleted.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Slimmer code." +
               $"{Environment.NewLine}" +
               $"- Easier support.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"- If you’re working on a framework, it’s eminently reasonable to create functionality " +
            $"not used in the framework itself, as long as the functionality is needed by the frameworks’s users." +
            $"{Environment.NewLine}" +
            $"- Before deleting elements, make sure that they aren’t used in unit tests. " +
            $"This happens if tests need a way to get certain internal information from a class " +
            $"or perform special testing-related actions.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
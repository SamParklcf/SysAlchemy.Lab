namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Couplers;

/// <summary>
/// Sooner or later, libraries stop meeting user needs.
/// The only solution to the problem—changing the library—is often impossible since the library is read-only.
/// See also <a href="https://refactoring.guru/smells/incomplete-library-class">incomplete-library-class</a>
/// </summary>
public class IncompleteLibraryClass : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Incomplete Library Class";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"Sooner or later, libraries stop meeting user needs. " +
            $"The only solution to the problem—changing the library—is often impossible since the library is read-only.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return $"The author of the library has’t provided the features you need or has refused to implement them.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- To introduce a few methods to a library class, use Introduce Foreign Method." +
               $"{Environment.NewLine}" +
               $"- For big changes in a class library, use Introduce Local Extension.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return
            $"Reduces code duplication (instead of creating your own library from scratch, " +
            $"you can still piggy-back off an existing one).";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Extending a library can generate additional work if the changes to the library involve changes in code.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
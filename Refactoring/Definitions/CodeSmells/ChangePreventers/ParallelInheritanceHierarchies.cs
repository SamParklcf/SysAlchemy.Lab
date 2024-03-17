namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ChangePreventers;

/// <summary>
/// Whenever you create a subclass for a class, you find yourself needing to create a subclass for another class.
/// See also <a href="https://refactoring.guru/smells/parallel-inheritance-hierarchies">parallel-inheritance-hierarchies</a>
/// </summary>
public class ParallelInheritanceHierarchies : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Parallel Inheritance Hierarchies";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"Whenever you create a subclass for a class, you find yourself needing to create a subclass for another class.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"All was well as long as the hierarchy stayed small. But with new classes being added, " +
            $"making changes has become harder and harder.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"You may de-duplicate parallel class hierarchies in two steps. " +
            $"First, make instances of one hierarchy refer to instances of another hierarchy. " +
            $"Then, remove the hierarchy in the referred class, by using Move Method and Move Field.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Reduces code duplication." +
               $"{Environment.NewLine}" +
               $"- Can improve organization of code.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Sometimes having parallel class hierarchies is just a way to avoid even bigger mess " +
            $"with program architecture. If you find that your attempts to de-duplicate hierarchies produce " +
            $"even uglier code, just step out, revert all of your changes and get used to that code.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
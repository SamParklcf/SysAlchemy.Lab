namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Dispensables;

/// <summary>
/// Understanding and maintaining classes always costs time and money.
/// So if a class does’t do enough to earn your attention, it should be deleted.
/// See also <a href=""></a>
/// </summary>
public class LazyClass : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Lazy Class";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"Understanding and maintaining classes always costs time and money. " +
            $"So if a class does’t do enough to earn your attention, it should be deleted.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Perhaps a class was designed to be fully functional but after some of the refactoring " +
            $"it has become ridiculously small." +
            $"{Environment.NewLine}" +
            $"Or perhaps it was designed to support future development work that never got done.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- Components that are near-useless should be given the Inline Class treatment." +
               $"{Environment.NewLine}" +
               $"- For subclasses with few functions, try Collapse Hierarchy.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Reduced code size." +
               $"{Environment.NewLine}" +
               $"- Easier maintenance.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Sometimes a Lazy Class is created in order to delineate intentions for future development, " +
            $"In this case, try to maintain a balance between clarity and simplicity in your code.";
    }
}
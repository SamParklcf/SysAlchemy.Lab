namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ChangePreventers;

/// <summary>
/// You find yourself having to change many unrelated methods when you make changes to a class.
/// For example, when adding a new product type you have to change the methods for finding,
/// displaying, and ordering products.<para/>
/// Divergent Change resembles Shotgun Surgery but is actually the opposite smell.
/// Divergent Change is when many changes are made to a single class.
/// Shotgun Surgery refers to when a single change is made to multiple classes simultaneously.
/// See also <a href="https://refactoring.guru/smells/divergent-change">divergent-change</a>
/// </summary>
public class DivergentChange :ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Divergent Change";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"You find yourself having to change many unrelated methods when you make changes to a class. " +
            $"For example, when adding a new product type you have to change the methods for finding, " +
            $"displaying, and ordering products.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return $"Often these divergent modifications are due to poor program structure or \"copy-pasta programming”.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- Split up the behavior of the class via Extract Class." +
               $"{Environment.NewLine}" +
               $"- If different classes have the same behavior, " +
               $"you may want to combine the classes through inheritance (Extract Superclass and Extract Subclass).";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Improves code organization." +
               $"{Environment.NewLine}" +
               $"- Reduces code duplication." +
               $"{Environment.NewLine}" +
               $"- Simplifies support.";
    }
}
namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Couplers;

/// <summary>
/// If a class performs only one action, delegating work to another class, why does it exist at all?
/// See also <a href="https://refactoring.guru/smells/middle-man">middle-man</a>
/// </summary>
public class MiddleMan : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Middle Man";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"If a class performs only one action, delegating work to another class, why does it exist at all?";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return $"This smell can be the result of overzealous elimination of Message Chains." +
               $"{Environment.NewLine}" +
               $"In other cases, it can be the result of the useful work of a class being gradually moved to other classes. " +
               $"The class remains as an empty shell that does’t do anything other than delegate.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"If most of a method’s classes delegate to another class, Remove Middle Man is in order.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"Less bulky code.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return $"Don’t delete middle man that have been created for a reason:" +
               $"{Environment.NewLine}" +
               $"- A middle man may have been added to avoid inter-class dependencies." +
               $"{Environment.NewLine}" +
               $"- Some design patterns create middle man on purpose (such as Proxy or Decorator).";
    }
}
namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Couplers;

/// <summary>
/// One class uses the internal fields and methods of another class.
/// See also <a href="https://refactoring.guru/smells/inappropriate-intimacy">inappropriate-intimacy</a>
/// </summary>
public class InappropriateIntimacy : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Inappropriate Intimacy";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"One class uses the internal fields and methods of another class.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Keep a close eye on classes that spend too much time together. " +
            $"Good classes should know as little about each other as possible. " +
            $"Such classes are easier to maintain and reuse.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"- The simplest solution is to use Move Method and Move Field to move parts of one class " +
            $"to the class in which those parts are used. But this works only if the first class truly does’t need these parts." +
            $"{Environment.NewLine}" +
            $"- Another solution is to use Extract Class and Hide Delegate on the class to make the code relations “official”." +
            $"{Environment.NewLine}" +
            $"- If the classes are mutually interdependent, you should use Change Bidirectional Association to Unidirectional." +
            $"{Environment.NewLine}" +
            $"- If this “intimacy” is between a subclass and the superclass, consider Replace Delegation with Inheritance.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Improves code organization." +
               $"{Environment.NewLine}" +
               $"Simplifies support and code reuse.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
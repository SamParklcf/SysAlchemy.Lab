namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.Couplers;

/// <summary>
/// In code you see a series of calls resembling $a->b()->c()->d()
/// See also <a href="https://refactoring.guru/smells/message-chains">message-chains</a>
/// </summary>
public class MessageChains : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Message Chains";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"In code you see a series of calls resembling $a->b()->c()->d()";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"A message chain occurs when a client requests another object, " +
            $"that object requests yet another one, and so on. " +
            $"These chains mean that the client is dependent on navigation along the class structure. " +
            $"Any changes in these relationships require modifying the client.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return $"- To delete a message chain, use Hide Delegate." +
               $"{Environment.NewLine}" +
               $"- Sometimes it’s better to think of why the end object is being used. " +
               $"Perhaps it would make sense to use Extract Method for this functionality " +
               $"and move it to the beginning of the chain, by using Move Method.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Reduces dependencies between classes of a chain." +
               $"{Environment.NewLine}" +
               $"- Reduces the amount of bloated code.";
    }

    /// <inheritdoc/>
    public string WhenToIgnore()
    {
        return
            $"Overly aggressive delegate hiding can cause code in which it’s hard to see " +
            $"where the functionality is actually occurring. Which is another way of saying, " +
            $"avoid the Middle Man smell as well.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
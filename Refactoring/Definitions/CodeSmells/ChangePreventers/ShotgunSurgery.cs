namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ChangePreventers;

/// <summary>
/// Making any modifications requires that you make many small changes to many different classes.<para/>
/// Shotgun Surgery resembles Divergent Change but is actually the opposite smell.
/// Divergent Change is when many changes are made to a single class.
/// Shotgun Surgery refers to when a single change is made to multiple classes simultaneously.
/// See also <a href="https://refactoring.guru/smells/shotgun-surgery">shotgun-surgery</a>
/// </summary>
public class ShotgunSurgery : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Shotgun Surgery";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return $"Making any modifications requires that you make many small changes to many different classes.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"A single responsibility has been split up among a large number of classes. " +
            $"This can happen after overzealous application of Divergent Change.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"- Use Move Method and Move Field to move existing class behaviors into a single class. " +
            $"If there’s no class appropriate for this, create a new one." +
            $"{Environment.NewLine}" +
            $"- If moving code to the same class leaves the original classes almost empty, " +
            $"try to get rid of these now-redundant classes via Inline Class.";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return $"- Better organization." +
               $"{Environment.NewLine}" +
               $"- Less code duplication." +
               $"{Environment.NewLine}" +
               $"- Easier maintenance.";
    }
    
    /// <inheritdoc/>
    public string KeyNotes => 
        $"";
}
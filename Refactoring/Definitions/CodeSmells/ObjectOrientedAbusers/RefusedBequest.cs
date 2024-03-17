namespace SysAlchemy.Lab.Refactoring.Definitions.CodeSmells.ObjectOrientedAbusers;

/// <summary>
/// If a subclass uses only some of the methods and properties inherited from its parents, the hierarchy is off-kilter. The unneeded methods may simply go unused or be redefined and give off exceptions.
/// See also <a href="https://refactoring.guru/smells/refused-bequest">refused-bequest</a>
/// </summary>
public class RefusedBequest : ICodeSmellsInstruction
{
    /// <inheritdoc/>
    public string Name()
    {
        return $"Refused Bequest";
    }

    /// <inheritdoc/>
    public string SignsAndSymptoms()
    {
        return
            $"If a subclass uses only some of the methods and properties inherited from its parents, " +
            $"the hierarchy is off-kilter. The unneeded methods may simply go unused " +
            $"or be redefined and give off exceptions.";
    }

    /// <inheritdoc/>
    public string ReasonsForTheProblem()
    {
        return
            $"Someone was motivated to create inheritance between classes only by the desire to reuse the code in a superclass. " +
            $"But the superclass and subclass are completely different.";
    }

    /// <inheritdoc/>
    public string Treatment()
    {
        return
            $"- If inheritance makes no sense and the subclass really does have nothing in common with the superclass, " +
            $"eliminate inheritance in favor of Replace Inheritance with Delegation." +
            $"{Environment.NewLine}" +
            $"- If inheritance is appropriate, get rid of unneeded fields and methods in the subclass. " +
            $"Extract all fields and methods needed by the subclass from the parent class, " +
            $"put them in a new superclass, and set both classes to inherit from it (Extract Superclass).";
    }

    /// <inheritdoc/>
    public string Payoff()
    {
        return
            $"Improves code clarity and organization. You will no longer have to wonder " +
            $"why the Dog class is inherited from the Chair class (even though they both have 4 legs).";
    }
}